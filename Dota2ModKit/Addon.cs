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
		public string gamePath, contentPath, name, relativeGamePath;
		internal int workshopID;
		internal Image image;
		internal MetroColorStyle tileColor = MetroColorStyle.Green;

		// tooltip generation stuff
		HashSet<string> abilityModifierNames = new HashSet<string>();
		HashSet<string> itemModifierNames = new HashSet<string>();
		List<AbilityEntry> abilityEntries = new List<AbilityEntry>();
		List<AbilityEntry> itemEntries = new List<AbilityEntry>();
		List<UnitEntry> unitEntries = new List<UnitEntry>();
		List<HeroEntry> heroEntries = new List<HeroEntry>();
		HashSet<string> alreadyHasKeys = new HashSet<string>();

		internal bool generateNote0,
            doesntHaveThumbnail,
            generateLore, 
            askToBreakUp, 
            autoDeleteBin, 
            barebonesLibUpdates,
            autoCompileCoffeeScript,
            generateUTF8 = true,
            hasContentPath = true;
		private string gameSizeStr = "", contentSizeStr = "";
		private MainForm mainForm;

        public MetroTile panelTile { get; internal set; }

        public Addon(string gamePath) {
			this.gamePath = gamePath;

			// extract other info from the gamePath
			name = gamePath.Substring(gamePath.LastIndexOf('\\')+1);
			Debug.WriteLine("New Addon detected: " + name);
			relativeGamePath = gamePath.Substring(gamePath.IndexOf(Path.Combine("game", "dota_addons")));

			contentPath = Path.Combine(Settings.Default.DotaDir, "content", "dota_addons", name);

			if (!Directory.Exists(contentPath)) {
				try {
					Directory.CreateDirectory(contentPath);
				} catch (Exception) {
					Debug.WriteLine("Couldn't auto-create content path for " + name);
					hasContentPath = false;
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
				mainForm.text_notification("Tooltips successfully generated", MetroColorStyle.Green, 2500);
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

        internal Image getThumbnail(MainForm mf) {
            if (image != null) {
                return image;
            }
            string thumbnailDir = Path.Combine(mf.dotaDir, "game", "bin", "win64");

            if (Directory.Exists(thumbnailDir) && workshopID != 0) {
                string imagePath = Path.Combine(thumbnailDir, workshopID + "_thumb.jpg");

                if (File.Exists(imagePath)) {
                    Debug.WriteLine(imagePath + " found!");
                    Image thumbnail = Image.FromFile(imagePath, true);
                    //Size size = new Size(mf.addonTile.Width, mf.addonTile.Height);
                    //thumbnail = (Image)new Bitmap(thumbnail, size);

                    image = thumbnail;
                    return thumbnail;
                }
            }
            return null;
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

        #region serializer/deserializer
        internal void deserializeSettings(KeyValue kv) {
			foreach (KeyValue kv2 in kv.Children) {
				if (kv2.Key == "workshopID") {
					Debug.WriteLine("#Children: " + kv2.Children.Count());
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
		}
        #endregion

        #region generate tooltip functions
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
        #endregion

        internal void onChangedTo(MainForm mainForm) {
			this.mainForm = mainForm;

			// delete .bin files if the option is checked.
			if (autoDeleteBin) {
				deleteBinFiles();
			}

			using (var addonSizeWorker = new BackgroundWorker()) {
				addonSizeWorker.DoWork += (s,e) => {
                    double gameSize = (Util.GetDirectorySize(gamePath) / 1024.0) / 1024.0;
                    gameSize = Math.Round(gameSize, 1);
                    gameSizeStr = gameSize.ToString();

                    double contentSize = (Util.GetDirectorySize(contentPath) / 1024.0) / 1024.0;
                    contentSize = Math.Round(contentSize, 1);
                    contentSizeStr = contentSize.ToString();
                };
				addonSizeWorker.RunWorkerCompleted += (s,e) => {
                    mainForm.MetroToolTip1.SetToolTip(mainForm.GameTile, "(" + gameSizeStr + " MB)." + " Opens the game directory of this addon.");
                    mainForm.MetroToolTip1.SetToolTip(mainForm.ContentTile, "(" + contentSizeStr + " MB)." + " Opens the content directory of this addon.");
                };
				addonSizeWorker.RunWorkerAsync();
			}
            mainForm.atAGlanceLabel.Text = name + " at a glance...";
            createTree();
		}

        public void createTree() {
            string bannedExtensionsStr = "";
            if (mainForm.hideCompiledFilesCheckBox1.Checked) {
                bannedExtensionsStr += ".vpcf_c;.vjs_c;.vcss_c;.vxml_c;.vtex_c;.vmat_c;.vsndevts_c;";
            }
            if (mainForm.imagesCheckBox1.Checked) {
                bannedExtensionsStr += ".png;.jpg;.jpeg;.bmp;.gif;.psd;.tga;";
            }

            var bannedExtensions = bannedExtensionsStr.Split(';').ToDictionary(v => v, v => true);

            var scriptsTree = mainForm.scriptsTree;
            var panoramaTree = mainForm.panoramaTree;
            var scriptsNode = scriptsTree.Nodes[0];
            var panoramaNode = panoramaTree.Nodes[0];
            scriptsNode.Nodes.Clear();
            panoramaNode.Nodes.Clear();
            scriptsNode.Name = Path.Combine(gamePath, "scripts");
            panoramaNode.Name = Path.Combine(contentPath, "panorama");
            if (!Directory.Exists(scriptsNode.Name) || !Directory.Exists(panoramaNode.Name)) { return; }

            var stack = new Stack<TreeNode>();
            stack.Push(scriptsNode);
            while (stack.Count > 0) {
                var node = stack.Pop();
                foreach (var dir in Directory.GetDirectories(node.Name)) {
                    var text = dir.Substring(dir.LastIndexOf('\\')+1);
                    TreeNode node2 = new TreeNode(text);
                    node2.Name = dir;
                    node.Nodes.Add(node2);
                    stack.Push(node2);
                }
                foreach (var file in Directory.GetFiles(node.Name)) {
                    var text = file.Substring(file.LastIndexOf('\\') + 1);
                    if (bannedExtensions.ContainsKey(Path.GetExtension(file))) {
                        continue;
                    }
                    TreeNode node2 = new TreeNode(text);
                    node2.Name = file;
                    node.Nodes.Add(node2);
                }
            }
            stack.Clear();
            stack.Push(panoramaNode);
            while (stack.Count > 0) {
                var node = stack.Pop();
                foreach (var dir in Directory.GetDirectories(node.Name)) {
                    var text = dir.Substring(dir.LastIndexOf('\\') + 1);
                    TreeNode node2 = new TreeNode(text);
                    node2.Name = dir;
                    node.Nodes.Add(node2);
                    stack.Push(node2);
                }
                foreach (var file in Directory.GetFiles(node.Name)) {
                    var text = file.Substring(file.LastIndexOf('\\') + 1);
                    if (bannedExtensions.ContainsKey(Path.GetExtension(file))) {
                        continue;
                    }
                    TreeNode node2 = new TreeNode(text);
                    node2.Name = file;
                    node.Nodes.Add(node2);
                }
            }
            scriptsNode.ExpandAll();
            panoramaNode.ExpandAll();
        }
    }
}