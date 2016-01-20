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
using MetroFramework.Components;

namespace Dota2ModKit {
    public partial class MainForm : MetroForm {
        public bool DEBUG = false;
        public Addon currAddon;
        public Dictionary<string, Addon> addons;
        internal bool firstRun = false;
        public string dotaDir = "",
            gamePath = "",
            contentPath = "",
            version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
            firstAddonName = "",
            newVers = "",
            newVersUrl = "",
            releases_page_source = "";
        public System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public Dictionary<string, List<string>> vsndToName = new Dictionary<string, List<string>>();

        // for updating modkit
        Updater updater;

        // Features of modkit
        internal KVFeatures kvFeatures;
        internal VTEXFeatures vtexFeatures;
        internal ParticleFeatures particleFeatures;
        internal SoundFeatures soundFeatures;
        internal SpellLibraryFeatures spellLibraryFeatures;
        internal AboutFeatures aboutFeatures;
        internal ChatFeatures chatFeatures;

        public CustomTile[] customTiles = new CustomTile[5];
        public CoffeeSharp.CoffeeScriptEngine cse = null;

        public MainForm() {
            // bring up the UI
            InitializeComponent();

            // if new version of modkit, update the settings.
            updateSettings();

            // setup hooks
            setupHooks();

            // check for new modkit version
            updater = new Updater(this);

            // init mainform controls stuff
            initMainFormControls();

            // get the dota directory
            retrieveDotaDir();

            // ** at this point assume valid dota dir. **
            Debug.WriteLine("Directory: " + dotaDir);
            Settings.Default.DotaDir = dotaDir;

            // get the game and content dirs
            gamePath = Path.Combine(dotaDir, "game", "dota_addons");
            contentPath = Path.Combine(dotaDir, "content", "dota_addons");

            // create these dirs if they don't exist.
            if (!Directory.Exists(gamePath)) { Directory.CreateDirectory(gamePath); }
            if (!Directory.Exists(contentPath)) { Directory.CreateDirectory(contentPath); }

            // get all the addons in the 'game' dir.
            addons = getAddons();

            // setup custom tiles
            //setupCustomTiles();

            // does this computer have any dota addons?
            if (addons.Count == 0) {
                MetroMessageBox.Show(this, "No Dota 2 addons detected. There must be one addon for D2ModKit to function properly. Exiting.",
                    "No Dota 2 addons detected.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            // some functions in the Tick try and use mainform's controls on another thread. so we need to allot a very small amount of time for
            // mainform to init its controls. this is mainly for the very first run of modkit.
            Util.CreateTimer(200, (timer) => {
                timer.Dispose();

                // clone a barebones repo if we don't have one, pull if we do
                updater.clonePullBarebones();

                // deserialize settings
                deserializeSettings();

                // auto-retrieve the workshop IDs for published addons if there are any.
                getPublishedAddonWorkshopIDs();

                // set currAddon to the addon that was last opened in last run of modkit.
                if (Settings.Default.LastAddon != "") {
                    Addon a = getAddonFromName(Settings.Default.LastAddon);
                    if (a != null) {
                        changeCurrAddon(a);
                    }
                }

                // basically, if this is first run of modkit, set the currAddon to w/e the default addon is in the workshop tools.
                if (currAddon == null) {
                    changeCurrAddon(addons[getDefaultAddonInTools()]);
                }

                // setup the addons panel, so user can choose the currAddon.
                setupAddonsPanel();

                // init our features of Modkit
                initModKitFeatures();
            });
        }

        private void initModKitFeatures() {
            kvFeatures = new KVFeatures(this);
            vtexFeatures = new VTEXFeatures(this);
            particleFeatures = new ParticleFeatures(this);
            soundFeatures = new SoundFeatures(this);
            spellLibraryFeatures = new SpellLibraryFeatures(this);
            aboutFeatures = new AboutFeatures(this);
            chatFeatures = new ChatFeatures(this);
        }

        private void initMainFormControls() {
            //Size size = new Size(steamTile.Width, steamTile.Height);
            //steamTile.TileImage = (Image)new Bitmap(Resources.steam_icon, size);

            //luaRadioBtn.Checked = true;
            tabControl.SelectedIndex = 0;
            notificationLabel.Text = "";
            versionLabel.Text = "v" + version;
            Style = Util.getRandomStyle();
        }

        private void setupHooks() {
            tabControl.Selected += (s, e) => {
                //PlaySound(Properties.Resources.browser_click_navigate);
            };

            FormClosing += (s, e) => {
                serializeSettings();
            };

            tabControl.SelectedIndexChanged += (s, e) => {
                if (tabControl.SelectedTab == homeTab) {
                    if (currAddon != null) {
                        currAddon.createTree();
                    }
                }
            };

            /*githubTextBox.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) {
                    doGithubSearch();
                }
            };*/

            addonTile.Click += (s, e) => {
                tabControl.SelectedTab = homeTab;
            };

            scriptsTree.NodeMouseDoubleClick += (s, e) => {
                Debug.WriteLine("scriptsTree afterSelect");
                var node = scriptsTree.SelectedNode;
                try {
                    Process.Start(node.Name);
                } catch (Exception) { }
            };

            panoramaTree.NodeMouseDoubleClick += (s, e) => {
                Debug.WriteLine("panoramaTree afterSelect");
                var node = panoramaTree.SelectedNode;
                try {
                    Process.Start(node.Name);
                } catch (Exception) { }
            };

        }

        private void updateSettings() {
            if (Settings.Default.UpdateRequired) {
                Settings.Default.Upgrade();
                Settings.Default.UpdateRequired = false;
                Settings.Default.Save();
                // open up changelog
                if (Settings.Default.OpenChangelog && !DEBUG) {
                    Process.Start("https://github.com/Myll/Dota-2-ModKit/releases");
                }
                // display notification
                //text_notification("D2ModKit updated!", MetroColorStyle.Green, 1500);
            }
        }

        private void retrieveDotaDir() {
            // start process of retrieving dota dir
            dotaDir = Settings.Default.DotaDir;

            if (Settings.Default.DotaDir == "") {
                // this is first run of application

                // try to auto-get the dir
                dotaDir = Util.getDotaDir();

                DialogResult dr = DialogResult.No;
                if (dotaDir != "") {
                    firstRun = true;
                    dr = MetroMessageBox.Show(this, "Dota directory has been set to: " + dotaDir +
                        ". Is this correct?",
                        "Confirmation",
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

                        Environment.Exit(0);
                    }

                    string p = fbd.SelectedPath;
                    dotaDir = p;
                }
            }

            // ModKit must ran in the same drive as the dota dir.
            if (!Util.hasSameDrives(Environment.CurrentDirectory, dotaDir)) {
                MetroMessageBox.Show(this, "Dota 2 ModKit must be ran from the same drive as Dota 2 or else errors " +
                    "will occur. Please move Dota 2 ModKit to the '" + dotaDir[0] + "' Drive and create a shortcut to it.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Environment.Exit(0);
            }

            // trying to read vpk practice. this works currently
            /*
			string s2vpkPath = Path.Combine(dotaDir, "game", "dota_imported", "pak01_dir.vpk");
			using (var vpk = new VpkFile(s2vpkPath)) {
				vpk.Open();
				Debug.WriteLine("Got VPK version {0}", vpk.Version);
				VpkNode node = vpk.GetFile("scripts/npc/npc_units.txt");
				using (var inputStream = VPKUtil.GetInputStream(s2vpkPath, node)) {
					var pathPieces = node.FilePath.Split('/');
					var directory = pathPieces.Take(pathPieces.Count() - 1);
					var fileName = pathPieces.Last();

					//EnsureDirectoryExists(Path.Combine(directory.ToArray()));

					using (var fsout = File.OpenWrite(Path.Combine(Environment.CurrentDirectory, "something.txt"))) {
						var buffer = new byte[1024];
						int amtToRead = (int)node.EntryLength;
						int read;

						while ((read = inputStream.Read(buffer, 0, buffer.Length)) > 0 && amtToRead > 0) {
							fsout.Write(buffer, 0, Math.Min(amtToRead, read));
							amtToRead -= read;
						}
					}
				}
			}*/
        }

        private string getDefaultAddonInTools() {
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

        private void getPublishedAddonWorkshopIDs() {
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
            /*
            string customTilesSerialized = "";
            for (int i = 0; i < customTiles.Length; i++) {
                customTilesSerialized += customTiles[i].serializedTileInfo + "|";
            }
            Settings.Default.CustomTileInfo = customTilesSerialized;*/
            Settings.Default.Save();
        }

        // String -> Addon object conversion
        public Addon getAddonFromName(string name) {
            Addon a;
            if (addons.TryGetValue(name, out a)) {
                return a;
            }

            return null;
        }

        public void changeCurrAddon(Addon a) {
            var panelTile = a.panelTile; // is null on startup.
            if (currAddon != null) { // is null on startup
                currAddon.panelTile = panelTile;
            }
            a.panelTile = null; // this is becoming currAddon, which has no panelTile.

            // perform the tile swap of currAddon and a.
            // first change the addonTile.
            var addonTileImage = a.getThumbnail(this);
            if (addonTileImage != null) {
                addonTile.UseTileImage = true;
                Util.CreateTimer(100, (timer) => {
                    timer.Dispose();
                    Size size = new Size(addonTile.Width, addonTile.Height);
                    addonTile.TileImage = (Image)new Bitmap(addonTileImage, size);
                    addonTile.Refresh();
                });
            } else {
                addonTile.UseTileImage = false;
                a.doesntHaveThumbnail = true;
                if (panelTile != null) {
                    addonTile.Style = panelTile.Style;
                } else {
                    addonTile.Style = Util.getRandomStyle();
                }
            }
            addonTile.Text = a.name;

            // now change the panelTile.
            if (panelTile != null && currAddon != null) {
                var panelTileImage = currAddon.getThumbnail(this);
                if (panelTileImage != null) {
                    panelTile.UseTileImage = true;
                    Size size = new Size(panelTile.Width, panelTile.Height);
                    panelTile.TileImage = (Image)new Bitmap(panelTileImage, size);
                } else {
                    panelTile.UseTileImage = false;
                    currAddon.doesntHaveThumbnail = true;
                    
                    panelTile.Style = Util.getRandomStyle();
                }
                panelTile.Text = currAddon.name;
            }

            currAddon = a;
            currAddon.onChangedTo(this);

            Settings.Default.LastAddon = a.name;
            //text_notification("Selected addon: " + a.name, MetroColorStyle.Green, 2500);
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

            //Util.Log(addons_constructed, false);
            return addons;
        }

        void setupAddonsPanel() {
            Random rand = new Random();
            var x = 0;
            var y = 0;
            int addon_height = 126;
            int y_padding = 6;
            var bar = (MetroScrollBar)addonsPanel.Controls[0];
            bar.Theme = MetroThemeStyle.Dark;
            bar.Width = 9;
            int scrollbar_width = bar.Width+4;
            bar = (MetroScrollBar)addonsPanel.Controls[1];
            bar.Theme = MetroThemeStyle.Dark;
            bar.Width = 9;

            int addon_width = addonsPanel.Size.Width - scrollbar_width;
            addonTile.Width = addon_width+scrollbar_width-y_padding;
            addonTile.Height = addon_height;
            //addonsPanel.Location = new Point(addonTile.Location.X, addonTile.Location.Y + addonTile.Height + y_padding);
            foreach (var kv in addons) {
                var a = kv.Value;
                if (a == currAddon) {
                    continue;
                }
                MetroTile mt = new MetroTile();
                mt.Parent = addonsPanel;
                mt.Size = new Size(addon_width, addon_height);
                mt.Location = new Point(x, y);
                mt.TileTextFontSize = MetroTileTextSize.Tall;
                y += addon_height + y_padding;

                mt.UseTileImage = false;
                if (a.getThumbnail(this) != null) {
                    mt.UseTileImage = true;
                    Size size = new Size(mt.Width, mt.Height);
                    mt.TileImage = (Image)new Bitmap(a.image, size);
                } else {
                    mt.Style = (MetroColorStyle)rand.Next(4, 14);
                }
                mt.Text = a.name;
                a.panelTile = mt;

                mt.Click += (s, e) => {
                    var tile = (MetroTile)s;
                    changeCurrAddon(getAddonFromName(tile.Text));
                };

                mt.Refresh();
            }
        }

        private void generateTooltipsBtn_Click(object sender, EventArgs e) {
            fixButton();
            currAddon.generateTooltips(this);
        }

        private void workshopPageBtn_Click(object sender, EventArgs e) {
            fixButton();

            if (currAddon.workshopID != 0) {
                try {
                    Process.Start("http://steamcommunity.com/sharedfiles/filedetails/?id=" + currAddon.workshopID);
                } catch (Exception) {
                    // TODO.... 9/12/15
                }
                return;
            }

            SingleTextboxForm stf = new SingleTextboxForm();
            stf.Text = "Workshop ID";
            stf.textBox.Text = "";
            stf.btn.Text = "OK";
            stf.label.Text = "Enter the workshop ID (ex. 427193566):";

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
                        "Couldn't parse ID!",
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

        // there's a bug in Metro where pressing a control will make it stay highlighted... this fixes it
        public void fixButton() {
            metroRadioButton1.Select();
        }

        private void deleteAddonBtn_Click(object sender, EventArgs e) {
            fixButton();

            DialogResult dr = MetroMessageBox.Show(this,
                "Are you sure you want to delete the addon '" + currAddon.name + "'? " +
                "This will permanently delete the 'content' and 'game' directories of this addon.",
                "Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.OK) {
                try {
                    Directory.Delete(currAddon.gamePath, true);
                    Directory.Delete(currAddon.contentPath, true);
                } catch (Exception) {
                    MetroMessageBox.Show(this, "Please close all programs that are using files related to this addon, " +
                    "including all related Windows Explorer processes, and try again.",
                    "Could not fully delete addon",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }

                string removed = currAddon.name;
                addons.Remove(currAddon.name);

                // reset currAddon
                foreach (KeyValuePair<string, Addon> a in addons) {
                    // pick the first one and break
                    changeCurrAddon(a.Value);
                    break;
                }

                text_notification("The addon '" + removed + "' was successfully deleted.", MetroColorStyle.Green, 2500);
            }
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

        /*private void goBtn_Click(object sender, EventArgs e) {
            fixButton();
            doGithubSearch();
        }

        private void doGithubSearch() {
            string query = githubTextBox.Text;

            if (query == "") {
                MetroMessageBox.Show(this, "",
                "No text inputted.",
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
            string url = "https://github.com/search?l=" + lang + "&q=%22" + query + "%22&ref=searchresults&type=Code&utf8=%E2%9C%93";
            //string url = "https://github.com/search?l=" + lang + "&q=" + query + "&ref=searchresults&s=indexed&type=Code&utf8=%E2%9C%93";
            Process.Start(url);
        }*/

        private void shortcutTile_Click(object sender, EventArgs e) {
            fixButton();
            try {
                string text = sender.ToString();
                Debug.WriteLine(text);
                if (text.EndsWith("Game")) {
                    Process.Start(currAddon.gamePath);
                } else if (text.EndsWith("Content")) {
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
            Process.Start("https://github.com/stephenfournier/Dota-2-ModKit/issues");
        }

        #region Options
        private void optionsBtn_Click(object sender, EventArgs e) {
            onOptionsClick();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            onOptionsClick();
        }

        private void hideExtensionsCheckbox_Click(object sender, EventArgs e) {
            fixButton();
            currAddon.createTree();
        }

        void onOptionsClick() {
            OptionsForm of = new OptionsForm(this);
            DialogResult dr = of.ShowDialog();

            if (dr != DialogResult.OK) {
                return;
            }

            text_notification("Options saved!", MetroColorStyle.Green, 2500);
        }
        #endregion

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

        private void versionLabel_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/stephenfournier/Dota-2-ModKit/releases/tag/v" + version);
        }

        private void compileCoffeeBtn_Click(object sender, EventArgs e) {
            fixButton();
            var coffeeScriptDir = Path.Combine(currAddon.contentPath, "panorama", "scripts", "coffeescript");

            if (!Directory.Exists(coffeeScriptDir)) {
                MetroMessageBox.Show(this,
                    coffeeScriptDir + " doesn't exist!",
                    "Directory doesn't exist",
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

                string relativePath = coffeePath.Substring(coffeePath.IndexOf("coffeescript") + 13);

                var jsPath = Path.Combine(currAddon.contentPath, "panorama", "scripts", relativePath);
                jsPath = jsPath.Replace(".coffee", ".js");

                // ensure the dir housing the new js file exists.
                string foldPath = jsPath.Substring(0, jsPath.LastIndexOf('\\') + 1);
                if (!Directory.Exists(foldPath)) {
                    Directory.CreateDirectory(foldPath);
                }

                File.WriteAllText(jsPath, js, Encoding.UTF8);
            }
            text_notification("CoffeeScript files compiled!", MetroColorStyle.Green, 1500);
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
            int tileNum = Int32.Parse(name.Substring(name.LastIndexOf('e') + 1)) - 1;
            customTiles[tileNum].editTile();
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
