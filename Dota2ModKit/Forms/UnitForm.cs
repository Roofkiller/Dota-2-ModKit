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
                    currentUnit.KeyValue = newData;
                if (currentUnit != null)
                    FillStats(_currentUnit);
                currentUnit?.Save();
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
	        var incomeNode = treeView1.Nodes.Add("incomeunits");
            foreach (var unit in LegionFeatures.IncomeUnits)
	        {
                units.Add(unit);
	            incomeNode.Nodes.Add(unit.ShortIncomeName);
	        }
	        var waveNode = treeView1.Nodes.Add("waveunits");
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
                    textBox1.Text = unit.KeyValue.ToString();
                    textBox1.ClearUndo();
                }
            };
	    }

	    private void FillStats(KeyValueData unit)
	    {
	        KeyValue kv = unit.KeyValue;
	        bool isIncome = false;
	        int cost = LegionFeatures.GetTotalGoldCost(unit);
	        if (isIncome = cost == -1)
	            cost = LegionFeatures.GetTangoCost(unit);
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
//	        var s = new
//	        {
//	            cost = cost,
//	            dmg = dmg,
//	            ar = ar,
//	            dps = dps,
//	            dps_p_c = dps_p_c,
//	            health = health,
//	            effHealth = effHealth,
//	            effHealth_p_g = effHealth_p_g,
//	            range = range,
//	            value = val,
//	        };
	        string stats = $"Cost : {cost} \n" +
	                       $"Damage : {dmg} \n" +
	                       $"AttackRate : {ar}\n" +
	                       $"DPS : {dps}\n" +
	                       (cost != -1 ? $"DPS/Cost : {dps_p_c}\n" : "") +
	                       $"Health : {health}\n" +
	                       $"Armor : {armor}\n" +
	                       $"EffHealth : {effHealth}\n" +
	                       (cost != -1 ? $"EffHealth/Cost : {effHealth_p_g}\n" : "") +
	                       $"Range : {range}\n" +
	                       (cost != -1 ? $"Value : {val} (This is just a guideline, abilities arent calculated!)" : "");
	        textBox2.Text = stats;
	    }

	    private KeyValueData GetUnit(TreeNode node)
	    {
	        if (node.Parent != null)
	        {
	            var unit = units.First(u => u.Path.Contains(node.Parent.Text) && u.Name.Contains(node.Text));
	            return unit;
	        }
	        return null;
	    }

	    private void copySpellBtn_Click(object sender, EventArgs e) {
			metroRadioButton1.Select();

			Clipboard.SetText(textBox1.Text);
			text_notification(strings.Copied, MetroColorStyle.Blue, 1000);
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

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void UnitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
