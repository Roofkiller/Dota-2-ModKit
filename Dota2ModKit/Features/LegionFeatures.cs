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

        private static readonly Dictionary<string, Func<KeyValue, string>> MatchingAbilities = new Dictionary<string, Func<KeyValue, string>>
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

        public static List<Builder> Builders => Directory.GetDirectories(PathToUnits).Where(s => s.Contains("builder")).Select(s => new Builder(s)).ToList();

        public static List<KeyValueData> IncomeUnits => Directory.GetFiles(PathToIncomeUnits).Select(u => new KeyValueData(u)).ToList();

        public static List<KeyValueData> WaveUntis => Directory.GetFiles(PathToWaveUnits).Select(u => new KeyValueData(u)).ToList();

        public static async void MatchAbilitiesToUnits()
        {
            MainForm.Instance.currAddon.FilesLocked = true;
            await Task.Run(() => Builders.ForEach(b => b.Units.ForEach(MatchAbilityToUnit)));
            MainForm.Instance.currAddon.FilesLocked = false;
        }

        public static void MatchAbilityToUnit(KeyValueData unit)
        {
            KeyValueData ability = GetSummonAbility(unit);
            KeyValue flatAbility = ability.KeyValue.ToFlat();
            foreach (var pair in MatchingAbilities)
            {
                var entry = flatAbility.Children.First(c => c.Key.Contains(pair.Key));
                entry.Set(pair.Value(unit.KeyValue));
            }
            ability.KeyValue = flatAbility.UnFlat();
            ability.Save();
        }

        public static int GetTangoCost(KeyValueData incomeUnit)
        {
            var mainHudLines = File.ReadAllLines(Path.Combine(MainForm.Instance.currAddon.contentPath, "panorama", "scripts", "custom_game",
                "main_hud.js"));
            var json = string.Join("", mainHudLines.SkipWhile(l => !l.Contains('[')).TakeWhile(l => !l.Contains(';')));
            var unitInfos = JArray.Parse(json);
            JToken unitInfo = null;
            foreach (var unit in unitInfos)
            {
                if (unit["name"].ToString().Equals(incomeUnit.Name))
                {
                    unitInfo = unit;
                    break;
                }
            }
            if (unitInfo != null) return unitInfo["cost"].ToObject<int>();
            return -1;
        }

        public static int GetTotalGoldCost(KeyValueData unit)
        {
            KeyValueData ability = GetSummonAbility(unit);
            if (!ability.KeyValue.HasKey("AbilityGoldCost"))
            {
                return -1;
            }
            int goldCost = ability.KeyValue["AbilityGoldCost"].GetInt();
            while (ability != null && ability.KeyValue.Key.Contains("upgrade"))
            {
                unit = GetAbilityUser(ability);
                ability = GetSummonAbility(unit);
                if (ability != null)
                    goldCost += ability.KeyValue["AbilityGoldCost"].GetInt();
            }
            return goldCost;
        }

        private static KeyValueData GetAbilityUser(KeyValueData ability)
        {
            return Builders.SelectMany(builder => builder.Units)
                .FirstOrDefault(unit => unit.KeyValue.Children.Any(kv => !kv.HasChildren && kv.GetString() == ability.KeyValue.Key));
        }

        public static KeyValueData GetSummonAbility(KeyValueData unit)
        {
            var name = "_" + unit.ShortBuilderName + @"\.txt";
            return new KeyValueData(DirSearch($".*builder.*{name}", PathToAbilities));
        }

        private static string DirSearch(string toSearch, string path)
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
        public KeyValue KeyValue { get; set; }

        public KeyValueData(string path, string kvData)
        {
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

        public KeyValueData(string path)
        {
            string content = "";
            if (path == null)
                path = "";
            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }
            Path = path;
            Name = Regex.Replace(Regex.Replace(path, @".*\\", ""), ".txt", "");
            KeyValue = content == "" ? new KeyValue(Name) : KVParser.KV1.Parse(content);
        }

        public void Save()
        {
            File.WriteAllText(Path, KeyValue.ToString());
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

        public List<KeyValueData> Units => Directory.GetFiles(Path).Select(u => new KeyValueData(u)).ToList();

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
