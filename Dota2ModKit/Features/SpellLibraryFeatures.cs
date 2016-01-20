using FastColoredTextBoxNS;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit.Features {
    public class SpellLibraryFeatures {
        public class SpellLibraryNode {
            TreeNode node;
            public bool isAbility = true;
            public string hero, path;
            public SpellLibraryNode(TreeNode node) {
                this.node = node;
            }
        }

        MainForm mf;
        string currLuaPath = "";
        string spellLibPath = "SpellLibrary";
        public SpellLibraryFeatures(MainForm mf) {
            this.mf = mf;
            cloneOrPull();
            
            // setup hooks:
            this.mf.abilitiesTreeView.AfterSelect += (s, e) => {
                changeToKV();
            };
            this.mf.fastColoredTextBox.KeyDown += (s, e) => {
                if (e.Control && (e.KeyCode == Keys.A)) {
                    this.mf.fastColoredTextBox.SelectAll();
                }
            };
            this.mf.abilitiesRadioButton.CheckedChanged += (s, e) => {
                this.mf.fixButton();
                initTree("abilities");
            };
            this.mf.itemsRadioButton.CheckedChanged += (s, e) => {
                this.mf.fixButton();
                initTree("items");
            };
            this.mf.luaKVBtn.Click += (s, e) => {
                this.mf.fixButton();
                if (this.mf.luaKVBtn.Text.Contains("Lua")) {
                    changeToLua();
                } else {
                    changeToKV();
                }
            };
            this.mf.spellOpenFileBtn.Click += (s, e) => {
                this.mf.fixButton();
                var node = this.mf.abilitiesTreeView.SelectedNode;
                if (this.mf.luaKVBtn.Text.Contains("KV") && File.Exists(currLuaPath)) {
                    Process.Start(currLuaPath);
                    return;
                }
                if (node != null && this.mf.luaKVBtn.Text.Contains("Lua") && File.Exists(node.Name)) {
                    Process.Start(node.Name);
                }
            };
            this.mf.spellCopyBtn.Click += (s, e) => {
                this.mf.fixButton();
                Clipboard.SetText(this.mf.fastColoredTextBox.Text);
            };
            this.mf.spellOpenFolderBtn.Click += (s, e) => {
                this.mf.fixButton();
                var node = this.mf.abilitiesTreeView.SelectedNode;
                if (this.mf.luaKVBtn.Text.Contains("KV") && File.Exists(currLuaPath)) {
                    Process.Start(Path.GetDirectoryName(currLuaPath));
                    return;
                }
                if (node != null && this.mf.luaKVBtn.Text.Contains("Lua") && File.Exists(node.Name)) {
                    Process.Start(Path.GetDirectoryName(node.Name));
                }
            };
        }

        void cloneOrPull() {
            var gitWorker = new BackgroundWorker();
            mf.progressSpinner.Visible = true;
            gitWorker.DoWork += (s, e) => {
                if (!Directory.Exists(spellLibPath)) {
                    Repository.Clone("https://github.com/Pizzalol/SpellLibrary", spellLibPath);
                } else {
                    // pull from the repo
                    using (var repo = new Repository(spellLibPath)) {
                        try {
                            MergeResult mr = repo.Network.Pull(new Signature("myname", "myname@email.com",
                                new DateTimeOffset()),
                                new PullOptions());
                            MergeStatus ms = mr.Status;
                        } catch (Exception) { }
                    }
                }
            };
            gitWorker.RunWorkerCompleted += (s, e) => {
                initTree("abilities");
                mf.progressSpinner.Visible = false;
            };
            gitWorker.RunWorkerAsync();


        }

        public void initTree(string kind) {
            var abilitiesTree = mf.abilitiesTreeView;
            abilitiesTree.Nodes.Clear();
            var abilitiesDir = Path.Combine(spellLibPath, "game", "scripts", "npc", "abilities");
            if (kind == "items") {
                abilitiesDir = Path.Combine(spellLibPath, "game", "scripts", "npc", "items");
            }

            // for abilities, it can be in a hero folder like scripts/npc/abilities/abaddon/aphotic_shield_datadriven.txt
            // or it can be just a file like scripts/npc/abilities/big_thunder_lizard_frenzy_datadriven.txt
            // case 1:
            foreach (var heroDir in Directory.GetDirectories(abilitiesDir)) {
                TreeNode heroNode = new TreeNode(Path.GetFileName(heroDir));
                heroNode.Text = Util.MakeUnderscoreStringNice(heroNode.Text);
                abilitiesTree.Nodes.Add(heroNode);
                heroNode.Name = heroDir;
                bool heroWorkedOn = false;
                foreach (var abil in Directory.GetFiles(heroDir)) {
                    if (!wasWorkedOn(abil)) {
                        continue;
                    }
                    heroWorkedOn = true;
                    TreeNode abilNode = new TreeNode(abil);
                    heroNode.Nodes.Add(abilNode);
                    abilNode.Name = abil;
                    abilNode.Text = Path.GetFileName(abil);
                    abilNode.Text = abilNode.Text.Replace("_datadriven.txt", "");
                    abilNode.Text = Util.MakeUnderscoreStringNice(abilNode.Text);
                }
                heroNode.ExpandAll();
                if (!heroWorkedOn) {
                    // don't spam the treeview with boilerplate non-finished abils.
                    abilitiesTree.Nodes.Remove(heroNode);
                }
            }
            // case2: when spelllibrary converts to case1 style, case2 won't be necessary.
            var files = Directory.GetFiles(abilitiesDir, "*.txt", SearchOption.TopDirectoryOnly);
            foreach (var file in files) {
                if (!wasWorkedOn(file)) {
                    continue;
                }
                var name = Path.GetFileNameWithoutExtension(file);
                name = name.Replace("_datadriven", "");
                name = name.Replace("item_", "");
                name = Util.MakeUnderscoreStringNice(name);
                TreeNode node = new TreeNode(name);
                abilitiesTree.Nodes.Add(node);
                node.Name = file;
            }
            if (kind == "abilities") {
                mf.abilitiesTreeView.SelectedNode = mf.abilitiesTreeView.Nodes[0].FirstNode;
            } else {
                mf.abilitiesTreeView.SelectedNode = mf.abilitiesTreeView.Nodes[0];
            }
            changeToKV();
        }

        // is this just a boilerplate abil/item or was it actually worked on by spelllib devs?
        private bool wasWorkedOn(string abil) {
            string txt = File.ReadAllText(abil);
            return (txt.StartsWith("//") || Util.ContainsKVKey(txt));
        }

        internal void changeToLua() {
            mf.fastColoredTextBox.Language = Language.Lua;
            mf.luaKVBtn.Text = "KV";
            mf.mainFormToolTip.SetToolTip(mf.luaKVBtn, "Open the KeyValues entry");

            if (currLuaPath != "" && File.Exists(currLuaPath)) {
                mf.fastColoredTextBox.Text = File.ReadAllText(currLuaPath);
            }
        }

        internal void changeToKV() {
            mf.fastColoredTextBox.Language = Language.JS;
            mf.luaKVBtn.Text = "Lua";
            mf.mainFormToolTip.SetToolTip(mf.luaKVBtn, "Open the Lua script");

            var node = mf.abilitiesTreeView.SelectedNode;
            if (node != null && File.Exists(node.Name)) {
                mf.fastColoredTextBox.Text = File.ReadAllText(node.Name);
                checkIfHasLuaScript(node);
                if (currLuaPath == "") {
                    mf.luaKVBtn.Enabled = false;
                } else {
                    mf.luaKVBtn.Enabled = true;
                }
            }
        }

        private void checkIfHasLuaScript(TreeNode node) {
            currLuaPath = "";
            var files = Directory.GetFiles(Path.Combine(spellLibPath, "game", "scripts", "vscripts", "heroes"), "*.lua", SearchOption.AllDirectories);
            if (mf.itemsRadioButton.Checked) {
                files = Directory.GetFiles(Path.Combine(spellLibPath, "game", "scripts", "vscripts", "items"), "*.lua", SearchOption.AllDirectories);
            }
            foreach (var file in files) {
                var name1 = Path.GetFileNameWithoutExtension(node.Name);
                var name2 = Path.GetFileNameWithoutExtension(file);
                name2 = name2.Replace("item_", "");
                if (name1.Contains(name2)) {
                    currLuaPath = file;
                }
            }
        }
    }
}
