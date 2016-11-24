using Dota2ModKit.Properties;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using MetroFramework;
using System;
using KVLib;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Net;
using MetroFramework.Controls;

namespace Dota2ModKit
{
	public class Addon {
		public string gamePath;
		public string contentPath;
		public string name;
		public bool hasContentPath = true;
		public int libraryPos;
		internal int libraryPage;
		internal int workshopID;
		internal Image image;
		internal bool doesntHaveThumbnail;
		internal MetroColorStyle tileColor = MetroColorStyle.Green;

		// for generating addon_lang files
		HashSet<string> abilityModifierNames = new HashSet<string>();
		HashSet<string> itemModifierNames = new HashSet<string>();
		List<AbilityEntry> abilityEntries = new List<AbilityEntry>();
		List<AbilityEntry> itemEntries = new List<AbilityEntry>();
		List<UnitEntry> unitEntries = new List<UnitEntry>();
		List<HeroEntry> heroEntries = new List<HeroEntry>();
		HashSet<string> alreadyHasKeys = new HashSet<string>();

		// deserialized settings
		internal bool generateNote0;
		internal bool generateLore;
		internal bool askToBreakUp;
		internal bool autoDeleteBin;
		internal bool barebonesLibUpdates;

		private string gameSizeStr = "";
		private string contentSizeStr = "";
		private MainForm mainForm;
		//public List<Library> libraries = new List<Library>();
		public Dictionary<string, Library> libraries = new Dictionary<string, Library>();
		HashSet<string> NotDefaultLibs = new HashSet<string>();
		public string relativeGamePath;
		internal bool generateUTF8 = true;
		internal bool autoCompileCoffeeScript;

		// FileSystemWatcher's
		public Dictionary<string, FileSystemWatcher> npcWatchers = new Dictionary<string, FileSystemWatcher>();
		internal FileSystemWatcher coffeeWatcher;

		public Addon(string gamePath) {
			this.gamePath = gamePath;

			// extract other info from the gamePath
			name = gamePath.Substring(gamePath.LastIndexOf('\\')+1);
			//Debug.WriteLine("New Addon detected: " + name);
			this.relativeGamePath = gamePath.Substring(gamePath.IndexOf(Path.Combine("game", "dota_addons")));

			string dotaDir = Settings.Default.DotaDir;

			contentPath = Path.Combine(dotaDir, "content", "dota_addons", name);

			if (!Directory.Exists(contentPath)) {
				try {
					Directory.CreateDirectory(contentPath);
				} catch (Exception) {
					Debug.WriteLine(strings.CouldntAutoCreateContent + " " + name);
					hasContentPath = false;
				}
			}
		}

		public class Library {
			public string local;
			public string remote;
			internal int gridRow;
			public bool updateAvailable;
			internal MetroGrid grid;
			string tempFile = "";
			internal string defaultLibPath;
			public Addon addon;
			public bool neverCheckForUpdates;
			public string name;
			public bool isDummyLib;
			private Exception exception;
			private bool needsUpdate;
			private string libName;
			private string libFileName;

			public string LibFileName {
				get {
					if (libFileName != null) {
						return libFileName;
					}

					if (defaultLibPath != null) {
						libFileName = defaultLibPath.Substring(defaultLibPath.LastIndexOf('\\') + 1);
					}
					return libFileName;
				} set {
					libFileName = value;
				}
			}

			public string LibName {
				get {
					if (libName != null) {
						return libName;
					}

					if (defaultLibPath != null) {
						if (defaultLibPath.Contains(Path.Combine("dota_addons", "barebones"))) {
							libName = "barebones";
						}
					}
					return libName;
				} set {
					libName = value;
				}
			}

			public Library(string local, Addon a) {
				this.local = local;
				this.addon = a;
				name = local.Substring(local.LastIndexOf('\\') + 1);
			}

			public void checkForUpdates() {
				var libUpdateWorker = new BackgroundWorker();

				libUpdateWorker.DoWork += (s, e) => {
					if (!File.Exists(local)) {
						// this shouldn't even be a library
						addon.libraries.Remove(local);

						return;
					}

					// check for dummy lib
					if (defaultLibPath == null && remote == null) {
						isDummyLib = true;
						return;
					}

					if (defaultLibPath != null && File.Exists(defaultLibPath) && !neverCheckForUpdates) {
						string defaultLibTxt = File.ReadAllText(defaultLibPath);
						string localTxt = File.ReadAllText(local);
						if (localTxt != defaultLibTxt) {
							needsUpdate = true;
						}

						return;
					}

					// lib wasn't a local lib. do remote stuff
					WebClient wc = new WebClient();

					try {
						tempFile = Path.Combine(Environment.CurrentDirectory, "temp", Util.DoUniqueString());
						wc.DownloadFile(remote, tempFile);
						byte[] responseBytes = wc.DownloadData(remote);

						if (new FileInfo(tempFile).Length != new FileInfo(local).Length) {
							updateAvailable = true;
						}

						//File.Delete(tempFile);

					} catch (Exception) { }
				};

				libUpdateWorker.RunWorkerCompleted += (s, e) => {
					if (!needsUpdate) {
						return;
					}
					needsUpdate = false;

					DialogResult dr = MetroMessageBox.Show(addon.mainForm,
						name + " in " + addon.name +
						" does not match the contents of " + LibFileName + " in " + LibName + ". " +
						"Replace the contents now? Press 'Cancel' to never see this again.",
						"Library Update",
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Information);

					if (dr == DialogResult.Cancel) {
						this.neverCheckForUpdates = true;
						return;
					} else if (dr == DialogResult.No) {
						return;
					}

					try {
						File.WriteAllText(local, File.ReadAllText(defaultLibPath));
					} catch (Exception ex) {
						this.exception = ex;
					}

					if (exception != null) {
						MetroMessageBox.Show(addon.mainForm,
							exception.Message,
							exception.ToString(),
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);

						exception = null;
					} else {
						addon.mainForm.text_notification(name + " updated!", MetroColorStyle.Blue, 1500);
					}
				};
				libUpdateWorker.RunWorkerAsync();
			}
		}

	    public bool FilesLocked { get; set; }

	    /// <summary>
		/// Default libs are mainly libs that are local.
		/// </summary>
		public void checkForDefaultLibs() {
			string vscriptsPath = Path.Combine(gamePath, "scripts", "vscripts");
			string barebonesLibsPath = Path.Combine(Environment.CurrentDirectory, "barebones", "game", "dota_addons",
				"barebones", "scripts", "vscripts", "libraries");

            if (!Directory.Exists(vscriptsPath) || !Directory.Exists(barebonesLibsPath)) {
				return;
			}

			Dictionary<string, string> libNameToPath = new Dictionary<string, string>();
			foreach (string barebonesLib in Directory.GetFiles(barebonesLibsPath, "*.lua", SearchOption.AllDirectories)) {
				string fn = barebonesLib.Substring(barebonesLib.LastIndexOf('\\') + 1);
				libNameToPath.Add(fn, barebonesLib);

			}

            string[] vscripts = Directory.GetFiles(vscriptsPath, "*.lua", SearchOption.AllDirectories);
			foreach (string path in vscripts) {
				string fn = path.Substring(path.LastIndexOf('\\') + 1);
				if (libNameToPath.ContainsKey(fn)) {
					if (libraries.ContainsKey(path) || NotDefaultLibs.Contains(path)) {
						// this has already been checked and it's not a default lib. don't waste user's time
						continue;
					}

					Library lib = new Library(path, this);
					DialogResult dr = MetroMessageBox.Show(mainForm,
						Util.Relative(path) + " has been detected to be a Barebones library. Enable auto update checker for this library?",
						"Library detected",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Information);

					if (dr == DialogResult.Yes) {
						lib.defaultLibPath = libNameToPath[fn];
					} // if it's No, still add it as a dummy library, to remember this decision later.

					libraries.Add(path, lib);
				}
			}
		}

		internal void generateAddonLangs(MainForm mainForm) {
			abilityModifierNames.Clear();
			itemModifierNames.Clear();
			abilityEntries.Clear();
			itemEntries.Clear();
			unitEntries.Clear();
			heroEntries.Clear();
			alreadyHasKeys.Clear();

			string curr = "";
			try {
				// these functions populate the data structures with the tooltips before writing to the addon_lang file.
				// items
				curr = "npc_items_custom.txt";
				generateAbilityTooltips(true);
				// abils
				curr = "npc_abilities_custom.txt";
				generateAbilityTooltips(false);
				curr = "npc_units_custom.txt";
				generateUnitTooltips();
				curr = "npc_heroes_custom.txt";
				generateHeroTooltips();
				writeTooltips();
				mainForm.text_notification(strings.TooltipsSuccessfully, MetroColorStyle.Green, 2500);
			} catch (Exception ex) {
				string msg = ex.Message;
				if (ex.InnerException != null) {
					msg = ex.InnerException.Message;
				}

				MetroMessageBox.Show(mainForm, msg,
					"Parse error: " + curr,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

			}

			// utf8 code
			if (generateUTF8) {
				string[] files = Directory.GetFiles(Path.Combine(gamePath, "resource"));
				foreach (string file in files) {
					// skip the existing utf8 files.
					if (file.Contains("utf8")) {
						continue;
					}
					string name = file.Substring(file.LastIndexOf("\\") + 1);
					name = name.Replace(".txt", "");
					//string firstPart = file.Substring(0, file.LastIndexOf("\\"));
					name += "_utf8.txt";
					File.WriteAllText(Path.Combine(contentPath, name), File.ReadAllText(file), Encoding.UTF8);
				}
			}
		}

		private void writeTooltips() {
			foreach (string path in getAddonLangPaths()) {

				alreadyHasKeys.Clear();

				string thisLang = path.Substring(path.LastIndexOf('\\') + 1);

				string thisLangCopy = thisLang;
				thisLang = thisLang.Substring(thisLang.LastIndexOf('_') + 1);

				string outputPath = Path.Combine(contentPath, "tooltips_" + thisLang);

				KeyValue kv = KVParser.KV1.ParseAll(File.ReadAllText(path, Encoding.Unicode))[0];

				foreach (KeyValue kv2 in kv.Children) {
					if (kv2.Key == "Tokens") {
						foreach (KeyValue kv3 in kv2.Children) {
							alreadyHasKeys.Add(kv3.Key.ToLowerInvariant());
						}
					}
				}

				StringBuilder content = new StringBuilder();

				string head0 =
				"\t\t// DOTA 2 MODKIT GENERATED TOOLTIPS FOR: " + this.name + "\n" +
				"\t\t// Keys already defined in " + thisLangCopy + " are not listed, nor are Modifiers with the property \"IsHidden\" \"1\".\n";
				content.Append(head0);

				string head1 = "\n\t\t// ******************** HEROES ********************\n";
				content.Append(head1);
				foreach (HeroEntry he in heroEntries) {
					if (!alreadyHasKeys.Contains(he.name.key.ToLowerInvariant())) {
						content.Append(he);
					}
				}

				string head2 = "\n\t\t// ******************** UNITS ********************\n";
				content.Append(head2);
				foreach (UnitEntry ue in unitEntries) {
					if (!alreadyHasKeys.Contains(ue.name.key.ToLowerInvariant())) {
						content.Append(ue);
					}
				}

				string head3 = "\n\t\t// ******************** ABILITY MODIFIERS ********************\n";
				content.Append(head3);
				foreach (string amn in abilityModifierNames) {
					ModifierEntry me = new ModifierEntry(this, amn);
					if (!alreadyHasKeys.Contains(me.name.key.ToLowerInvariant())) {
						content.Append(me + "\n");
					}
				}

				string head4 = "\n\t\t// ******************** ITEM MODIFIERS ********************\n";
				content.Append(head4);
				foreach (string imn in itemModifierNames) {
					ModifierEntry me = new ModifierEntry(this, imn);
					if (!alreadyHasKeys.Contains(me.name.key.ToLowerInvariant())) {
						content.Append(me + "\n");
					}
				}

				string head5 = "\n\t\t// ******************** ABILITIES ********************\n";
				content.Append(head5);
				foreach (AbilityEntry ae in abilityEntries) {
					if (!alreadyHasKeys.Contains(ae.name.key.ToLowerInvariant())) {
						content.Append(ae + "\n");
					} else {
						// the addon_language already has this ability. but let's check
						// if there are any new AbilitySpecials.
						bool missingAbilSpecials = false;
						foreach (Pair p in ae.abilitySpecials) {
							if (!alreadyHasKeys.Contains(p.key.ToLowerInvariant())) {
								// the addon_language doesn't contain this abil special.
								content.Append(p.ToString());
								missingAbilSpecials = true;
							}
						}
						if (missingAbilSpecials) {
							content.Append("\n");
						}
					}
				}

				string head6 = "\n\t\t// ******************** ITEMS ********************\n";
				content.Append(head6);
				foreach (AbilityEntry ae in itemEntries) {
					if (!alreadyHasKeys.Contains(ae.name.key.ToLowerInvariant())) {
						content.Append(ae + "\n");
					} else {
						// the addon_language already has this ability. but let's check
						// if there are any new AbilitySpecials.
						bool missingAbilSpecials = false;
						foreach (Pair p in ae.abilitySpecials) {
							if (!alreadyHasKeys.Contains(p.key.ToLowerInvariant())) {
								// the addon_language doesn't contain this abil special.
								content.Append(p.ToString());
								missingAbilSpecials = true;
							}
						}
						if (missingAbilSpecials) {
							content.Append("\n");
						}
					}
				}
				File.WriteAllText(outputPath, content.ToString(), Encoding.Unicode);
				Process.Start(outputPath);
			}
		}

		internal void deleteBinFiles() {
			if (!autoDeleteBin) {
				return;
			}

			string[] binFilePaths = Directory.GetFiles(gamePath, "*.bin", SearchOption.TopDirectoryOnly);
			foreach (string binFilePath in binFilePaths) {
				try {
					File.Delete(binFilePath);
				} catch (Exception) { }
			}
		}

		private List<string> getAddonLangPaths() {
			string[] resourceFiles = Directory.GetFiles(Path.Combine(gamePath, "resource"));
			List<string> langFiles = new List<string>();

			// only take the addon_language files
			for (int i = 0; i < resourceFiles.Length; i++) {
				string resourceFile = resourceFiles[i];
				if (resourceFile.Contains("addon_") && resourceFile.EndsWith(".txt") && !resourceFile.EndsWith("utf8.txt")) {
					langFiles.Add(resourceFile);
				}
			}
			return langFiles;
		}

		#region private generate tooltip functions

		private void generateHeroTooltips() {
			string path = Path.Combine(gamePath, "scripts", "npc", "npc_heroes_custom.txt");

			if (!File.Exists(path)) {
				return;
			}

			KeyValue kvs = kvs = KVParser.KV1.ParseAll(File.ReadAllText(path))[0];

			foreach (KeyValue kv in kvs.Children) {
				if (kv.Key == "Version") {
					continue;
				}

				string name = kv.Key;

				foreach (KeyValue kv2 in kv.Children) {
					if (kv2.Key == "override_hero") {
						heroEntries.Add(new HeroEntry(this, kv2.GetString(), name));
						break;
					}

				}

				unitEntries.Add(new UnitEntry(this, kv.Key));
			}
		}

		private void generateUnitTooltips() {
			string path = Path.Combine(gamePath, "scripts", "npc", "npc_units_custom.txt");

			if (!File.Exists(path)) {
				return;
			}

			KeyValue kvs = kvs = KVParser.KV1.ParseAll(File.ReadAllText(path))[0];

			foreach (KeyValue kv in kvs.Children) {
				if (kv.Key == "Version") {
					continue;
				}
				unitEntries.Add(new UnitEntry(this, kv.Key));
			}
		}

		internal void delete() {
			DialogResult dr = MetroMessageBox.Show(mainForm,
				strings.AreYouSure + " '" + name + "'? " + strings.PermanentlyDelete,
				strings.Warning,
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Warning);

			if (dr == DialogResult.OK) {
				try {
					Directory.Delete(gamePath, true);
					Directory.Delete(contentPath, true);
				} catch (Exception ex) {
					MetroMessageBox.Show(mainForm,
						strings.PleaseClose,
						strings.CouldNotFullyDelete,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}

				string removed = name;
				mainForm.addons.Remove(name);

				// reset currAddon
				foreach (KeyValuePair<string, Addon> a in mainForm.addons) {
					// pick the first one and break
					mainForm.changeCurrAddon(a.Value);
					break;
				}

				mainForm.text_notification(strings.TheAddon + " '" + removed + "' " + strings.WasSuccessfullyDeleted, MetroColorStyle.Green, 2500);
			}
		}

		internal void deserializeSettings(KeyValue kv) {
			foreach (KeyValue kv2 in kv.Children) {
				if (kv2.Key == "workshopID") {
					//Debug.WriteLine("#Children: " + kv2.Children.Count());
					if (kv2.HasChildren) {
						if (!Int32.TryParse(kv2.Children.ElementAt(0).Key, out this.workshopID)) {
							Debug.WriteLine("Couldn't parse workshopID for " + this.name);
						}
					}
				} else if (kv2.Key == "generateNote0") {
					if (kv2.HasChildren) {
						string value = kv2.Children.ElementAt(0).Key;
						if (value == "True") {
							this.generateNote0 = true;
						} else {
							this.generateNote0 = false;
						}
					}
				} else if (kv2.Key == "generateLore") {
					if (kv2.HasChildren) {
						string value = kv2.Children.ElementAt(0).Key;
						if (value == "True") {
							this.generateLore = true;
						} else {
							this.generateLore = false;
						}
					}
				} else if (kv2.Key == "askToBreakUp") {
					if (kv2.HasChildren) {
						string value = kv2.Children.ElementAt(0).Key;
						if (value == "True") {
							this.askToBreakUp = true;
						} else {
							this.askToBreakUp = false;
						}
					}
				} else if (kv2.Key == "autoDeleteBin") {
					if (kv2.HasChildren) {
						string value = kv2.Children.ElementAt(0).Key;
						if (value == "True") {
							this.autoDeleteBin = true;
						} else {
							this.autoDeleteBin = false;
						}
					}
				} else if (kv2.Key == "barebonesLibUpdates") {
					if (kv2.HasChildren) {
						string value = kv2.Children.ElementAt(0).Key;
						if (value == "True") {
							this.barebonesLibUpdates = true;
						} else {
							this.barebonesLibUpdates = false;
						}
					}
				} else if (kv2.Key == "autoCompileCoffeeScript") {
					if (kv2.HasChildren) {
						string value = kv2.Children.ElementAt(0).Key;
						if (value == "True") {
							this.autoCompileCoffeeScript = true;
						} else {
							this.autoCompileCoffeeScript = false;
						}
					}
				} else if (kv2.Key == "generateUTF8") {
					if (kv2.HasChildren) {
						string value = kv2.Children.ElementAt(0).Key;
						if (value == "True") {
							this.generateUTF8 = true;
						} else {
							this.generateUTF8 = false;
						}
					}
				} else if (kv2.Key == "libraries") {
					if (kv2.HasChildren) {
						foreach (KeyValue kv3 in kv2.Children) {
							string localPath = kv3.Key;
							Library lib = new Library(localPath, this);
							if (kv3.HasChildren) {
								foreach (KeyValue kv4 in kv3.Children) {
									if (kv4.Key == "Remote") {
										lib.remote = kv4.GetString();
									} else if (kv4.Key == "DefaultLibPath") {
										lib.defaultLibPath = kv4.GetString();
									} else if (kv4.Key == "NeverCheckForUpdates" && kv4.GetBool()) {
										lib.neverCheckForUpdates = true;
									}
								}
							}
							libraries.Add(lib.local, lib);

							if (lib.remote == null && lib.defaultLibPath == null) {
								// this was checked to be a default addon, but the user said it wasn't a default addon.
								// we still need to store it so we don't ask user "is this a default addon?" later again
								NotDefaultLibs.Add(lib.local);
							}
						}
					}
				}
			}
		}

		internal void serializeSettings(KeyValue addonKV) {
			KeyValue workshopIDKV = new KeyValue("workshopID");
			workshopIDKV.AddChild(new KeyValue(this.workshopID.ToString()));
			addonKV.AddChild(workshopIDKV);

			KeyValue generateNote0KV = new KeyValue("generateNote0");
			generateNote0KV.AddChild(new KeyValue(this.generateNote0.ToString()));
			addonKV.AddChild(generateNote0KV);

			KeyValue generateLoreKV = new KeyValue("generateLore");
			generateLoreKV.AddChild(new KeyValue(this.generateLore.ToString()));
			addonKV.AddChild(generateLoreKV);

			KeyValue askToBreakUp = new KeyValue("askToBreakUp");
			askToBreakUp.AddChild(new KeyValue(this.askToBreakUp.ToString()));
			addonKV.AddChild(askToBreakUp);

			KeyValue autoDeleteBin = new KeyValue("autoDeleteBin");
			autoDeleteBin.AddChild(new KeyValue(this.autoDeleteBin.ToString()));
			addonKV.AddChild(autoDeleteBin);

			KeyValue barebonesLibUpdates = new KeyValue("barebonesLibUpdates");
			barebonesLibUpdates.AddChild(new KeyValue(this.barebonesLibUpdates.ToString()));
			addonKV.AddChild(barebonesLibUpdates);

			KeyValue generateUTF8 = new KeyValue("generateUTF8");
			generateUTF8.AddChild(new KeyValue(this.generateUTF8.ToString()));
			addonKV.AddChild(generateUTF8);

			KeyValue autoCompileCoffeeScript = new KeyValue("autoCompileCoffeeScript");
			autoCompileCoffeeScript.AddChild(new KeyValue(this.autoCompileCoffeeScript.ToString()));
			addonKV.AddChild(autoCompileCoffeeScript);

			KeyValue libraries = new KeyValue("libraries");
			addonKV.AddChild(libraries);
			foreach (KeyValuePair<string, Library> libraryKV in this.libraries) {
				Library lib = libraryKV.Value;
				KeyValue libKV = new KeyValue(lib.local);
				libraries.AddChild(libKV);
				// populate libKV
				if (lib.remote != null) {
					KeyValue remoteKV = new KeyValue("Remote");
					remoteKV.Set(lib.remote);
					libKV.AddChild(remoteKV);
				}
				if (lib.defaultLibPath != null) {
					KeyValue kv = new KeyValue("DefaultLibPath");
					kv.Set(lib.defaultLibPath);
					libKV.AddChild(kv);
				}
				var kv2 = new KeyValue("NeverCheckForUpdates");
				kv2.Set(lib.neverCheckForUpdates);
				libKV.AddChild(kv2);
			}
		}

		private void generateAbilityTooltips(bool item) {
			string path = Path.Combine(gamePath, "scripts", "npc", "npc_abilities_custom.txt");

			if (item) {
				path = Path.Combine(gamePath, "scripts", "npc", "npc_items_custom.txt");
			}

			if (!File.Exists(path)) {
				return;
			}

			KeyValue kvs = kvs = KVParser.KV1.ParseAll(File.ReadAllText(path))[0];

			foreach (KeyValue kv in kvs.Children) {
				if (kv.Key == "Version") {
					continue;
				}

				string abilName = kv.Key;
				List<string> abilitySpecialNames = new List<string>();

				foreach (KeyValue kv2 in kv.Children) {
					if (kv2.Key == "AbilitySpecial") {
						foreach (KeyValue kv3 in kv2.Children) {
							foreach (KeyValue kv4 in kv3.Children) {
								if (kv4.Key != "var_type") {
									string abilitySpecialName = kv4.Key;
									abilitySpecialNames.Add(abilitySpecialName);
								}
							}

						}
					} else if (kv2.Key == "Modifiers") {
						foreach (KeyValue kv3 in kv2.Children) {
							string modifierName = kv3.Key;
							bool hiddenModifier = false;
							foreach (KeyValue kv4 in kv3.Children) {
								if (kv4.Key == "IsHidden" && kv4.GetString() == "1") {
									hiddenModifier = true;
								}
							}
							if (!hiddenModifier) {
								if (!item) {
									abilityModifierNames.Add(modifierName);
								} else {
									itemModifierNames.Add(modifierName);
								}
							}

						}
					}
				}
				if (!item) {
					abilityEntries.Add(new AbilityEntry(this, abilName, abilitySpecialNames));
				} else {
					itemEntries.Add(new AbilityEntry(this, abilName, abilitySpecialNames));
				}
			}
		}

		internal void onChangedTo(MainForm mainForm) {
			this.mainForm = mainForm;

			// delete .bin files if the option is checked.
			if (autoDeleteBin) {
				deleteBinFiles();
			}

			Util.CreateTimer(200, (timer) => {
				timer.Stop();
				mainForm.kvFeatures.setupNPCWatchers(this);
				mainForm.kvFeatures.setupCoffeeWatcher(this);
			});

		    if (!name.Equals("legion_td"))
		    {
		        mainForm.unitToAbility.Visible = false;
		        mainForm.unitBrowserBtn.Visible = false;
		    }

			displayAddonSize();

			if (barebonesLibUpdates) {
				// we need to allot time to pull or clone barebones, before checking for lib updates.
				// lib update code is called in Updater.cs in this case.
				if (!mainForm.firstAddonChange) {
					mainForm.firstAddonChange = true;
					return;
				}

				Util.CreateTimer(200, (timer) => {
					timer.Stop();
					checkForDefaultLibs();

					foreach (KeyValuePair<string, Library> libKV in libraries) {
						Library lib = libKV.Value;
						lib.checkForUpdates();
					}
				});
			}
		}

		private void displayAddonSize() {
			var addonSizeWorker = new BackgroundWorker();
			addonSizeWorker.DoWork += (s, e) => {
				double gameSize = (Util.GetDirectorySize(gamePath) / 1024.0) / 1024.0;
				gameSize = Math.Round(gameSize, 1);
				gameSizeStr = gameSize.ToString();

				double contentSize = (Util.GetDirectorySize(contentPath) / 1024.0) / 1024.0;
				contentSize = Math.Round(contentSize, 1);
				contentSizeStr = contentSize.ToString();
			};

			addonSizeWorker.RunWorkerCompleted += (s, e) => {
				var tooltip = mainForm.mainFormToolTip;
				tooltip.SetToolTip(mainForm.gameTile, "(" + gameSizeStr + " MB)." + " Opens the game directory of this addon.");
				tooltip.SetToolTip(mainForm.contentTile, "(" + contentSizeStr + " MB)." + " Opens the content directory of this addon.");
			};
			addonSizeWorker.RunWorkerAsync();
		}

		#endregion

	}
}