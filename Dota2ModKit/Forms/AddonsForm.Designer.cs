namespace Dota2ModKit {
	partial class AddonsForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddonsForm));
			this.tabControl = new MetroFramework.Controls.MetroTabControl();
			this.myAddonsTab = new MetroFramework.Controls.MetroTabPage();
			this.metroTile1 = new MetroFramework.Controls.MetroTile();
			this.newAddonTab = new MetroFramework.Controls.MetroTabPage();
			this.stringToReplaceTextbox = new MetroFramework.Controls.MetroTextBox();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.existingAddonRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
			this.progressLabel = new MetroFramework.Controls.MetroLabel();
			this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
			this.addonNameTextBox = new MetroFramework.Controls.MetroTextBox();
			this.addonNameLabel = new MetroFramework.Controls.MetroLabel();
			this.createAddonBtn = new MetroFramework.Controls.MetroButton();
			this.bmdRadioButton = new MetroFramework.Controls.MetroRadioButton();
			this.dummyBtn = new MetroFramework.Controls.MetroRadioButton();
			this.tabControl.SuspendLayout();
			this.myAddonsTab.SuspendLayout();
			this.newAddonTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.myAddonsTab);
			this.tabControl.Controls.Add(this.newAddonTab);
			this.tabControl.FontSize = MetroFramework.MetroTabControlSize.Tall;
			this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
			this.tabControl.Location = new System.Drawing.Point(4, 52);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(556, 584);
			this.tabControl.TabIndex = 1;
			this.tabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.tabControl.UseSelectable = true;
			// 
			// myAddonsTab
			// 
			this.myAddonsTab.AutoScroll = true;
			this.myAddonsTab.Controls.Add(this.metroTile1);
			this.myAddonsTab.HorizontalScrollbar = true;
			this.myAddonsTab.HorizontalScrollbarBarColor = true;
			this.myAddonsTab.HorizontalScrollbarHighlightOnWheel = false;
			this.myAddonsTab.HorizontalScrollbarSize = 10;
			this.myAddonsTab.Location = new System.Drawing.Point(4, 44);
			this.myAddonsTab.Name = "myAddonsTab";
			this.myAddonsTab.Size = new System.Drawing.Size(548, 536);
			this.myAddonsTab.TabIndex = 0;
			this.myAddonsTab.Text = "My Addons";
			this.myAddonsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.myAddonsTab.VerticalScrollbar = true;
			this.myAddonsTab.VerticalScrollbarBarColor = true;
			this.myAddonsTab.VerticalScrollbarHighlightOnWheel = true;
			this.myAddonsTab.VerticalScrollbarSize = 10;
			// 
			// metroTile1
			// 
			this.metroTile1.ActiveControl = null;
			this.metroTile1.Location = new System.Drawing.Point(4, 8);
			this.metroTile1.Name = "metroTile1";
			this.metroTile1.Size = new System.Drawing.Size(124, 108);
			this.metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroTile1.TabIndex = 2;
			this.metroTile1.Text = "metroTile1";
			this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroTile1.UseSelectable = true;
			this.metroTile1.Click += new System.EventHandler(this.metroTile_Click);
			// 
			// newAddonTab
			// 
			this.newAddonTab.Controls.Add(this.stringToReplaceTextbox);
			this.newAddonTab.Controls.Add(this.metroLabel1);
			this.newAddonTab.Controls.Add(this.existingAddonRadioButton1);
			this.newAddonTab.Controls.Add(this.progressLabel);
			this.newAddonTab.Controls.Add(this.metroProgressBar1);
			this.newAddonTab.Controls.Add(this.addonNameTextBox);
			this.newAddonTab.Controls.Add(this.addonNameLabel);
			this.newAddonTab.Controls.Add(this.createAddonBtn);
			this.newAddonTab.Controls.Add(this.bmdRadioButton);
			this.newAddonTab.HorizontalScrollbarBarColor = true;
			this.newAddonTab.HorizontalScrollbarHighlightOnWheel = false;
			this.newAddonTab.HorizontalScrollbarSize = 10;
			this.newAddonTab.Location = new System.Drawing.Point(4, 44);
			this.newAddonTab.Name = "newAddonTab";
			this.newAddonTab.Size = new System.Drawing.Size(548, 536);
			this.newAddonTab.TabIndex = 1;
			this.newAddonTab.Text = "New Addon";
			this.newAddonTab.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.newAddonTab.VerticalScrollbarBarColor = true;
			this.newAddonTab.VerticalScrollbarHighlightOnWheel = false;
			this.newAddonTab.VerticalScrollbarSize = 10;
			// 
			// stringToReplaceTextbox
			// 
			this.stringToReplaceTextbox.Lines = new string[0];
			this.stringToReplaceTextbox.Location = new System.Drawing.Point(114, 46);
			this.stringToReplaceTextbox.MaxLength = 32767;
			this.stringToReplaceTextbox.Name = "stringToReplaceTextbox";
			this.stringToReplaceTextbox.PasswordChar = '\0';
			this.stringToReplaceTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.stringToReplaceTextbox.SelectedText = "";
			this.stringToReplaceTextbox.Size = new System.Drawing.Size(173, 23);
			this.stringToReplaceTextbox.TabIndex = 14;
			this.stringToReplaceTextbox.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.stringToReplaceTextbox.UseSelectable = true;
			this.stringToReplaceTextbox.Visible = false;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel1.Location = new System.Drawing.Point(-4, 50);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(112, 19);
			this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
			this.metroLabel1.TabIndex = 13;
			this.metroLabel1.Text = "String to replace:";
			this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroLabel1.Visible = false;
			// 
			// existingAddonRadioButton1
			// 
			this.existingAddonRadioButton1.AutoSize = true;
			this.existingAddonRadioButton1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
			this.existingAddonRadioButton1.Location = new System.Drawing.Point(139, 21);
			this.existingAddonRadioButton1.Name = "existingAddonRadioButton1";
			this.existingAddonRadioButton1.Size = new System.Drawing.Size(152, 19);
			this.existingAddonRadioButton1.TabIndex = 12;
			this.existingAddonRadioButton1.Text = "From Existing Addon";
			this.existingAddonRadioButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.existingAddonRadioButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.existingAddonRadioButton1.UseSelectable = true;
			this.existingAddonRadioButton1.Visible = false;
			// 
			// progressLabel
			// 
			this.progressLabel.AutoSize = true;
			this.progressLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.progressLabel.Location = new System.Drawing.Point(193, 146);
			this.progressLabel.Name = "progressLabel";
			this.progressLabel.Size = new System.Drawing.Size(99, 19);
			this.progressLabel.Style = MetroFramework.MetroColorStyle.Blue;
			this.progressLabel.TabIndex = 11;
			this.progressLabel.Text = "Downloading...";
			this.progressLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.progressLabel.Visible = false;
			// 
			// metroProgressBar1
			// 
			this.metroProgressBar1.Location = new System.Drawing.Point(31, 168);
			this.metroProgressBar1.Name = "metroProgressBar1";
			this.metroProgressBar1.Size = new System.Drawing.Size(426, 26);
			this.metroProgressBar1.TabIndex = 10;
			this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.metroProgressBar1.Visible = false;
			// 
			// addonNameTextBox
			// 
			this.addonNameTextBox.Lines = new string[0];
			this.addonNameTextBox.Location = new System.Drawing.Point(220, 76);
			this.addonNameTextBox.MaxLength = 32767;
			this.addonNameTextBox.Name = "addonNameTextBox";
			this.addonNameTextBox.PasswordChar = '\0';
			this.addonNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.addonNameTextBox.SelectedText = "";
			this.addonNameTextBox.Size = new System.Drawing.Size(173, 23);
			this.addonNameTextBox.TabIndex = 9;
			this.addonNameTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.addonNameTextBox.UseSelectable = true;
			this.addonNameTextBox.Click += new System.EventHandler(this.addonNameTextBox_Click);
			// 
			// addonNameLabel
			// 
			this.addonNameLabel.AutoSize = true;
			this.addonNameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.addonNameLabel.Location = new System.Drawing.Point(-4, 76);
			this.addonNameLabel.Name = "addonNameLabel";
			this.addonNameLabel.Size = new System.Drawing.Size(218, 38);
			this.addonNameLabel.Style = MetroFramework.MetroColorStyle.Blue;
			this.addonNameLabel.TabIndex = 8;
			this.addonNameLabel.Text = "New Addon Name (in camel-case):\r\n(ex. YourAddonName)";
			this.addonNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
			// 
			// createAddonBtn
			// 
			this.createAddonBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
			this.createAddonBtn.Location = new System.Drawing.Point(156, 360);
			this.createAddonBtn.Margin = new System.Windows.Forms.Padding(4);
			this.createAddonBtn.Name = "createAddonBtn";
			this.createAddonBtn.Size = new System.Drawing.Size(176, 41);
			this.createAddonBtn.Style = MetroFramework.MetroColorStyle.Blue;
			this.createAddonBtn.TabIndex = 5;
			this.createAddonBtn.TabStop = false;
			this.createAddonBtn.Text = "Create Addon";
			this.createAddonBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.createAddonBtn.UseSelectable = true;
			this.createAddonBtn.UseStyleColors = true;
			this.createAddonBtn.Click += new System.EventHandler(this.createAddonBtn_Click);
			// 
			// bmdRadioButton
			// 
			this.bmdRadioButton.AutoSize = true;
			this.bmdRadioButton.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
			this.bmdRadioButton.Location = new System.Drawing.Point(0, 21);
			this.bmdRadioButton.Name = "bmdRadioButton";
			this.bmdRadioButton.Size = new System.Drawing.Size(133, 19);
			this.bmdRadioButton.TabIndex = 2;
			this.bmdRadioButton.Text = "BMD\'s Barebones";
			this.bmdRadioButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.bmdRadioButton.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.bmdRadioButton.UseSelectable = true;
			// 
			// dummyBtn
			// 
			this.dummyBtn.AutoSize = true;
			this.dummyBtn.Location = new System.Drawing.Point(289, 2);
			this.dummyBtn.Name = "dummyBtn";
			this.dummyBtn.Size = new System.Drawing.Size(127, 15);
			this.dummyBtn.TabIndex = 10;
			this.dummyBtn.Text = "metroRadioButton2";
			this.dummyBtn.UseSelectable = true;
			this.dummyBtn.Visible = false;
			// 
			// AddonsForm
			// 
			this.AcceptButton = this.createAddonBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 646);
			this.Controls.Add(this.dummyBtn);
			this.Controls.Add(this.tabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddonsForm";
			this.Resizable = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Addon Library";
			this.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.tabControl.ResumeLayout(false);
			this.myAddonsTab.ResumeLayout(false);
			this.newAddonTab.ResumeLayout(false);
			this.newAddonTab.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroTabControl tabControl;
		private MetroFramework.Controls.MetroTabPage myAddonsTab;
		private MetroFramework.Controls.MetroTabPage newAddonTab;
		private MetroFramework.Controls.MetroRadioButton bmdRadioButton;
		private MetroFramework.Controls.MetroTile metroTile1;
		private MetroFramework.Controls.MetroRadioButton dummyBtn;
		private MetroFramework.Controls.MetroButton createAddonBtn;
		private MetroFramework.Controls.MetroLabel addonNameLabel;
		private MetroFramework.Controls.MetroTextBox addonNameTextBox;
		private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
		private MetroFramework.Controls.MetroLabel progressLabel;
		private MetroFramework.Controls.MetroTextBox stringToReplaceTextbox;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroRadioButton existingAddonRadioButton1;
	}
}