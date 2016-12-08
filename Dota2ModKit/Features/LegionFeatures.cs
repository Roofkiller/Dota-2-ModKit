using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Dota2ModKit.HelperClasses;
using KVLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Dota2ModKit.Features
{
    public static class LegionFeatures
    {
        static LegionFeatures()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        public static readonly Dictionary<string, Func<KeyValue, string>> MatchingAbilities = new Dictionary<string, Func<KeyValue, string>>
        {
            ["atk_damage_tooltip"] = kv => ((kv["AttackDamageMin"].GetFloat() + kv["AttackDamageMax"].GetFloat()) / 2).ToString(CultureInfo.InvariantCulture),
            ["atk_speed_tooltip"] = kv => kv["AttackRate"].GetString(),
            ["atk_range_tooltip"] = kv => kv["AttackRange"].GetString(),
            ["health_tooltip"] = kv => kv["StatusHealth"].GetString(),
            ["armor_tooltip"] = kv => kv["ArmorPhysical"].GetString(),
        };

        public static string PathToUnits => Path.Combine(MainForm.Instance.currAddon.gamePath, "scripts", "npc", "units");
        public static string PathToAbilities => Path.Combine(MainForm.Instance.currAddon.gamePath, "scripts", "npc", "abilities");
        public static string PathToIncomeUnits => Path.Combine(MainForm.Instance.currAddon.gamePath, "scripts", "npc", "units", "incomeunits");
        public static string PathToWaveUnits => Path.Combine(MainForm.Instance.currAddon.gamePath, "scripts", "npc", "units", "waveunits");

        private static List<Builder> builders = null;
        public static List<Builder> Builders
        {
            get
            {
                if (builders != null)
                    return builders;
                return builders = Directory.GetDirectories(PathToUnits).Where(s => s.Contains("builder")).Select(s => new Builder(s)).ToList();
            }
        }

        private static List<KeyValueData> incomeUnits;

        public static List<KeyValueData> IncomeUnits
        {
            get
            {
                if (incomeUnits != null)
                    return incomeUnits;
                return incomeUnits = Directory.GetFiles(PathToIncomeUnits).Select(u => new KeyValueData(u)).ToList();
            }
        }

        private static List<KeyValueData> waveUnits;

        public static List<KeyValueData> WaveUntis
        {
            get
            {
                if (waveUnits != null)
                    return waveUnits;
                return waveUnits = Directory.GetFiles(PathToWaveUnits).Select(u => new KeyValueData(u)).ToList();
            }
        } 

        public static async void MatchAbilitiesToUnits()
        {
            MainForm.Instance.currAddon.FilesLocked = true;
            await Task.Run(() => Builders.ForEach(b => b.Units.ForEach(u => u.MatchAbilityToUnit())));
            MainForm.Instance.currAddon.FilesLocked = false;
        }

        public static string DirSearch(string toSearch, string path)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                if (Regex.Match(file, toSearch).Success)
                    return file;
            }
            foreach (var directory in Directory.GetDirectories(path))
            {
                var r = DirSearch(toSearch, directory);
                if (r != null)
                    return r;
            }
            return null;
        }
    }
    
    public class KeyValueData
    {
        public string ShortBuilderName => Regex.Replace(Name, @".*builder_", "");
        public string ShortIncomeName => Regex.Replace(Name, @"incomeunit_", "");
        public string ShortWaveName => Regex.Replace(Name, @"unit_", "");

        public string Name { get; set; }
        public string Path { get; set; }
        public string Text { get; set; }
        public KeyValue KeyValue { get; set; }

        public KeyValueData(string path, string kvData)
        {
            Text = kvData;
            try
            {
                KeyValue = KVParser.KV1.Parse(kvData);
            }
            catch (Exception e)
            {
                throw e;
            }
            Path = path;
            Name = Regex.Replace(Regex.Replace(path, @".*\\", ""), ".txt", "");
        }
        
        private int totalGoldCost = -2;
        public int TotalGoldCost
        {
            get
            {
                if (totalGoldCost != -2)
                    return totalGoldCost;
                KeyValueData ability = SummonAbility;
                if (!ability.KeyValue.HasKey("AbilityGoldCost"))
                {
                    return totalGoldCost = -1;
                }
                int goldCost = ability.KeyValue["AbilityGoldCost"].GetInt();
                while (ability != null && ability.KeyValue.Key.Contains("upgrade"))
                {
                    ability = ability.AbilityUser?.SummonAbility;
                    if (ability != null)
                        goldCost += ability.KeyValue["AbilityGoldCost"].GetInt();
                }
                totalGoldCost = goldCost;
                return goldCost;
            }
        }

        public void MatchAbilityToUnit()
        {
            KeyValueData ability = SummonAbility;
            KeyValue flatAbility = ability.KeyValue.ToFlat();
            foreach (var pair in LegionFeatures.MatchingAbilities)
            {
                var entry = flatAbility.Children.First(c => c.Key.Contains(pair.Key));
                entry.Set(pair.Value(KeyValue));
            }
            ability.KeyValue = flatAbility.UnFlat();
            ability.Save();
        }

        private int tangoCost = -1;
        public int TangoCost
        {
            get
            {
                if (tangoCost != -1)
                    return tangoCost;
                var mainHudLines =
                    File.ReadAllLines(System.IO.Path.Combine(MainForm.Instance.currAddon.contentPath, "panorama",
                        "scripts", "custom_game",
                        "main_hud.js"));
                var json = string.Join("",
                    mainHudLines.SkipWhile(l => !l.Contains('[')).TakeWhile(l => !l.Contains(';')));
                var unitInfos = JArray.Parse(json);
                JToken unitInfo = null;
                foreach (var unit in unitInfos)
                {
                    if (unit["name"].ToString().Equals(Name))
                    {
                        unitInfo = unit;
                        break;
                    }
                }
                return tangoCost = unitInfo?["cost"].ToObject<int>() ?? -1;
            }
        }

        private KeyValueData abilityUser = null;
        private KeyValueData AbilityUser
        {
            get
            {
                if (abilityUser != null)
                    return abilityUser;
                return abilityUser = LegionFeatures.Builders.SelectMany(builder => builder.Units)
                    .FirstOrDefault(unit => unit.KeyValue.Children.Any(kv => !kv.HasChildren && kv.GetString() == KeyValue.Key));
            }
        }

        private KeyValueData summonAbility = null;
        public KeyValueData SummonAbility
        {
            get
            {
                if (summonAbility != null)
                    return summonAbility;
                var name = ShortBuilderName + @"\.txt";
                return summonAbility = new KeyValueData(LegionFeatures.DirSearch($".*builder_(spawn|upgrade)_{name}", LegionFeatures.PathToAbilities));
            }
        }

        public KeyValueData(string path)
        {
            string content = "";
            if (path == null)
                path = "";
            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }
            Text = content;
            Path = path;
            Name = Regex.Replace(Regex.Replace(path, @".*\\", ""), ".txt", "");
            KeyValue = content == "" ? new KeyValue(Name) : KVParser.KV1.Parse(content);
        }

        public void Save()
        {
            File.WriteAllText(Path, KeyValue.ToString());
        }

        public void SaveText()
        {
            File.WriteAllText(Path, Text);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Builder
    {
        public string Name { get; set; }
        public string Path { get; set; }

        private List<KeyValueData> units = null;

        public List<KeyValueData> Units
        {
            get
            {
                if (units != null)
                    return units;
                return units = Directory.GetFiles(Path).Select(u => new KeyValueData(u)).ToList();
            }
        } 

        public Builder(string path)
        {
            Path = path;
            Name = Regex.Replace(path, @".*\\", "");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
