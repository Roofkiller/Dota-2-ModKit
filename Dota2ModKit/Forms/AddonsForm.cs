using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Dota2ModKit {
	public partial class AddonsForm : MetroForm {
		private MainForm mainForm;
		int currPage = 1;
		int totalPages = 1;
		List<MetroTile> mts = new List<MetroTile>();

		// for addon forking
		string newAddonName;
		bool remove_print = false;
		bool remove_items = false;
		bool remove_heroes = false;
        string version = "bmd";
		string existingAddonName = "";

		public AddonsForm(MainForm mainForm) {
			this.mainForm = mainForm;

			InitializeComponent();

			tabControl.SelectedIndex = 0;
			createAddonBtn.Enabled = true;
			bmdRadioButton.Checked = true;

			mts.Add(metroTile1);
			mts.Add(metroTile2);
			mts.Add(metroTile3);
			mts.Add(metroTile4);
			mts.Add(metroTile5);
			mts.Add(metroTile6);
			mts.Add(metroTile7);
			mts.Add(metroTile8);
			mts.Add(metroTile9);
			mts.Add(metroTile10);
			mts.Add(metroTile11);
			mts.Add(metroTile12);
			mts.Add(metroTile13);
			mts.Add(metroTile14);
			mts.Add(metroTile15);
			mts.Add(metroTile16);

			totalPages = mainForm.addons.Count / 16;

			if (mainForm.addons.Count % 16 != 0) {
				totalPages++;
			}

			if (totalPages == 1) {
				nextBtn.Visible = false;
			}

			int addonCount = 0;
			int pos = 1;
			int page = 1;
			foreach (KeyValuePair<string, Addon> kv in mainForm.addons) {
				Addon a = kv.Value;
				addonCount++;

				// store the page and pos of this addon
				a.libraryPos = pos;
				a.libraryPage = page;

				//if ()

				pos++;

				if (addonCount % 16 == 0) {
					page++;
					pos = 1;
				}
			}

			backBtn.Visible = false;

			refreshPage();
		}

		private void nextBtn_Click(object sender, EventArgs e) {
			dummyBtn.Select();

			if (currPage != totalPages) {
				currPage++;
				refreshPage();
			}

			if (currPage == totalPages) {
				nextBtn.Visible = false;
			}

			if (!backBtn.Visible) {
				backBtn.Visible = true;
			}

		}

		private void backBtn_Click(object sender, EventArgs e) {
			dummyBtn.Select();

			if (currPage == 1) {
				return;
			}

			currPage--;

			if (currPage == 1) {
				backBtn.Visible = false;
			}

			if (!nextBtn.Visible) {
				nextBtn.Visible = true;
			}

			refreshPage();
		}

		private void refreshPage() {

			for (int i = 0; i < mts.Count; i++) {
				MetroTile mt = mts[i];
				mt.Visible = false;
				mt.UseTileImage = false;
			}

			foreach (KeyValuePair<string, Addon> kv in mainForm.addons) {
				Addon a = kv.Value;
				if (a.libraryPage == currPage) {
					for (int i = 0; i < mts.Count; i++) {
						if (a.libraryPos == i+1) {
							MetroTile mt = mts[i];
							mt.Text = a.name;
							mt.Visible = true;
							bool useImage = false;

							if (a.image != null) {
								useImage = true;
							} else if (!a.doesntHaveThumbnail) {
								if (mainForm.findAddonThumbnail(a) != null) {
									useImage = true;
								}
							}

							if (useImage) {
								mt.UseTileImage = true;
								Size size = new Size(mt.Width, mt.Height);
								mt.TileImage = (Image)new Bitmap(a.image, size);
							} else {
								if (a == mainForm.currAddon) {
									// we alrdy know the tileColor for the currAddon if it's not using an image.
									mt.Style = mainForm.addonTile.Style;
								} else {
									a.tileColor = mt.Style;
								}	
							}
							break;
						}
					}
				}
			}
		}

		private void metroTile_Click(object sender, EventArgs e) {
			string s = sender.ToString();

			string addonName = s.Substring(s.LastIndexOf(':') + 2);
			mainForm.changeCurrAddon(mainForm.getAddonFromName(addonName));
			mainForm.addonTile.Text = addonName;

			this.Close();
		}

		private void createAddonBtn_Click(object sender, EventArgs e) {
			try {
				createAddon();
			} catch (Exception ex) {
				MetroMessageBox.Show(this, ex.ToString() + "\n" + ex.Message,
					"Error while creating addon.",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Util.LogException(ex);
			}
            
        }

		private void createAddon() {
			dummyBtn.Select();

			// ensure an addon is selected.
			if (existingAddonRadioButton1.Checked) {
				version = "existing";
			}

			// check if stuff in textbox is fine.
			newAddonName = addonNameTextBox.Text;
			if (newAddonName == "" || !(newAddonName.Length > 2)) {
				MetroMessageBox.Show(this, "Length must be > 2 characters.",
					"Invalid addon name",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// init some of the new addon stuff
			string lower = newAddonName.ToLowerInvariant();
			string upper = newAddonName.ToUpperInvariant();

			string newG = Path.Combine(mainForm.gamePath, lower);
			string newC = Path.Combine(mainForm.contentPath, lower);

			// Ensure the addon doesn't already exist.
			if (Directory.Exists(newG)) {
				MetroMessageBox.Show(this, newG + " already exists!",
					"Directory already exists",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			} else if (Directory.Exists(newC)) {
				MetroMessageBox.Show(this, newC + " already exists!",
					"Directory already exists",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// do inital specific forking stuff
			bool dontContinue = false;
			if (version == "existing") {
				if (!forkExisting()) {
					dontContinue = true;
				}


			} else if (version == "bmd") {
				//stringToReplaceTextbox.ReadOnly = true;
				//stringToReplaceTextbox.Text = "barebones";
				if (!forkBMD()) {
					dontContinue = true;
				}
			}

			if (dontContinue) {
				MetroMessageBox.Show(this, "Addon was not created.",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			// do general forking stuff
			fork();

			// move the game and content dirs to the actual dirs
			string game = Path.Combine(Environment.CurrentDirectory, lower, "game", "dota_addons", lower);
			string content = Path.Combine(Environment.CurrentDirectory, lower, "content", "dota_addons", lower);
			Directory.Move(game, newG);
			Directory.Move(content, newC);

			// delete the old dir now.
			Directory.Delete(Path.Combine(Environment.CurrentDirectory, lower), true);

			// change currAddon on the main form.
			Addon newAddon = new Addon(newG);
			mainForm.addons.Add(lower, newAddon);
			mainForm.changeCurrAddon(newAddon);

			mainForm.text_notification("Successfully created new addon: " + newAddonName.ToLowerInvariant(), MetroColorStyle.Green, 2500);
			Process.Start(Path.Combine(newG, "scripts", "vscripts"));
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private bool forkExisting() {
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.Description = "Browse to the existing addon's 'game' directory";
			DialogResult dr = fbd.ShowDialog();
			if (dr != DialogResult.OK) {
				return false;
			}
			var path = fbd.SelectedPath;
			existingAddonName = path.Substring(path.LastIndexOf('\\') + 1);


			return true;
		}

		private bool forkBMD() {
			// done with all the checks, now procede to fork addon
			string barebonesDir = Path.Combine(Environment.CurrentDirectory, "barebones");
			string newBarebonesDir = Path.Combine(Environment.CurrentDirectory, "barebones_temp");

			if (!Directory.Exists(barebonesDir)) {
				MetroMessageBox.Show(this, "Error",
					barebonesDir + " doesn't exist!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return false;
			}

			// maybe this can exist if forking went wrong before.
			if (Directory.Exists(newBarebonesDir)) {
				Directory.Delete(newBarebonesDir, true);
			}

			// copy everything from barebonesDir to a new dir.
			// Create all of the directories
			foreach (string dir in Directory.GetDirectories(barebonesDir, "*", SearchOption.AllDirectories)) {
				// don't copy git dir
				if (dir.Contains(".git")) {
					continue;
				}

				Directory.CreateDirectory(dir.Replace(barebonesDir, newBarebonesDir));
			}

			// Copy all the files & Replaces any files with the same name
			foreach (string oldPath in Directory.GetFiles(barebonesDir, "*.*", SearchOption.AllDirectories)) {
				if (oldPath.Contains(Path.Combine("barebones", ".git"))) {
					continue;
				}

				File.Copy(oldPath, oldPath.Replace(barebonesDir, newBarebonesDir), true);
			}

			return true;
		}

		private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
			metroProgressBar1.Value = metroProgressBar1.Value + (e.ProgressPercentage - metroProgressBar1.Value);
		}

		private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
	
		}

		private void fork() {
			// we assume we have a valid 'barebones' dir with 'game' and 'content' due to our checks earlier.
			string newLower = newAddonName.ToLowerInvariant();
			string newUpper = newAddonName.ToUpperInvariant();

			// first move the root dir.
			string rootDir = Path.Combine(Environment.CurrentDirectory, "barebones_temp");
			string newRootDir = rootDir.Replace("barebones_temp", newLower);

			// this could happen if there was an error before when forking an addon.
			if (Directory.Exists(newRootDir)) {
				Directory.Delete(newRootDir, true);
			}

			// TODO: sometimes this causes a "access denied" error.
			Directory.Move(rootDir, newRootDir);

			// next modify subdirectory names.
			string[] dirs = Directory.GetDirectories(newRootDir, "*barebones*", SearchOption.AllDirectories);
			for (int i = 0; i < dirs.Length; i++) {
				string newDir = dirs[i].Replace("barebones", newLower);
				Directory.Move(dirs[i], newDir);
			}

			List<string> files = Util.GetFiles(newRootDir, "*.txt;*.lua;*.vmap");
			for (int i = 0; i < files.Count; i++) {
				// let's change the filename first, before modifying the contents.
				string newFileName = files[i].Replace("barebones", newLower);
				newFileName = newFileName.Replace("reflex", newLower);
				newFileName = newFileName.Replace("gamemode", newLower);
				File.Move(files[i], newFileName);
				files[i] = newFileName;

				// don't modify contents of these files.
				if (newFileName.Contains(".vmap")) {
					continue;
				}

				// now modify file contents
				Encoding enc = Util.GetEncoding(files[i]);
				string[] lines = File.ReadAllLines(files[i], enc);

				for (int j = 0; j < lines.Length; j++) {
					string l = lines[j];

					// special cases for special files
					if (remove_items && newFileName.EndsWith("npc_abilities_override.txt")) {
						l = l.Replace("//\"item_", "\"item_");
					}
					if (remove_heroes && newFileName.EndsWith("herolist.txt")) {
						if (!l.Contains("npc_dota_hero_ancient_apparition")) {
							l = l.Replace("\"npc_dota_hero_", "//\"npc_dota_hero_");
						}
					}

					l = l.Replace("barebones", newLower);
					l = l.Replace("BAREBONES", newUpper);
					l = l.Replace("Barebones", newAddonName);
					l = l.Replace("BareBones", newAddonName);
					l = l.Replace("reflex", newLower);
					l = l.Replace("Reflex", newAddonName);
					l = l.Replace("gamemode", newLower);
					l = l.Replace("REFLEX", newUpper);
					if (newFileName.EndsWith(newLower + ".lua") && remove_print) {
						string trimmed = l.Trim();
						if (trimmed.StartsWith("print") || trimmed.StartsWith("Print")) {
							l = l.Replace("Print", "--Print");
							l = l.Replace("print", "--print");
						}
					}
					if (l.Contains("GameMode") && !l.Contains("GetGameModeEntity")) {
						l = l.Replace("GameMode", newAddonName);
					}
					lines[j] = l;
				}

				File.WriteAllLines(files[i], lines, enc);
			}
		}

		private void addonNameTextBox_Click(object sender, EventArgs e) {

		}
	}
}
