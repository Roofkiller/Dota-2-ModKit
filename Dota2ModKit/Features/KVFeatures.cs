using KVLib;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit.Features {
	class KVFeatures {
		MainForm mf;

		public KVFeatures(MainForm mf) {
			this.mf = mf;
		}

        #region breakup/combine
        internal void combine() {
			string[] items = { "heroes", "units", "items", "abilities" };
			for (int i = 0; i < items.Length; i++) {
				string item = items[i];
				string foldPath = Path.Combine(mf.currAddon.gamePath, "scripts", "npc", item);
				string foldName = foldPath.Substring(foldPath.LastIndexOf('\\') + 1);
				string foldParent = foldPath.Substring(0, foldPath.LastIndexOf('\\'));
				string bigKVPath = Path.Combine(foldParent, "npc_" + foldName + "_custom.txt");

				//if (!File.Exists(bigKVPath)) {
				//	continue;
				//}

				bool doBreakUp = false;
				if (File.Exists(bigKVPath)) {
					if (!Directory.Exists(foldPath)) {
						DialogResult dr = MetroMessageBox.Show(mf, "npc_" + item + "_custom.txt has not been broken up. Break it up now?",
							"Break Up KV File",
							MessageBoxButtons.OKCancel,
							MessageBoxIcon.Information);

						if (dr != DialogResult.OK) {
							// nothings been broken up, so nothing to combine
							continue;
						} else {
							doBreakUp = true;
						}
					} else {
						if (mf.currAddon.askToBreakUp) {
							DialogResult dr = MetroMessageBox.Show(mf, "Do you want to break up npc_" + item + "_custom.txt?",
								"Break Up KV File",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Information);
							if (dr == DialogResult.Yes) {
								doBreakUp = true;
							}
						}
					}

					if (doBreakUp) {
						breakUp(item);
					}
				}

				string currText = File.ReadAllText(bigKVPath);

				// so now we have the big KV file created and ready to be populated.
				string[] files = Directory.GetFiles(foldPath, "*.txt", SearchOption.AllDirectories);
				StringBuilder text = new StringBuilder("\"DOTAAbilities\"" + "\n{\n");
				if (foldName == "heroes") {
					text = new StringBuilder("\"DOTAHeroes\"" + "\n{\n");
				} else if (foldName == "units") {
					text = new StringBuilder("\"DOTAUnits\"" + "\n{\n");
				}

				foreach (string file in files) {

					bool addTab = false;
					string[] lines = File.ReadAllLines(file);
					for (int j = 0; j < lines.Length; j++) {
						string line = lines[j];
						if (j == 0 && line.StartsWith("\t") == false && line.StartsWith("  ") == false) {
							addTab = true;
						}
						string newLine = line;
						if (addTab) {
							newLine = "\t" + line;
						}
						text.AppendLine(newLine);
					}
				}

				text.Append("}");

				// check if they're different before writing
				string txt = text.ToString();
				if (txt.Trim() != currText.Trim()) {
					File.WriteAllText(bigKVPath, txt);
				} else {
					Debug.WriteLine("Not overwriting.");
				}
			}

			mf.text_notification("Combine success", MetroColorStyle.Green, 1500);
		}

		public void breakUp(string itemStr) {
			string file = Path.Combine(mf.currAddon.gamePath, "scripts", "npc", "npc_" + itemStr + "_custom.txt");
			string foldPath = Path.Combine(mf.currAddon.gamePath, "scripts", "npc", itemStr);

			// Ensure the npc_ file exists.
			if (!File.Exists(file)) {
				return;
			}

			string foldName = file.Substring(file.LastIndexOf('\\') + 1);
			// get rid of extension.
			foldName = foldName.Substring(0, foldName.LastIndexOf('.'));

			if (Directory.Exists(foldPath)) {
				Directory.Delete(foldPath, true);
			}
			Directory.CreateDirectory(foldPath);

			string allText = File.ReadAllText(file);
			allText = allText.Replace("\r", "");
			KeyValue[] kvs = KVLib.KVParser.KV1.ParseAll(allText);
			foreach (KeyValue kv in kvs) {
				if (kv.Key == "DOTAAbilities" || kv.Key == "DOTAHeroes" || kv.Key == "DOTAUnits") {
					// skip this first nextKey, go straight to children.
					if (kv.HasChildren) {
						IEnumerable<KeyValue> kvs2 = kv.Children;
						KeyValue[] kvArr = kvs2.ToArray();

						if (kvArr.Length == 0) {
							// This kv file is screwed up.
							break;
						}

						// record start line number and end line number of each Key-Value block
						int[] startLineNumber = new int[kvArr.Length];
						int[] endLineNumber = new int[kvArr.Length];

						// catch the start pointer, ignore all "Version"s
						int ptr = 0;
						while (kvArr[ptr].Key == "Version" && ptr < kvArr.Length)
							ptr++;

						// store the start pointer
						int startPtr = ptr;

						// init the first key
						string key = kvArr[ptr].Key;

						// loop over all lines to record the start/end of all kvs
						string[] lines = allText.Split('\n');
						for (int index = 0; index < lines.Length; index++) {
							string line = lines[index];
							if (line.Trim().StartsWith("\"" + key)) {
								int ind = index - 1;
								// go back to add all comments/empty lines to this block
								while ((lines[ind].Trim() == "" || lines[ind].Trim().StartsWith("//")) && (ind > 0))
									ind--;
								startLineNumber[ptr] = ind + 1;
								// record the end of the block for last pointer
								if (ptr > 0)
									endLineNumber[ptr - 1] = ind;
								if (ptr < kvArr.Length - 1) {
									ptr++;
									key = kvArr[ptr].Key;
								}
							}
						}
						// deal with very last pointer
						int lastInd = lines.Length - 1;
						while (lastInd > 0 && lines[lastInd].Contains("}") && (lines[lastInd].IndexOf("//") > lines[lastInd].IndexOf("}")))
							lastInd--;
						endLineNumber[kvArr.Length - 1] = lastInd;

						// generate break-down kv files and write text
						for (int p = startPtr; p < kvArr.Length; p++) {
							string filePath = Path.Combine(foldPath, kvArr[p].Key + ".txt");
							File.Create(filePath).Close();
							StringBuilder sb = new StringBuilder();

							for (int p1 = startLineNumber[p]; p1 <= endLineNumber[p]; p1++) {
								string line = lines[p1];
								// remove first tab
								if (line.StartsWith("\t")) {
									line = line.Substring(1);
								}
								sb.AppendLine(line);
							}

							string output = sb.ToString();
							// remove beginning newline
							output = output.TrimStart();

							// if last file, we need to remove the last }
							if (p == kvArr.Length - 1) {
								output = output.TrimEnd();
								if (output.EndsWith("}")) {
									output = output.Substring(0, output.Length - 1);
								}
							}
							File.WriteAllText(filePath, output);
						}
					}
				}
			}
		}
        #endregion

        #region generate tooltip functions
        internal void generateTooltips(Addon a) {
            a.abilityModifierNames.Clear();
            a.itemModifierNames.Clear();
            a.abilityEntries.Clear();
            a.itemEntries.Clear();
            a.unitEntries.Clear();
            a.heroEntries.Clear();
            a.alreadyHasKeys.Clear();

            string curr = "";
            try {
                // these functions populate the data structures with the tooltips before writing to the addon_lang file.
                // items
                curr = "npc_items_custom.txt";
                generateAbilityTooltips(a, true);
                // abils
                curr = "npc_abilities_custom.txt";
                generateAbilityTooltips(a, false);
                curr = "npc_units_custom.txt";
                generateUnitTooltips(a);
                curr = "npc_heroes_custom.txt";
                generateHeroTooltips(a);
                writeTooltips(a);
                mf.text_notification("Tooltips successfully generated", MetroColorStyle.Green, 2500);
            } catch (Exception ex) {
                string msg = ex.Message;
                if (ex.InnerException != null) {
                    msg = ex.InnerException.Message;
                }

                MetroMessageBox.Show(mf, msg,
                    "Parse error: " + curr,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }

            // utf8 code
            if (a.generateUTF8) {
                string[] files = Directory.GetFiles(Path.Combine(a.gamePath, "resource"));
                foreach (string file in files) {
                    // skip the existing utf8 files.
                    if (file.Contains("utf8")) {
                        continue;
                    }
                    string name = file.Substring(file.LastIndexOf("\\") + 1);
                    name = name.Replace(".txt", "");
                    //string firstPart = file.Substring(0, file.LastIndexOf("\\"));
                    name += "_utf8.txt";
                    File.WriteAllText(Path.Combine(a.contentPath, name), File.ReadAllText(file), Encoding.UTF8);
                }
            }
        }
        private void generateAbilityTooltips(Addon a, bool item) {
            string path = Path.Combine(a.gamePath, "scripts", "npc", "npc_abilities_custom.txt");

            if (item) {
                path = Path.Combine(a.gamePath, "scripts", "npc", "npc_items_custom.txt");
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
                                    a.abilityModifierNames.Add(modifierName);
                                } else {
                                    a.itemModifierNames.Add(modifierName);
                                }
                            }

                        }
                    }
                }
                if (!item) {
                    a.abilityEntries.Add(new AbilityEntry(a, abilName, abilitySpecialNames));
                } else {
                    a.itemEntries.Add(new AbilityEntry(a, abilName, abilitySpecialNames));
                }
            }
        }

        private void generateHeroTooltips(Addon a) {
            string path = Path.Combine(a.gamePath, "scripts", "npc", "npc_heroes_custom.txt");

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
                        a.heroEntries.Add(new HeroEntry(a, kv2.GetString(), name));
                        break;
                    }

                }

                a.unitEntries.Add(new UnitEntry(a, kv.Key));
            }
        }

        private void generateUnitTooltips(Addon a) {
            string path = Path.Combine(a.gamePath, "scripts", "npc", "npc_units_custom.txt");

            if (!File.Exists(path)) {
                return;
            }

            KeyValue kvs = kvs = KVParser.KV1.ParseAll(File.ReadAllText(path))[0];

            foreach (KeyValue kv in kvs.Children) {
                if (kv.Key == "Version") {
                    continue;
                }
                a.unitEntries.Add(new UnitEntry(a, kv.Key));
            }
        }

        private void writeTooltips(Addon a) {
            foreach (string path in getAddonLangPaths(a)) {

                a.alreadyHasKeys.Clear();

                string thisLang = path.Substring(path.LastIndexOf('\\') + 1);

                string thisLangCopy = thisLang;
                thisLang = thisLang.Substring(thisLang.LastIndexOf('_') + 1);

                string outputPath = Path.Combine(a.contentPath, "tooltips_" + thisLang);

                KeyValue kv = KVParser.KV1.ParseAll(File.ReadAllText(path, Encoding.Unicode))[0];

                foreach (KeyValue kv2 in kv.Children) {
                    if (kv2.Key == "Tokens") {
                        foreach (KeyValue kv3 in kv2.Children) {
                            a.alreadyHasKeys.Add(kv3.Key.ToLowerInvariant());
                        }
                    }
                }

                StringBuilder content = new StringBuilder();

                string head0 =
                "\t\t// DOTA 2 MODKIT GENERATED TOOLTIPS FOR: " + a.name + "\n" +
                "\t\t// Keys already defined in " + thisLangCopy + " are not listed, nor are Modifiers with the property \"IsHidden\" \"1\".\n";
                content.Append(head0);

                string head1 = "\n\t\t// ******************** HEROES ********************\n";
                content.Append(head1);
                foreach (HeroEntry he in a.heroEntries) {
                    if (!a.alreadyHasKeys.Contains(he.name.key.ToLowerInvariant())) {
                        content.Append(he);
                    }
                }

                string head2 = "\n\t\t// ******************** UNITS ********************\n";
                content.Append(head2);
                foreach (UnitEntry ue in a.unitEntries) {
                    if (!a.alreadyHasKeys.Contains(ue.name.key.ToLowerInvariant())) {
                        content.Append(ue);
                    }
                }

                string head3 = "\n\t\t// ******************** ABILITY MODIFIERS ********************\n";
                content.Append(head3);
                foreach (string amn in a.abilityModifierNames) {
                    ModifierEntry me = new ModifierEntry(a, amn);
                    if (!a.alreadyHasKeys.Contains(me.name.key.ToLowerInvariant())) {
                        content.Append(me + "\n");
                    }
                }

                string head4 = "\n\t\t// ******************** ITEM MODIFIERS ********************\n";
                content.Append(head4);
                foreach (string imn in a.itemModifierNames) {
                    ModifierEntry me = new ModifierEntry(a, imn);
                    if (!a.alreadyHasKeys.Contains(me.name.key.ToLowerInvariant())) {
                        content.Append(me + "\n");
                    }
                }

                string head5 = "\n\t\t// ******************** ABILITIES ********************\n";
                content.Append(head5);
                foreach (AbilityEntry ae in a.abilityEntries) {
                    if (!a.alreadyHasKeys.Contains(ae.name.key.ToLowerInvariant())) {
                        content.Append(ae + "\n");
                    } else {
                        // the addon_language already has this ability. but let's check
                        // if there are any new AbilitySpecials.
                        bool missingAbilSpecials = false;
                        foreach (Pair p in ae.abilitySpecials) {
                            if (!a.alreadyHasKeys.Contains(p.key.ToLowerInvariant())) {
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
                foreach (AbilityEntry ae in a.itemEntries) {
                    if (!a.alreadyHasKeys.Contains(ae.name.key.ToLowerInvariant())) {
                        content.Append(ae + "\n");
                    } else {
                        // the addon_language already has this ability. but let's check
                        // if there are any new AbilitySpecials.
                        bool missingAbilSpecials = false;
                        foreach (Pair p in ae.abilitySpecials) {
                            if (!a.alreadyHasKeys.Contains(p.key.ToLowerInvariant())) {
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
        private List<string> getAddonLangPaths(Addon a) {
            string[] resourceFiles = Directory.GetFiles(Path.Combine(a.gamePath, "resource"));
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
        #endregion
    }
}
