using System;
using System.Collections.Generic;
using System.Linq;
using MetroFramework.Forms;
using Dota2ModKit.Properties;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework;
using System.IO;
using MetroFramework.Controls;
using System.Drawing;
using KVLib;
using System.Reflection;
using System.Text;
using Dota2ModKit.Features;
using Dota2ModKit.Forms;
using System.Globalization;
using System.Threading;
using Dota2ModKit.HelperClasses;

namespace Dota2ModKit {
	public partial class MainForm : MetroForm {
		public bool DEBUG = false;

        public Addon currAddon;
		public Dictionary<string, Addon> addons;
		public string dotaDir = "";
		public string gamePath = "";
		public string contentPath = "";
		string firstAddonName = "";
		public System.Media.SoundPlayer player = new System.Media.SoundPlayer();
		public string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		public Dictionary<string, List<string>> vsndToName = new Dictionary<string, List<string>>();

		// objects for features of ModKit
		public KVFeatures kvFeatures;
		public VTEXFeatures vtexFeatures;
		public ParticleFeatures particleFeatures;
		public SoundFeatures soundFeatures;

		internal bool firstAddonChange;
		public CustomTile[] customTiles = new CustomTile[5];

		public CoffeeSharp.CoffeeScriptEngine cse = null;

		// for updating modkit
		Updater updater;
		public string newVers = "";
		public string newVersUrl = "";
		public string releases_page_source = "";

		public MainForm() {
			// bring up the UI
			InitializeComponent();

			// localize ModKit strings.
			Localizer localizer = new Localizer(this);

			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("cn-CN");
			Console.WriteLine(strings.Hello);

			// setup MainForm hooks.
			setupHooks();

			// check for updates
			updater = new Updater(this);

			// init mainform controls stuff
			initControls();

			// get the dota dir
			retrieveDotaDir();

			// get the master 'game' and 'content' paths.
			gamePath = Path.Combine(dotaDir, "game", "dota_addons");
			contentPath = Path.Combine(dotaDir, "content", "dota_addons");

			// create these dirs if they don't exist.
			if (!Directory.Exists(gamePath)) {
				Directory.CreateDirectory(gamePath);
			}
			if (!Directory.Exists(contentPath)) {
				Directory.CreateDirectory(contentPath);
			}

			// get all the addons in the 'game' dir.
			addons = getAddons();

			// setup custom tiles
			setupCustomTiles();
		}

		private void initFeatures() {
			kvFeatures = new KVFeatures(this);
			vtexFeatures = new VTEXFeatures(this);
			particleFeatures = new ParticleFeatures(this);
			soundFeatures = new SoundFeatures(this);
		}

		private void initControls() {
			steamTile.TileImage = new Bitmap(Resources.steam_icon, new Size(steamTile.Width, steamTile.Height));
			luaRadioBtn.Checked = true;
			tabControl.SelectedIndex = 0;
			notificationLabel.Text = "";
			versionLabel.Text = "v" + version;
		}

		private void setupHooks() {
			Shown += (s, e) => {
				// clone a barebones repo if we don't have one, pull if we do
				updater.clonePullBarebones();

				// deserialize settings
				deserializeSettings();

				// auto-retrieve the workshop IDs for published addons if there are any.
				getWorkshopIDs();

				// set currAddon to the addon that was last opened in last run of modkit.
				if (Settings.Default.LastAddon != "") {
					Addon a = getAddonFromName(Settings.Default.LastAddon);
					if (a != null) {
						changeCurrAddon(a);
					}
				}

				// basically, if this is first run of modkit, set the currAddon to w/e the default addon is in the workshop tools.
				if (currAddon == null) {
					changeCurrAddon(addons[getDefaultAddonName()]);
				}

				// init our features of Modkit
				initFeatures();
			};

			// setup hooks
			FormClosing += (s, e) => {
				serializeSettings();
			};

			tabControl.Selected += (s, e) => {
				//PlaySound(Properties.Resources.browser_click_navigate);
			};

			githubTextBox.KeyDown += (s, e) => {
				if (e.KeyCode == Keys.Enter) {
					doGithubSearch();
				}
			};

		}

		private void retrieveDotaDir() {
			// start process of retrieving dota dir
			dotaDir = Settings.Default.DotaDir;

			if (dotaDir == "") {
				// user opened this application for the first time ever.
				// try to auto-get the dir
				dotaDir = Util.GetDotaDir();

				DialogResult dr = DialogResult.No;
				if (dotaDir != "") {
					// first run of modkit on this computer.
					dr = MetroMessageBox.Show(this,
						"Dota directory has been set to: " + dotaDir + ". Is this correct?",
						"Dota Directory",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Information);
				}

				if (dr == DialogResult.No) {
					FolderBrowserDialog fbd = new FolderBrowserDialog();
					fbd.Description = "Dota 2 directory (i.e. 'dota 2 beta')";
					var dr2 = fbd.ShowDialog();

					if (dr2 != DialogResult.OK) {
						MetroMessageBox.Show(this, "No folder selected. Exiting.",
							"Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);

						Application.Exit();
						return;
					}
					string p = fbd.SelectedPath;
					dotaDir = p;
				}
			}

			Settings.Default.DotaDir = dotaDir;
			Settings.Default.Save();
		}

		private string getDefaultAddonName() {
			string dota2cfgPath = Path.Combine(gamePath, "dota2cfg.cfg");
			string defaultAddonName = firstAddonName;

			try {
				if (File.Exists(dota2cfgPath)) {
					KeyValue kv = KVLib.KVParser.KV1.ParseAll(File.ReadAllText(dota2cfgPath))[0];
					if (kv.HasChildren) {
						foreach (KeyValue kv2 in kv.Children) {
							if (kv2.Key == "default") {
								if (addons.ContainsKey(kv2.GetString())) {
									defaultAddonName = kv2.GetString();
								}
							}
						}
					}
				}
			} catch (Exception ex) {
				Util.LogException(ex);
			}

			return defaultAddonName;
		}

		public void PlaySound(Stream sound) {
			sound.Position = 0;     // Manually rewind stream 
			player.Stream = null;    // Then we have to set stream to null 
			player.Stream = sound;  // And set it again, to force it to be loaded again... 
			player.Play();          // Yes! We can play the sound! 
		}

		private void getWorkshopIDs() {
			string vpksPath = Path.Combine(gamePath, "vpks");

			if (Directory.Exists(vpksPath)) {
				string[] dirs = Directory.GetDirectories(vpksPath);
				foreach (string dir in dirs) {
					string wIDs = dir.Substring(dir.LastIndexOf('\\') + 1);
					int wID;
					if (Int32.TryParse(wIDs, out wID)) {
						string publishDataPath = Path.Combine(dir, "publish_data.txt");
						string[] lines = File.ReadAllLines(publishDataPath);

						KeyValue publish_data = KVLib.KVParser.KV1.ParseAll(File.ReadAllText(publishDataPath))[0];

						foreach (KeyValue kv in publish_data.Children) {
							if (kv.Key == "source_folder") {
								string name = kv.GetString();
								Addon a = getAddonFromName(name);
								if (a != null) {
									a.workshopID = wID;
								}
							}
						}
					}
				}
			}
		}

		private void deserializeSettings() {
			string addonSettings = Settings.Default.AddonsKV;
            if (addonSettings == "") {
				// no addon settings to deserialize.
				return;
			}

			KeyValue rootKV = KVParser.KV1.ParseAll(addonSettings)[0];

			foreach (KeyValue kv in rootKV.Children) {
				string addonName = kv.Key;
				Addon addon = getAddonFromName(addonName);

				// this can occur if addon is deleted and program doesn't exit correctly.
				if (addon == null) {
					continue;
				}

				addon.deserializeSettings(kv);
			}
		}

		public void serializeSettings() {
			KeyValue rootKV = new KeyValue("Addons");
			foreach (KeyValuePair<string, Addon> a in addons) {
				string addonName = a.Key;
				Addon addon = a.Value;
				KeyValue addonKV = new KeyValue(addonName);
				addon.serializeSettings(addonKV);
				rootKV.AddChild(addonKV);
			}

			Settings.Default.AddonsKV = rootKV.ToString();

			// serialize the customTiles
			string customTilesSerialized = "";
			for (int i = 0; i < customTiles.Length; i++) {
				customTilesSerialized += customTiles[i].serializedTileInfo + "|";
			}
			Settings.Default.CustomTileInfo = customTilesSerialized;
			Settings.Default.Save();
		}

		/// <summary>
		/// String -> Addon object conversion
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Addon getAddonFromName(string name) {
			Addon a;
			if (addons.TryGetValue(name, out a)) {
				return a;
			}

			return null;
		}

		public void changeCurrAddon(Addon a) {
			addonTile.Text = a.name;

			if (a.image != null) {
				addonTile.UseTileImage = true;
				addonTile.TileImage = a.image;
			} else {
				Image thumbnail = findAddonThumbnail(a);
				if (thumbnail != null) {
					addonTile.UseTileImage = true;
					addonTile.TileImage = thumbnail;
				} else {
					addonTile.UseTileImage = false;
					a.doesntHaveThumbnail = true;
					addonTile.Style = a.tileColor;
					//Debug.WriteLine(a.tileColor.GetType().ToString());
				}
			}
			currAddon = a;
			currAddon.onChangedTo(this);

			Settings.Default.LastAddon = a.name;
			//text_notification("Selected addon: " + a.name, MetroColorStyle.Green, 2500);
		}

		public Image findAddonThumbnail(Addon a) {
			string thumbnailDir = Path.Combine(dotaDir, "game", "bin", "win64");

			if (Directory.Exists(thumbnailDir) && a.workshopID != 0) {
				string imagePath = Path.Combine(thumbnailDir, a.workshopID + "_thumb.jpg");

				if (File.Exists(imagePath)) {
					Debug.WriteLine(imagePath + " found!");
					Image thumbnail = Image.FromFile(imagePath, true);
					Size size = new Size(addonTile.Width, addonTile.Height);
					thumbnail = (Image)new Bitmap(thumbnail, size);

					a.image = thumbnail;
					return thumbnail;
				}
			}
			return null;
		}

		private Dictionary<string, Addon> getAddons() {
			Dictionary<string, Addon> addons = new Dictionary<string, Addon>();
			string[] dirs = Directory.GetDirectories(gamePath);
			string addons_constructed = "Addons constructed:\n";
			foreach (string s in dirs) {
				// construct a new addon from this dir path.
				Addon a = new Addon(s);
				addons_constructed += s + "\n";
				// skip the dirs that we know aren't addons.
				if (a.name == "vpks") {
					continue;
				}

				// if constructor didn't return null, we have a valid addon.
				if (a != null) {
					addons.Add(a.name, a);
					if (firstAddonName == "") {
						firstAddonName = a.name;
					}
				}
			}

			// does this computer have any dota addons?
			if (addons.Count == 0) {
				MetroMessageBox.Show(this, strings.NoDota2AddonsDetectedMsg,
					strings.NoDota2AddonsDetectedCaption,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Environment.Exit(0);
				return addons;
			}

			//Util.Log(addons_constructed, false);
			return addons;
		}

		/// <summary>
		/// Opens up info about all addons on the computer. User is able to change addon here.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void addonTile_Click(object sender, EventArgs e) {
			AddonsForm addonsForm = new AddonsForm(this);
			// ShowDialog() will not allow the user to go back to parent dialog until this dialog is dealt with.
			// Show() still allows the user to go back to the parent dialog.
			addonsForm.ShowDialog();
		}

		private void generateAddonLangsBtn_Click(object sender, EventArgs e) {
			fixButton();
			currAddon.generateAddonLangs(this);
		}

		private void workshopPageBtn_Click(object sender, EventArgs e) {
			fixButton();

			if (currAddon.workshopID != 0) {
				try {
					Process.Start("http://steamcommunity.com/sharedfiles/filedetails/?id=" + currAddon.workshopID);
				} catch (Exception ex) {
					// TODO.... 9/12/15
				}
				return;
			}

			SingleTextboxForm stf = new SingleTextboxForm();
			stf.Text = strings.WorkshopID;
			stf.textBox.Text = "";
			stf.btn.Text = "OK";
			stf.label.Text = strings.EnterWorkshopID + " (ex. 427193566):";

			DialogResult dr = stf.ShowDialog();
			if (dr == DialogResult.OK) {
				int id;
				if (Int32.TryParse(stf.textBox.Text, out id)) {
					currAddon.workshopID = id;
					Settings.Default.AddonNameToWorkshopID += currAddon.name + "=" + id + ";";
					// perform a refresh
					changeCurrAddon(currAddon);
				} else {
					MetroMessageBox.Show(this,
						strings.CouldntParseID,
						"",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		public void text_notification(string text, MetroColorStyle color, int duration) {
			System.Timers.Timer notificationLabelTimer = new System.Timers.Timer(duration);
			notificationLabelTimer.SynchronizingObject = this;
			notificationLabelTimer.AutoReset = false;
			notificationLabelTimer.Start();
			notificationLabelTimer.Elapsed += (s, e) => {
				notificationLabel.Text = "";
			};
			notificationLabel.Style = color;
			notificationLabel.Text = text;
		}

		private void combineKVBtn_Click(object sender, EventArgs e) {
			fixButton();
			kvFeatures.combine();
		}

		/// <summary>
		/// there is a bug with Metro where pressing a button in dark theme will keep it grey.
		/// </summary>
		public void fixButton() {
			metroRadioButton1.Select();
		}

		private void particleDesignBtn_Click(object sender, EventArgs e) {
			fixButton();
			particleFeatures.design();
		}

		private void deleteAddonBtn_Click(object sender, EventArgs e) {
			currAddon.delete();
		}

		private void onLink_Click(object sender, EventArgs e) {
			Debug.WriteLine(sender.ToString());
			string text = sender.ToString();
			if (text.EndsWith("Lua API")) {
				Process.Start("https://developer.valvesoftware.com/wiki/Dota_2_Workshop_Tools/Scripting/API");
			} else if (text.EndsWith("Panorama API")) {
				Process.Start("https://developer.valvesoftware.com/wiki/Dota_2_Workshop_Tools/Panorama/Javascript/API");
			} else if (text.EndsWith("r/Dota2Modding")) {
				Process.Start("https://www.reddit.com/r/dota2modding/");
			} else if (text.EndsWith("VPK")) {
				Process.Start("https://github.com/dotabuff/d2vpk/tree/master/dota_pak01");
			} else if (text.EndsWith("IRC")) {
				Process.Start("https://moddota.com/forums/chat");
			} else if (text.EndsWith("Lua Modifiers")) {
				Process.Start("https://developer.valvesoftware.com/wiki/Dota_2_Workshop_Tools/Scripting/Built-In_Modifier_Names");
			} else if (text.EndsWith("ModDota")) {
				Process.Start("https://moddota.com/forums");
			} else if (text.EndsWith("Ability Names")) {
				Process.Start("https://developer.valvesoftware.com/wiki/Dota_2_Workshop_Tools/Scripting/Built-In_Ability_Names");
			} else if (text.EndsWith("r/Dota2Modding")) {
				Process.Start("https://www.reddit.com/r/dota2modding/");
			} else if (text.EndsWith("SpellLibrary")) {
				Process.Start("https://github.com/Pizzalol/SpellLibrary");
			} else if (text.EndsWith("Workshop")) {
				Process.Start("http://steamcommunity.com/app/570/workshop/");
			} else if (text.EndsWith("GetDotaStats")) {
				Process.Start("http://getdotastats.com/#source2__beta_changes");
			} else if (text.EndsWith("dev.dota")) {
				Process.Start("http://dev.dota2.com/");
			}
		}

		private void goBtn_Click(object sender, EventArgs e) {
			fixButton();
			doGithubSearch();
		}

		private void doGithubSearch() {
			string query = githubTextBox.Text;

			if (query == "") {
				MetroMessageBox.Show(this, "",
				strings.NoTextInputted,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
				return;
			}

			string lang = "lua";
			if (textRadioButton.Checked) {
				lang = "text";
			} else if (jsRadioButton.Checked) {
				lang = "js";
			}
			//string url = "https://github.com/search?l=" + lang + "&q=\"" + query + "\"+dota&ref=searchresults&type=Code&utf8=%E2%9C%93";
			string url = "https://github.com/search?l=" + lang + "&q=" + query + "&ref=searchresults&s=indexed&type=Code&utf8=%E2%9C%93";
			Process.Start(url);
		}

		private void shortcutTile_Click(object sender, EventArgs e) {
			try {
				string text = sender.ToString();
				Debug.WriteLine(text);
				if (text.EndsWith("G")) {
					Process.Start(currAddon.gamePath);
				} else if (text.EndsWith("C")) {
					Process.Start(currAddon.contentPath);
				} else if (text.EndsWith("VS")) {
					Process.Start(Path.Combine(currAddon.gamePath, "scripts", "vscripts"));
				} else if (text.EndsWith("N")) {
					Process.Start(Path.Combine(currAddon.gamePath, "scripts", "npc"));
				} else if (text.EndsWith("P")) {
					Process.Start(Path.Combine(currAddon.contentPath, "panorama"));
				} else if (text.EndsWith("R")) {
					Process.Start(Path.Combine(currAddon.gamePath, "resource"));
				} else if (text.EndsWith("VPK")) {
					Process.Start(Path.Combine(dotaDir, "game", "dota", "pak01_dir.vpk"));
				} else if (text.EndsWith("E")) {
					//dota_english.txt
				}
			} catch (Exception ex) {
				// likely directoryNotFound exceptions.
				MetroMessageBox.Show(this, ex.Message,
				ex.ToString(),
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			}
		}

		private void changePictureToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void compileVtexButton_Click(object sender, EventArgs e) {
			fixButton();
			try {
				vtexFeatures.compileVTEX();
			} catch (Exception ex) {
				MetroMessageBox.Show(this, ex.Message,
					ex.ToString(),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}

		}

		private void decompileVtexButton_Click(object sender, EventArgs e) {
			fixButton();
			try {
				vtexFeatures.decompileVTEX();
			} catch (Exception ex) {
				MetroMessageBox.Show(this, ex.Message,
					ex.ToString(),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void reportBugBtn_Click(object sender, EventArgs e) {
			Process.Start("https://github.com/Myll/Dota-2-ModKit/issues");
		}

		private void optionsBtn_Click(object sender, EventArgs e) {
			onOptionsClick();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			onOptionsClick();
		}

		void onOptionsClick() {
			OptionsForm of = new OptionsForm(this);
			DialogResult dr = of.ShowDialog();

			if (dr != DialogResult.OK) {
				return;
			}

			text_notification(strings.OptionsSaved, MetroColorStyle.Green, 2500);
		}

		private void findSoundNameBtn_Click(object sender, EventArgs e) {
			fixButton();

			try {
				soundFeatures.findSoundName();
			} catch (Exception ex) {
				MetroMessageBox.Show(this, ex.Message,
					ex.ToString(),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void spellLibraryBtn_Click(object sender, EventArgs e) {
			fixButton();

			if (Application.OpenForms["SpellLibraryForm"] != null) {
				Application.OpenForms["SpellLibraryForm"].BringToFront();
                Application.OpenForms["SpellLibraryForm"].WindowState = FormWindowState.Normal;
				return;
            }

			//try {
				SpellLibraryForm slf = new SpellLibraryForm(this);
			/*} catch (Exception ex) {
				MetroMessageBox.Show(this, ex.Message,
					ex.ToString(),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}*/
		}

		private void libraryManagerBtn_Click(object sender, EventArgs e) {
			LibraryManagerForm lmf = new LibraryManagerForm(this);
			lmf.ShowDialog();

		}

		private void libraryManagerToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void versionLabel_Click(object sender, EventArgs e) {
			Process.Start("https://github.com/stephenfournier/Dota-2-ModKit/releases/tag/v" + version);
        }

		private void compileCoffeeBtn_Click(object sender, EventArgs e) {
			fixButton();
			var coffeeScriptDir = Path.Combine(currAddon.contentPath, "panorama", "scripts", "coffeescript");

			if (!Directory.Exists(coffeeScriptDir)) {
				MetroMessageBox.Show(this,
					coffeeScriptDir + " " + strings.DirectoryDoesntExistCaption,
					strings.DirectoryDoesntExistMsg,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if (cse == null) {
				cse = new CoffeeSharp.CoffeeScriptEngine();
			}

            var coffeePaths = Directory.GetFiles(coffeeScriptDir, "*.coffee", SearchOption.AllDirectories);

			foreach (var coffeePath in coffeePaths) {
				string coffeeCode = File.ReadAllText(coffeePath, Util.GetEncoding(coffeePath));
				string js = cse.Compile(coffeeCode, true);

				string relativePath = coffeePath.Substring(coffeePath.IndexOf("coffeescript")+13);

				var jsPath = Path.Combine(currAddon.contentPath, "panorama", "scripts", relativePath);
				jsPath = jsPath.Replace(".coffee", ".js");

				// ensure the dir housing the new js file exists.
				string foldPath = jsPath.Substring(0, jsPath.LastIndexOf('\\') + 1);
				if (!Directory.Exists(foldPath)) {
					Directory.CreateDirectory(foldPath);
				}

				File.WriteAllText(jsPath, js, Encoding.UTF8);
			}
			text_notification(strings.CoffeeScriptFilesCompiled, MetroColorStyle.Green, 1500);
		}

		private void setupCustomTiles() {
			var str_customTileInfos = Settings.Default.CustomTileInfo;
			string[] serializedTileInfos = null;

			if (str_customTileInfos.Contains('|')) {
				serializedTileInfos = str_customTileInfos.Split('|');
			}

			for (int i = 0; i < customTiles.Length; i++) {
				int tileNum = i + 1;
				MetroTile tile = (MetroTile)this.Controls["customTile" + tileNum];
				CustomTile customTile = null;
				if (serializedTileInfos != null) {
					customTile = new CustomTile(this, tile, tileNum, serializedTileInfos[i]);
				} else {
					customTile = new CustomTile(this, tile, tileNum, "");
				}
				customTiles[i] = customTile;
			}
		}

		private void editTileToolStripMenuItem_Click(object sender, EventArgs e) {
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			var owner = (ContextMenuStrip)item.Owner;
			MetroTile tile = (MetroTile)(owner.SourceControl);
			string name = tile.Name;
			int tileNum = Int32.Parse(name.Substring(name.LastIndexOf('e')+1))-1;
			customTiles[tileNum].editTile();
		}

		private void notificationLabel_Click(object sender, EventArgs e) {

		}

		private void reportBug_Click(object sender, EventArgs e) {
			Process.Start("https://github.com/stephenfournier/Dota-2-ModKit/issues/new");
		}

		private void donateBtn_Click(object sender, EventArgs e) {
			DonateForm df = new DonateForm(this);
			df.ShowDialog();
		}
	}
}
