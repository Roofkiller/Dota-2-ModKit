namespace Dota2ModKit {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.generateAddonLangsBtn = new MetroFramework.Controls.MetroButton();
            this.addonTile = new MetroFramework.Controls.MetroTile();
            this.addonTileContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.changePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAddonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.toolsTab = new MetroFramework.Controls.MetroTabPage();
            this.compileCoffeeBtn = new MetroFramework.Controls.MetroButton();
            this.findSoundNameBtn = new MetroFramework.Controls.MetroButton();
            this.combineKVBtn = new MetroFramework.Controls.MetroButton();
            this.particlesTab = new MetroFramework.Controls.MetroTabPage();
            this.linksTab = new MetroFramework.Controls.MetroTabPage();
            this.metroLink12 = new MetroFramework.Controls.MetroLink();
            this.metroLink11 = new MetroFramework.Controls.MetroLink();
            this.metroLink10 = new MetroFramework.Controls.MetroLink();
            this.metroLink9 = new MetroFramework.Controls.MetroLink();
            this.metroLink8 = new MetroFramework.Controls.MetroLink();
            this.metroLink7 = new MetroFramework.Controls.MetroLink();
            this.metroLink6 = new MetroFramework.Controls.MetroLink();
            this.goBtn = new MetroFramework.Controls.MetroButton();
            this.jsRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.textRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.luaRadioBtn = new MetroFramework.Controls.MetroRadioButton();
            this.addonNameLabel = new MetroFramework.Controls.MetroLabel();
            this.githubTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLink5 = new MetroFramework.Controls.MetroLink();
            this.metroLink4 = new MetroFramework.Controls.MetroLink();
            this.metroLink3 = new MetroFramework.Controls.MetroLink();
            this.metroLink2 = new MetroFramework.Controls.MetroLink();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.notificationLabel = new MetroFramework.Controls.MetroLabel();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.gameTile = new MetroFramework.Controls.MetroTile();
            this.contentTile = new MetroFramework.Controls.MetroTile();
            this.steamTile = new MetroFramework.Controls.MetroTile();
            this.mainFormToolTip = new MetroFramework.Components.MetroToolTip();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.optionsBtn = new MetroFramework.Controls.MetroTile();
            this.customTile1 = new MetroFramework.Controls.MetroTile();
            this.tileContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.editTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customTile2 = new MetroFramework.Controls.MetroTile();
            this.customTile3 = new MetroFramework.Controls.MetroTile();
            this.customTile4 = new MetroFramework.Controls.MetroTile();
            this.customTile5 = new MetroFramework.Controls.MetroTile();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.donateBtn = new MetroFramework.Controls.MetroLink();
            this.progressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.versionLabel = new MetroFramework.Controls.MetroLink();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.addonsPanel = new MetroFramework.Controls.MetroPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.spellLibraryTab = new MetroFramework.Controls.MetroTabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.decompilerTab = new MetroFramework.Controls.MetroTabPage();
            this.optionsTab = new MetroFramework.Controls.MetroTabPage();
            this.decompileVtexButton = new MetroFramework.Controls.MetroButton();
            this.compileVtexButton = new MetroFramework.Controls.MetroButton();
            this.addonTileContextMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.toolsTab.SuspendLayout();
            this.linksTab.SuspendLayout();
            this.tileContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.decompilerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateAddonLangsBtn
            // 
            this.generateAddonLangsBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.generateAddonLangsBtn.Location = new System.Drawing.Point(180, 12);
            this.generateAddonLangsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.generateAddonLangsBtn.Name = "generateAddonLangsBtn";
            this.generateAddonLangsBtn.Size = new System.Drawing.Size(168, 68);
            this.generateAddonLangsBtn.TabIndex = 1;
            this.generateAddonLangsBtn.TabStop = false;
            this.generateAddonLangsBtn.Text = "Generate Tooltips";
            this.generateAddonLangsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.generateAddonLangsBtn, "Generates tooltips from the scripts/npc files of this addon,\r\nwhich you can easil" +
        "y transfer over to addon_language.txt\r\nfiles.");
            this.generateAddonLangsBtn.UseSelectable = true;
            this.generateAddonLangsBtn.Click += new System.EventHandler(this.generateAddonLangsBtn_Click);
            // 
            // addonTile
            // 
            this.addonTile.ActiveControl = null;
            this.addonTile.ContextMenuStrip = this.addonTileContextMenu;
            this.addonTile.Location = new System.Drawing.Point(12, 62);
            this.addonTile.Name = "addonTile";
            this.addonTile.Size = new System.Drawing.Size(172, 120);
            this.addonTile.Style = MetroFramework.MetroColorStyle.Blue;
            this.addonTile.TabIndex = 0;
            this.addonTile.Text = "AddonName";
            this.addonTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mainFormToolTip.SetToolTip(this.addonTile, "zxdfgsdfgsdf");
            this.addonTile.UseSelectable = true;
            this.addonTile.UseTileImage = true;
            this.addonTile.Click += new System.EventHandler(this.addonTile_Click);
            // 
            // addonTileContextMenu
            // 
            this.addonTileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePictureToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.deleteAddonToolStripMenuItem});
            this.addonTileContextMenu.Name = "metroContextMenu1";
            this.addonTileContextMenu.Size = new System.Drawing.Size(156, 70);
            this.addonTileContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // changePictureToolStripMenuItem
            // 
            this.changePictureToolStripMenuItem.Enabled = false;
            this.changePictureToolStripMenuItem.Name = "changePictureToolStripMenuItem";
            this.changePictureToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.changePictureToolStripMenuItem.Text = "Change Picture";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // deleteAddonToolStripMenuItem
            // 
            this.deleteAddonToolStripMenuItem.Name = "deleteAddonToolStripMenuItem";
            this.deleteAddonToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteAddonToolStripMenuItem.Text = "Delete Addon";
            this.deleteAddonToolStripMenuItem.Click += new System.EventHandler(this.deleteAddonBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.toolsTab);
            this.tabControl.Controls.Add(this.spellLibraryTab);
            this.tabControl.Controls.Add(this.particlesTab);
            this.tabControl.Controls.Add(this.decompilerTab);
            this.tabControl.Controls.Add(this.linksTab);
            this.tabControl.Controls.Add(this.optionsTab);
            this.tabControl.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.tabControl.ItemSize = new System.Drawing.Size(40, 25);
            this.tabControl.Location = new System.Drawing.Point(282, 54);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 4;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(990, 656);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 2;
            this.tabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl.UseSelectable = true;
            // 
            // toolsTab
            // 
            this.toolsTab.Controls.Add(this.compileCoffeeBtn);
            this.toolsTab.Controls.Add(this.findSoundNameBtn);
            this.toolsTab.Controls.Add(this.combineKVBtn);
            this.toolsTab.Controls.Add(this.generateAddonLangsBtn);
            this.toolsTab.Controls.Add(this.customTile5);
            this.toolsTab.Controls.Add(this.customTile2);
            this.toolsTab.Controls.Add(this.metroComboBox1);
            this.toolsTab.Controls.Add(this.customTile1);
            this.toolsTab.Controls.Add(this.pictureBox1);
            this.toolsTab.Controls.Add(this.optionsBtn);
            this.toolsTab.Controls.Add(this.customTile3);
            this.toolsTab.Controls.Add(this.customTile4);
            this.toolsTab.Controls.Add(this.progressSpinner1);
            this.toolsTab.Controls.Add(this.notificationLabel);
            this.toolsTab.Controls.Add(this.metroTile1);
            this.toolsTab.Controls.Add(this.gameTile);
            this.toolsTab.Controls.Add(this.steamTile);
            this.toolsTab.Controls.Add(this.contentTile);
            this.toolsTab.HorizontalScrollbarBarColor = true;
            this.toolsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.toolsTab.HorizontalScrollbarSize = 1;
            this.toolsTab.Location = new System.Drawing.Point(4, 29);
            this.toolsTab.Name = "toolsTab";
            this.toolsTab.Size = new System.Drawing.Size(982, 623);
            this.toolsTab.TabIndex = 0;
            this.toolsTab.Text = "Tools";
            this.toolsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolsTab.ToolTipText = "Tools page 1";
            this.toolsTab.VerticalScrollbarBarColor = true;
            this.toolsTab.VerticalScrollbarHighlightOnWheel = false;
            this.toolsTab.VerticalScrollbarSize = 2;
            // 
            // compileCoffeeBtn
            // 
            this.compileCoffeeBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.compileCoffeeBtn.Location = new System.Drawing.Point(180, 86);
            this.compileCoffeeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.compileCoffeeBtn.Name = "compileCoffeeBtn";
            this.compileCoffeeBtn.Size = new System.Drawing.Size(168, 68);
            this.compileCoffeeBtn.TabIndex = 8;
            this.compileCoffeeBtn.TabStop = false;
            this.compileCoffeeBtn.Text = "CoffeeScript -> JS";
            this.compileCoffeeBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.compileCoffeeBtn, "Compiles CoffeeScript files in the panorama/scripts/coffeescript\r\ndirectory to Ja" +
        "vaScript files in panorama/scripts");
            this.compileCoffeeBtn.UseSelectable = true;
            this.compileCoffeeBtn.Click += new System.EventHandler(this.compileCoffeeBtn_Click);
            // 
            // findSoundNameBtn
            // 
            this.findSoundNameBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.findSoundNameBtn.Location = new System.Drawing.Point(6, 86);
            this.findSoundNameBtn.Margin = new System.Windows.Forms.Padding(4);
            this.findSoundNameBtn.Name = "findSoundNameBtn";
            this.findSoundNameBtn.Size = new System.Drawing.Size(168, 68);
            this.findSoundNameBtn.TabIndex = 6;
            this.findSoundNameBtn.TabStop = false;
            this.findSoundNameBtn.Text = "Find SoundName";
            this.findSoundNameBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.findSoundNameBtn, "Search for Sound Names with a .vsnd path");
            this.findSoundNameBtn.UseSelectable = true;
            this.findSoundNameBtn.Click += new System.EventHandler(this.findSoundNameBtn_Click);
            // 
            // combineKVBtn
            // 
            this.combineKVBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.combineKVBtn.Location = new System.Drawing.Point(6, 12);
            this.combineKVBtn.Margin = new System.Windows.Forms.Padding(4);
            this.combineKVBtn.Name = "combineKVBtn";
            this.combineKVBtn.Size = new System.Drawing.Size(168, 68);
            this.combineKVBtn.TabIndex = 3;
            this.combineKVBtn.TabStop = false;
            this.combineKVBtn.Text = "Combine KV Files";
            this.combineKVBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.combineKVBtn, "Combines KV files in the scripts/npc directory of this\r\naddon. Prompts to break u" +
        "p the KV files if not done so\r\nalready.");
            this.combineKVBtn.UseSelectable = true;
            this.combineKVBtn.Click += new System.EventHandler(this.combineKVBtn_Click);
            // 
            // particlesTab
            // 
            this.particlesTab.HorizontalScrollbarBarColor = true;
            this.particlesTab.HorizontalScrollbarHighlightOnWheel = false;
            this.particlesTab.HorizontalScrollbarSize = 1;
            this.particlesTab.Location = new System.Drawing.Point(4, 29);
            this.particlesTab.Name = "particlesTab";
            this.particlesTab.Size = new System.Drawing.Size(982, 623);
            this.particlesTab.TabIndex = 4;
            this.particlesTab.Text = "Particle Designer";
            this.particlesTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.particlesTab.ToolTipText = "Tools page 2";
            this.particlesTab.VerticalScrollbarBarColor = true;
            this.particlesTab.VerticalScrollbarHighlightOnWheel = false;
            this.particlesTab.VerticalScrollbarSize = 2;
            // 
            // linksTab
            // 
            this.linksTab.Controls.Add(this.metroLink12);
            this.linksTab.Controls.Add(this.metroLink11);
            this.linksTab.Controls.Add(this.metroLink10);
            this.linksTab.Controls.Add(this.metroLink9);
            this.linksTab.Controls.Add(this.metroLink8);
            this.linksTab.Controls.Add(this.metroLink7);
            this.linksTab.Controls.Add(this.metroLink6);
            this.linksTab.Controls.Add(this.goBtn);
            this.linksTab.Controls.Add(this.jsRadioButton);
            this.linksTab.Controls.Add(this.textRadioButton);
            this.linksTab.Controls.Add(this.luaRadioBtn);
            this.linksTab.Controls.Add(this.addonNameLabel);
            this.linksTab.Controls.Add(this.githubTextBox);
            this.linksTab.Controls.Add(this.metroLink5);
            this.linksTab.Controls.Add(this.metroLink4);
            this.linksTab.Controls.Add(this.metroLink3);
            this.linksTab.Controls.Add(this.metroLink2);
            this.linksTab.Controls.Add(this.metroLink1);
            this.linksTab.HorizontalScrollbarBarColor = true;
            this.linksTab.HorizontalScrollbarHighlightOnWheel = false;
            this.linksTab.HorizontalScrollbarSize = 1;
            this.linksTab.Location = new System.Drawing.Point(4, 29);
            this.linksTab.Name = "linksTab";
            this.linksTab.Size = new System.Drawing.Size(982, 623);
            this.linksTab.TabIndex = 3;
            this.linksTab.Text = "Links";
            this.linksTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.linksTab.ToolTipText = "Help related tools";
            this.linksTab.VerticalScrollbarBarColor = true;
            this.linksTab.VerticalScrollbarHighlightOnWheel = false;
            this.linksTab.VerticalScrollbarSize = 2;
            // 
            // metroLink12
            // 
            this.metroLink12.Location = new System.Drawing.Point(166, 196);
            this.metroLink12.Name = "metroLink12";
            this.metroLink12.Size = new System.Drawing.Size(62, 18);
            this.metroLink12.TabIndex = 19;
            this.metroLink12.Text = "dev.dota";
            this.metroLink12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink12.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink12.UseSelectable = true;
            this.metroLink12.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink11
            // 
            this.metroLink11.Location = new System.Drawing.Point(87, 196);
            this.metroLink11.Name = "metroLink11";
            this.metroLink11.Size = new System.Drawing.Size(73, 18);
            this.metroLink11.TabIndex = 18;
            this.metroLink11.Text = "SpellLibrary";
            this.metroLink11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink11.UseSelectable = true;
            this.metroLink11.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink10
            // 
            this.metroLink10.Location = new System.Drawing.Point(269, 148);
            this.metroLink10.Name = "metroLink10";
            this.metroLink10.Size = new System.Drawing.Size(31, 18);
            this.metroLink10.TabIndex = 17;
            this.metroLink10.Text = "VPK";
            this.metroLink10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink10.UseSelectable = true;
            this.metroLink10.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink9
            // 
            this.metroLink9.Location = new System.Drawing.Point(154, 172);
            this.metroLink9.Name = "metroLink9";
            this.metroLink9.Size = new System.Drawing.Size(83, 18);
            this.metroLink9.TabIndex = 16;
            this.metroLink9.Text = "Ability Names";
            this.metroLink9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink9.UseSelectable = true;
            this.metroLink9.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink8
            // 
            this.metroLink8.Location = new System.Drawing.Point(144, 148);
            this.metroLink8.Name = "metroLink8";
            this.metroLink8.Size = new System.Drawing.Size(84, 18);
            this.metroLink8.TabIndex = 15;
            this.metroLink8.Text = "Panorama API";
            this.metroLink8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink8.UseSelectable = true;
            this.metroLink8.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink7
            // 
            this.metroLink7.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroLink7.Location = new System.Drawing.Point(42, 70);
            this.metroLink7.Name = "metroLink7";
            this.metroLink7.Size = new System.Drawing.Size(72, 36);
            this.metroLink7.TabIndex = 14;
            this.metroLink7.Text = "Lua API";
            this.metroLink7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink7.UseSelectable = true;
            this.metroLink7.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink6
            // 
            this.metroLink6.Location = new System.Drawing.Point(243, 172);
            this.metroLink6.Name = "metroLink6";
            this.metroLink6.Size = new System.Drawing.Size(82, 18);
            this.metroLink6.TabIndex = 13;
            this.metroLink6.Text = "Lua Modifiers";
            this.metroLink6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink6.UseSelectable = true;
            this.metroLink6.Click += new System.EventHandler(this.onLink_Click);
            // 
            // goBtn
            // 
            this.goBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.goBtn.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.goBtn.Location = new System.Drawing.Point(344, 14);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(70, 30);
            this.goBtn.TabIndex = 7;
            this.goBtn.Text = "Search";
            this.goBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.goBtn.UseSelectable = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // jsRadioButton
            // 
            this.jsRadioButton.AutoSize = true;
            this.jsRadioButton.Location = new System.Drawing.Point(226, 128);
            this.jsRadioButton.Name = "jsRadioButton";
            this.jsRadioButton.Size = new System.Drawing.Size(33, 15);
            this.jsRadioButton.TabIndex = 12;
            this.jsRadioButton.Text = "JS";
            this.jsRadioButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.jsRadioButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.jsRadioButton.UseSelectable = true;
            // 
            // textRadioButton
            // 
            this.textRadioButton.AutoSize = true;
            this.textRadioButton.Location = new System.Drawing.Point(186, 128);
            this.textRadioButton.Name = "textRadioButton";
            this.textRadioButton.Size = new System.Drawing.Size(37, 15);
            this.textRadioButton.TabIndex = 11;
            this.textRadioButton.Text = "KV";
            this.textRadioButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.textRadioButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textRadioButton.UseSelectable = true;
            // 
            // luaRadioBtn
            // 
            this.luaRadioBtn.AutoSize = true;
            this.luaRadioBtn.Location = new System.Drawing.Point(142, 128);
            this.luaRadioBtn.Name = "luaRadioBtn";
            this.luaRadioBtn.Size = new System.Drawing.Size(42, 15);
            this.luaRadioBtn.TabIndex = 10;
            this.luaRadioBtn.Text = "Lua";
            this.luaRadioBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.luaRadioBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.luaRadioBtn.UseSelectable = true;
            // 
            // addonNameLabel
            // 
            this.addonNameLabel.AutoSize = true;
            this.addonNameLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.addonNameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.addonNameLabel.Location = new System.Drawing.Point(36, 18);
            this.addonNameLabel.Name = "addonNameLabel";
            this.addonNameLabel.Size = new System.Drawing.Size(72, 25);
            this.addonNameLabel.Style = MetroFramework.MetroColorStyle.Lime;
            this.addonNameLabel.TabIndex = 9;
            this.addonNameLabel.Text = "GitHub:";
            this.addonNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addonNameLabel.UseStyleColors = true;
            // 
            // githubTextBox
            // 
            // 
            // 
            // 
            this.githubTextBox.CustomButton.Image = null;
            this.githubTextBox.CustomButton.Location = new System.Drawing.Point(98, 1);
            this.githubTextBox.CustomButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.githubTextBox.CustomButton.Name = "";
            this.githubTextBox.CustomButton.Size = new System.Drawing.Size(16, 14);
            this.githubTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.githubTextBox.CustomButton.TabIndex = 1;
            this.githubTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.githubTextBox.CustomButton.UseSelectable = true;
            this.githubTextBox.CustomButton.Visible = false;
            this.githubTextBox.Lines = new string[0];
            this.githubTextBox.Location = new System.Drawing.Point(114, 20);
            this.githubTextBox.MaxLength = 32767;
            this.githubTextBox.Name = "githubTextBox";
            this.githubTextBox.PasswordChar = '\0';
            this.githubTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.githubTextBox.SelectedText = "";
            this.githubTextBox.SelectionLength = 0;
            this.githubTextBox.SelectionStart = 0;
            this.githubTextBox.Size = new System.Drawing.Size(220, 23);
            this.githubTextBox.TabIndex = 7;
            this.githubTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.githubTextBox.UseSelectable = true;
            this.githubTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.githubTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLink5
            // 
            this.metroLink5.Location = new System.Drawing.Point(87, 220);
            this.metroLink5.Name = "metroLink5";
            this.metroLink5.Size = new System.Drawing.Size(83, 18);
            this.metroLink5.TabIndex = 6;
            this.metroLink5.Text = "GetDotaStats";
            this.metroLink5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink5.UseSelectable = true;
            this.metroLink5.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink4
            // 
            this.metroLink4.Location = new System.Drawing.Point(234, 148);
            this.metroLink4.Name = "metroLink4";
            this.metroLink4.Size = new System.Drawing.Size(29, 18);
            this.metroLink4.TabIndex = 5;
            this.metroLink4.Text = "IRC";
            this.metroLink4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink4.UseSelectable = true;
            this.metroLink4.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink3
            // 
            this.metroLink3.Location = new System.Drawing.Point(234, 196);
            this.metroLink3.Name = "metroLink3";
            this.metroLink3.Size = new System.Drawing.Size(100, 18);
            this.metroLink3.TabIndex = 4;
            this.metroLink3.Text = "r/Dota2Modding";
            this.metroLink3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink3.UseSelectable = true;
            this.metroLink3.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink2
            // 
            this.metroLink2.Location = new System.Drawing.Point(176, 220);
            this.metroLink2.Name = "metroLink2";
            this.metroLink2.Size = new System.Drawing.Size(64, 18);
            this.metroLink2.TabIndex = 3;
            this.metroLink2.Text = "Workshop";
            this.metroLink2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink2.UseSelectable = true;
            this.metroLink2.Click += new System.EventHandler(this.onLink_Click);
            // 
            // metroLink1
            // 
            this.metroLink1.Location = new System.Drawing.Point(87, 172);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(61, 18);
            this.metroLink1.TabIndex = 2;
            this.metroLink1.Text = "ModDota";
            this.metroLink1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLink1.UseSelectable = true;
            this.metroLink1.Click += new System.EventHandler(this.onLink_Click);
            // 
            // notificationLabel
            // 
            this.notificationLabel.AutoSize = true;
            this.notificationLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.notificationLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.notificationLabel.ForeColor = System.Drawing.Color.Maroon;
            this.notificationLabel.Location = new System.Drawing.Point(302, 309);
            this.notificationLabel.Name = "notificationLabel";
            this.notificationLabel.Size = new System.Drawing.Size(153, 25);
            this.notificationLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.notificationLabel.TabIndex = 5;
            this.notificationLabel.Text = "notificationLabelg";
            this.notificationLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.notificationLabel.UseStyleColors = true;
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(200, -5);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(127, 15);
            this.metroRadioButton1.TabIndex = 6;
            this.metroRadioButton1.Text = "metroRadioButton1";
            this.metroRadioButton1.UseSelectable = true;
            this.metroRadioButton1.Visible = false;
            // 
            // gameTile
            // 
            this.gameTile.ActiveControl = null;
            this.gameTile.Location = new System.Drawing.Point(420, 394);
            this.gameTile.Name = "gameTile";
            this.gameTile.Size = new System.Drawing.Size(36, 28);
            this.gameTile.Style = MetroFramework.MetroColorStyle.Blue;
            this.gameTile.TabIndex = 7;
            this.gameTile.Text = "G";
            this.gameTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.gameTile, "Open the game directory of this addon.");
            this.gameTile.UseSelectable = true;
            this.gameTile.UseTileImage = true;
            this.gameTile.Click += new System.EventHandler(this.shortcutTile_Click);
            // 
            // contentTile
            // 
            this.contentTile.ActiveControl = null;
            this.contentTile.Location = new System.Drawing.Point(450, 450);
            this.contentTile.Name = "contentTile";
            this.contentTile.Size = new System.Drawing.Size(36, 28);
            this.contentTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.contentTile.TabIndex = 10;
            this.contentTile.Text = "C";
            this.contentTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.contentTile, "Open the content directory of this addon.");
            this.contentTile.UseSelectable = true;
            this.contentTile.UseTileImage = true;
            this.contentTile.Click += new System.EventHandler(this.shortcutTile_Click);
            // 
            // steamTile
            // 
            this.steamTile.ActiveControl = null;
            this.steamTile.Location = new System.Drawing.Point(454, 359);
            this.steamTile.Name = "steamTile";
            this.steamTile.Size = new System.Drawing.Size(36, 28);
            this.steamTile.Style = MetroFramework.MetroColorStyle.Silver;
            this.steamTile.TabIndex = 14;
            this.steamTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.steamTile, "Open the Steam Workshop page for this addon.");
            this.steamTile.UseSelectable = true;
            this.steamTile.UseTileImage = true;
            this.steamTile.Click += new System.EventHandler(this.workshopPageBtn_Click);
            // 
            // mainFormToolTip
            // 
            this.mainFormToolTip.AutoPopDelay = 8000;
            this.mainFormToolTip.InitialDelay = 500;
            this.mainFormToolTip.ReshowDelay = 100;
            this.mainFormToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.mainFormToolTip.StyleManager = null;
            this.mainFormToolTip.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(270, 421);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(40, 28);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile1.TabIndex = 16;
            this.metroTile1.Text = "VPK";
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.metroTile1, "Open the Dota 2 VPK (requires GCFScape)");
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.shortcutTile_Click);
            // 
            // optionsBtn
            // 
            this.optionsBtn.ActiveControl = null;
            this.optionsBtn.Location = new System.Drawing.Point(528, 319);
            this.optionsBtn.Name = "optionsBtn";
            this.optionsBtn.Size = new System.Drawing.Size(36, 28);
            this.optionsBtn.Style = MetroFramework.MetroColorStyle.Silver;
            this.optionsBtn.TabIndex = 18;
            this.optionsBtn.Text = "O";
            this.optionsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.optionsBtn, "Open the Options page");
            this.optionsBtn.UseSelectable = true;
            this.optionsBtn.UseTileImage = true;
            this.optionsBtn.Click += new System.EventHandler(this.optionsBtn_Click);
            // 
            // customTile1
            // 
            this.customTile1.ActiveControl = null;
            this.customTile1.ContextMenuStrip = this.tileContextMenu;
            this.customTile1.Location = new System.Drawing.Point(600, 388);
            this.customTile1.Name = "customTile1";
            this.customTile1.Size = new System.Drawing.Size(36, 28);
            this.customTile1.Style = MetroFramework.MetroColorStyle.Purple;
            this.customTile1.TabIndex = 22;
            this.customTile1.Text = "?";
            this.customTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.customTile1, "Click to customize this tile!");
            this.customTile1.UseSelectable = true;
            this.customTile1.UseTileImage = true;
            // 
            // tileContextMenu
            // 
            this.tileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTileToolStripMenuItem});
            this.tileContextMenu.Name = "metroContextMenu2";
            this.tileContextMenu.Size = new System.Drawing.Size(117, 26);
            this.tileContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // editTileToolStripMenuItem
            // 
            this.editTileToolStripMenuItem.Name = "editTileToolStripMenuItem";
            this.editTileToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.editTileToolStripMenuItem.Text = "Edit Tile";
            this.editTileToolStripMenuItem.Click += new System.EventHandler(this.editTileToolStripMenuItem_Click);
            // 
            // customTile2
            // 
            this.customTile2.ActiveControl = null;
            this.customTile2.ContextMenuStrip = this.tileContextMenu;
            this.customTile2.Location = new System.Drawing.Point(528, 245);
            this.customTile2.Name = "customTile2";
            this.customTile2.Size = new System.Drawing.Size(36, 28);
            this.customTile2.Style = MetroFramework.MetroColorStyle.Brown;
            this.customTile2.TabIndex = 23;
            this.customTile2.Text = "?";
            this.customTile2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.customTile2, "Click to customize this tile!");
            this.customTile2.UseSelectable = true;
            this.customTile2.UseTileImage = true;
            // 
            // customTile3
            // 
            this.customTile3.ActiveControl = null;
            this.customTile3.ContextMenuStrip = this.tileContextMenu;
            this.customTile3.Location = new System.Drawing.Point(520, 420);
            this.customTile3.Name = "customTile3";
            this.customTile3.Size = new System.Drawing.Size(36, 28);
            this.customTile3.Style = MetroFramework.MetroColorStyle.Yellow;
            this.customTile3.TabIndex = 24;
            this.customTile3.Text = "?";
            this.customTile3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.customTile3, "Click to customize this tile!");
            this.customTile3.UseSelectable = true;
            this.customTile3.UseTileImage = true;
            // 
            // customTile4
            // 
            this.customTile4.ActiveControl = null;
            this.customTile4.ContextMenuStrip = this.tileContextMenu;
            this.customTile4.Location = new System.Drawing.Point(600, 420);
            this.customTile4.Name = "customTile4";
            this.customTile4.Size = new System.Drawing.Size(36, 28);
            this.customTile4.Style = MetroFramework.MetroColorStyle.Lime;
            this.customTile4.TabIndex = 25;
            this.customTile4.Text = "?";
            this.customTile4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.customTile4, "Click to customize this tile!");
            this.customTile4.UseSelectable = true;
            this.customTile4.UseTileImage = true;
            // 
            // customTile5
            // 
            this.customTile5.ActiveControl = null;
            this.customTile5.ContextMenuStrip = this.tileContextMenu;
            this.customTile5.Location = new System.Drawing.Point(560, 420);
            this.customTile5.Name = "customTile5";
            this.customTile5.Size = new System.Drawing.Size(36, 28);
            this.customTile5.Style = MetroFramework.MetroColorStyle.Magenta;
            this.customTile5.TabIndex = 26;
            this.customTile5.Text = "?";
            this.customTile5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.customTile5, "Click to customize this tile!");
            this.customTile5.UseSelectable = true;
            this.customTile5.UseTileImage = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(758, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            this.mainFormToolTip.SetToolTip(this.pictureBox2, "Report a bug!");
            this.pictureBox2.Click += new System.EventHandler(this.reportBug_Click);
            // 
            // donateBtn
            // 
            this.donateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.donateBtn.Location = new System.Drawing.Point(516, 14);
            this.donateBtn.Name = "donateBtn";
            this.donateBtn.Size = new System.Drawing.Size(56, 20);
            this.donateBtn.Style = MetroFramework.MetroColorStyle.Yellow;
            this.donateBtn.TabIndex = 28;
            this.donateBtn.Text = "Donate!";
            this.donateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.donateBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.donateBtn, "Consider a donation to the developer!");
            this.donateBtn.UseSelectable = true;
            this.donateBtn.UseStyleColors = true;
            this.donateBtn.Click += new System.EventHandler(this.donateBtn_Click);
            // 
            // progressSpinner1
            // 
            this.progressSpinner1.Location = new System.Drawing.Point(370, 212);
            this.progressSpinner1.Maximum = 100;
            this.progressSpinner1.Name = "progressSpinner1";
            this.progressSpinner1.Size = new System.Drawing.Size(24, 24);
            this.progressSpinner1.TabIndex = 19;
            this.progressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressSpinner1.UseSelectable = true;
            this.progressSpinner1.Value = 80;
            this.progressSpinner1.Visible = false;
            // 
            // versionLabel
            // 
            this.versionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.versionLabel.Location = new System.Drawing.Point(650, 34);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(52, 20);
            this.versionLabel.TabIndex = 21;
            this.versionLabel.Text = "v2.x.x.x";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.versionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.versionLabel.UseSelectable = true;
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(350, 387);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(314, 453);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 29);
            this.metroComboBox1.TabIndex = 30;
            this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.Visible = false;
            // 
            // addonsPanel
            // 
            this.addonsPanel.AutoScroll = true;
            this.addonsPanel.HorizontalScrollbar = true;
            this.addonsPanel.HorizontalScrollbarBarColor = true;
            this.addonsPanel.HorizontalScrollbarHighlightOnWheel = true;
            this.addonsPanel.HorizontalScrollbarSize = 10;
            this.addonsPanel.Location = new System.Drawing.Point(12, 186);
            this.addonsPanel.Name = "addonsPanel";
            this.addonsPanel.Size = new System.Drawing.Size(172, 520);
            this.addonsPanel.TabIndex = 32;
            this.addonsPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addonsPanel.UseStyleColors = true;
            this.addonsPanel.VerticalScrollbar = true;
            this.addonsPanel.VerticalScrollbarBarColor = true;
            this.addonsPanel.VerticalScrollbarHighlightOnWheel = false;
            this.addonsPanel.VerticalScrollbarSize = 9;
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.Location = new System.Drawing.Point(192, 64);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(84, 57);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.TabIndex = 33;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "Game";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.metroButton1, "Combines KV files in the scripts/npc directory of this\r\naddon. Prompts to break u" +
        "p the KV files if not done so\r\nalready.");
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            // 
            // spellLibraryTab
            // 
            this.spellLibraryTab.HorizontalScrollbarBarColor = true;
            this.spellLibraryTab.HorizontalScrollbarHighlightOnWheel = false;
            this.spellLibraryTab.HorizontalScrollbarSize = 10;
            this.spellLibraryTab.Location = new System.Drawing.Point(4, 29);
            this.spellLibraryTab.Name = "spellLibraryTab";
            this.spellLibraryTab.Size = new System.Drawing.Size(982, 623);
            this.spellLibraryTab.TabIndex = 5;
            this.spellLibraryTab.Text = "SpellLibrary";
            this.spellLibraryTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.spellLibraryTab.VerticalScrollbarBarColor = true;
            this.spellLibraryTab.VerticalScrollbarHighlightOnWheel = false;
            this.spellLibraryTab.VerticalScrollbarSize = 10;
            // 
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton2.Location = new System.Drawing.Point(192, 126);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(84, 57);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroButton2.TabIndex = 34;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "Content";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.metroButton2, "Combines KV files in the scripts/npc directory of this\r\naddon. Prompts to break u" +
        "p the KV files if not done so\r\nalready.");
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            // 
            // metroButton3
            // 
            this.metroButton3.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton3.Location = new System.Drawing.Point(192, 188);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(84, 57);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButton3.TabIndex = 35;
            this.metroButton3.TabStop = false;
            this.metroButton3.Text = "VPK";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.metroButton3, "Combines KV files in the scripts/npc directory of this\r\naddon. Prompts to break u" +
        "p the KV files if not done so\r\nalready.");
            this.metroButton3.UseSelectable = true;
            this.metroButton3.UseStyleColors = true;
            // 
            // decompilerTab
            // 
            this.decompilerTab.Controls.Add(this.decompileVtexButton);
            this.decompilerTab.Controls.Add(this.compileVtexButton);
            this.decompilerTab.HorizontalScrollbarBarColor = true;
            this.decompilerTab.HorizontalScrollbarHighlightOnWheel = false;
            this.decompilerTab.HorizontalScrollbarSize = 10;
            this.decompilerTab.Location = new System.Drawing.Point(4, 29);
            this.decompilerTab.Name = "decompilerTab";
            this.decompilerTab.Size = new System.Drawing.Size(982, 623);
            this.decompilerTab.TabIndex = 6;
            this.decompilerTab.Text = "Decompiler";
            this.decompilerTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.decompilerTab.VerticalScrollbarBarColor = true;
            this.decompilerTab.VerticalScrollbarHighlightOnWheel = false;
            this.decompilerTab.VerticalScrollbarSize = 10;
            // 
            // optionsTab
            // 
            this.optionsTab.HorizontalScrollbarBarColor = true;
            this.optionsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.optionsTab.HorizontalScrollbarSize = 10;
            this.optionsTab.Location = new System.Drawing.Point(4, 29);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(982, 623);
            this.optionsTab.TabIndex = 7;
            this.optionsTab.Text = "Options";
            this.optionsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.optionsTab.VerticalScrollbarBarColor = true;
            this.optionsTab.VerticalScrollbarHighlightOnWheel = false;
            this.optionsTab.VerticalScrollbarSize = 10;
            // 
            // decompileVtexButton
            // 
            this.decompileVtexButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.decompileVtexButton.Location = new System.Drawing.Point(224, 211);
            this.decompileVtexButton.Margin = new System.Windows.Forms.Padding(4);
            this.decompileVtexButton.Name = "decompileVtexButton";
            this.decompileVtexButton.Size = new System.Drawing.Size(125, 33);
            this.decompileVtexButton.TabIndex = 8;
            this.decompileVtexButton.TabStop = false;
            this.decompileVtexButton.Text = ".vtex_c -> .tga";
            this.decompileVtexButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.decompileVtexButton.UseSelectable = true;
            // 
            // compileVtexButton
            // 
            this.compileVtexButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.compileVtexButton.Location = new System.Drawing.Point(146, 62);
            this.compileVtexButton.Margin = new System.Windows.Forms.Padding(4);
            this.compileVtexButton.Name = "compileVtexButton";
            this.compileVtexButton.Size = new System.Drawing.Size(125, 33);
            this.compileVtexButton.TabIndex = 7;
            this.compileVtexButton.TabStop = false;
            this.compileVtexButton.Text = ".tga -> .vtex_c";
            this.compileVtexButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.compileVtexButton.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.addonsPanel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.donateBtn);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroRadioButton1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.addonTile);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dota 2 ModKit";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addonTileContextMenu.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.toolsTab.ResumeLayout(false);
            this.toolsTab.PerformLayout();
            this.linksTab.ResumeLayout(false);
            this.linksTab.PerformLayout();
            this.tileContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.decompilerTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroButton generateAddonLangsBtn;
		private MetroFramework.Controls.MetroTabControl tabControl;
		private MetroFramework.Controls.MetroTabPage toolsTab;
		private MetroFramework.Controls.MetroButton combineKVBtn;
		private MetroFramework.Controls.MetroLabel notificationLabel;
		private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
		private MetroFramework.Controls.MetroTabPage linksTab;
		private MetroFramework.Controls.MetroLink metroLink5;
		private MetroFramework.Controls.MetroLink metroLink4;
		private MetroFramework.Controls.MetroLink metroLink3;
		private MetroFramework.Controls.MetroLink metroLink2;
		private MetroFramework.Controls.MetroLink metroLink1;
		private MetroFramework.Controls.MetroTextBox githubTextBox;
		private MetroFramework.Controls.MetroLabel addonNameLabel;
		private MetroFramework.Controls.MetroRadioButton textRadioButton;
		private MetroFramework.Controls.MetroRadioButton luaRadioBtn;
		private MetroFramework.Controls.MetroRadioButton jsRadioButton;
		private MetroFramework.Controls.MetroButton goBtn;
		private MetroFramework.Controls.MetroLink metroLink8;
		private MetroFramework.Controls.MetroLink metroLink7;
		private MetroFramework.Controls.MetroLink metroLink6;
		private MetroFramework.Controls.MetroLink metroLink9;
		private MetroFramework.Controls.MetroLink metroLink10;
		private MetroFramework.Controls.MetroLink metroLink11;
		private MetroFramework.Controls.MetroTile gameTile;
		private MetroFramework.Controls.MetroTile contentTile;
		private MetroFramework.Controls.MetroTile steamTile;
		private MetroFramework.Controls.MetroLink metroLink12;
		private MetroFramework.Components.MetroToolTip mainFormToolTip;
		private MetroFramework.Controls.MetroContextMenu addonTileContextMenu;
		private System.Windows.Forms.ToolStripMenuItem changePictureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteAddonToolStripMenuItem;
		private MetroFramework.Controls.MetroTile metroTile1;
		private MetroFramework.Controls.MetroTile optionsBtn;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private MetroFramework.Controls.MetroButton findSoundNameBtn;
		private MetroFramework.Controls.MetroTabPage particlesTab;
		private MetroFramework.Controls.MetroProgressSpinner progressSpinner1;
		private MetroFramework.Controls.MetroLink versionLabel;
		private MetroFramework.Controls.MetroButton compileCoffeeBtn;
		private MetroFramework.Controls.MetroTile customTile1;
		private MetroFramework.Controls.MetroTile customTile2;
		private MetroFramework.Controls.MetroTile customTile3;
		private MetroFramework.Controls.MetroTile customTile4;
		private MetroFramework.Controls.MetroTile customTile5;
		private MetroFramework.Controls.MetroContextMenu tileContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editTileToolStripMenuItem;
		private MetroFramework.Controls.MetroLink donateBtn;
		private System.Windows.Forms.PictureBox pictureBox1;
		private MetroFramework.Controls.MetroComboBox metroComboBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroPanel addonsPanel;
        public MetroFramework.Controls.MetroTile addonTile;
        private MetroFramework.Controls.MetroTabPage spellLibraryTab;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroTabPage decompilerTab;
        private MetroFramework.Controls.MetroTabPage optionsTab;
        private MetroFramework.Controls.MetroButton decompileVtexButton;
        private MetroFramework.Controls.MetroButton compileVtexButton;
    }
}
