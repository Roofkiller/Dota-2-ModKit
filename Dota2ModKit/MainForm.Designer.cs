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
			this.mainFormToolTip = new MetroFramework.Drawing.Html.HtmlToolTip();
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
			resources.ApplyResources(this.generateAddonLangsBtn, "generateAddonLangsBtn");
			this.generateAddonLangsBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.generateAddonLangsBtn.Name = "generateAddonLangsBtn";
			this.generateAddonLangsBtn.TabStop = false;
			this.generateAddonLangsBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.generateAddonLangsBtn, resources.GetString("generateAddonLangsBtn.ToolTip"));
			this.generateAddonLangsBtn.UseSelectable = true;
			this.generateAddonLangsBtn.Click += new System.EventHandler(this.generateAddonLangsBtn_Click);
			// 
			// addonTile
			// 
			resources.ApplyResources(this.addonTile, "addonTile");
			this.addonTile.ActiveControl = null;
			this.addonTile.ContextMenuStrip = this.addonTileContextMenu;
			this.addonTile.Name = "addonTile";
			this.addonTile.Style = MetroFramework.MetroColorStyle.Green;
			this.addonTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.addonTile, resources.GetString("addonTile.ToolTip"));
			this.addonTile.UseSelectable = true;
			this.addonTile.UseTileImage = true;
			this.addonTile.Click += new System.EventHandler(this.addonTile_Click);
			// 
			// addonTileContextMenu
			// 
			resources.ApplyResources(this.addonTileContextMenu, "addonTileContextMenu");
			this.addonTileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePictureToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.deleteAddonToolStripMenuItem});
			this.addonTileContextMenu.Name = "metroContextMenu1";
			this.addonTileContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.addonTileContextMenu, resources.GetString("addonTileContextMenu.ToolTip"));
			// 
			// changePictureToolStripMenuItem
			// 
			resources.ApplyResources(this.changePictureToolStripMenuItem, "changePictureToolStripMenuItem");
			this.changePictureToolStripMenuItem.Name = "changePictureToolStripMenuItem";
			this.changePictureToolStripMenuItem.Click += new System.EventHandler(this.changePictureToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// deleteAddonToolStripMenuItem
			// 
			resources.ApplyResources(this.deleteAddonToolStripMenuItem, "deleteAddonToolStripMenuItem");
			this.deleteAddonToolStripMenuItem.Name = "deleteAddonToolStripMenuItem";
			this.deleteAddonToolStripMenuItem.Click += new System.EventHandler(this.deleteAddonBtn_Click);
			// 
			// tabControl
			// 
			resources.ApplyResources(this.tabControl, "tabControl");
			this.tabControl.Controls.Add(this.toolsTab);
			this.tabControl.Controls.Add(this.tools2Tab);
			this.tabControl.Controls.Add(this.helpTab);
			this.tabControl.FontSize = MetroFramework.MetroTabControlSize.Tall;
			this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.tabControl, resources.GetString("tabControl.ToolTip"));
			this.tabControl.UseSelectable = true;
			// 
			// toolsTab
			// 
			resources.ApplyResources(this.toolsTab, "toolsTab");
			this.toolsTab.Controls.Add(this.compileCoffeeBtn);
			this.toolsTab.Controls.Add(this.spellLibraryBtn);
			this.toolsTab.Controls.Add(this.findSoundNameBtn);
			this.toolsTab.Controls.Add(this.combineKVBtn);
			this.toolsTab.Controls.Add(this.particleDesignBtn);
			this.toolsTab.Controls.Add(this.generateAddonLangsBtn);
			this.toolsTab.HorizontalScrollbarBarColor = true;
			this.toolsTab.HorizontalScrollbarHighlightOnWheel = false;
			this.toolsTab.HorizontalScrollbarSize = 1;
			this.toolsTab.Name = "toolsTab";
			this.toolsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.toolsTab, resources.GetString("toolsTab.ToolTip"));
			this.toolsTab.VerticalScrollbarBarColor = true;
			this.toolsTab.VerticalScrollbarHighlightOnWheel = false;
			this.toolsTab.VerticalScrollbarSize = 2;
			// 
			// compileCoffeeBtn
			// 
			resources.ApplyResources(this.compileCoffeeBtn, "compileCoffeeBtn");
			this.compileCoffeeBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.compileCoffeeBtn.Name = "compileCoffeeBtn";
			this.compileCoffeeBtn.TabStop = false;
			this.compileCoffeeBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.compileCoffeeBtn, resources.GetString("compileCoffeeBtn.ToolTip"));
			this.compileCoffeeBtn.UseSelectable = true;
			this.compileCoffeeBtn.Click += new System.EventHandler(this.compileCoffeeBtn_Click);
			// 
			// spellLibraryBtn
			// 
			resources.ApplyResources(this.spellLibraryBtn, "spellLibraryBtn");
			this.spellLibraryBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.spellLibraryBtn.Name = "spellLibraryBtn";
			this.spellLibraryBtn.TabStop = false;
			this.spellLibraryBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.spellLibraryBtn, resources.GetString("spellLibraryBtn.ToolTip"));
			this.spellLibraryBtn.UseSelectable = true;
			this.spellLibraryBtn.Click += new System.EventHandler(this.spellLibraryBtn_Click);
			// 
			// findSoundNameBtn
			// 
			resources.ApplyResources(this.findSoundNameBtn, "findSoundNameBtn");
			this.findSoundNameBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.findSoundNameBtn.Name = "findSoundNameBtn";
			this.findSoundNameBtn.TabStop = false;
			this.findSoundNameBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.findSoundNameBtn, resources.GetString("findSoundNameBtn.ToolTip"));
			this.findSoundNameBtn.UseSelectable = true;
			this.findSoundNameBtn.Click += new System.EventHandler(this.findSoundNameBtn_Click);
			// 
			// combineKVBtn
			// 
			resources.ApplyResources(this.combineKVBtn, "combineKVBtn");
			this.combineKVBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.combineKVBtn.Name = "combineKVBtn";
			this.combineKVBtn.TabStop = false;
			this.combineKVBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.combineKVBtn, resources.GetString("combineKVBtn.ToolTip"));
			this.combineKVBtn.UseSelectable = true;
			this.combineKVBtn.Click += new System.EventHandler(this.combineKVBtn_Click);
			// 
			// particleDesignBtn
			// 
			resources.ApplyResources(this.particleDesignBtn, "particleDesignBtn");
			this.particleDesignBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.particleDesignBtn.Name = "particleDesignBtn";
			this.particleDesignBtn.TabStop = false;
			this.particleDesignBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.particleDesignBtn, resources.GetString("particleDesignBtn.ToolTip"));
			this.particleDesignBtn.UseSelectable = true;
			this.particleDesignBtn.Click += new System.EventHandler(this.particleDesignBtn_Click);
			// 
			// tools2Tab
			// 
			resources.ApplyResources(this.tools2Tab, "tools2Tab");
			this.tools2Tab.Controls.Add(this.decompileVtexButton);
			this.tools2Tab.Controls.Add(this.compileVtexButton);
			this.tools2Tab.HorizontalScrollbarBarColor = true;
			this.tools2Tab.HorizontalScrollbarHighlightOnWheel = false;
			this.tools2Tab.HorizontalScrollbarSize = 1;
			this.tools2Tab.Name = "tools2Tab";
			this.tools2Tab.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.tools2Tab, resources.GetString("tools2Tab.ToolTip"));
			this.tools2Tab.VerticalScrollbarBarColor = true;
			this.tools2Tab.VerticalScrollbarHighlightOnWheel = false;
			this.tools2Tab.VerticalScrollbarSize = 2;
			// 
			// decompileVtexButton
			// 
			resources.ApplyResources(this.decompileVtexButton, "decompileVtexButton");
			this.decompileVtexButton.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.decompileVtexButton.Name = "decompileVtexButton";
			this.decompileVtexButton.TabStop = false;
			this.decompileVtexButton.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.decompileVtexButton, resources.GetString("decompileVtexButton.ToolTip"));
			this.decompileVtexButton.UseSelectable = true;
			this.decompileVtexButton.Click += new System.EventHandler(this.decompileVtexButton_Click);
			// 
			// compileVtexButton
			// 
			resources.ApplyResources(this.compileVtexButton, "compileVtexButton");
			this.compileVtexButton.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.compileVtexButton.Name = "compileVtexButton";
			this.compileVtexButton.TabStop = false;
			this.compileVtexButton.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.compileVtexButton, resources.GetString("compileVtexButton.ToolTip"));
			this.compileVtexButton.UseSelectable = true;
			this.compileVtexButton.Click += new System.EventHandler(this.compileVtexButton_Click);
			// 
			// helpTab
			// 
			resources.ApplyResources(this.helpTab, "helpTab");
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
			this.helpTab.Name = "helpTab";
			this.helpTab.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.helpTab, resources.GetString("helpTab.ToolTip"));
			this.helpTab.VerticalScrollbarBarColor = true;
			this.helpTab.VerticalScrollbarHighlightOnWheel = false;
			this.helpTab.VerticalScrollbarSize = 2;
			// 
			// metroLink12
			// 
			resources.ApplyResources(this.metroLink12, "metroLink12");
			this.metroLink12.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink12.Name = "metroLink12";
			this.metroLink12.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink12, resources.GetString("metroLink12.ToolTip"));
			this.metroLink12.UseSelectable = true;
			this.metroLink12.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink11
			// 
			resources.ApplyResources(this.metroLink11, "metroLink11");
			this.metroLink11.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink11.Name = "metroLink11";
			this.metroLink11.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink11, resources.GetString("metroLink11.ToolTip"));
			this.metroLink11.UseSelectable = true;
			this.metroLink11.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink10
			// 
			resources.ApplyResources(this.metroLink10, "metroLink10");
			this.metroLink10.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink10.Name = "metroLink10";
			this.metroLink10.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink10, resources.GetString("metroLink10.ToolTip"));
			this.metroLink10.UseSelectable = true;
			this.metroLink10.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink9
			// 
			resources.ApplyResources(this.metroLink9, "metroLink9");
			this.metroLink9.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink9.Name = "metroLink9";
			this.metroLink9.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink9, resources.GetString("metroLink9.ToolTip"));
			this.metroLink9.UseSelectable = true;
			this.metroLink9.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink8
			// 
			resources.ApplyResources(this.metroLink8, "metroLink8");
			this.metroLink8.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink8.Name = "metroLink8";
			this.metroLink8.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink8, resources.GetString("metroLink8.ToolTip"));
			this.metroLink8.UseSelectable = true;
			this.metroLink8.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink7
			// 
			resources.ApplyResources(this.metroLink7, "metroLink7");
			this.metroLink7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink7.Name = "metroLink7";
			this.metroLink7.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink7, resources.GetString("metroLink7.ToolTip"));
			this.metroLink7.UseSelectable = true;
			this.metroLink7.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink6
			// 
			resources.ApplyResources(this.metroLink6, "metroLink6");
			this.metroLink6.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink6.Name = "metroLink6";
			this.metroLink6.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink6, resources.GetString("metroLink6.ToolTip"));
			this.metroLink6.UseSelectable = true;
			this.metroLink6.Click += new System.EventHandler(this.onLink_Click);
			// 
			// githubGoBtn
			// 
			resources.ApplyResources(this.githubGoBtn, "githubGoBtn");
			this.githubGoBtn.Name = "githubGoBtn";
			this.githubGoBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.githubGoBtn, resources.GetString("githubGoBtn.ToolTip"));
			this.githubGoBtn.UseSelectable = true;
			this.githubGoBtn.Click += new System.EventHandler(this.goBtn_Click);
			// 
			// jsRadioButton
			// 
			resources.ApplyResources(this.jsRadioButton, "jsRadioButton");
			this.jsRadioButton.Name = "jsRadioButton";
			this.jsRadioButton.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.jsRadioButton, resources.GetString("jsRadioButton.ToolTip"));
			this.jsRadioButton.UseSelectable = true;
			// 
			// textRadioButton
			// 
			resources.ApplyResources(this.textRadioButton, "textRadioButton");
			this.textRadioButton.Name = "textRadioButton";
			this.textRadioButton.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.textRadioButton, resources.GetString("textRadioButton.ToolTip"));
			this.textRadioButton.UseSelectable = true;
			// 
			// luaRadioBtn
			// 
			resources.ApplyResources(this.luaRadioBtn, "luaRadioBtn");
			this.luaRadioBtn.Name = "luaRadioBtn";
			this.luaRadioBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.luaRadioBtn, resources.GetString("luaRadioBtn.ToolTip"));
			this.luaRadioBtn.UseSelectable = true;
			// 
			// addonNameLabel
			// 
			resources.ApplyResources(this.addonNameLabel, "addonNameLabel");
			this.addonNameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.addonNameLabel.Name = "addonNameLabel";
			this.addonNameLabel.Style = MetroFramework.MetroColorStyle.Blue;
			this.addonNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.addonNameLabel, resources.GetString("addonNameLabel.ToolTip"));
			// 
			// githubTextBox
			// 
			resources.ApplyResources(this.githubTextBox, "githubTextBox");
			// 
			// 
			// 
			this.githubTextBox.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription");
			this.githubTextBox.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName");
			this.githubTextBox.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor")));
			this.githubTextBox.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize")));
			this.githubTextBox.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode")));
			this.githubTextBox.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage")));
			this.githubTextBox.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout")));
			this.githubTextBox.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock")));
			this.githubTextBox.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle")));
			this.githubTextBox.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font")));
			this.githubTextBox.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
			this.githubTextBox.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign")));
			this.githubTextBox.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex")));
			this.githubTextBox.CustomButton.ImageKey = resources.GetString("resource.ImageKey");
			this.githubTextBox.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
			this.githubTextBox.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
			this.githubTextBox.CustomButton.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Margin")));
			this.githubTextBox.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize")));
			this.githubTextBox.CustomButton.Name = "";
			this.githubTextBox.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft")));
			this.githubTextBox.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
			this.githubTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.githubTextBox.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
			this.githubTextBox.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign")));
			this.githubTextBox.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation")));
			this.githubTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.githubTextBox.CustomButton.UseSelectable = true;
			this.githubTextBox.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
			this.githubTextBox.Lines = new string[0];
			this.githubTextBox.MaxLength = 32767;
			this.githubTextBox.Name = "githubTextBox";
			this.githubTextBox.PasswordChar = '\0';
			this.githubTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.githubTextBox.SelectedText = "";
			this.githubTextBox.SelectionLength = 0;
			this.githubTextBox.SelectionStart = 0;
			this.githubTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.githubTextBox, resources.GetString("githubTextBox.ToolTip"));
			this.githubTextBox.UseSelectable = true;
			this.githubTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.githubTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// metroLink5
			// 
			resources.ApplyResources(this.metroLink5, "metroLink5");
			this.metroLink5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink5.Name = "metroLink5";
			this.metroLink5.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink5, resources.GetString("metroLink5.ToolTip"));
			this.metroLink5.UseSelectable = true;
			this.metroLink5.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink4
			// 
			resources.ApplyResources(this.metroLink4, "metroLink4");
			this.metroLink4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink4.Name = "metroLink4";
			this.metroLink4.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink4, resources.GetString("metroLink4.ToolTip"));
			this.metroLink4.UseSelectable = true;
			this.metroLink4.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink3
			// 
			resources.ApplyResources(this.metroLink3, "metroLink3");
			this.metroLink3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink3.Name = "metroLink3";
			this.metroLink3.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink3, resources.GetString("metroLink3.ToolTip"));
			this.metroLink3.UseSelectable = true;
			this.metroLink3.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink2
			// 
			resources.ApplyResources(this.metroLink2, "metroLink2");
			this.metroLink2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink2.Name = "metroLink2";
			this.metroLink2.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink2, resources.GetString("metroLink2.ToolTip"));
			this.metroLink2.UseSelectable = true;
			this.metroLink2.Click += new System.EventHandler(this.onLink_Click);
			// 
			// metroLink1
			// 
			resources.ApplyResources(this.metroLink1, "metroLink1");
			this.metroLink1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.metroLink1.Name = "metroLink1";
			this.metroLink1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroLink1, resources.GetString("metroLink1.ToolTip"));
			this.metroLink1.UseSelectable = true;
			this.metroLink1.Click += new System.EventHandler(this.onLink_Click);
			// 
			// notificationLabel
			// 
			resources.ApplyResources(this.notificationLabel, "notificationLabel");
			this.notificationLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.notificationLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.notificationLabel.ForeColor = System.Drawing.Color.Maroon;
			this.notificationLabel.Name = "notificationLabel";
			this.notificationLabel.Style = MetroFramework.MetroColorStyle.Green;
			this.notificationLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.notificationLabel, resources.GetString("notificationLabel.ToolTip"));
			this.notificationLabel.UseStyleColors = true;
			this.notificationLabel.Click += new System.EventHandler(this.notificationLabel_Click);
			// 
			// metroRadioButton1
			// 
			resources.ApplyResources(this.metroRadioButton1, "metroRadioButton1");
			this.metroRadioButton1.Name = "metroRadioButton1";
			this.mainFormToolTip.SetToolTip(this.metroRadioButton1, resources.GetString("metroRadioButton1.ToolTip"));
			this.metroRadioButton1.UseSelectable = true;
			// 
			// gameTile
			// 
			resources.ApplyResources(this.gameTile, "gameTile");
			this.gameTile.ActiveControl = null;
			this.gameTile.Name = "gameTile";
			this.gameTile.Style = MetroFramework.MetroColorStyle.Blue;
			this.gameTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.gameTile, resources.GetString("gameTile.ToolTip"));
			this.gameTile.UseSelectable = true;
			this.gameTile.UseTileImage = true;
			this.gameTile.Click += new System.EventHandler(this.shortcutTile_Click);
			// 
			// contentTile
			// 
			resources.ApplyResources(this.contentTile, "contentTile");
			this.contentTile.ActiveControl = null;
			this.contentTile.Name = "contentTile";
			this.contentTile.Style = MetroFramework.MetroColorStyle.Orange;
			this.contentTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.contentTile, resources.GetString("contentTile.ToolTip"));
			this.contentTile.UseSelectable = true;
			this.contentTile.UseTileImage = true;
			this.contentTile.Click += new System.EventHandler(this.shortcutTile_Click);
			// 
			// steamTile
			// 
			resources.ApplyResources(this.steamTile, "steamTile");
			this.steamTile.ActiveControl = null;
			this.steamTile.Name = "steamTile";
			this.steamTile.Style = MetroFramework.MetroColorStyle.Silver;
			this.steamTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.steamTile, resources.GetString("steamTile.ToolTip"));
			this.steamTile.UseSelectable = true;
			this.steamTile.UseTileImage = true;
			this.steamTile.Click += new System.EventHandler(this.workshopPageBtn_Click);
			// 
			// vpkTile
			// 
			resources.ApplyResources(this.vpkTile, "vpkTile");
			this.vpkTile.ActiveControl = null;
			this.vpkTile.Name = "vpkTile";
			this.vpkTile.Style = MetroFramework.MetroColorStyle.Red;
			this.vpkTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.vpkTile, resources.GetString("vpkTile.ToolTip"));
			this.vpkTile.UseSelectable = true;
			this.vpkTile.UseTileImage = true;
			this.vpkTile.Click += new System.EventHandler(this.shortcutTile_Click);
			// 
			// optionsTile
			// 
			resources.ApplyResources(this.optionsTile, "optionsTile");
			this.optionsTile.ActiveControl = null;
			this.optionsTile.Name = "optionsTile";
			this.optionsTile.Style = MetroFramework.MetroColorStyle.Silver;
			this.optionsTile.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.optionsTile, resources.GetString("optionsTile.ToolTip"));
			this.optionsTile.UseSelectable = true;
			this.optionsTile.UseTileImage = true;
			this.optionsTile.Click += new System.EventHandler(this.optionsBtn_Click);
			// 
			// customTile1
			// 
			resources.ApplyResources(this.customTile1, "customTile1");
			this.customTile1.ActiveControl = null;
			this.customTile1.ContextMenuStrip = this.tileContextMenu;
			this.customTile1.Name = "customTile1";
			this.customTile1.Style = MetroFramework.MetroColorStyle.Purple;
			this.customTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.customTile1, resources.GetString("customTile1.ToolTip"));
			this.customTile1.UseSelectable = true;
			this.customTile1.UseTileImage = true;
			// 
			// tileContextMenu
			// 
			resources.ApplyResources(this.tileContextMenu, "tileContextMenu");
			this.tileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTileToolStripMenuItem});
			this.tileContextMenu.Name = "metroContextMenu2";
			this.tileContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.tileContextMenu, resources.GetString("tileContextMenu.ToolTip"));
			// 
			// editTileToolStripMenuItem
			// 
			resources.ApplyResources(this.editTileToolStripMenuItem, "editTileToolStripMenuItem");
			this.editTileToolStripMenuItem.Name = "editTileToolStripMenuItem";
			this.editTileToolStripMenuItem.Click += new System.EventHandler(this.editTileToolStripMenuItem_Click);
			// 
			// customTile2
			// 
			resources.ApplyResources(this.customTile2, "customTile2");
			this.customTile2.ActiveControl = null;
			this.customTile2.ContextMenuStrip = this.tileContextMenu;
			this.customTile2.Name = "customTile2";
			this.customTile2.Style = MetroFramework.MetroColorStyle.Brown;
			this.customTile2.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.customTile2, resources.GetString("customTile2.ToolTip"));
			this.customTile2.UseSelectable = true;
			this.customTile2.UseTileImage = true;
			// 
			// customTile3
			// 
			resources.ApplyResources(this.customTile3, "customTile3");
			this.customTile3.ActiveControl = null;
			this.customTile3.ContextMenuStrip = this.tileContextMenu;
			this.customTile3.Name = "customTile3";
			this.customTile3.Style = MetroFramework.MetroColorStyle.Yellow;
			this.customTile3.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.customTile3, resources.GetString("customTile3.ToolTip"));
			this.customTile3.UseSelectable = true;
			this.customTile3.UseTileImage = true;
			// 
			// customTile4
			// 
			resources.ApplyResources(this.customTile4, "customTile4");
			this.customTile4.ActiveControl = null;
			this.customTile4.ContextMenuStrip = this.tileContextMenu;
			this.customTile4.Name = "customTile4";
			this.customTile4.Style = MetroFramework.MetroColorStyle.Lime;
			this.customTile4.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.customTile4, resources.GetString("customTile4.ToolTip"));
			this.customTile4.UseSelectable = true;
			this.customTile4.UseTileImage = true;
			// 
			// customTile5
			// 
			resources.ApplyResources(this.customTile5, "customTile5");
			this.customTile5.ActiveControl = null;
			this.customTile5.ContextMenuStrip = this.tileContextMenu;
			this.customTile5.Name = "customTile5";
			this.customTile5.Style = MetroFramework.MetroColorStyle.Magenta;
			this.customTile5.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.customTile5, resources.GetString("customTile5.ToolTip"));
			this.customTile5.UseSelectable = true;
			this.customTile5.UseTileImage = true;
			// 
			// versionLabel
			// 
			resources.ApplyResources(this.versionLabel, "versionLabel");
			this.versionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.versionLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.versionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Style = MetroFramework.MetroColorStyle.Teal;
			this.versionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.versionLabel, resources.GetString("versionLabel.ToolTip"));
			this.versionLabel.UseSelectable = true;
			this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
			// 
			// donateBtn
			// 
			resources.ApplyResources(this.donateBtn, "donateBtn");
			this.donateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.donateBtn.Name = "donateBtn";
			this.donateBtn.Style = MetroFramework.MetroColorStyle.Yellow;
			this.donateBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.donateBtn, resources.GetString("donateBtn.ToolTip"));
			this.donateBtn.UseSelectable = true;
			this.donateBtn.UseStyleColors = true;
			this.donateBtn.Click += new System.EventHandler(this.donateBtn_Click);
			// 
			// reportBugBtn
			// 
			resources.ApplyResources(this.reportBugBtn, "reportBugBtn");
			this.reportBugBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.reportBugBtn.Name = "reportBugBtn";
			this.reportBugBtn.TabStop = false;
			this.mainFormToolTip.SetToolTip(this.reportBugBtn, resources.GetString("reportBugBtn.ToolTip"));
			this.reportBugBtn.Click += new System.EventHandler(this.reportBug_Click);
			// 
			// progressSpinner1
			// 
			resources.ApplyResources(this.progressSpinner1, "progressSpinner1");
			this.progressSpinner1.Maximum = 100;
			this.progressSpinner1.Name = "progressSpinner1";
			this.progressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.progressSpinner1, resources.GetString("progressSpinner1.ToolTip"));
			this.progressSpinner1.UseSelectable = true;
			this.progressSpinner1.Value = 80;
			// 
			// metroComboBox1
			// 
			resources.ApplyResources(this.metroComboBox1, "metroComboBox1");
			this.metroComboBox1.FormattingEnabled = true;
			this.metroComboBox1.Items.AddRange(new object[] {
            resources.GetString("metroComboBox1.Items"),
            resources.GetString("metroComboBox1.Items1"),
            resources.GetString("metroComboBox1.Items2"),
            resources.GetString("metroComboBox1.Items3"),
            resources.GetString("metroComboBox1.Items4"),
            resources.GetString("metroComboBox1.Items5")});
			this.metroComboBox1.Name = "metroComboBox1";
			this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this.metroComboBox1, resources.GetString("metroComboBox1.ToolTip"));
			this.metroComboBox1.UseSelectable = true;
			// 
			// mainFormToolTip
			// 
			this.mainFormToolTip.OwnerDraw = true;
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Resizable = false;
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mainFormToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
		private MetroFramework.Controls.MetroTabControl tabControl;
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
		private MetroFramework.Controls.MetroComboBox metroComboBox1;
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
		public MetroFramework.Drawing.Html.HtmlToolTip mainFormToolTip;
	}
}
