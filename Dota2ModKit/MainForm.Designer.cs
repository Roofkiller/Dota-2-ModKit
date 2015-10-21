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
			this.spellLibraryBtn = new MetroFramework.Controls.MetroButton();
			this.findSoundNameBtn = new MetroFramework.Controls.MetroButton();
			this.combineKVBtn = new MetroFramework.Controls.MetroButton();
			this.particleDesignBtn = new MetroFramework.Controls.MetroButton();
			this.tools2Tab = new MetroFramework.Controls.MetroTabPage();
			this.decompileVtexButton = new MetroFramework.Controls.MetroButton();
			this.compileVtexButton = new MetroFramework.Controls.MetroButton();
			this.helpTab = new MetroFramework.Controls.MetroTabPage();
			this.metroLink12 = new MetroFramework.Controls.MetroLink();
			this.metroLink11 = new MetroFramework.Controls.MetroLink();
			this.metroLink10 = new MetroFramework.Controls.MetroLink();
			this.metroLink9 = new MetroFramework.Controls.MetroLink();
			this.metroLink8 = new MetroFramework.Controls.MetroLink();
			this.metroLink7 = new MetroFramework.Controls.MetroLink();
			this.metroLink6 = new MetroFramework.Controls.MetroLink();
			this.githubGoBtn = new MetroFramework.Controls.MetroButton();
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
			this.vpkTile = new MetroFramework.Controls.MetroTile();
			this.optionsTile = new MetroFramework.Controls.MetroTile();
			this.customTile1 = new MetroFramework.Controls.MetroTile();
			this.tileContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
			this.editTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customTile2 = new MetroFramework.Controls.MetroTile();
			this.customTile3 = new MetroFramework.Controls.MetroTile();
			this.customTile4 = new MetroFramework.Controls.MetroTile();
			this.customTile5 = new MetroFramework.Controls.MetroTile();
			this.versionLabel = new MetroFramework.Controls.MetroLink();
			this.donateBtn = new MetroFramework.Controls.MetroLink();
			this.reportBugBtn = new System.Windows.Forms.PictureBox();
			this.progressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
			this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
			this.addonTileContextMenu.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.toolsTab.SuspendLayout();
			this.tools2Tab.SuspendLayout();
			this.helpTab.SuspendLayout();
			this.tileContextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.reportBugBtn)).BeginInit();
			this.SuspendLayout();
			// 
			// generateAddonLangsBtn
			// 
			this.generateAddonLangsBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.generateAddonLangsBtn.Location = new System.Drawing.Point(132, 4);
			this.generateAddonLangsBtn.Margin = new System.Windows.Forms.Padding(4);
			this.generateAddonLangsBtn.Name = "generateAddonLangsBtn";
			this.generateAddonLangsBtn.Size = new System.Drawing.Size(128, 32);
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
			this.addonTile.Location = new System.Drawing.Point(16, 64);
			this.addonTile.Name = "addonTile";
			this.addonTile.Size = new System.Drawing.Size(144, 120);
			this.addonTile.Style = MetroFramework.MetroColorStyle.Green;
			this.addonTile.TabIndex = 0;
			this.addonTile.Text = "AddonName";
			this.addonTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.addonTile, "Left-click to change current addon. Right-click for\r\nmore options.");
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
			this.changePictureToolStripMenuItem.Click += new System.EventHandler(this.changePictureToolStripMenuItem_Click);
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
			this.tabControl.Controls.Add(this.tools2Tab);
			this.tabControl.Controls.Add(this.helpTab);
			this.tabControl.FontSize = MetroFramework.MetroTabControlSize.Tall;
			this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
			this.tabControl.ItemSize = new System.Drawing.Size(40, 25);
			this.tabControl.Location = new System.Drawing.Point(332, 56);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.ShowToolTips = true;
			this.tabControl.Size = new System.Drawing.Size(268, 196);
			this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl.TabIndex = 2;
			this.tabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.tabControl.UseSelectable = true;
			// 
			// toolsTab
			// 
			this.toolsTab.Controls.Add(this.compileCoffeeBtn);
			this.toolsTab.Controls.Add(this.spellLibraryBtn);
			this.toolsTab.Controls.Add(this.findSoundNameBtn);
			this.toolsTab.Controls.Add(this.combineKVBtn);
			this.toolsTab.Controls.Add(this.particleDesignBtn);
			this.toolsTab.Controls.Add(this.generateAddonLangsBtn);
			this.toolsTab.HorizontalScrollbarBarColor = true;
			this.toolsTab.HorizontalScrollbarHighlightOnWheel = false;
			this.toolsTab.HorizontalScrollbarSize = 1;
			this.toolsTab.Location = new System.Drawing.Point(4, 29);
			this.toolsTab.Name = "toolsTab";
			this.toolsTab.Size = new System.Drawing.Size(260, 163);
			this.toolsTab.TabIndex = 0;
			this.toolsTab.Text = "T1";
			this.toolsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.toolsTab.ToolTipText = "Tools page 1";
			this.toolsTab.VerticalScrollbarBarColor = true;
			this.toolsTab.VerticalScrollbarHighlightOnWheel = false;
			this.toolsTab.VerticalScrollbarSize = 2;
			// 
			// compileCoffeeBtn
			// 
			this.compileCoffeeBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.compileCoffeeBtn.Location = new System.Drawing.Point(132, 112);
			this.compileCoffeeBtn.Margin = new System.Windows.Forms.Padding(4);
			this.compileCoffeeBtn.Name = "compileCoffeeBtn";
			this.compileCoffeeBtn.Size = new System.Drawing.Size(128, 32);
			this.compileCoffeeBtn.TabIndex = 8;
			this.compileCoffeeBtn.TabStop = false;
			this.compileCoffeeBtn.Text = "CoffeeScript -> JS";
			this.compileCoffeeBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.compileCoffeeBtn, "Compiles CoffeeScript files in the panorama/scripts/coffeescript\r\ndirectory to Ja" +
        "vaScript files in panorama/scripts");
			this.compileCoffeeBtn.UseSelectable = true;
			this.compileCoffeeBtn.Click += new System.EventHandler(this.compileCoffeeBtn_Click);
			// 
			// spellLibraryBtn
			// 
			this.spellLibraryBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.spellLibraryBtn.Location = new System.Drawing.Point(132, 40);
			this.spellLibraryBtn.Margin = new System.Windows.Forms.Padding(4);
			this.spellLibraryBtn.Name = "spellLibraryBtn";
			this.spellLibraryBtn.Size = new System.Drawing.Size(128, 32);
			this.spellLibraryBtn.TabIndex = 7;
			this.spellLibraryBtn.TabStop = false;
			this.spellLibraryBtn.Text = "SpellLibrary";
			this.spellLibraryBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.spellLibraryBtn, "Open up the SpellLibrary Browser");
			this.spellLibraryBtn.UseSelectable = true;
			this.spellLibraryBtn.Click += new System.EventHandler(this.spellLibraryBtn_Click);
			// 
			// findSoundNameBtn
			// 
			this.findSoundNameBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.findSoundNameBtn.Location = new System.Drawing.Point(132, 76);
			this.findSoundNameBtn.Margin = new System.Windows.Forms.Padding(4);
			this.findSoundNameBtn.Name = "findSoundNameBtn";
			this.findSoundNameBtn.Size = new System.Drawing.Size(128, 32);
			this.findSoundNameBtn.TabIndex = 6;
			this.findSoundNameBtn.TabStop = false;
			this.findSoundNameBtn.Text = "Find Sound.Name";
			this.findSoundNameBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.findSoundNameBtn, "Search for Sound Names with a .vsnd path");
			this.findSoundNameBtn.UseSelectable = true;
			this.findSoundNameBtn.Click += new System.EventHandler(this.findSoundNameBtn_Click);
			// 
			// combineKVBtn
			// 
			this.combineKVBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.combineKVBtn.Location = new System.Drawing.Point(0, 4);
			this.combineKVBtn.Margin = new System.Windows.Forms.Padding(4);
			this.combineKVBtn.Name = "combineKVBtn";
			this.combineKVBtn.Size = new System.Drawing.Size(128, 32);
			this.combineKVBtn.TabIndex = 3;
			this.combineKVBtn.TabStop = false;
			this.combineKVBtn.Text = "Combine KV Files";
			this.combineKVBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.combineKVBtn, "Combines KV files in the scripts/npc directory of this\r\naddon. Prompts to break u" +
        "p the KV files if not done so\r\nalready.");
			this.combineKVBtn.UseSelectable = true;
			this.combineKVBtn.Click += new System.EventHandler(this.combineKVBtn_Click);
			// 
			// particleDesignBtn
			// 
			this.particleDesignBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.particleDesignBtn.Location = new System.Drawing.Point(0, 40);
			this.particleDesignBtn.Margin = new System.Windows.Forms.Padding(4);
			this.particleDesignBtn.Name = "particleDesignBtn";
			this.particleDesignBtn.Size = new System.Drawing.Size(128, 32);
			this.particleDesignBtn.TabIndex = 2;
			this.particleDesignBtn.TabStop = false;
			this.particleDesignBtn.Text = "Particle Designer";
			this.particleDesignBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.particleDesignBtn, "Provides options to bulk modify the color and size of\r\nselected particles.");
			this.particleDesignBtn.UseSelectable = true;
			this.particleDesignBtn.Click += new System.EventHandler(this.particleDesignBtn_Click);
			// 
			// tools2Tab
			// 
			this.tools2Tab.Controls.Add(this.decompileVtexButton);
			this.tools2Tab.Controls.Add(this.compileVtexButton);
			this.tools2Tab.HorizontalScrollbarBarColor = true;
			this.tools2Tab.HorizontalScrollbarHighlightOnWheel = false;
			this.tools2Tab.HorizontalScrollbarSize = 1;
			this.tools2Tab.Location = new System.Drawing.Point(4, 29);
			this.tools2Tab.Name = "tools2Tab";
			this.tools2Tab.Size = new System.Drawing.Size(260, 163);
			this.tools2Tab.TabIndex = 4;
			this.tools2Tab.Text = "T2";
			this.tools2Tab.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.tools2Tab.ToolTipText = "Tools page 2";
			this.tools2Tab.VerticalScrollbarBarColor = true;
			this.tools2Tab.VerticalScrollbarHighlightOnWheel = false;
			this.tools2Tab.VerticalScrollbarSize = 2;
			// 
			// decompileVtexButton
			// 
			this.decompileVtexButton.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.decompileVtexButton.Location = new System.Drawing.Point(0, 40);
			this.decompileVtexButton.Margin = new System.Windows.Forms.Padding(4);
			this.decompileVtexButton.Name = "decompileVtexButton";
			this.decompileVtexButton.Size = new System.Drawing.Size(128, 32);
			this.decompileVtexButton.TabIndex = 6;
			this.decompileVtexButton.TabStop = false;
			this.decompileVtexButton.Text = ".vtex_c -> .tga";
			this.decompileVtexButton.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.decompileVtexButton.UseSelectable = true;
			this.decompileVtexButton.Click += new System.EventHandler(this.decompileVtexButton_Click);
			// 
			// compileVtexButton
			// 
			this.compileVtexButton.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.compileVtexButton.Location = new System.Drawing.Point(0, 4);
			this.compileVtexButton.Margin = new System.Windows.Forms.Padding(4);
			this.compileVtexButton.Name = "compileVtexButton";
			this.compileVtexButton.Size = new System.Drawing.Size(128, 32);
			this.compileVtexButton.TabIndex = 5;
			this.compileVtexButton.TabStop = false;
			this.compileVtexButton.Text = ".tga -> .vtex_c";
			this.compileVtexButton.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.compileVtexButton.UseSelectable = true;
			this.compileVtexButton.Click += new System.EventHandler(this.compileVtexButton_Click);
			// 
			// helpTab
			// 
			this.helpTab.Controls.Add(this.metroLink12);
			this.helpTab.Controls.Add(this.metroLink11);
			this.helpTab.Controls.Add(this.metroLink10);
			this.helpTab.Controls.Add(this.metroLink9);
			this.helpTab.Controls.Add(this.metroLink8);
			this.helpTab.Controls.Add(this.metroLink7);
			this.helpTab.Controls.Add(this.metroLink6);
			this.helpTab.Controls.Add(this.githubGoBtn);
			this.helpTab.Controls.Add(this.jsRadioButton);
			this.helpTab.Controls.Add(this.textRadioButton);
			this.helpTab.Controls.Add(this.luaRadioBtn);
			this.helpTab.Controls.Add(this.addonNameLabel);
			this.helpTab.Controls.Add(this.githubTextBox);
			this.helpTab.Controls.Add(this.metroLink5);
			this.helpTab.Controls.Add(this.metroLink4);
			this.helpTab.Controls.Add(this.metroLink3);
			this.helpTab.Controls.Add(this.metroLink2);
			this.helpTab.Controls.Add(this.metroLink1);
			this.helpTab.HorizontalScrollbarBarColor = true;
			this.helpTab.HorizontalScrollbarHighlightOnWheel = false;
			this.helpTab.HorizontalScrollbarSize = 1;
			this.helpTab.Location = new System.Drawing.Point(4, 29);
			this.helpTab.Name = "helpTab";
			this.helpTab.Size = new System.Drawing.Size(260, 163);
			this.helpTab.TabIndex = 3;
			this.helpTab.Text = "Help";
			this.helpTab.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.helpTab.ToolTipText = "Help related tools";
			this.helpTab.VerticalScrollbarBarColor = true;
			this.helpTab.VerticalScrollbarHighlightOnWheel = false;
			this.helpTab.VerticalScrollbarSize = 2;
			// 
			// metroLink12
			// 
			this.metroLink12.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink12.Location = new System.Drawing.Point(80, 100);
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
			this.metroLink11.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink11.Location = new System.Drawing.Point(1, 100);
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
			this.metroLink10.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink10.Location = new System.Drawing.Point(183, 52);
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
			this.metroLink9.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink9.Location = new System.Drawing.Point(68, 76);
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
			this.metroLink8.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink8.Location = new System.Drawing.Point(58, 52);
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
			this.metroLink7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink7.Location = new System.Drawing.Point(1, 52);
			this.metroLink7.Name = "metroLink7";
			this.metroLink7.Size = new System.Drawing.Size(51, 18);
			this.metroLink7.TabIndex = 14;
			this.metroLink7.Text = "Lua API";
			this.metroLink7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.metroLink7.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroLink7.UseSelectable = true;
			this.metroLink7.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink6
			// 
			this.metroLink6.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink6.Location = new System.Drawing.Point(157, 76);
			this.metroLink6.Name = "metroLink6";
			this.metroLink6.Size = new System.Drawing.Size(82, 18);
			this.metroLink6.TabIndex = 13;
			this.metroLink6.Text = "Lua Modifiers";
			this.metroLink6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.metroLink6.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroLink6.UseSelectable = true;
			this.metroLink6.Click += new System.EventHandler(this.onLink_Click);
			// 
			// githubGoBtn
			// 
			this.githubGoBtn.Location = new System.Drawing.Point(212, 4);
			this.githubGoBtn.Name = "githubGoBtn";
			this.githubGoBtn.Size = new System.Drawing.Size(28, 23);
			this.githubGoBtn.TabIndex = 7;
			this.githubGoBtn.Text = "GO";
			this.githubGoBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.githubGoBtn, "Perform a search on GitHub.com");
			this.githubGoBtn.UseSelectable = true;
			this.githubGoBtn.Click += new System.EventHandler(this.goBtn_Click);
			// 
			// jsRadioButton
			// 
			this.jsRadioButton.AutoSize = true;
			this.jsRadioButton.Location = new System.Drawing.Point(140, 32);
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
			this.textRadioButton.Location = new System.Drawing.Point(100, 32);
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
			this.luaRadioBtn.Location = new System.Drawing.Point(56, 32);
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
			this.addonNameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.addonNameLabel.Location = new System.Drawing.Point(0, 4);
			this.addonNameLabel.Name = "addonNameLabel";
			this.addonNameLabel.Size = new System.Drawing.Size(56, 19);
			this.addonNameLabel.Style = MetroFramework.MetroColorStyle.Blue;
			this.addonNameLabel.TabIndex = 9;
			this.addonNameLabel.Text = "GitHub:";
			this.addonNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// githubTextBox
			// 
			this.githubTextBox.Lines = new string[0];
			this.githubTextBox.Location = new System.Drawing.Point(56, 4);
			this.githubTextBox.MaxLength = 32767;
			this.githubTextBox.Name = "githubTextBox";
			this.githubTextBox.PasswordChar = '\0';
			this.githubTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.githubTextBox.SelectedText = "";
			this.githubTextBox.Size = new System.Drawing.Size(153, 23);
			this.githubTextBox.TabIndex = 7;
			this.githubTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.githubTextBox.UseSelectable = true;
			// 
			// metroLink5
			// 
			this.metroLink5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink5.Location = new System.Drawing.Point(1, 124);
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
			this.metroLink4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink4.Location = new System.Drawing.Point(148, 52);
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
			this.metroLink3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink3.Location = new System.Drawing.Point(148, 100);
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
			this.metroLink2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink2.Location = new System.Drawing.Point(90, 124);
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
			this.metroLink1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink1.Location = new System.Drawing.Point(1, 76);
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
			this.notificationLabel.Location = new System.Drawing.Point(160, 312);
			this.notificationLabel.Name = "notificationLabel";
			this.notificationLabel.Size = new System.Drawing.Size(153, 25);
			this.notificationLabel.Style = MetroFramework.MetroColorStyle.Green;
			this.notificationLabel.TabIndex = 5;
			this.notificationLabel.Text = "notificationLabelg";
			this.notificationLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.notificationLabel.UseStyleColors = true;
			this.notificationLabel.Click += new System.EventHandler(this.notificationLabel_Click);
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
			this.gameTile.Location = new System.Drawing.Point(164, 64);
			this.gameTile.Name = "gameTile";
			this.gameTile.Size = new System.Drawing.Size(40, 36);
			this.gameTile.Style = MetroFramework.MetroColorStyle.Blue;
			this.gameTile.TabIndex = 7;
			this.gameTile.Text = "G";
			this.gameTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.gameTile, "Opens the game directory of this addon.");
			this.gameTile.UseSelectable = true;
			this.gameTile.UseTileImage = true;
			this.gameTile.Click += new System.EventHandler(this.shortcutTile_Click);
			// 
			// contentTile
			// 
			this.contentTile.ActiveControl = null;
			this.contentTile.Location = new System.Drawing.Point(164, 104);
			this.contentTile.Name = "contentTile";
			this.contentTile.Size = new System.Drawing.Size(40, 36);
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
			this.steamTile.Location = new System.Drawing.Point(264, 128);
			this.steamTile.Name = "steamTile";
			this.steamTile.Size = new System.Drawing.Size(36, 28);
			this.steamTile.Style = MetroFramework.MetroColorStyle.Silver;
			this.steamTile.TabIndex = 14;
			this.steamTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.steamTile, "Opens the Steam Workshop page for this addon.");
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
			// vpkTile
			// 
			this.vpkTile.ActiveControl = null;
			this.vpkTile.Location = new System.Drawing.Point(212, 244);
			this.vpkTile.Name = "vpkTile";
			this.vpkTile.Size = new System.Drawing.Size(40, 28);
			this.vpkTile.Style = MetroFramework.MetroColorStyle.Red;
			this.vpkTile.TabIndex = 16;
			this.vpkTile.Text = "VPK";
			this.vpkTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.vpkTile, "Opens the Dota 2 VPK (requires GCFScape)");
			this.vpkTile.UseSelectable = true;
			this.vpkTile.UseTileImage = true;
			this.vpkTile.Click += new System.EventHandler(this.shortcutTile_Click);
			// 
			// optionsTile
			// 
			this.optionsTile.ActiveControl = null;
			this.optionsTile.Location = new System.Drawing.Point(172, 244);
			this.optionsTile.Name = "optionsTile";
			this.optionsTile.Size = new System.Drawing.Size(36, 28);
			this.optionsTile.Style = MetroFramework.MetroColorStyle.Silver;
			this.optionsTile.TabIndex = 18;
			this.optionsTile.Text = "O";
			this.optionsTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.optionsTile, "Opens the Options page");
			this.optionsTile.UseSelectable = true;
			this.optionsTile.UseTileImage = true;
			this.optionsTile.Click += new System.EventHandler(this.optionsBtn_Click);
			// 
			// customTile1
			// 
			this.customTile1.ActiveControl = null;
			this.customTile1.ContextMenuStrip = this.tileContextMenu;
			this.customTile1.Location = new System.Drawing.Point(264, 160);
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
			this.customTile2.Location = new System.Drawing.Point(336, 276);
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
			this.customTile3.Location = new System.Drawing.Point(256, 244);
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
			this.customTile4.Location = new System.Drawing.Point(336, 244);
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
			this.customTile5.Location = new System.Drawing.Point(296, 244);
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
			// versionLabel
			// 
			this.versionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.versionLabel.Location = new System.Drawing.Point(176, 28);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(52, 20);
			this.versionLabel.TabIndex = 21;
			this.versionLabel.Text = "v2.x.x.x";
			this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.versionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.versionLabel, "View version changelog");
			this.versionLabel.UseSelectable = true;
			this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
			// 
			// donateBtn
			// 
			this.donateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.donateBtn.Location = new System.Drawing.Point(228, 28);
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
			// reportBugBtn
			// 
			this.reportBugBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.reportBugBtn.Image = ((System.Drawing.Image)(resources.GetObject("reportBugBtn.Image")));
			this.reportBugBtn.Location = new System.Drawing.Point(284, 28);
			this.reportBugBtn.Name = "reportBugBtn";
			this.reportBugBtn.Size = new System.Drawing.Size(16, 16);
			this.reportBugBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.reportBugBtn.TabIndex = 31;
			this.reportBugBtn.TabStop = false;
			this.mainFormToolTip.SetToolTip(this.reportBugBtn, "Report a bug!");
			this.reportBugBtn.Click += new System.EventHandler(this.reportBug_Click);
			// 
			// progressSpinner1
			// 
			this.progressSpinner1.Location = new System.Drawing.Point(520, 292);
			this.progressSpinner1.Maximum = 100;
			this.progressSpinner1.Name = "progressSpinner1";
			this.progressSpinner1.Size = new System.Drawing.Size(24, 24);
			this.progressSpinner1.TabIndex = 19;
			this.progressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.progressSpinner1.UseSelectable = true;
			this.progressSpinner1.Value = 80;
			this.progressSpinner1.Visible = false;
			// 
			// metroComboBox1
			// 
			this.metroComboBox1.FormattingEnabled = true;
			this.metroComboBox1.ItemHeight = 23;
			this.metroComboBox1.Items.AddRange(new object[] {
            "npc_abilities_custom.txt",
            "npc_items_custom.txt",
            "npc_heroes_custom.txt",
            "npc_units_custom.txt",
            "addon_english.txt",
            "... etc"});
			this.metroComboBox1.Location = new System.Drawing.Point(172, 276);
			this.metroComboBox1.Name = "metroComboBox1";
			this.metroComboBox1.Size = new System.Drawing.Size(161, 29);
			this.metroComboBox1.TabIndex = 30;
			this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroComboBox1.UseSelectable = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 531);
			this.Controls.Add(this.reportBugBtn);
			this.Controls.Add(this.donateBtn);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.metroComboBox1);
			this.Controls.Add(this.customTile5);
			this.Controls.Add(this.customTile4);
			this.Controls.Add(this.customTile3);
			this.Controls.Add(this.customTile2);
			this.Controls.Add(this.customTile1);
			this.Controls.Add(this.optionsTile);
			this.Controls.Add(this.progressSpinner1);
			this.Controls.Add(this.vpkTile);
			this.Controls.Add(this.steamTile);
			this.Controls.Add(this.contentTile);
			this.Controls.Add(this.gameTile);
			this.Controls.Add(this.metroRadioButton1);
			this.Controls.Add(this.notificationLabel);
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
			this.Style = MetroFramework.MetroColorStyle.Teal;
			this.Text = "Dota 2 ModKit";
			this.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.addonTileContextMenu.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.toolsTab.ResumeLayout(false);
			this.tools2Tab.ResumeLayout(false);
			this.helpTab.ResumeLayout(false);
			this.helpTab.PerformLayout();
			this.tileContextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.reportBugBtn)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private MetroFramework.Controls.MetroTabPage toolsTab;
		private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
		private MetroFramework.Controls.MetroTabPage helpTab;
		private MetroFramework.Controls.MetroContextMenu addonTileContextMenu;
		private System.Windows.Forms.ToolStripMenuItem changePictureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteAddonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private MetroFramework.Controls.MetroTabPage tools2Tab;
		private MetroFramework.Controls.MetroButton decompileVtexButton;
		private MetroFramework.Controls.MetroButton compileVtexButton;
		private MetroFramework.Controls.MetroContextMenu tileContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editTileToolStripMenuItem;
		public MetroFramework.Controls.MetroTile addonTile;
		public MetroFramework.Controls.MetroButton generateAddonLangsBtn;
		public MetroFramework.Controls.MetroButton particleDesignBtn;
		public MetroFramework.Controls.MetroButton combineKVBtn;
		public MetroFramework.Controls.MetroTile gameTile;
		public MetroFramework.Controls.MetroTile contentTile;
		public MetroFramework.Controls.MetroTile steamTile;
		public MetroFramework.Controls.MetroTile vpkTile;
		public MetroFramework.Controls.MetroTile optionsTile;
		public MetroFramework.Controls.MetroButton findSoundNameBtn;
		public MetroFramework.Controls.MetroButton spellLibraryBtn;
		public MetroFramework.Controls.MetroButton compileCoffeeBtn;
		public MetroFramework.Controls.MetroTile customTile1;
		public MetroFramework.Controls.MetroTile customTile2;
		public MetroFramework.Controls.MetroTile customTile3;
		public MetroFramework.Controls.MetroTile customTile4;
		public MetroFramework.Controls.MetroTile customTile5;
		public MetroFramework.Controls.MetroLabel notificationLabel;
		public MetroFramework.Controls.MetroProgressSpinner progressSpinner1;
		public MetroFramework.Components.MetroToolTip mainFormToolTip;
		public MetroFramework.Controls.MetroLink versionLabel;
		public MetroFramework.Controls.MetroLink donateBtn;
		public System.Windows.Forms.PictureBox reportBugBtn;
		public MetroFramework.Controls.MetroLink metroLink5;
		public MetroFramework.Controls.MetroLink metroLink4;
		public MetroFramework.Controls.MetroLink metroLink3;
		public MetroFramework.Controls.MetroLink metroLink2;
		public MetroFramework.Controls.MetroLink metroLink1;
		public MetroFramework.Controls.MetroTextBox githubTextBox;
		public MetroFramework.Controls.MetroLabel addonNameLabel;
		public MetroFramework.Controls.MetroRadioButton textRadioButton;
		public MetroFramework.Controls.MetroRadioButton luaRadioBtn;
		public MetroFramework.Controls.MetroRadioButton jsRadioButton;
		public MetroFramework.Controls.MetroButton githubGoBtn;
		public MetroFramework.Controls.MetroLink metroLink8;
		public MetroFramework.Controls.MetroLink metroLink7;
		public MetroFramework.Controls.MetroLink metroLink6;
		public MetroFramework.Controls.MetroLink metroLink9;
		public MetroFramework.Controls.MetroLink metroLink10;
		public MetroFramework.Controls.MetroLink metroLink11;
		public MetroFramework.Controls.MetroLink metroLink12;
		public MetroFramework.Controls.MetroTabControl tabControl;
		public MetroFramework.Controls.MetroComboBox metroComboBox1;
	}
}
