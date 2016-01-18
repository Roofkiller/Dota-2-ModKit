using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ModKit {
	public class Pair {
		public string key, val;

		public Pair(string key, string val) {
			this.key = key;
			this.val = val;
		}

		public override string ToString() {
			// determine amount of whitespace
			string whitespace = "";
			int count = 80 - key.Length;
			if (count > 2) {
				for (int i = 0; i < count; i++) {
					whitespace += " ";
				}
			}
			// the nextKey is really long, so just add some tabs.
			else {
				whitespace += "\t\t";
			}

			string str = "\t\t\"" + key + "\"" + whitespace + "\"" + val + "\"\n";
			return str;
		}
	}

	public class ModifierEntry {
		public Pair name, description;
		private Addon addon;

		public ModifierEntry(Addon a, string _name) {
			this.addon = a;

			// prevent modifier_modifier names
			name = new Pair("DOTA_Tooltip_" + _name, getVal(_name));

			// Noya says modifier tooltips are like this DOTA_Tooltip_some_modifier
			/*if (_name.Length > 8)
			{
				if (_name.Substring(0, 8) == "modifier")
				{
					name = new Pair("DOTA_Tooltip_" + _name, getVal(_name));
				}
			}*/

			description = new Pair(name.key + "_Description", "");
		}

		// tries to auto-generate the value
		private string getVal(string name) {
			string[] parts = name.Split('_');
			string val = "";
			for (int i = 0; i < parts.Count(); i++) {
				string part = parts[i];
				// we don't want 'Item' as part of the value.
				if (i == 0 && part == "modifier") {
					continue;
				}


				// ensure valid string to work with
				if (part.Length > 0) {
					// make the first char uppercase
					string firstLetter = part.ElementAt(0).ToString().ToUpper();
					try {
						part = firstLetter + part.Substring(1);
					} catch (IndexOutOfRangeException) {
						// part was just 1 char.
						part = firstLetter;
					}
					// now add this part to the final value.
					val += part;
					// add a space
					if (i != parts.Count() - 1) {
						val += " ";
					}
				}
			}
			return val;
		}

		public override string ToString() {
			string str = "";
			str += name.ToString();
			str += description.ToString();
			return str;
		}
	}

	public class UnitEntry {
		public Pair name;
		private Addon addon;

		public UnitEntry(Addon a, string _name) {
			this.addon = a;
			name = new Pair(_name, getVal(_name));
		}

		// tries to auto-generate the value
		private string getVal(string name) {
			string[] parts = name.Split('_');
			string val = "";
			for (int i = 0; i < parts.Count(); i++) {
				string part = parts[i];
				// we don't want 'npc' as part of the value.
				if (i == 0 && part == "npc") {
					continue;
				}

				// ensure valid string to work with
				if (part.Length > 0) {
					// make the first char uppercase
					string firstLetter = part.ElementAt(0).ToString().ToUpper();
					try {
						part = firstLetter + part.Substring(1);
					} catch (IndexOutOfRangeException) {
						// part was just 1 char.
						part = firstLetter;
					}
					// now add this part to the final value.
					val += part;
					// add a space
					if (i != parts.Count() - 1) {
						val += " ";
					}
				}
			}
			return val;
		}

		public override string ToString() {
			return name.ToString();
		}
	}

	public class HeroEntry {
		public Pair name;
		private Addon addon;

		public HeroEntry(Addon a, string overrideHeroName, string name) {
			this.addon = a;
			try {
				// remove the npc_dota_hero part for the value.
				//this.name = new Pair(overrideHeroName, getVal(overrideHeroName.Substring(14)));
				this.name = new Pair(overrideHeroName, getVal(name));
			} catch (IndexOutOfRangeException) {
				this.name = new Pair(overrideHeroName, "");
			}
		}


		// tries to auto-generate the value
		private string getVal(string name) {
			string[] parts = name.Split('_');
			string val = "";
			for (int i = 0; i < parts.Count(); i++) {
				string part = parts[i];

				// ensure valid string to work with
				if (part.Length > 0) {
					// make the first char uppercase
					string firstLetter = part.ElementAt(0).ToString().ToUpper();
					try {
						part = firstLetter + part.Substring(1);
					} catch (IndexOutOfRangeException) {
						// part was just 1 char.
						part = firstLetter;
					}
					// now add this part to the final value.
					val += part;
					// add a space
					if (i != parts.Count() - 1) {
						val += " ";
					}
				}
			}
			return val;
		}

		public override string ToString() {
			return name.ToString();
		}
	}

	public class AbilityEntry {
		// description and lore are default for abilities.
		public Pair name, description, lore, note0;
		public List<Pair> abilitySpecials = new List<Pair>();
		private Addon addon;

		public AbilityEntry(Addon a, string _name, List<string> keys) {
			this.addon = a;
			name = new Pair("DOTA_Tooltip_ability_" + _name, getVal(_name));
			description = new Pair(name.key + "_Description", "");
			note0 = new Pair(name.key + "_Note0", "");
			lore = new Pair(name.key + "_Lore", "");

			if (keys != null) {
				abilitySpecials = new List<Pair>(keys.Count());
				for (int i = 0; i < keys.Count(); i++) {
					string abilSpecial = keys.ElementAt(i);
					abilitySpecials.Add(new Pair(name.key + "_" + abilSpecial, getAbilSpecialVal(abilSpecial)));
				}
			}
		}

		private string getAbilSpecialVal(string key) {
			string[] parts = key.Split('_');
			string val = "";
			for (int i = 0; i < parts.Count(); i++) {
				string part = parts[i];

				// ensure valid string to work with
				if (part.Length > 0) {
					// make everything uppercase
					part = part.ToUpper();

					// now add this part to the final value.
					val += part;
					// add a space
					if (i != parts.Count() - 1) {
						val += " ";
					} else {
						// add a colon
						val += ":";
					}
				}
			}
			return val;
		}

		// tries to auto-generate the value
		private string getVal(string name) {
			string[] parts = name.Split('_');
			string val = "";
			for (int i = 0; i < parts.Count(); i++) {
				string part = parts[i];
				// we don't want 'Item' as part of the value.
				if (i == 0 && part == "item") {
					continue;
				}


				// ensure valid string to work with
				if (part.Length > 0) {
					// make the first char uppercase
					string firstLetter = part.ElementAt(0).ToString().ToUpper();
					try {
						part = firstLetter + part.Substring(1);
					} catch (IndexOutOfRangeException) {
						// part was just 1 char.
						part = firstLetter;
					}
					// now add this part to the final value.
					val += part;
					// add a space
					if (i != parts.Count() - 1) {
						val += " ";
					}
				}
			}
			return val;
		}

		public override string ToString() {
			string str = "";
			str += name.ToString();
			str += description.ToString();
			if (addon.generateNote0) {
				str += note0.ToString();
			}
			if (addon.generateLore) {
				str += lore.ToString();
			}
			/*
			if (Properties.Settings.Default.GenNote0Lore) {
				str += Note0.ToString();
				str += Lore.ToString();
			}*/

			for (int i = 0; i < abilitySpecials.Count(); i++) {
				str += abilitySpecials.ElementAt(i).ToString();
			}
			return str;
		}
	}
}
