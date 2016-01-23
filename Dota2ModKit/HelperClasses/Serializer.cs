using Dota2ModKit.Properties;
using KVLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ModKit.HelperClasses {
    public class Serializer {
        private MainForm mf;

        public Serializer(MainForm mf) {
            this.mf = mf;

            // hooks:
            mf.saveBtn.Click += (s, e) => {
                mf.fixButton();

                // d2modkit options
                Settings.Default.OpenChangelog = mf.openChangelogCheckBox.Checked;
                Settings.Default.ChatEnabled = mf.enableChatCheckBox1.Checked;

                var currAddon = mf.currAddon;
                // addon options
                currAddon.generateLore = mf.loreCheckBox.Checked;
                currAddon.generateNote0 = mf.note0CheckBox.Checked;
                currAddon.askToBreakUp = mf.askToBreakUpCheckBox.Checked;
                currAddon.autoDeleteBin = mf.autoDeleteBinCheckBox.Checked;
                currAddon.generateUTF8 = mf.utf8CheckBox.Checked;
                currAddon.autoCompileCoffeeScript = mf.autoCompileCoffeeCheckbox.Checked;

                // save stuff
                serializeSettings();
            };
        }

        public void initOptionControlsForAddon(Addon a) {
            // general:
            mf.openChangelogCheckBox.Checked = Settings.Default.OpenChangelog;
            mf.enableChatCheckBox1.Checked = Settings.Default.ChatEnabled;

            // addon-specific:
            mf.note0CheckBox.Checked = a.generateNote0;
            mf.loreCheckBox.Checked = a.generateLore;
            mf.askToBreakUpCheckBox.Checked = a.askToBreakUp;
            mf.autoDeleteBinCheckBox.Checked = a.autoDeleteBin;
            mf.utf8CheckBox.Checked = a.generateUTF8;
            mf.autoCompileCoffeeCheckbox.Checked = a.autoCompileCoffeeScript;
        }

        public void deserializeSettings() {
            string addonSettings = Settings.Default.AddonsKV;
            if (addonSettings == "") {
                // no addon settings to deserialize.
                return;
            }

            KeyValue rootKV = KVParser.KV1.ParseAll(addonSettings)[0];

            foreach (KeyValue kv in rootKV.Children) {
                string addonName = kv.Key;
                Addon addon = mf.getAddonFromName(addonName);

                // this can occur if addon is deleted and program doesn't exit correctly.
                if (addon == null) {
                    continue;
                }

                deserializeAddon(addon, kv);
            }
        }

        public void serializeSettings() {
            KeyValue rootKV = new KeyValue("Addons");
            foreach (KeyValuePair<string, Addon> a in mf.addons) {
                string addonName = a.Key;
                Addon addon = a.Value;
                KeyValue addonKV = new KeyValue(addonName);
                serializeAddon(addon, addonKV);
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

            // write the settings out
            Settings.Default.Save();
        }

        #region addon serializer/deserializer
        internal void deserializeAddon(Addon a, KeyValue kv) {
            foreach (KeyValue kv2 in kv.Children) {
                if (kv2.Key == "workshopID") {
                    Debug.WriteLine("#Children: " + kv2.Children.Count());
                    if (kv2.HasChildren) {
                        if (!Int32.TryParse(kv2.Children.ElementAt(0).Key, out a.workshopID)) {
                            Debug.WriteLine("Couldn't parse workshopID for " + a.name);
                        }
                    }
                } else if (kv2.Key == "generateNote0") {
                    if (kv2.HasChildren) {
                        string value = kv2.Children.ElementAt(0).Key;
                        if (value == "True") {
                            a.generateNote0 = true;
                        } else {
                            a.generateNote0 = false;
                        }
                    }
                } else if (kv2.Key == "generateLore") {
                    if (kv2.HasChildren) {
                        string value = kv2.Children.ElementAt(0).Key;
                        if (value == "True") {
                            a.generateLore = true;
                        } else {
                            a.generateLore = false;
                        }
                    }
                } else if (kv2.Key == "askToBreakUp") {
                    if (kv2.HasChildren) {
                        string value = kv2.Children.ElementAt(0).Key;
                        if (value == "True") {
                            a.askToBreakUp = true;
                        } else {
                            a.askToBreakUp = false;
                        }
                    }
                } else if (kv2.Key == "autoDeleteBin") {
                    if (kv2.HasChildren) {
                        string value = kv2.Children.ElementAt(0).Key;
                        if (value == "True") {
                            a.autoDeleteBin = true;
                        } else {
                            a.autoDeleteBin = false;
                        }
                    }
                } else if (kv2.Key == "autoCompileCoffeeScript") {
                    if (kv2.HasChildren) {
                        string value = kv2.Children.ElementAt(0).Key;
                        if (value == "True") {
                            a.autoCompileCoffeeScript = true;
                        } else {
                            a.autoCompileCoffeeScript = false;
                        }
                    }
                } else if (kv2.Key == "generateUTF8") {
                    if (kv2.HasChildren) {
                        string value = kv2.Children.ElementAt(0).Key;
                        if (value == "True") {
                            a.generateUTF8 = true;
                        } else {
                            a.generateUTF8 = false;
                        }
                    }
                }
            }
        }

        internal void serializeAddon(Addon a, KeyValue addonKV) {
            KeyValue workshopIDKV = new KeyValue("workshopID");
            workshopIDKV.AddChild(new KeyValue(a.workshopID.ToString()));
            addonKV.AddChild(workshopIDKV);

            KeyValue generateNote0KV = new KeyValue("generateNote0");
            generateNote0KV.AddChild(new KeyValue(a.generateNote0.ToString()));
            addonKV.AddChild(generateNote0KV);

            KeyValue generateLoreKV = new KeyValue("generateLore");
            generateLoreKV.AddChild(new KeyValue(a.generateLore.ToString()));
            addonKV.AddChild(generateLoreKV);

            KeyValue askToBreakUp = new KeyValue("askToBreakUp");
            askToBreakUp.AddChild(new KeyValue(a.askToBreakUp.ToString()));
            addonKV.AddChild(askToBreakUp);

            KeyValue autoDeleteBin = new KeyValue("autoDeleteBin");
            autoDeleteBin.AddChild(new KeyValue(a.autoDeleteBin.ToString()));
            addonKV.AddChild(autoDeleteBin);

            KeyValue generateUTF8 = new KeyValue("generateUTF8");
            generateUTF8.AddChild(new KeyValue(a.generateUTF8.ToString()));
            addonKV.AddChild(generateUTF8);

            KeyValue autoCompileCoffeeScript = new KeyValue("autoCompileCoffeeScript");
            autoCompileCoffeeScript.AddChild(new KeyValue(a.autoCompileCoffeeScript.ToString()));
            addonKV.AddChild(autoCompileCoffeeScript);
        }
        #endregion
    }
}
