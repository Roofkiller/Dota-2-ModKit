using KVLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit.Forms {
    public class LinkFeatures {
        public class LinkTreeNode {
            KeyValue kv;
            TreeNode node;
            string link, description, author, difficulty, title;
            public LinkTreeNode(KeyValue kv) {
                this.kv = kv;
                foreach (var kv2 in kv.Children) {

                }
            }
        }

        MainForm mf;
        public LinkFeatures(MainForm mf) {
            this.mf = mf;
            parseKV();
        }

        private void parseKV() {
            var txt = File.ReadAllText("dotamoddinglinks.kv");
            var root = KVParser.KV1.Parse(txt);
            Stack<KeyValue> stack = new Stack<KeyValue>();
            stack.Push(root);
            while (stack.Count > 0) {
                var kv = stack.Pop();
                TreeNode node = new TreeNode(kv.Key);
                foreach (var child in kv.Children) {
                    stack.Push(child);
                    node.Nodes.Add(new TreeNode(child.Key));
                }
            }
        }
    }
}
