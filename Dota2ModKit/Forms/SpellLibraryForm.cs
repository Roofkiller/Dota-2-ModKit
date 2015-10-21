using FastColoredTextBoxNS;
using LibGit2Sharp;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Dota2ModKit.Forms {
	public partial class SpellLibraryForm : MetroForm {
		private MainForm mainForm;
		string spellLibPath = Path.Combine(Environment.CurrentDirectory, "SpellLibrary");
		string npcPath = "";
		private string currKVPath = "";
		private string luaHeroesPath;
		private string luaItemsPath;
		private string currLuaPath = "";

		public SpellLibraryForm(MainForm mainForm) {
			this.mainForm = mainForm;
			npcPath = Path.Combine(spellLibPath, "game", "scripts", "npc");
			luaHeroesPath = Path.Combine(spellLibPath, "game", "scripts", "vscripts", "heroes");
			luaItemsPath = Path.Combine(spellLibPath, "game", "scripts", "vscripts", "items");

			InitializeComponent();
			notificationLabel.Text = "";

			textBox1.KeyDown += (s, e) => {
				if (e.Control && (e.KeyCode == Keys.A)) {
					textBox1.SelectAll();
				}
			};

			if (!Directory.Exists(spellLibPath)) {
				DialogResult dr = MetroMessageBox.Show(mainForm, strings.SpellLibWillNowBeClonedMsg + " " + spellLibPath,
					strings.SpellLibNotFoundCaption,
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Information);

				if (dr != DialogResult.OK) {
					return;
				}
			}
			// user wants to continue, clone if necessary, and pull
			mainForm.spellLibraryBtn.Enabled = false;
			mainForm.progressSpinner1.Value = 60;
			mainForm.progressSpinner1.Visible = true;

			if (!Directory.Exists(spellLibPath)) {
				mainForm.text_notification("Cloning SpellLibrary...", MetroColorStyle.Blue, 999999);
			} else {
				mainForm.text_notification("Pulling SpellLibrary...", MetroColorStyle.Blue, 999999);
			}

			var gitWorker = new BackgroundWorker();
			gitWorker.RunWorkerCompleted += (s, e) => {
				mainForm.text_notification("", MetroColorStyle.Blue, 500);
				mainForm.progressSpinner1.Visible = false;
				mainForm.spellLibraryBtn.Enabled = true;

				initTreeView();
			};
			gitWorker.DoWork += (s, e) => {
				if (!Directory.Exists(spellLibPath)) {
					try {
						string gitPath = Repository.Clone("https://github.com/Pizzalol/SpellLibrary", spellLibPath);
						Console.WriteLine("repo path:" + gitPath);
					} catch (Exception ex) {

					}
					return;
				}

				// pull from the repo
				using (var repo = new Repository(spellLibPath)) {
					try {
						//var remote = repo.Network.Remotes["origin"];
						MergeResult mr = repo.Network.Pull(new Signature(new Identity("myname", "myname@email.com"),
							new DateTimeOffset()),
							new PullOptions());
						MergeStatus ms = mr.Status;
					} catch (Exception ex) {}
				}
			};
			gitWorker.RunWorkerAsync();
		}

		private void initTreeView() {
			populateTreeView();
			treeView1.Nodes[0].ExpandAll();
			treeView1.Nodes[1].ExpandAll();
			treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0].Nodes[0];

			treeView1.AfterSelect += (s, e) => {
				TreeNode node = e.Node;

				if (node.Parent != null && node.Parent.Parent != null && node.Parent.Parent.Text == "Abilities") {
					string abilName = node.Name;
					string heroName = node.Parent.Name;
					string p = Path.Combine(npcPath, "abilities", abilName);
					if (File.Exists(p)) {
						changeToKV();
						textBox1.Text = File.ReadAllText(p);
						currKVPath = p;

						string lua = Path.Combine(luaHeroesPath, "hero_" + heroName, abilName.Replace(heroName + "_", "").Replace("_datadriven.txt", ".lua"));
						if (!File.Exists(lua)) {
							luaKVBtn.Enabled = false;

						} else {
							luaKVBtn.Enabled = true;
							luaKVBtn.Text = "Lua Script";
							currLuaPath = lua;
						}
					} else {
						//Console.WriteLine(abilName + " path wasn't found!");
					}

				} else if (node.Parent != null && node.Parent.Text == "Items") {
					string itemName = node.Name;
					string p = Path.Combine(npcPath, "items", itemName);
					if (File.Exists(p)) {
						changeToKV();
						textBox1.Text = File.ReadAllText(p);
						currKVPath = p;

						string lua = Path.Combine(luaItemsPath, itemName.Replace("_datadriven.txt", ".lua"));
						if (!File.Exists(lua)) {
							luaKVBtn.Enabled = false;

						} else {
							luaKVBtn.Enabled = true;
							luaKVBtn.Text = "Lua Script";
							currLuaPath = lua;
						}
					} else {
						//Console.WriteLine(itemName + " path wasn't found!");
					}
				}
			};


			treeView1.KeyDown += (s, e) => {
				if (e.KeyCode == Keys.Enter && treeView1.SelectedNode != null) {
					treeView1.SelectedNode.Expand();
				}
			};

			//treeView1.ExpandAll();
			this.Show();
		}

		private void populateTreeView() {
			TreeNode abilities = treeView1.Nodes.Add("Abilities");
			TreeNode items = treeView1.Nodes.Add("Items");

			string[] abilPaths = Directory.GetFiles(Path.Combine(npcPath, "abilities"), "*.txt");
			string[] itemPaths = Directory.GetFiles(Path.Combine(npcPath, "items"), "*.txt");
            Dictionary<string, TreeNode> heroNames = new Dictionary<string, TreeNode>();
			string currHeroName = "";
			List<string> abilArr = new List<string>();
			//StringBuilder allAbils = new StringBuilder();

			foreach (string abilPath in abilPaths) {
				string abilName = abilPath.Substring(abilPath.LastIndexOf('\\') + 1);

				abilName = abilName.Replace(".txt", "").Replace("_datadriven", "");
				string heroName = abilName.Substring(0, abilName.IndexOf('_'));

				if (heroName =="phantom" || heroName == "shadow" || heroName == "dark") {
					// hardcode these
					string[] split = abilName.Split('_');
					heroName = split[0] + "_" + split[1];

				}

				if (currHeroName == "") {
					currHeroName = heroName;
				}

				if (heroName.StartsWith(currHeroName)) {
					abilArr.Add(abilPath.Substring(abilPath.LastIndexOf('\\') + 1));
				} else {
					currHeroName = heroName;

					string commonHeroName = Util.FindCommonBeginning(abilArr.ToArray());
					if (commonHeroName.EndsWith("_")) {
						commonHeroName = commonHeroName.Substring(0, commonHeroName.Length - 1);
					}
					commonHeroName = commonHeroName.Replace(".txt", "").Replace("_datadriven", "");

					TreeNode heroNode = null;
					for (int i = 0; i < abilArr.Count; i++) {
						string abilName2 = abilArr[i];
						string abilName3 = abilName2.Replace("_datadriven", "").Replace(".txt", "");
						string path2 = Path.Combine(npcPath, "abilities", abilName2);
						string txt = File.ReadAllText(path2);

                        if (!txt.StartsWith("//") && !Util.ContainsKVKey(txt)) {
							continue;
						}
                        
						string com = commonHeroName + "_";
						if (abilName3.StartsWith(com)) {
							abilName3 = abilName3.Substring(com.Length, abilName3.Length - com.Length);
						}

						if (!heroNames.ContainsKey(commonHeroName)) {
							//Console.WriteLine("\"" + commonHeroName + "\"");
							//Console.WriteLine("\"" + Util.MakeUnderscoreStringNice(commonHeroName) + "\"");
							heroNode = abilities.Nodes.Add(Util.MakeUnderscoreStringNice(commonHeroName));
							heroNode.Name = commonHeroName;
                            heroNames.Add(commonHeroName, heroNode);
							//heroNode.Expand();
						}

						// add the abil to the hero node
						TreeNode abilNode = heroNames[commonHeroName].Nodes.Add(Util.MakeUnderscoreStringNice(abilName3));
						abilNode.Name = abilName2;
					}

					abilArr.Clear();
					abilArr.Add(abilPath.Substring(abilPath.LastIndexOf('\\') + 1));
				}
			}

			// done with abils. now onto items.
			foreach (string itemPath in itemPaths) {
				string itemName = itemPath.Substring(itemPath.LastIndexOf('\\') + 1);
				string niceName = Util.MakeUnderscoreStringNice(itemName.Replace(".txt", "").Replace("_datadriven", "").Replace("item_", ""));

				string txt = File.ReadAllText(itemPath);
				// ensure this item was actually completed by devs of spell library.
				if (txt.StartsWith("//") || Util.ContainsKVKey(txt)) {
					TreeNode itemNode = items.Nodes.Add(niceName);
					itemNode.Name = itemName;
					//itemNode.Expand();
				}
			}
		}

		private void copySpellBtn_Click(object sender, EventArgs e) {
			metroRadioButton1.Select();

			Clipboard.SetText(textBox1.Text);
			text_notification(strings.Copied, MetroColorStyle.Blue, 1000);
		}

		private void luaKVBtn_Click(object sender, EventArgs e) {
			metroRadioButton1.Select();

			if (luaKVBtn.Text == strings.LuaScript) {
				// open lua
				changeToLua();
				textBox1.Text = File.ReadAllText(currLuaPath);
			} else {
				// open kv
				changeToKV();
				textBox1.Text = File.ReadAllText(currKVPath);
			}

		}

		void changeToKV() {
			textBox1.Language = Language.JS;
			luaKVBtn.Text = strings.LuaScript;
			metroToolTip1.SetToolTip(luaKVBtn, strings.OpensTheLuaScript);
		}

		void changeToLua() {
			textBox1.Language = Language.Lua;
			luaKVBtn.Text = strings.KeyValues;
			metroToolTip1.SetToolTip(luaKVBtn, strings.OpensTheKVEntry);
		}

		private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e) {
			Console.WriteLine(e.NewValue);
			Console.WriteLine(textBox1.AutoScrollOffset.X + ", " + textBox1.AutoScrollOffset.Y);
		}

		public void text_notification(string text, MetroColorStyle color, int duration) {
			System.Timers.Timer notificationLabelTimer = new System.Timers.Timer(duration);
			notificationLabelTimer.SynchronizingObject = this;
			notificationLabelTimer.AutoReset = false;
			notificationLabelTimer.Start();
			notificationLabelTimer.Elapsed += notificationLabelTimer_Elapsed;
			notificationLabel.Style = color;
			notificationLabel.Text = text;
		}

		private void notificationLabelTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
			notificationLabel.Text = "";
		}

		private void openFileBtn_Click(object sender, EventArgs e) {
			metroRadioButton1.Select();

			if (luaKVBtn.Text == strings.LuaScript) {
				Process.Start(currKVPath);
			} else {
				// open kv
				Process.Start(currLuaPath);
			}
		}
	}
}
