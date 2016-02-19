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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("panorama");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("scripts");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.generateTooltipsBtn = new MetroFramework.Controls.MetroButton();
            this.addonTile = new MetroFramework.Controls.MetroTile();
            this.addonTileContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAddonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.homeTab = new MetroFramework.Controls.MetroTabPage();
            this.homeRefreshBtn = new MetroFramework.Controls.MetroButton();
            this.addonsPanel = new MetroFramework.Controls.MetroPanel();
            this.imagesCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.panoramaTree = new System.Windows.Forms.TreeView();
            this.scriptsTree = new System.Windows.Forms.TreeView();
            this.chatTab = new MetroFramework.Controls.MetroTabPage();
            this.chatMsgTextBox = new System.Windows.Forms.RichTextBox();
            this.usernamesRichTB = new System.Windows.Forms.RichTextBox();
            this.chatViewRichTB = new System.Windows.Forms.RichTextBox();
            this.toolsTab = new MetroFramework.Controls.MetroTabPage();
            this.compileCoffeeBtn = new MetroFramework.Controls.MetroButton();
            this.findSoundNameBtn = new MetroFramework.Controls.MetroButton();
            this.combineKVBtn = new MetroFramework.Controls.MetroButton();
            this.spellLibraryTab = new MetroFramework.Controls.MetroTabPage();
            this.spellOpenFolderBtn = new MetroFramework.Controls.MetroButton();
            this.spellOpenFileBtn = new MetroFramework.Controls.MetroButton();
            this.spellCopyBtn = new MetroFramework.Controls.MetroButton();
            this.luaKVBtn = new MetroFramework.Controls.MetroButton();
            this.fastColoredTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.itemsRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.abilitiesRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.abilitiesTreeView = new System.Windows.Forms.TreeView();
            this.particlesTab = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.particlesTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.particleSubmitBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.recolorBtn = new MetroFramework.Controls.MetroButton();
            this.bLabel = new MetroFramework.Controls.MetroLabel();
            this.gLabel = new MetroFramework.Controls.MetroLabel();
            this.rLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.sizeLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.particlesTrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.particleCopyTutorial = new MetroFramework.Controls.MetroLink();
            this.selectParticlesBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.linksTab = new MetroFramework.Controls.MetroTabPage();
            this.linkHttp = new MetroFramework.Controls.MetroLink();
            this.linksTreeView = new System.Windows.Forms.TreeView();
            this.linksPanel = new MetroFramework.Controls.MetroPanel();
            this.optionsTab = new MetroFramework.Controls.MetroTabPage();
            this.saveBtn = new MetroFramework.Controls.MetroButton();
            this.optionsForLabel = new MetroFramework.Controls.MetroLabel();
            this.openChangelogCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.autoCompileCoffeeCheckbox = new MetroFramework.Controls.MetroCheckBox();
            this.utf8CheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.autoDeleteBinCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.askToBreakUpCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.loreCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.note0CheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.enableChatCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.chatReconnectBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.chatPasswordTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chatUsernameTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.installedGamesTab = new MetroFramework.Controls.MetroTabPage();
            this.versionTab = new MetroFramework.Controls.MetroTabPage();
            this.tileContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.editTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.mainFormToolTip = new MetroFramework.Components.MetroToolTip();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.donateBtn = new MetroFramework.Controls.MetroLink();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.versionLabel = new MetroFramework.Controls.MetroLink();
            this.notificationLabel = new MetroFramework.Controls.MetroLabel();
            this.progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.installedGamesPanel = new MetroFramework.Controls.MetroPanel();
            this.addonTileContextMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.chatTab.SuspendLayout();
            this.toolsTab.SuspendLayout();
            this.spellLibraryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.particlesTab.SuspendLayout();
            this.linksTab.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.installedGamesTab.SuspendLayout();
            this.tileContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // generateTooltipsBtn
            // 
            this.generateTooltipsBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.generateTooltipsBtn.Location = new System.Drawing.Point(180, 12);
            this.generateTooltipsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.generateTooltipsBtn.Name = "generateTooltipsBtn";
            this.generateTooltipsBtn.Size = new System.Drawing.Size(168, 68);
            this.generateTooltipsBtn.TabIndex = 1;
            this.generateTooltipsBtn.TabStop = false;
            this.generateTooltipsBtn.Text = "Generate Tooltips";
            this.generateTooltipsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.generateTooltipsBtn, "Generates tooltips from the scripts/npc files of this addon,\r\nwhich you can easil" +
        "y transfer over to addon_language.txt\r\nfiles.");
            this.generateTooltipsBtn.UseSelectable = true;
            this.generateTooltipsBtn.Click += new System.EventHandler(this.generateTooltipsBtn_Click);
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
            // 
            // addonTileContextMenu
            // 
            this.addonTileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.deleteAddonToolStripMenuItem});
            this.addonTileContextMenu.Name = "metroContextMenu1";
            this.addonTileContextMenu.Size = new System.Drawing.Size(147, 48);
            this.addonTileContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // deleteAddonToolStripMenuItem
            // 
            this.deleteAddonToolStripMenuItem.Name = "deleteAddonToolStripMenuItem";
            this.deleteAddonToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.deleteAddonToolStripMenuItem.Text = "Delete Addon";
            this.deleteAddonToolStripMenuItem.Click += new System.EventHandler(this.deleteAddonBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.homeTab);
            this.tabControl.Controls.Add(this.chatTab);
            this.tabControl.Controls.Add(this.toolsTab);
            this.tabControl.Controls.Add(this.spellLibraryTab);
            this.tabControl.Controls.Add(this.particlesTab);
            this.tabControl.Controls.Add(this.linksTab);
            this.tabControl.Controls.Add(this.optionsTab);
            this.tabControl.Controls.Add(this.installedGamesTab);
            this.tabControl.Controls.Add(this.versionTab);
            this.tabControl.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.tabControl.ItemSize = new System.Drawing.Size(40, 25);
            this.tabControl.Location = new System.Drawing.Point(188, 54);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 7;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(1084, 656);
            this.tabControl.TabIndex = 2;
            this.tabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl.UseSelectable = true;
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.homeRefreshBtn);
            this.homeTab.Controls.Add(this.addonsPanel);
            this.homeTab.Controls.Add(this.imagesCheckBox1);
            this.homeTab.Controls.Add(this.panoramaTree);
            this.homeTab.Controls.Add(this.scriptsTree);
            this.homeTab.HorizontalScrollbarBarColor = true;
            this.homeTab.HorizontalScrollbarHighlightOnWheel = false;
            this.homeTab.HorizontalScrollbarSize = 1;
            this.homeTab.Location = new System.Drawing.Point(4, 29);
            this.homeTab.Name = "homeTab";
            this.homeTab.Size = new System.Drawing.Size(1076, 623);
            this.homeTab.TabIndex = 8;
            this.homeTab.Text = "Home";
            this.homeTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.homeTab.VerticalScrollbarBarColor = true;
            this.homeTab.VerticalScrollbarHighlightOnWheel = false;
            this.homeTab.VerticalScrollbarSize = 1;
            // 
            // homeRefreshBtn
            // 
            this.homeRefreshBtn.Location = new System.Drawing.Point(350, 4);
            this.homeRefreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.homeRefreshBtn.Name = "homeRefreshBtn";
            this.homeRefreshBtn.Size = new System.Drawing.Size(86, 20);
            this.homeRefreshBtn.TabIndex = 36;
            this.homeRefreshBtn.TabStop = false;
            this.homeRefreshBtn.Text = "Refresh";
            this.homeRefreshBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.homeRefreshBtn.UseSelectable = true;
            this.homeRefreshBtn.Click += new System.EventHandler(this.homeRefreshBtn_Click);
            // 
            // addonsPanel
            // 
            this.addonsPanel.AutoScroll = true;
            this.addonsPanel.HorizontalScrollbar = true;
            this.addonsPanel.HorizontalScrollbarBarColor = true;
            this.addonsPanel.HorizontalScrollbarHighlightOnWheel = true;
            this.addonsPanel.HorizontalScrollbarSize = 1;
            this.addonsPanel.Location = new System.Drawing.Point(888, 8);
            this.addonsPanel.Name = "addonsPanel";
            this.addonsPanel.Size = new System.Drawing.Size(186, 606);
            this.addonsPanel.TabIndex = 32;
            this.addonsPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addonsPanel.UseStyleColors = true;
            this.addonsPanel.VerticalScrollbar = true;
            this.addonsPanel.VerticalScrollbarBarColor = true;
            this.addonsPanel.VerticalScrollbarHighlightOnWheel = false;
            this.addonsPanel.VerticalScrollbarSize = 1;
            // 
            // imagesCheckBox1
            // 
            this.imagesCheckBox1.AutoSize = true;
            this.imagesCheckBox1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.imagesCheckBox1.Location = new System.Drawing.Point(452, 8);
            this.imagesCheckBox1.Name = "imagesCheckBox1";
            this.imagesCheckBox1.Size = new System.Drawing.Size(162, 19);
            this.imagesCheckBox1.TabIndex = 34;
            this.imagesCheckBox1.Text = "Hide image extensions";
            this.imagesCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.imagesCheckBox1.UseSelectable = true;
            this.imagesCheckBox1.CheckedChanged += new System.EventHandler(this.hideExtensionsCheckbox_Click);
            // 
            // panoramaTree
            // 
            this.panoramaTree.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panoramaTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panoramaTree.ForeColor = System.Drawing.Color.White;
            this.panoramaTree.LineColor = System.Drawing.Color.White;
            this.panoramaTree.Location = new System.Drawing.Point(394, 28);
            this.panoramaTree.Name = "panoramaTree";
            treeNode1.Name = "panoramaNode";
            treeNode1.Text = "panorama";
            treeNode1.ToolTipText = "Double-click a node to open the file or directory";
            this.panoramaTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.panoramaTree.ShowNodeToolTips = true;
            this.panoramaTree.Size = new System.Drawing.Size(392, 592);
            this.panoramaTree.TabIndex = 4;
            // 
            // scriptsTree
            // 
            this.scriptsTree.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.scriptsTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptsTree.ForeColor = System.Drawing.Color.White;
            this.scriptsTree.LineColor = System.Drawing.Color.White;
            this.scriptsTree.Location = new System.Drawing.Point(0, 28);
            this.scriptsTree.Name = "scriptsTree";
            treeNode2.Name = "scriptsNode";
            treeNode2.Text = "scripts";
            treeNode2.ToolTipText = "Double-click a node to open the file or directory";
            this.scriptsTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.scriptsTree.ShowNodeToolTips = true;
            this.scriptsTree.Size = new System.Drawing.Size(392, 592);
            this.scriptsTree.TabIndex = 2;
            // 
            // chatTab
            // 
            this.chatTab.Controls.Add(this.chatMsgTextBox);
            this.chatTab.Controls.Add(this.usernamesRichTB);
            this.chatTab.Controls.Add(this.chatViewRichTB);
            this.chatTab.HorizontalScrollbarBarColor = true;
            this.chatTab.HorizontalScrollbarHighlightOnWheel = false;
            this.chatTab.HorizontalScrollbarSize = 1;
            this.chatTab.Location = new System.Drawing.Point(4, 29);
            this.chatTab.Name = "chatTab";
            this.chatTab.Size = new System.Drawing.Size(1076, 623);
            this.chatTab.TabIndex = 10;
            this.chatTab.Text = "Chat";
            this.chatTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chatTab.VerticalScrollbarBarColor = true;
            this.chatTab.VerticalScrollbarHighlightOnWheel = false;
            this.chatTab.VerticalScrollbarSize = 1;
            // 
            // chatMsgTextBox
            // 
            this.chatMsgTextBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.chatMsgTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatMsgTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.chatMsgTextBox.Location = new System.Drawing.Point(0, 566);
            this.chatMsgTextBox.Multiline = false;
            this.chatMsgTextBox.Name = "chatMsgTextBox";
            this.chatMsgTextBox.Size = new System.Drawing.Size(936, 26);
            this.chatMsgTextBox.TabIndex = 22;
            this.chatMsgTextBox.Text = "";
            // 
            // usernamesRichTB
            // 
            this.usernamesRichTB.BackColor = System.Drawing.SystemColors.ControlText;
            this.usernamesRichTB.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamesRichTB.ForeColor = System.Drawing.SystemColors.Window;
            this.usernamesRichTB.Location = new System.Drawing.Point(938, 4);
            this.usernamesRichTB.Name = "usernamesRichTB";
            this.usernamesRichTB.ReadOnly = true;
            this.usernamesRichTB.Size = new System.Drawing.Size(136, 560);
            this.usernamesRichTB.TabIndex = 21;
            this.usernamesRichTB.Text = "";
            // 
            // chatViewRichTB
            // 
            this.chatViewRichTB.BackColor = System.Drawing.SystemColors.ControlText;
            this.chatViewRichTB.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatViewRichTB.ForeColor = System.Drawing.SystemColors.Window;
            this.chatViewRichTB.Location = new System.Drawing.Point(0, 4);
            this.chatViewRichTB.Name = "chatViewRichTB";
            this.chatViewRichTB.ReadOnly = true;
            this.chatViewRichTB.Size = new System.Drawing.Size(936, 560);
            this.chatViewRichTB.TabIndex = 20;
            this.chatViewRichTB.Text = "";
            // 
            // toolsTab
            // 
            this.toolsTab.Controls.Add(this.compileCoffeeBtn);
            this.toolsTab.Controls.Add(this.findSoundNameBtn);
            this.toolsTab.Controls.Add(this.combineKVBtn);
            this.toolsTab.Controls.Add(this.generateTooltipsBtn);
            this.toolsTab.HorizontalScrollbarBarColor = true;
            this.toolsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.toolsTab.HorizontalScrollbarSize = 1;
            this.toolsTab.Location = new System.Drawing.Point(4, 29);
            this.toolsTab.Name = "toolsTab";
            this.toolsTab.Size = new System.Drawing.Size(1076, 623);
            this.toolsTab.TabIndex = 0;
            this.toolsTab.Text = "Tools";
            this.toolsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolsTab.VerticalScrollbarBarColor = true;
            this.toolsTab.VerticalScrollbarHighlightOnWheel = false;
            this.toolsTab.VerticalScrollbarSize = 1;
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
            // spellLibraryTab
            // 
            this.spellLibraryTab.Controls.Add(this.spellOpenFolderBtn);
            this.spellLibraryTab.Controls.Add(this.spellOpenFileBtn);
            this.spellLibraryTab.Controls.Add(this.spellCopyBtn);
            this.spellLibraryTab.Controls.Add(this.luaKVBtn);
            this.spellLibraryTab.Controls.Add(this.fastColoredTextBox);
            this.spellLibraryTab.Controls.Add(this.metroPanel1);
            this.spellLibraryTab.Controls.Add(this.abilitiesTreeView);
            this.spellLibraryTab.HorizontalScrollbarBarColor = true;
            this.spellLibraryTab.HorizontalScrollbarHighlightOnWheel = false;
            this.spellLibraryTab.HorizontalScrollbarSize = 1;
            this.spellLibraryTab.Location = new System.Drawing.Point(4, 29);
            this.spellLibraryTab.Name = "spellLibraryTab";
            this.spellLibraryTab.Size = new System.Drawing.Size(1076, 623);
            this.spellLibraryTab.TabIndex = 5;
            this.spellLibraryTab.Text = "SpellLibrary";
            this.spellLibraryTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.spellLibraryTab.VerticalScrollbarBarColor = true;
            this.spellLibraryTab.VerticalScrollbarHighlightOnWheel = false;
            this.spellLibraryTab.VerticalScrollbarSize = 1;
            // 
            // spellOpenFolderBtn
            // 
            this.spellOpenFolderBtn.Location = new System.Drawing.Point(522, 4);
            this.spellOpenFolderBtn.Margin = new System.Windows.Forms.Padding(4);
            this.spellOpenFolderBtn.Name = "spellOpenFolderBtn";
            this.spellOpenFolderBtn.Size = new System.Drawing.Size(86, 22);
            this.spellOpenFolderBtn.TabIndex = 38;
            this.spellOpenFolderBtn.TabStop = false;
            this.spellOpenFolderBtn.Text = "Open folder";
            this.spellOpenFolderBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.spellOpenFolderBtn, "Opens the folder containing the file");
            this.spellOpenFolderBtn.UseSelectable = true;
            // 
            // spellOpenFileBtn
            // 
            this.spellOpenFileBtn.Location = new System.Drawing.Point(430, 4);
            this.spellOpenFileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.spellOpenFileBtn.Name = "spellOpenFileBtn";
            this.spellOpenFileBtn.Size = new System.Drawing.Size(86, 22);
            this.spellOpenFileBtn.TabIndex = 37;
            this.spellOpenFileBtn.TabStop = false;
            this.spellOpenFileBtn.Text = "Open file";
            this.spellOpenFileBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.spellOpenFileBtn, "Opens the file");
            this.spellOpenFileBtn.UseSelectable = true;
            // 
            // spellCopyBtn
            // 
            this.spellCopyBtn.Location = new System.Drawing.Point(338, 4);
            this.spellCopyBtn.Margin = new System.Windows.Forms.Padding(4);
            this.spellCopyBtn.Name = "spellCopyBtn";
            this.spellCopyBtn.Size = new System.Drawing.Size(86, 22);
            this.spellCopyBtn.TabIndex = 36;
            this.spellCopyBtn.TabStop = false;
            this.spellCopyBtn.Text = "Copy";
            this.spellCopyBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.spellCopyBtn, "Copy the contents of the textbox to the clipboard");
            this.spellCopyBtn.UseSelectable = true;
            // 
            // luaKVBtn
            // 
            this.luaKVBtn.Location = new System.Drawing.Point(246, 4);
            this.luaKVBtn.Margin = new System.Windows.Forms.Padding(4);
            this.luaKVBtn.Name = "luaKVBtn";
            this.luaKVBtn.Size = new System.Drawing.Size(86, 22);
            this.luaKVBtn.TabIndex = 35;
            this.luaKVBtn.TabStop = false;
            this.luaKVBtn.Text = "KV";
            this.luaKVBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.luaKVBtn.UseSelectable = true;
            // 
            // fastColoredTextBox
            // 
            this.fastColoredTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fastColoredTextBox.BackBrush = null;
            this.fastColoredTextBox.CharHeight = 14;
            this.fastColoredTextBox.CharWidth = 8;
            this.fastColoredTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBox.IsReplaceMode = false;
            this.fastColoredTextBox.Location = new System.Drawing.Point(224, 30);
            this.fastColoredTextBox.Name = "fastColoredTextBox";
            this.fastColoredTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox.ReadOnly = true;
            this.fastColoredTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox.ServiceColors")));
            this.fastColoredTextBox.Size = new System.Drawing.Size(852, 590);
            this.fastColoredTextBox.TabIndex = 7;
            this.fastColoredTextBox.Zoom = 100;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.itemsRadioButton);
            this.metroPanel1.Controls.Add(this.abilitiesRadioButton);
            this.metroPanel1.Controls.Add(this.metroRadioButton2);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 1;
            this.metroPanel1.Location = new System.Drawing.Point(2, 4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(226, 24);
            this.metroPanel1.TabIndex = 6;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 1;
            // 
            // itemsRadioButton
            // 
            this.itemsRadioButton.AutoSize = true;
            this.itemsRadioButton.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.itemsRadioButton.Location = new System.Drawing.Point(88, 2);
            this.itemsRadioButton.Name = "itemsRadioButton";
            this.itemsRadioButton.Size = new System.Drawing.Size(59, 19);
            this.itemsRadioButton.TabIndex = 4;
            this.itemsRadioButton.Text = "Items";
            this.itemsRadioButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.itemsRadioButton.UseSelectable = true;
            // 
            // abilitiesRadioButton
            // 
            this.abilitiesRadioButton.AutoSize = true;
            this.abilitiesRadioButton.Checked = true;
            this.abilitiesRadioButton.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.abilitiesRadioButton.Location = new System.Drawing.Point(8, 2);
            this.abilitiesRadioButton.Name = "abilitiesRadioButton";
            this.abilitiesRadioButton.Size = new System.Drawing.Size(72, 19);
            this.abilitiesRadioButton.TabIndex = 3;
            this.abilitiesRadioButton.TabStop = true;
            this.abilitiesRadioButton.Text = "Abilities";
            this.abilitiesRadioButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.abilitiesRadioButton.UseSelectable = true;
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Location = new System.Drawing.Point(14, 36);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(127, 15);
            this.metroRadioButton2.TabIndex = 2;
            this.metroRadioButton2.Text = "metroRadioButton2";
            this.metroRadioButton2.UseSelectable = true;
            // 
            // abilitiesTreeView
            // 
            this.abilitiesTreeView.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.abilitiesTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abilitiesTreeView.ForeColor = System.Drawing.Color.White;
            this.abilitiesTreeView.LineColor = System.Drawing.Color.White;
            this.abilitiesTreeView.Location = new System.Drawing.Point(2, 30);
            this.abilitiesTreeView.Name = "abilitiesTreeView";
            this.abilitiesTreeView.Size = new System.Drawing.Size(220, 590);
            this.abilitiesTreeView.TabIndex = 5;
            // 
            // particlesTab
            // 
            this.particlesTab.Controls.Add(this.metroLabel10);
            this.particlesTab.Controls.Add(this.particlesTextBox1);
            this.particlesTab.Controls.Add(this.particleSubmitBtn);
            this.particlesTab.Controls.Add(this.metroLabel9);
            this.particlesTab.Controls.Add(this.recolorBtn);
            this.particlesTab.Controls.Add(this.bLabel);
            this.particlesTab.Controls.Add(this.gLabel);
            this.particlesTab.Controls.Add(this.rLabel);
            this.particlesTab.Controls.Add(this.metroLabel8);
            this.particlesTab.Controls.Add(this.sizeLabel);
            this.particlesTab.Controls.Add(this.metroLabel6);
            this.particlesTab.Controls.Add(this.metroLabel7);
            this.particlesTab.Controls.Add(this.particlesTrackBar);
            this.particlesTab.Controls.Add(this.particleCopyTutorial);
            this.particlesTab.Controls.Add(this.selectParticlesBtn);
            this.particlesTab.Controls.Add(this.metroLabel1);
            this.particlesTab.Controls.Add(this.metroLabel5);
            this.particlesTab.Controls.Add(this.metroLabel4);
            this.particlesTab.HorizontalScrollbarBarColor = true;
            this.particlesTab.HorizontalScrollbarHighlightOnWheel = false;
            this.particlesTab.HorizontalScrollbarSize = 1;
            this.particlesTab.Location = new System.Drawing.Point(4, 29);
            this.particlesTab.Name = "particlesTab";
            this.particlesTab.Size = new System.Drawing.Size(1076, 623);
            this.particlesTab.TabIndex = 4;
            this.particlesTab.Text = "Particle Designer";
            this.particlesTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.particlesTab.ToolTipText = "Tools page 2";
            this.particlesTab.VerticalScrollbarBarColor = true;
            this.particlesTab.VerticalScrollbarHighlightOnWheel = false;
            this.particlesTab.VerticalScrollbarSize = 1;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(318, 94);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(116, 19);
            this.metroLabel10.TabIndex = 21;
            this.metroLabel10.Text = "Selected particles:";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // particlesTextBox1
            // 
            // 
            // 
            // 
            this.particlesTextBox1.CustomButton.Image = null;
            this.particlesTextBox1.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.particlesTextBox1.CustomButton.Margin = new System.Windows.Forms.Padding(1);
            this.particlesTextBox1.CustomButton.Name = "";
            this.particlesTextBox1.CustomButton.Size = new System.Drawing.Size(106, 115);
            this.particlesTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.particlesTextBox1.CustomButton.TabIndex = 1;
            this.particlesTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.particlesTextBox1.CustomButton.UseSelectable = true;
            this.particlesTextBox1.CustomButton.Visible = false;
            this.particlesTextBox1.Lines = new string[0];
            this.particlesTextBox1.Location = new System.Drawing.Point(322, 116);
            this.particlesTextBox1.MaxLength = 32767;
            this.particlesTextBox1.Multiline = true;
            this.particlesTextBox1.Name = "particlesTextBox1";
            this.particlesTextBox1.PasswordChar = '\0';
            this.particlesTextBox1.ReadOnly = true;
            this.particlesTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.particlesTextBox1.SelectedText = "";
            this.particlesTextBox1.SelectionLength = 0;
            this.particlesTextBox1.SelectionStart = 0;
            this.particlesTextBox1.Size = new System.Drawing.Size(356, 182);
            this.particlesTextBox1.TabIndex = 20;
            this.particlesTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.particlesTextBox1.UseSelectable = true;
            this.particlesTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.particlesTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // particleSubmitBtn
            // 
            this.particleSubmitBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.particleSubmitBtn.Location = new System.Drawing.Point(72, 378);
            this.particleSubmitBtn.Name = "particleSubmitBtn";
            this.particleSubmitBtn.Size = new System.Drawing.Size(114, 40);
            this.particleSubmitBtn.TabIndex = 19;
            this.particleSubmitBtn.Text = "Submit";
            this.particleSubmitBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.particleSubmitBtn.UseSelectable = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(12, 390);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(51, 19);
            this.metroLabel9.TabIndex = 18;
            this.metroLabel9.Text = "Step 4.";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // recolorBtn
            // 
            this.recolorBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.recolorBtn.Location = new System.Drawing.Point(11, 207);
            this.recolorBtn.Margin = new System.Windows.Forms.Padding(4);
            this.recolorBtn.Name = "recolorBtn";
            this.recolorBtn.Size = new System.Drawing.Size(128, 52);
            this.recolorBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.recolorBtn.TabIndex = 17;
            this.recolorBtn.TabStop = false;
            this.recolorBtn.Text = "Re-Color";
            this.recolorBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.recolorBtn.UseSelectable = true;
            this.recolorBtn.UseStyleColors = true;
            // 
            // bLabel
            // 
            this.bLabel.AutoSize = true;
            this.bLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.bLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.bLabel.Location = new System.Drawing.Point(150, 252);
            this.bLabel.Name = "bLabel";
            this.bLabel.Size = new System.Drawing.Size(26, 25);
            this.bLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.bLabel.TabIndex = 16;
            this.bLabel.Text = "B:";
            this.bLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bLabel.UseStyleColors = true;
            // 
            // gLabel
            // 
            this.gLabel.AutoSize = true;
            this.gLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.gLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.gLabel.Location = new System.Drawing.Point(148, 220);
            this.gLabel.Name = "gLabel";
            this.gLabel.Size = new System.Drawing.Size(28, 25);
            this.gLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.gLabel.TabIndex = 15;
            this.gLabel.Text = "G:";
            this.gLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.gLabel.UseStyleColors = true;
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.rLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.rLabel.Location = new System.Drawing.Point(148, 188);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(27, 25);
            this.rLabel.Style = MetroFramework.MetroColorStyle.Red;
            this.rLabel.TabIndex = 14;
            this.rLabel.Text = "R:";
            this.rLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rLabel.UseStyleColors = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(12, 150);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(154, 19);
            this.metroLabel8.TabIndex = 13;
            this.metroLabel8.Text = "Step 3. Choose options:";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.sizeLabel.Location = new System.Drawing.Point(128, 306);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(116, 19);
            this.sizeLabel.Style = MetroFramework.MetroColorStyle.Yellow;
            this.sizeLabel.TabIndex = 12;
            this.sizeLabel.Text = "Size change: +0%";
            this.sizeLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.sizeLabel.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(312, 328);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(54, 19);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "+200%";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(12, 328);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(50, 19);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "-100%";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // particlesTrackBar
            // 
            this.particlesTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.particlesTrackBar.Location = new System.Drawing.Point(66, 330);
            this.particlesTrackBar.Name = "particlesTrackBar";
            this.particlesTrackBar.Size = new System.Drawing.Size(243, 19);
            this.particlesTrackBar.TabIndex = 9;
            this.particlesTrackBar.Text = "metroTrackBar1";
            this.particlesTrackBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // particleCopyTutorial
            // 
            this.particleCopyTutorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.particleCopyTutorial.Location = new System.Drawing.Point(503, 61);
            this.particleCopyTutorial.Name = "particleCopyTutorial";
            this.particleCopyTutorial.Size = new System.Drawing.Size(58, 22);
            this.particleCopyTutorial.Style = MetroFramework.MetroColorStyle.Teal;
            this.particleCopyTutorial.TabIndex = 7;
            this.particleCopyTutorial.Text = "Tutorial";
            this.particleCopyTutorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.particleCopyTutorial.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.particleCopyTutorial.UseSelectable = true;
            this.particleCopyTutorial.UseStyleColors = true;
            // 
            // selectParticlesBtn
            // 
            this.selectParticlesBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.selectParticlesBtn.Location = new System.Drawing.Point(70, 92);
            this.selectParticlesBtn.Name = "selectParticlesBtn";
            this.selectParticlesBtn.Size = new System.Drawing.Size(168, 40);
            this.selectParticlesBtn.TabIndex = 6;
            this.selectParticlesBtn.Text = "Select the particle files";
            this.selectParticlesBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.selectParticlesBtn.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(12, 102);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Step 2.";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(12, 62);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(489, 19);
            this.metroLabel5.TabIndex = 4;
            this.metroLabel5.Text = "Step 1. Use the Particle Copy Tool to copy particles over to your custom game.";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(12, 12);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(416, 38);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Particle Designer allows you to easily bulk modify .vpcf particle files\r\nwithout " +
    "having to go through the Particle Editor.";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // linksTab
            // 
            this.linksTab.Controls.Add(this.linkHttp);
            this.linksTab.Controls.Add(this.linksTreeView);
            this.linksTab.Controls.Add(this.linksPanel);
            this.linksTab.HorizontalScrollbarBarColor = true;
            this.linksTab.HorizontalScrollbarHighlightOnWheel = false;
            this.linksTab.HorizontalScrollbarSize = 1;
            this.linksTab.Location = new System.Drawing.Point(4, 29);
            this.linksTab.Name = "linksTab";
            this.linksTab.Size = new System.Drawing.Size(1076, 623);
            this.linksTab.TabIndex = 3;
            this.linksTab.Text = "Links";
            this.linksTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.linksTab.ToolTipText = "Help related tools";
            this.linksTab.VerticalScrollbarBarColor = true;
            this.linksTab.VerticalScrollbarHighlightOnWheel = false;
            this.linksTab.VerticalScrollbarSize = 1;
            // 
            // linkHttp
            // 
            this.linkHttp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkHttp.Location = new System.Drawing.Point(514, 40);
            this.linkHttp.Name = "linkHttp";
            this.linkHttp.Size = new System.Drawing.Size(550, 22);
            this.linkHttp.Style = MetroFramework.MetroColorStyle.Blue;
            this.linkHttp.TabIndex = 35;
            this.linkHttp.Text = "moddota.com";
            this.linkHttp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkHttp.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.linkHttp.UseSelectable = true;
            this.linkHttp.UseStyleColors = true;
            // 
            // linksTreeView
            // 
            this.linksTreeView.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linksTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linksTreeView.ForeColor = System.Drawing.Color.White;
            this.linksTreeView.LineColor = System.Drawing.Color.White;
            this.linksTreeView.Location = new System.Drawing.Point(4, 8);
            this.linksTreeView.Name = "linksTreeView";
            this.linksTreeView.Size = new System.Drawing.Size(500, 612);
            this.linksTreeView.TabIndex = 34;
            // 
            // linksPanel
            // 
            this.linksPanel.AutoScroll = true;
            this.linksPanel.HorizontalScrollbar = true;
            this.linksPanel.HorizontalScrollbarBarColor = true;
            this.linksPanel.HorizontalScrollbarHighlightOnWheel = true;
            this.linksPanel.HorizontalScrollbarSize = 1;
            this.linksPanel.Location = new System.Drawing.Point(658, 232);
            this.linksPanel.Name = "linksPanel";
            this.linksPanel.Size = new System.Drawing.Size(190, 242);
            this.linksPanel.TabIndex = 33;
            this.linksPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.linksPanel.UseStyleColors = true;
            this.linksPanel.VerticalScrollbar = true;
            this.linksPanel.VerticalScrollbarBarColor = true;
            this.linksPanel.VerticalScrollbarHighlightOnWheel = false;
            this.linksPanel.VerticalScrollbarSize = 1;
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.saveBtn);
            this.optionsTab.Controls.Add(this.optionsForLabel);
            this.optionsTab.Controls.Add(this.openChangelogCheckBox);
            this.optionsTab.Controls.Add(this.autoCompileCoffeeCheckbox);
            this.optionsTab.Controls.Add(this.utf8CheckBox);
            this.optionsTab.Controls.Add(this.autoDeleteBinCheckBox);
            this.optionsTab.Controls.Add(this.askToBreakUpCheckBox);
            this.optionsTab.Controls.Add(this.loreCheckBox);
            this.optionsTab.Controls.Add(this.note0CheckBox);
            this.optionsTab.Controls.Add(this.enableChatCheckBox1);
            this.optionsTab.Controls.Add(this.chatReconnectBtn);
            this.optionsTab.Controls.Add(this.metroLabel3);
            this.optionsTab.Controls.Add(this.chatPasswordTextBox1);
            this.optionsTab.Controls.Add(this.metroLabel11);
            this.optionsTab.Controls.Add(this.metroLabel2);
            this.optionsTab.Controls.Add(this.chatUsernameTextBox1);
            this.optionsTab.HorizontalScrollbarBarColor = true;
            this.optionsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.optionsTab.HorizontalScrollbarSize = 1;
            this.optionsTab.Location = new System.Drawing.Point(4, 29);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(1076, 623);
            this.optionsTab.TabIndex = 7;
            this.optionsTab.Text = "Options";
            this.optionsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.optionsTab.VerticalScrollbarBarColor = true;
            this.optionsTab.VerticalScrollbarHighlightOnWheel = false;
            this.optionsTab.VerticalScrollbarSize = 1;
            // 
            // saveBtn
            // 
            this.saveBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.saveBtn.Location = new System.Drawing.Point(470, 578);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(138, 38);
            this.saveBtn.Style = MetroFramework.MetroColorStyle.Lime;
            this.saveBtn.TabIndex = 47;
            this.saveBtn.TabStop = false;
            this.saveBtn.Text = "Save Settings";
            this.saveBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.saveBtn.UseSelectable = true;
            this.saveBtn.UseStyleColors = true;
            // 
            // optionsForLabel
            // 
            this.optionsForLabel.AutoSize = true;
            this.optionsForLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.optionsForLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.optionsForLabel.Location = new System.Drawing.Point(590, 12);
            this.optionsForLabel.Name = "optionsForLabel";
            this.optionsForLabel.Size = new System.Drawing.Size(112, 25);
            this.optionsForLabel.Style = MetroFramework.MetroColorStyle.Green;
            this.optionsForLabel.TabIndex = 46;
            this.optionsForLabel.Text = "addonname:";
            this.optionsForLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.optionsForLabel.UseStyleColors = true;
            // 
            // openChangelogCheckBox
            // 
            this.openChangelogCheckBox.AutoSize = true;
            this.openChangelogCheckBox.Location = new System.Drawing.Point(8, 136);
            this.openChangelogCheckBox.Name = "openChangelogCheckBox";
            this.openChangelogCheckBox.Size = new System.Drawing.Size(229, 15);
            this.openChangelogCheckBox.TabIndex = 45;
            this.openChangelogCheckBox.Text = "Open changelog webpage after update";
            this.openChangelogCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.openChangelogCheckBox.UseSelectable = true;
            // 
            // autoCompileCoffeeCheckbox
            // 
            this.autoCompileCoffeeCheckbox.AutoSize = true;
            this.autoCompileCoffeeCheckbox.Location = new System.Drawing.Point(594, 160);
            this.autoCompileCoffeeCheckbox.Name = "autoCompileCoffeeCheckbox";
            this.autoCompileCoffeeCheckbox.Size = new System.Drawing.Size(336, 15);
            this.autoCompileCoffeeCheckbox.TabIndex = 44;
            this.autoCompileCoffeeCheckbox.Text = "Auto-compile CoffeeScript files when changes are detected";
            this.autoCompileCoffeeCheckbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.autoCompileCoffeeCheckbox.UseSelectable = true;
            // 
            // utf8CheckBox
            // 
            this.utf8CheckBox.AutoSize = true;
            this.utf8CheckBox.Location = new System.Drawing.Point(594, 138);
            this.utf8CheckBox.Name = "utf8CheckBox";
            this.utf8CheckBox.Size = new System.Drawing.Size(391, 15);
            this.utf8CheckBox.TabIndex = 43;
            this.utf8CheckBox.Text = "Auto-generate UTF-8 addon_language files during tooltips generation";
            this.utf8CheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.utf8CheckBox.UseSelectable = true;
            // 
            // autoDeleteBinCheckBox
            // 
            this.autoDeleteBinCheckBox.AutoSize = true;
            this.autoDeleteBinCheckBox.Location = new System.Drawing.Point(594, 114);
            this.autoDeleteBinCheckBox.Name = "autoDeleteBinCheckBox";
            this.autoDeleteBinCheckBox.Size = new System.Drawing.Size(348, 15);
            this.autoDeleteBinCheckBox.TabIndex = 41;
            this.autoDeleteBinCheckBox.Text = "Auto-delete the .bin files in the \'game\' directory of this addon";
            this.autoDeleteBinCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.autoDeleteBinCheckBox.UseSelectable = true;
            // 
            // askToBreakUpCheckBox
            // 
            this.askToBreakUpCheckBox.AutoSize = true;
            this.askToBreakUpCheckBox.Location = new System.Drawing.Point(594, 92);
            this.askToBreakUpCheckBox.Name = "askToBreakUpCheckBox";
            this.askToBreakUpCheckBox.Size = new System.Drawing.Size(282, 15);
            this.askToBreakUpCheckBox.TabIndex = 40;
            this.askToBreakUpCheckBox.Text = "Always ask to break up before combining KV files";
            this.askToBreakUpCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.askToBreakUpCheckBox.UseSelectable = true;
            // 
            // loreCheckBox
            // 
            this.loreCheckBox.AutoSize = true;
            this.loreCheckBox.Location = new System.Drawing.Point(594, 68);
            this.loreCheckBox.Name = "loreCheckBox";
            this.loreCheckBox.Size = new System.Drawing.Size(147, 15);
            this.loreCheckBox.TabIndex = 39;
            this.loreCheckBox.Text = "Generate \'Lore\' Tooltips";
            this.loreCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loreCheckBox.UseSelectable = true;
            // 
            // note0CheckBox
            // 
            this.note0CheckBox.AutoSize = true;
            this.note0CheckBox.Location = new System.Drawing.Point(594, 46);
            this.note0CheckBox.Name = "note0CheckBox";
            this.note0CheckBox.Size = new System.Drawing.Size(156, 15);
            this.note0CheckBox.TabIndex = 38;
            this.note0CheckBox.Text = "Generate \'Note0\' Tooltips";
            this.note0CheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.note0CheckBox.UseSelectable = true;
            // 
            // enableChatCheckBox1
            // 
            this.enableChatCheckBox1.AutoSize = true;
            this.enableChatCheckBox1.Checked = true;
            this.enableChatCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableChatCheckBox1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.enableChatCheckBox1.Location = new System.Drawing.Point(8, 8);
            this.enableChatCheckBox1.Name = "enableChatCheckBox1";
            this.enableChatCheckBox1.Size = new System.Drawing.Size(95, 19);
            this.enableChatCheckBox1.TabIndex = 37;
            this.enableChatCheckBox1.Text = "Enable chat";
            this.enableChatCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.enableChatCheckBox1.UseSelectable = true;
            // 
            // chatReconnectBtn
            // 
            this.chatReconnectBtn.Location = new System.Drawing.Point(200, 32);
            this.chatReconnectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.chatReconnectBtn.Name = "chatReconnectBtn";
            this.chatReconnectBtn.Size = new System.Drawing.Size(86, 22);
            this.chatReconnectBtn.TabIndex = 36;
            this.chatReconnectBtn.TabStop = false;
            this.chatReconnectBtn.Text = "Reconnect";
            this.chatReconnectBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chatReconnectBtn.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(4, 30);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(190, 38);
            this.metroLabel3.TabIndex = 18;
            this.metroLabel3.Text = "Network: irc.globalgamers.net\r\nChannel: #dotacoders";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // chatPasswordTextBox1
            // 
            // 
            // 
            // 
            this.chatPasswordTextBox1.CustomButton.Image = null;
            this.chatPasswordTextBox1.CustomButton.Location = new System.Drawing.Point(70, 1);
            this.chatPasswordTextBox1.CustomButton.Margin = new System.Windows.Forms.Padding(1);
            this.chatPasswordTextBox1.CustomButton.Name = "";
            this.chatPasswordTextBox1.CustomButton.Size = new System.Drawing.Size(13, 14);
            this.chatPasswordTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.chatPasswordTextBox1.CustomButton.TabIndex = 1;
            this.chatPasswordTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chatPasswordTextBox1.CustomButton.UseSelectable = true;
            this.chatPasswordTextBox1.CustomButton.Visible = false;
            this.chatPasswordTextBox1.Lines = new string[0];
            this.chatPasswordTextBox1.Location = new System.Drawing.Point(171, 100);
            this.chatPasswordTextBox1.MaxLength = 32767;
            this.chatPasswordTextBox1.Name = "chatPasswordTextBox1";
            this.chatPasswordTextBox1.PasswordChar = '\0';
            this.chatPasswordTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.chatPasswordTextBox1.SelectedText = "";
            this.chatPasswordTextBox1.SelectionLength = 0;
            this.chatPasswordTextBox1.SelectionStart = 0;
            this.chatPasswordTextBox1.Size = new System.Drawing.Size(138, 23);
            this.chatPasswordTextBox1.TabIndex = 17;
            this.chatPasswordTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chatPasswordTextBox1.UseSelectable = true;
            this.chatPasswordTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.chatPasswordTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(3, 100);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(165, 19);
            this.metroLabel11.TabIndex = 16;
            this.metroLabel11.Text = "Chat password (optional):";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(65, 74);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(103, 19);
            this.metroLabel2.TabIndex = 14;
            this.metroLabel2.Text = "Chat nickname:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // chatUsernameTextBox1
            // 
            // 
            // 
            // 
            this.chatUsernameTextBox1.CustomButton.Image = null;
            this.chatUsernameTextBox1.CustomButton.Location = new System.Drawing.Point(70, 1);
            this.chatUsernameTextBox1.CustomButton.Margin = new System.Windows.Forms.Padding(1);
            this.chatUsernameTextBox1.CustomButton.Name = "";
            this.chatUsernameTextBox1.CustomButton.Size = new System.Drawing.Size(13, 14);
            this.chatUsernameTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.chatUsernameTextBox1.CustomButton.TabIndex = 1;
            this.chatUsernameTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chatUsernameTextBox1.CustomButton.UseSelectable = true;
            this.chatUsernameTextBox1.CustomButton.Visible = false;
            this.chatUsernameTextBox1.Lines = new string[0];
            this.chatUsernameTextBox1.Location = new System.Drawing.Point(171, 72);
            this.chatUsernameTextBox1.MaxLength = 32767;
            this.chatUsernameTextBox1.Name = "chatUsernameTextBox1";
            this.chatUsernameTextBox1.PasswordChar = '\0';
            this.chatUsernameTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.chatUsernameTextBox1.SelectedText = "";
            this.chatUsernameTextBox1.SelectionLength = 0;
            this.chatUsernameTextBox1.SelectionStart = 0;
            this.chatUsernameTextBox1.Size = new System.Drawing.Size(138, 23);
            this.chatUsernameTextBox1.TabIndex = 2;
            this.chatUsernameTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chatUsernameTextBox1.UseSelectable = true;
            this.chatUsernameTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.chatUsernameTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // installedGamesTab
            // 
            this.installedGamesTab.Controls.Add(this.installedGamesPanel);
            this.installedGamesTab.HorizontalScrollbarBarColor = true;
            this.installedGamesTab.HorizontalScrollbarHighlightOnWheel = false;
            this.installedGamesTab.HorizontalScrollbarSize = 4;
            this.installedGamesTab.Location = new System.Drawing.Point(4, 29);
            this.installedGamesTab.Name = "installedGamesTab";
            this.installedGamesTab.Size = new System.Drawing.Size(1076, 623);
            this.installedGamesTab.TabIndex = 11;
            this.installedGamesTab.Text = "Games";
            this.installedGamesTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.installedGamesTab.VerticalScrollbarBarColor = true;
            this.installedGamesTab.VerticalScrollbarHighlightOnWheel = false;
            this.installedGamesTab.VerticalScrollbarSize = 4;
            // 
            // versionTab
            // 
            this.versionTab.HorizontalScrollbarBarColor = true;
            this.versionTab.HorizontalScrollbarHighlightOnWheel = false;
            this.versionTab.HorizontalScrollbarSize = 1;
            this.versionTab.Location = new System.Drawing.Point(4, 29);
            this.versionTab.Name = "versionTab";
            this.versionTab.Size = new System.Drawing.Size(1076, 623);
            this.versionTab.TabIndex = 9;
            this.versionTab.Text = "v2.X.X.X";
            this.versionTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.versionTab.VerticalScrollbarBarColor = true;
            this.versionTab.VerticalScrollbarHighlightOnWheel = false;
            this.versionTab.VerticalScrollbarSize = 1;
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
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(212, -4);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(127, 15);
            this.metroRadioButton1.TabIndex = 6;
            this.metroRadioButton1.Text = "metroRadioButton1";
            this.metroRadioButton1.UseSelectable = true;
            this.metroRadioButton1.Visible = false;
            // 
            // mainFormToolTip
            // 
            this.mainFormToolTip.AutoPopDelay = 8000;
            this.mainFormToolTip.InitialDelay = 500;
            this.mainFormToolTip.ReshowDelay = 200;
            this.mainFormToolTip.Style = MetroFramework.MetroColorStyle.Default;
            this.mainFormToolTip.StyleManager = null;
            this.mainFormToolTip.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton2.Location = new System.Drawing.Point(12, 256);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(84, 57);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroButton2.TabIndex = 34;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "Content";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.metroButton2, "Opens the content directory of this addon.");
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            this.metroButton2.Click += new System.EventHandler(this.shortcutTile_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.Location = new System.Drawing.Point(12, 192);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(84, 57);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 33;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "Game";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.metroButton1, "Opens the game directory of this addon.");
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.shortcutTile_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton3.Location = new System.Drawing.Point(12, 320);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(84, 57);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButton3.TabIndex = 35;
            this.metroButton3.TabStop = false;
            this.metroButton3.Text = "VPK";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainFormToolTip.SetToolTip(this.metroButton3, "Opens the Dota 2 VPK");
            this.metroButton3.UseSelectable = true;
            this.metroButton3.UseStyleColors = true;
            this.metroButton3.Click += new System.EventHandler(this.shortcutTile_Click);
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
            // notificationLabel
            // 
            this.notificationLabel.AutoSize = true;
            this.notificationLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.notificationLabel.Location = new System.Drawing.Point(10, 690);
            this.notificationLabel.Name = "notificationLabel";
            this.notificationLabel.Size = new System.Drawing.Size(124, 19);
            this.notificationLabel.Style = MetroFramework.MetroColorStyle.Teal;
            this.notificationLabel.TabIndex = 37;
            this.notificationLabel.Text = "Doing something...";
            this.notificationLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.notificationLabel.UseStyleColors = true;
            // 
            // progressSpinner
            // 
            this.progressSpinner.Location = new System.Drawing.Point(10, 648);
            this.progressSpinner.Maximum = 100;
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.Size = new System.Drawing.Size(36, 36);
            this.progressSpinner.TabIndex = 37;
            this.progressSpinner.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressSpinner.UseSelectable = true;
            this.progressSpinner.Value = 70;
            this.progressSpinner.Visible = false;
            // 
            // installedGamesPanel
            // 
            this.installedGamesPanel.AutoScroll = true;
            this.installedGamesPanel.HorizontalScrollbar = true;
            this.installedGamesPanel.HorizontalScrollbarBarColor = true;
            this.installedGamesPanel.HorizontalScrollbarHighlightOnWheel = true;
            this.installedGamesPanel.HorizontalScrollbarSize = 1;
            this.installedGamesPanel.Location = new System.Drawing.Point(30, 24);
            this.installedGamesPanel.Name = "installedGamesPanel";
            this.installedGamesPanel.Size = new System.Drawing.Size(1010, 590);
            this.installedGamesPanel.TabIndex = 33;
            this.installedGamesPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.installedGamesPanel.UseStyleColors = true;
            this.installedGamesPanel.VerticalScrollbar = true;
            this.installedGamesPanel.VerticalScrollbarBarColor = true;
            this.installedGamesPanel.VerticalScrollbarHighlightOnWheel = false;
            this.installedGamesPanel.VerticalScrollbarSize = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.notificationLabel);
            this.Controls.Add(this.progressSpinner);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.donateBtn);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroRadioButton1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.addonTile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.homeTab.ResumeLayout(false);
            this.homeTab.PerformLayout();
            this.chatTab.ResumeLayout(false);
            this.toolsTab.ResumeLayout(false);
            this.spellLibraryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.particlesTab.ResumeLayout(false);
            this.particlesTab.PerformLayout();
            this.linksTab.ResumeLayout(false);
            this.optionsTab.ResumeLayout(false);
            this.optionsTab.PerformLayout();
            this.installedGamesTab.ResumeLayout(false);
            this.tileContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroButton generateTooltipsBtn;
		private MetroFramework.Controls.MetroTabPage toolsTab;
		private MetroFramework.Controls.MetroButton combineKVBtn;
		private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
		private MetroFramework.Controls.MetroTabPage linksTab;
		private MetroFramework.Controls.MetroContextMenu addonTileContextMenu;
		private System.Windows.Forms.ToolStripMenuItem deleteAddonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private MetroFramework.Controls.MetroButton findSoundNameBtn;
		private MetroFramework.Controls.MetroTabPage particlesTab;
		private MetroFramework.Controls.MetroLink versionLabel;
		private MetroFramework.Controls.MetroButton compileCoffeeBtn;
		private MetroFramework.Controls.MetroContextMenu tileContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editTileToolStripMenuItem;
		private MetroFramework.Controls.MetroLink donateBtn;
		private System.Windows.Forms.PictureBox pictureBox2;
        public MetroFramework.Controls.MetroTile addonTile;
        private MetroFramework.Controls.MetroTabPage spellLibraryTab;
        private MetroFramework.Controls.MetroTabPage optionsTab;
        private MetroFramework.Controls.MetroTabPage homeTab;
        public System.Windows.Forms.TreeView scriptsTree;
        public System.Windows.Forms.TreeView panoramaTree;
        public MetroFramework.Controls.MetroCheckBox imagesCheckBox1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton3;
        public MetroFramework.Controls.MetroLabel notificationLabel;
        public MetroFramework.Controls.MetroProgressSpinner progressSpinner;
        public System.Windows.Forms.TreeView abilitiesTreeView;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
        public MetroFramework.Controls.MetroButton luaKVBtn;
        public FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox;
        public MetroFramework.Components.MetroToolTip mainFormToolTip;
        public MetroFramework.Controls.MetroButton spellCopyBtn;
        public MetroFramework.Controls.MetroRadioButton itemsRadioButton;
        public MetroFramework.Controls.MetroRadioButton abilitiesRadioButton;
        public MetroFramework.Controls.MetroButton spellOpenFileBtn;
        public MetroFramework.Controls.MetroButton spellOpenFolderBtn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLink particleCopyTutorial;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        public MetroFramework.Controls.MetroButton selectParticlesBtn;
        public MetroFramework.Controls.MetroTrackBar particlesTrackBar;
        public MetroFramework.Controls.MetroButton recolorBtn;
        public MetroFramework.Controls.MetroButton particleSubmitBtn;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        public MetroFramework.Controls.MetroLabel bLabel;
        public MetroFramework.Controls.MetroLabel gLabel;
        public MetroFramework.Controls.MetroLabel rLabel;
        public MetroFramework.Controls.MetroLabel sizeLabel;
        public MetroFramework.Controls.MetroTextBox particlesTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        public MetroFramework.Controls.MetroTabControl tabControl;
        public MetroFramework.Controls.MetroPanel linksPanel;
        public MetroFramework.Controls.MetroPanel addonsPanel;
        public MetroFramework.Controls.MetroTabPage versionTab;
        private MetroFramework.Controls.MetroTabPage chatTab;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroButton chatReconnectBtn;
        public MetroFramework.Controls.MetroTextBox chatPasswordTextBox1;
        public MetroFramework.Controls.MetroTextBox chatUsernameTextBox1;
        public System.Windows.Forms.RichTextBox chatViewRichTB;
        public System.Windows.Forms.RichTextBox usernamesRichTB;
        public System.Windows.Forms.RichTextBox chatMsgTextBox;
        public MetroFramework.Controls.MetroButton homeRefreshBtn;
        public MetroFramework.Controls.MetroCheckBox enableChatCheckBox1;
        public MetroFramework.Controls.MetroCheckBox autoCompileCoffeeCheckbox;
        public MetroFramework.Controls.MetroCheckBox utf8CheckBox;
        public MetroFramework.Controls.MetroCheckBox autoDeleteBinCheckBox;
        public MetroFramework.Controls.MetroCheckBox askToBreakUpCheckBox;
        public MetroFramework.Controls.MetroCheckBox loreCheckBox;
        public MetroFramework.Controls.MetroCheckBox note0CheckBox;
        public MetroFramework.Controls.MetroLabel optionsForLabel;
        public MetroFramework.Controls.MetroCheckBox openChangelogCheckBox;
        public MetroFramework.Controls.MetroButton saveBtn;
        public System.Windows.Forms.TreeView linksTreeView;
        public MetroFramework.Controls.MetroLink linkHttp;
        public MetroFramework.Controls.MetroTabPage installedGamesTab;
        public MetroFramework.Controls.MetroPanel installedGamesPanel;
    }
}
