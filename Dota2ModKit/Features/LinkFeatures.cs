using KVLib;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit.Forms {
    public class LinkFeatures {
        MainForm mf;
        Dictionary<TreeNode, KeyValue> nodeToKV = new Dictionary<TreeNode, KeyValue>();
        static string[] linkDataKeys = { "Link", "Description", "Author", "Difficulty" };
        HashSet<string> linkDataKeysSet = new HashSet<string>(linkDataKeys);

        public LinkFeatures(MainForm mf) {
            this.mf = mf;
            cloneOrPull();

            // setup hooks:
            mf.linksTreeView.AfterSelect += (s, e) => {
                var node = mf.linksTreeView.SelectedNode;
                KeyValue kv = null;
                if (nodeToKV.TryGetValue(node, out kv)) {
                    foreach (var child in kv.Children) {
                        if (child.Key == "Link") {
                            mf.linkHttp.Text = child.GetString();
                        } else if (child.Key == "Description") {

                        }
                    }
                }
            };
            mf.linkHttp.Click += (s, e) => {
                Process.Start("https://" + mf.linkHttp.Text);
            };
        }

        private void cloneOrPull() {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, e) => {
                if (!Directory.Exists("Dota2ModdingLinks")) {
                    Repository.Clone("https://github.com/stephenfournier/Dota2ModdingLinks", "Dota2ModdingLinks");
                } else {
                    // pull
                    using (var repo = new Repository("Dota2ModdingLinks")) {
                        try {
                            MergeResult mr = repo.Network.Pull(new Signature("myname", "myname@email.com",
                                new DateTimeOffset()),
                                new PullOptions());
                            MergeStatus ms = mr.Status;
                        } catch (Exception) { }
                    }
                }
            };
            bw.RunWorkerCompleted += (s, e) => {
                parseKV();
            };
            bw.RunWorkerAsync();
        }

        private void parseKV() {
            var treeView = mf.linksTreeView;
            var txt = File.ReadAllText(Path.Combine("Dota2ModdingLinks", "dotamoddinglinks.kv"));
            var root = KVParser.KV1.Parse(txt);
            Dictionary<KeyValue, TreeNode> kvToNode = new Dictionary<KeyValue, TreeNode>();
            Stack<KeyValue> stack = new Stack<KeyValue>();
            stack.Push(root);
            TreeNode rootNode = null;
            while (stack.Count > 0) {
                var kv = stack.Pop();
                TreeNode node = new TreeNode(kv.Key);
                if (kv == root) {
                    rootNode = node;
                }
                kvToNode.Add(kv, node);
                nodeToKV.Add(node, kv);
                if (kv.Parent != null) {
                    TreeNode parentNode = null;
                    if (kvToNode.TryGetValue(kv.Parent, out parentNode)) {
                        if (!linkDataKeysSet.Contains(kv.Key)) {
                            parentNode.Nodes.Add(node);
                        } else {
                            //var linkTitleKV = 
                            parentNode.ForeColor = Color.Yellow;
                        }
                    }
                }
                foreach (var child in kv.Children) {
                    stack.Push(child);
                }
            }
            foreach (TreeNode node in rootNode.Nodes) {
                treeView.Nodes.Add(node);
                node.ForeColor = Color.SandyBrown;
            }
            
            treeView.ExpandAll();
        }
    }
}
