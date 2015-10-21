using Dota2ModKit.Forms;
using Dota2ModKit.Properties;
using LibGit2Sharp;
using MetroFramework;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Dota2ModKit {
	class Updater {
		MainForm mainForm;
		string version;
		string url = "";
		string newVers = "";
		bool newVersFound = false;
		string barebonesPath = Path.Combine(Environment.CurrentDirectory, "barebones");
		string releases_page_source;

		public Updater(MainForm mainForm) {
			this.mainForm = mainForm;
			version = mainForm.version;

			checkForUpdates();
			clonePullBarebones();
        }

		public void checkForUpdates() {
			// Check for settings updates.
			if (Settings.Default.UpdateRequired) {
				Settings.Default.Upgrade();
				Settings.Default.UpdateRequired = false;
				Settings.Default.Save();
				// open up changelog
				if (Settings.Default.OpenChangelog && !mainForm.DEBUG) {
					Process.Start("https://github.com/Myll/Dota-2-ModKit/releases");
				}
				// display notification
				//text_notification("D2ModKit updated!", MetroColorStyle.Green, 1500);
			}

			var updatesWorker = new BackgroundWorker();

			updatesWorker.DoWork += (s, e) => {
				// use these to test version updater.
				//newVers = "1.3.2";
				//url = "https://github.com/stephenfournier/Dota-2-ModKit/releases/download/v1.3.2/D2ModKit.zip";

				// remember to keep the version naming consistent!
				//  you can go from 1.3.4.4 to 1.3.5.0, OR 1.3.4.0 to 1.3.5.0

				int count = 1;
				int j = 0;
				while (true) {
					newVers = Util.IncrementVers(version, count + j);
					url = "https://github.com/stephenfournier/Dota-2-ModKit/releases/download/v";
					url += newVers + "/D2ModKit.zip";
					WebClient wc = new WebClient();

					try {
						byte[] responseBytes = wc.DownloadData("https://github.com/stephenfournier/Dota-2-ModKit/releases/tag/v" + newVers);
						releases_page_source = System.Text.Encoding.ASCII.GetString(responseBytes);
					} catch (Exception) {
						if (j < 10) {
							j++;
							continue;
						}
						break;
					}

					newVersFound = true;
					count += j + 1;
					j = 0;
				}
				newVers = Util.IncrementVers(version, count - 1);
				url = "https://github.com/stephenfournier/Dota-2-ModKit/releases/download/v";
				url += newVers + "/D2ModKit.zip";
			};

			updatesWorker.RunWorkerCompleted += (s, e) => {
				if (!newVersFound) {
					Debug.WriteLine("No new vers available.");
					return;
				}

				mainForm.newVers = newVers;
				mainForm.newVersUrl = url;
				mainForm.releases_page_source = releases_page_source;

				UpdateInfoForm uif = new UpdateInfoForm(mainForm);
				uif.ShowDialog();
			};

			updatesWorker.RunWorkerAsync();
		}

		internal void clonePullBarebones() {
			mainForm.progressSpinner1.Value = 60;
			mainForm.progressSpinner1.Visible = true;

			if (!Directory.Exists(barebonesPath)) {
				mainForm.mainFormToolTip.SetToolTip(mainForm.progressSpinner1, "Cloning Barebones...");
			} else {
				mainForm.mainFormToolTip.SetToolTip(mainForm.progressSpinner1, "Pulling Barebones...");
			}

			var barebonesCloneWorker = new BackgroundWorker();

			barebonesCloneWorker.DoWork += (s, e) => {
				if (!Directory.Exists(barebonesPath)) {
					try {
						string gitPath = Repository.Clone("https://github.com/bmddota/barebones", barebonesPath);
						Console.WriteLine("repo path:" + gitPath);
					} catch (Exception ex) {

					}
					return;
				}

				// pull from the repo
				using (var repo = new Repository(barebonesPath)) {
					try {
						//var remote = repo.Network.Remotes["origin"];
						MergeResult mr = repo.Network.Pull(new Signature("myname", "myname@email.com", new DateTimeOffset()), new PullOptions());
						MergeStatus ms = mr.Status;
						Console.WriteLine("MergeStatus: " + ms.ToString());
					} catch (Exception ex) {

					}
				}
			};

			barebonesCloneWorker.RunWorkerCompleted += (s, e) => {
				//mainForm.text_notification("", MetroColorStyle.Blue, 500);
				mainForm.mainFormToolTip.SetToolTip(mainForm.progressSpinner1, "");
				mainForm.progressSpinner1.Visible = false;

				if (mainForm.currAddon != null && mainForm.currAddon.barebonesLibUpdates) {
					mainForm.currAddon.checkForDefaultLibs();
					foreach (var lib in mainForm.currAddon.libraries) {
						lib.Value.checkForUpdates();
					}
				}
			};

			barebonesCloneWorker.RunWorkerAsync();
		}
	}
}
