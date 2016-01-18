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
        internal HashSet<string> abilityModifierNames = new HashSet<string>();
        internal HashSet<string> itemModifierNames = new HashSet<string>();
        internal List<AbilityEntry> abilityEntries = new List<AbilityEntry>();
        internal List<AbilityEntry> itemEntries = new List<AbilityEntry>();
        internal List<UnitEntry> unitEntries = new List<UnitEntry>();
        internal List<HeroEntry> heroEntries = new List<HeroEntry>();
        internal HashSet<string> alreadyHasKeys = new HashSet<string>();

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

        internal void generateTooltips(MainForm mainForm) {
            mainForm.kvFeatures.generateTooltips(this);
        }

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
                   // mainForm.MetroToolTip1.SetToolTip(mainForm.GameTile, "(" + gameSizeStr + " MB)." + " Opens the game directory of this addon.");
                   // mainForm.MetroToolTip1.SetToolTip(mainForm.ContentTile, "(" + contentSizeStr + " MB)." + " Opens the content directory of this addon.");
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