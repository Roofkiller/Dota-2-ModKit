using MetroFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
//using Timer = System.Timers.Timer;

namespace Dota2ModKit {
    public static class Util {
		public static string logPath = Path.Combine(Environment.CurrentDirectory, "debug_log.txt");

		public static void Log(string text) {
			try {
				// if log file is over xxx KB, delete.
				if (File.Exists(logPath) && new FileInfo(logPath).Length > 1024 * 400) {
					File.Delete(logPath);
				}

				if (!File.Exists(logPath)) {
					File.Create(logPath).Close();
				}

				StringBuilder logText = new StringBuilder(File.ReadAllText(logPath));
				if (logText.Length == 0) {
					logText.AppendLine("REPORT THIS TO https://github.com/Myll/Dota-2-ModKit/issues IF CRASHES OCCUR.\n");
                }

				logText.AppendLine("\n\nNEW ENTRY: " + DateTime.Now.ToShortDateString() + ", " + DateTime.Now.ToLongTimeString());
				logText.AppendLine(text);

				File.WriteAllText(logPath, logText.ToString());
			} catch (Exception) { }
		}

        public static MetroColorStyle getRandomStyle() {
            Random rand = new Random();
            return (MetroColorStyle)rand.Next(4, 14);
        }

		internal static void LogException(Exception ex) {
			StringBuilder txt = new StringBuilder();
			txt.AppendLine("ex.toString(): " + ex.ToString());
			// toString() includes the Message and StackTrace.
			//txt.AppendLine("Message: " + ex.Message);
			//txt.AppendLine("StackTrace: " + ex.StackTrace);
			if (ex.InnerException != null) {
				txt.AppendLine("InnerException.toString(): " + ex.InnerException.ToString());
			}

			Log(txt.ToString());
		}

        public static Timer CreateTimer(int interval, Action<Timer> onTick) {
            Timer timer = new Timer();
            timer.Interval = interval;
            timer.Tick += (s, e) => {
                onTick(timer);
            };
            timer.Start();
            return timer;
        }

        public static string Relative(string str) {
			if (str.Contains(Path.Combine("game", "dota_addons"))) {
				return str.Substring(str.IndexOf(Path.Combine("game", "dota_addons")));
			} else if (str.Contains(Path.Combine("content", "dota_addons"))) {
				return str.Substring(str.IndexOf(Path.Combine("content", "dota_addons")));
			}
			return null;
		}

		public static string DoUniqueString() {
			Guid g = Guid.NewGuid();
			string GuidString = Convert.ToBase64String(g.ToByteArray());
			GuidString = GuidString.Replace("=", "");
			GuidString = GuidString.Replace("+", "");

			return GuidString;
		}

		public static long GetDirectorySize(string dirPath) {
			// 1.
			// Get array of all file names.
			string[] filePaths = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);

			// 2.
			// Calculate total bytes of all files in a loop.
			long totalBytes = 0;
			foreach (string filePath in filePaths) {
				// 3.
				// Use FileInfo to get length of each file.
				FileInfo info = new FileInfo(filePath);
				totalBytes += info.Length;
			}
			// 4.
			// Return total size
			return totalBytes;
		}

		public static string findCommonBeginning(string[] strs) {
			string commonBeginning = "";
			int maxLength = Int32.MaxValue;

			foreach (string s in strs) {
				if (s.Length < maxLength) {
					maxLength = s.Length;
				}
			}
			for (int i = 0; i < maxLength; i++) {

				string possibleCommonBeg = commonBeginning + strs[0][i];
				foreach (string s in strs) {
					if (!s.StartsWith(possibleCommonBeg)) {
						return commonBeginning;
					}
				}
				commonBeginning = possibleCommonBeg;
			}
			return commonBeginning;
		}

		public static string getDotaDir() {
			string dotaDir = "";
			// Auto-find the dota path.
			Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.LocalMachine;
			try {
				regKey =
					regKey.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 570");
				if (regKey != null) {
					string dir = regKey.GetValue("InstallLocation").ToString();
					dotaDir = dir;
				}
			} catch (Exception) {

			}

			if (dotaDir != "") {
				return dotaDir;
			}

			// try another way to auto-get the dir
			string p1 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
			string p2 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

			p1 = Path.Combine(p1, "steam", "steamapps", "common", "dota 2 beta");
			p2 = Path.Combine(p2, "steam", "steamapps", "common", "dota 2 beta");

			if (Directory.Exists(p1)) {
				dotaDir = p1;
			} else if (Directory.Exists(p2)) {
				dotaDir = p2;
			}

			// try another
			p1 = Path.Combine(p1, "steam", "steamapps", "common", "dota 2");
			p2 = Path.Combine(p2, "steam", "steamapps", "common", "dota 2");

			if (Directory.Exists(p1)) {
				dotaDir = p1;
			} else if (Directory.Exists(p2)) {
				dotaDir = p2;
			}

			return dotaDir;
		}

		public static bool hasSameDrives(string path1, string path2) {
			// D2ModKit must be ran from the same drive as dota or else things will break.
			char path1Drive = path1[0];
			char path2Drive = path2[0];
			if (path1Drive != path2Drive) {
				return false;
			}
			return true;
		}

		/// <summary>
		/// Determines a text file's encoding by analyzing its byte order mark (BOM).
		/// Defaults to ASCII when detection of the text file's endianness fails.
		/// </summary>
		/// <param name="filename">The text file to analyze.</param>
		/// <returns>The detected encoding.</returns>
		public static Encoding GetEncoding(string filename) {
			// Read the BOM
			var bom = new byte[4];
			using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
				file.Read(bom, 0, 4);
			}

			// Analyze the BOM
			if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
			if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
			if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
			if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
			if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
			return Encoding.ASCII;
		}

		public static List<string> getFiles(string directory, string searchPattern) {
		List<string> allFiles = new List<string>();
		string[] exts = searchPattern.Split(';');
		for (int i = 0; i < exts.Count(); i++) {
			string[] foundFiles = Directory.GetFiles(directory, exts[i], SearchOption.AllDirectories);
			for (int j = 0; j < foundFiles.Count(); j++) {
				allFiles.Add(foundFiles[j]);
			}
		}
		return allFiles;
	}

	public static string[] getRGB() {
			string[] rgb = new string[3];
			ColorDialog color = new ColorDialog();
			color.AnyColor = true;
			color.AllowFullOpen = true;
			DialogResult re = color.ShowDialog();
			if (re == DialogResult.OK) {
				Color picked = color.Color;
				rgb[0] = picked.R.ToString();
				rgb[1] = picked.G.ToString();
				rgb[2] = picked.B.ToString();
			} else {
				return null;
			}
			return rgb;
		}

		public static string incrementVers(string vers, int add) {
			//Debug.WriteLine("input: " + vers);
			// check for new Vers
			string[] numStrings = vers.Split('.');
			int thousands = Int32.Parse(numStrings[0]) * 1000;
			int hundreds = Int32.Parse(numStrings[1]) * 100;
			int tens = Int32.Parse(numStrings[2]) * 10;
			int ones = Int32.Parse(numStrings[3]);
			int num = thousands + hundreds + tens + ones + add;

			//Debug.WriteLine("new num: " + num);
			int newThousands = num / 1000;
			int newHundreds = (num - newThousands * 1000) / 100;
			int newTens = (num - newThousands * 1000 - newHundreds * 100) / 10;
			int newOnes = num - newThousands * 1000 - newHundreds * 100 - newTens * 10;
			string newVers = newThousands + "." + newHundreds + "." + newTens + "." + newOnes;
			//Debug.WriteLine("New vers: " + newVers);
			return newVers;
		}

		internal static System.Drawing.Image imageUrlToObj(string url) {
			WebClient wc = new WebClient();
			byte[] bytes = wc.DownloadData("http://localhost/image.gif");
			MemoryStream ms = new MemoryStream(bytes);
			System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

			return img;
		}

		internal static string MakeUnderscoreStringNice(string str) {
			string[] split = str.Split('_');
			StringBuilder newS = new StringBuilder();
			for (int i = 0; i < split.Length; i++) {
				string s = split[i];
				if (s.Length == 0) {
					continue;
				}

				newS.Append(s[0].ToString().ToUpper());
				if (s.Length > 1) {
					newS.Append(s.Substring(1, s.Length-1));
				}

				if (i < split.Length-1) {
					newS.Append(" ");
				}
			}
			return newS.ToString();
		}

		internal static bool ContainsKVKey(string txt) {
			string[] kvKeys = new string[] {
				//"precache",
				"OnSpellStart",
				"Modifiers",
				"RunScript",
				".vpcf",
				".vsndevts",
			};
			for (int i = 0; i < kvKeys.Length; i++) {
				if (txt.Contains(kvKeys[i])) {
					return true;
				}
			}
			return false;
		}
	}
}
