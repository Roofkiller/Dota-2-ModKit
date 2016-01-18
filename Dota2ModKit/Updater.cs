using Dota2ModKit.Forms;
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
        }

		public void checkForUpdates() {
			using (var updatesWorker = new BackgroundWorker()) {
				updatesWorker.DoWork += UpdatesWorker_DoWork;
				updatesWorker.RunWorkerCompleted += UpdatesWorker_RunWorkerCompleted;
				updatesWorker.RunWorkerAsync();
			}
		}

		private void UpdatesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (!newVersFound) {
				Debug.WriteLine("No new vers available.");
				return;
			}

			mainForm.newVers = newVers;
			mainForm.newVersUrl = url;
			mainForm.releases_page_source = releases_page_source;

			UpdateInfoForm uif = new UpdateInfoForm(mainForm);
			uif.ShowDialog();
		}

		private void UpdatesWorker_DoWork(object sender, DoWorkEventArgs e) {
			// use these to test version updater.
			//newVers = "1.3.2";
			//url = "https://github.com/stephenfournier/Dota-2-ModKit/releases/download/v1.3.2/D2ModKit.zip";

			// remember to keep the version naming consistent!
			//  you can go from 1.3.4.4 to 1.3.5.0, OR 1.3.4.0 to 1.3.5.0

			int count = 1;
			int j = 0;
			while (true) {
				newVers = Util.incrementVers(version, count + j);
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
			newVers = Util.incrementVers(version, count - 1);
			url = "https://github.com/stephenfournier/Dota-2-ModKit/releases/download/v";
			url += newVers + "/D2ModKit.zip";
		}

		internal void clonePullBarebones() {
			mainForm.ProgressSpinner1.Value = 60;
			mainForm.ProgressSpinner1.Visible = true;

			if (!Directory.Exists(barebonesPath)) {
				mainForm.text_notification("Cloning Barebones...", MetroColorStyle.Blue, 999999);
			} else {
				mainForm.text_notification("Pulling Barebones...", MetroColorStyle.Blue, 999999);
			}

			using (var barebonesCloneWorker = new BackgroundWorker()) {
				
				barebonesCloneWorker.RunWorkerCompleted += BarebonesCloneWorker_RunWorkerCompleted;
				barebonesCloneWorker.DoWork += BarebonesCloneWorker_DoWork;
				barebonesCloneWorker.RunWorkerAsync();
			}
		}

		private void BarebonesCloneWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			mainForm.text_notification("", MetroColorStyle.Blue, 500);
			mainForm.ProgressSpinner1.Visible = false;

			if (mainForm.currAddon != null && mainForm.currAddon.barebonesLibUpdates) {
			}

		}

		private void BarebonesCloneWorker_DoWork(object sender, DoWorkEventArgs e) {
			if (!Directory.Exists(barebonesPath)) {
				try {
					string gitPath = Repository.Clone("https://github.com/bmddota/barebones", barebonesPath);
					Console.WriteLine("repo path:" + gitPath);
				} catch (Exception) {

				}
				return;
			}

			// pull from the repo
			using (var repo = new Repository(barebonesPath)) {
				try {
                    MergeResult mr = repo.Network.Pull(new Signature("myname", "myname@gmail.com", new DateTimeOffset()), new PullOptions());
					MergeStatus ms = mr.Status;
					Console.WriteLine("MergeStatus: " + ms.ToString());
				} catch (Exception) {

				}
			}
		}
	}
}
