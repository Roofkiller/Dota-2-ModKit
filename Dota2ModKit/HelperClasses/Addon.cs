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
            autoCompileCoffeeScript,
            generateUTF8 = true,
            hasContentPath = true;
		private string gameSizeStr = "", contentSizeStr = "";
		private MainForm mf;

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

        internal void generateTooltips(MainForm mainForm) {
            mainForm.kvFeatures.generateTooltips(this);
        }

        internal void onChangedTo(MainForm mf) {
			this.mf = mf;

			// delete .bin files if the option is checked.
			if (autoDeleteBin) {
				deleteBinFiles();
			}

            // get the addon-specific settings
            mf.serializer.initOptionControlsForAddon(this);

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
            mf.optionsForLabel.Text = name + ":";
            mf.optionsForLabel.Style = mf.addonTile.Style;
            createTree();
		}

        public void createTree() {
            string bannedExtensionsStr = "";
            if (mf.hideCompiledFilesCheckBox1.Checked) {
                bannedExtensionsStr += ".vpcf_c;.vjs_c;.vcss_c;.vxml_c;.vtex_c;.vmat_c;.vsndevts_c;";
            }
            if (mf.imagesCheckBox1.Checked) {
                bannedExtensionsStr += ".png;.jpg;.jpeg;.bmp;.gif;.psd;.tga;";
            }

            var bannedExtensions = bannedExtensionsStr.Split(';').ToDictionary(v => v, v => true);

            var scriptsTree = mf.scriptsTree;
            var panoramaTree = mf.panoramaTree;
            var scriptsNode = scriptsTree.Nodes[0];
            var panoramaNode = panoramaTree.Nodes[0];
            scriptsNode.Nodes.Clear();
            panoramaNode.Nodes.Clear();
            scriptsNode.Name = Path.Combine(gamePath, "scripts");
            panoramaNode.Name = Path.Combine(contentPath, "panorama");
            if (!Directory.Exists(scriptsNode.Name)) { return; }

            var stack = new Stack<TreeNode>();
            stack.Push(scriptsNode);
            while (stack.Count > 0) {
                var node = stack.Pop();
                node.ToolTipText = "Double-click a node to open the file or directory";
                foreach (var dir in Directory.GetDirectories(node.Name)) {
                    var text = dir.Substring(dir.LastIndexOf('\\')+1);
                    TreeNode node2 = new TreeNode(text);
                    node2.ForeColor = Color.SandyBrown;
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
                    if (file.EndsWith(".lua")) {
                        node2.ForeColor = Color.Yellow;
                    }
                    node2.Name = file;
                    node.Nodes.Add(node2);
                }
            }
            scriptsNode.ExpandAll();
            scriptsNode.EnsureVisible();
            stack.Clear();

            // do panorama tree
            if (!Directory.Exists(panoramaNode.Name)) { return; }
            stack.Push(panoramaNode);
            while (stack.Count > 0) {
                var node = stack.Pop();
                node.ToolTipText = "Double-click a node to open the file or directory";
                foreach (var dir in Directory.GetDirectories(node.Name)) {
                    var text = dir.Substring(dir.LastIndexOf('\\') + 1);
                    TreeNode node2 = new TreeNode(text);
                    node2.ForeColor = Color.SandyBrown;
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
                    if (file.EndsWith(".js")) {
                        node2.ForeColor = Color.GreenYellow;
                    } else if (file.EndsWith(".css")) {
                        node2.ForeColor = Color.LightPink;
                    } else if (file.EndsWith(".xml")) {
                        node2.ForeColor = Color.SkyBlue;
                    }
                    node2.Name = file;
                    node.Nodes.Add(node2);
                }
            }
            panoramaNode.ExpandAll();
            panoramaNode.EnsureVisible();
        }
    }
}