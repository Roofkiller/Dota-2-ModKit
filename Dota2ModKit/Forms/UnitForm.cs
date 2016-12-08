using FastColoredTextBoxNS;
using LibGit2Sharp;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Dota2ModKit.Features;
using KVLib;
using Newtonsoft.Json;

namespace Dota2ModKit.Forms
{

    public partial class UnitForm : MetroForm
    {
        private MainForm mainForm;
        private List<Builder> builders;
        private List<KeyValueData> units = new List<KeyValueData>();
        private KeyValueData _currentUnit;
        private KeyValue waveInfos;

        private KeyValueData currentUnit
        {
            get { return _currentUnit; }
            set
            {
                _currentUnit = value;
                FillStats(_currentUnit);
            }
        }

        public UnitForm(MainForm mainForm)
        {
            waveInfos = KVParser.KV1.Parse(File.ReadAllText(Path.Combine(MainForm.Instance.currAddon.gamePath, "scripts", "maps", "legion_td_4v4.txt")));
            MainForm.Instance.currAddon.FilesLocked = true;
            this.mainForm = mainForm;

            InitializeComponent();

            notificationLabel.Text = "";
            FillTreeView();
            textBox1.ReadOnly = false;
            textBox1.TextChangedDelayed += (sender, args) =>
            {
                KeyValue newData = null;
                try
                {
                    newData = KVParser.KV1.Parse(textBox1.Text);
                }
                catch (Exception)
                {
                    // ignored
                }
                if (newData != null)
                {
                    currentUnit.KeyValue = newData;
                    currentUnit.Text = textBox1.Text;
                }
                if (currentUnit != null)
                    FillStats(_currentUnit);
                currentUnit?.SaveText();
            };

            this.Closed += (sender, args) => MainForm.Instance.currAddon.FilesLocked = false;
        }

	    private void FillTreeView()
	    {
	        foreach (var builder in builders = LegionFeatures.Builders)
	        {
	            var node = treeView1.Nodes.Add(builder.Name);
	            foreach (var unit in builder.Units)
	            {
                    units.Add(unit);
	                var unitNode = node.Nodes.Add(unit.ShortBuilderName);
	            }
            }
	        var incomeNode = treeView1.Nodes.Add("incomeunit");
            foreach (var unit in LegionFeatures.IncomeUnits)
	        {
                units.Add(unit);
	            incomeNode.Nodes.Add(unit.ShortIncomeName);
	        }
	        var waveNode = treeView1.Nodes.Add("unit");
	        foreach (var unit in LegionFeatures.WaveUntis)
	        {
	            units.Add(unit);
	            waveNode.Nodes.Add(unit.ShortWaveName);
	        }
            treeView1.ExpandAll();

	        treeView1.AfterSelect += (s, e) =>
	        {
	            TreeNode selected = e.Node;
	            var unit = GetUnit(selected);
	            if (unit != null)
                {
                    currentUnit = unit;
                    textBox1.Text = unit.Text;
                    textBox1.ClearUndo();
                }
            };
	    }

	    private void FillStats(KeyValueData unit)
	    {
	        KeyValue kv = unit.KeyValue;
	        bool isIncome = false;
	        int cost = unit.TotalGoldCost;
	        if (isIncome = cost == -1)
	            cost = unit.TangoCost;
            float dmg = (kv["AttackDamageMin"].GetFloat() + kv["AttackDamageMax"].GetFloat()) / 2;
            float ar = kv["AttackRate"].GetFloat();
            float dps = dmg / ar;
            float dps_p_c = cost != -1 ? dps / cost : 0;
            float health = kv["StatusHealth"].GetFloat();
            float armor = kv["ArmorPhysical"].GetFloat();
            float effHealth = health / (1 - 0.06f * armor / (1 + 0.06f * Math.Abs(armor)));
            float effHealth_p_g = cost != -1 ? effHealth / cost : 0;
            float range = kv["AttackRange"].GetFloat();
	        float val = 0;
	        if (cost != -1)
	        {
	            float dpsVal, hpVal = 0;
	            if (!isIncome)
	            {
	                dpsVal = dps/(cost*(range > 150 ? 1f : 0.7f));
	                hpVal = effHealth/(cost*(range > 150 ? 1.2f : 3));
	            }
	            else
	            {
	                dpsVal = dps/(cost*(range > 150 ? 0.5f : 0.3f));
	                hpVal = effHealth/(cost*(range > 150 ? 2.0f : 3.5f));
	            }
	            val = (dpsVal*dpsVal*hpVal*hpVal);
	        }
	        int unitCount = GetUnitCount(unit);
	        float waveDps = dps*unitCount;
	        float waveHealth = effHealth*unitCount;
	        string stats = $"Cost : {cost} \n" +
	                       $"Damage : {dmg} \n" +
	                       $"AttackRate : {ar}\n" +
	                       $"DPS : {dps}\n" +
	                       $"Health : {health}\n" +
	                       $"Armor : {armor}\n" +
	                       $"EffHealth : {effHealth}\n" +
	                       $"Range : {range}\n" +
                           (cost != -1 ? $"DPS/Cost : {dps_p_c}\n" +
                                         $"EffHealth/Cost : {effHealth_p_g}\n" +
                                         $"Value : {val} (This is just a guideline, abilities arent calculated!)" : "") +
                           (unitCount > 0 ? $"UnitCount : {unitCount} \n" +
                                            $"Wave DPS : {waveDps} \n" +
                                            $"Wave Health : {waveHealth}" : "");
	        textBox2.Text = stats;
	    }

        private int GetUnitCount(KeyValueData unit)
        {
            foreach (var info in waveInfos.Children)
            {
                if (info.HasChildren)
                {
                    if (info.HasKey("Unit"))
                    {
                        if (info["Unit"]["NPCName"].GetString().Equals(unit.Name))
                        {
                            return info["Unit"]["UnitCount"].GetInt();
                        }
                    }
                }
            }
            return -1;
        }

	    private KeyValueData GetUnit(TreeNode node)
	    {
	        if (node.Parent != null)
	        {
	            var unit = units.Single(u => Regex.Match(u.Path, $@".*{node.Parent.Text}_{node.Text}.txt").Success);
	            return unit;
	        }
	        return null;
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

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void UnitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
