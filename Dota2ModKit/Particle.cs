using MetroFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit {
	class Particle {
		public string path;
		public string[] lines;

		public Particle(string path) {
			this.path = path;
			lines = File.ReadAllLines(path);
		}

		internal bool alterParticle(MainForm mf, string[] rgb, int sizeValue) {
			List<string> newLines = new List<string>();
			bool changeColor = false, changeSize = false;
			int newR = 0, newG = 0, newB = 0;

			if (rgb != null) {
				changeColor = true;
				newR = Int32.Parse(rgb[0]);
				newG = Int32.Parse(rgb[1]);
				newB = Int32.Parse(rgb[2]);
			}
			if (sizeValue != 0) {
				changeSize = true;
			}

			bool colorKeyFound = false;
			int count = 0;
			int r, g, b;
			//int rIndex, gIndex, bIndex, aIndex;
			bool error = false;

			// Are we currently inside a colorKey or sizeKey?
			for (int i = 0; i < lines.Length; i++) {
				string l = lines[i];

				if (i == 0) {
					// Check if particle is in KV3 format.
					if (!l.Contains("<!-- kv3")) {
						MetroMessageBox.Show(mf, path + " is not in KV3 format!",
						"Error parsing .vpcf",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
						error = true;
						break;
					}
				}

				if (colorKeyFound && changeColor) {
					count++;
					l = l.Trim();

					if (count == 2) {
						// we're at the 1st number
						if (Int32.TryParse(l.Substring(0, l.IndexOf(',')), out r)) {
							l = newR.ToString() + ",";
						}
					} else if (count == 3) {
						if (Int32.TryParse(l.Substring(0, l.IndexOf(',')), out g)) {
							l = newG.ToString() + ",";
						}
					} else if (count == 4) {
						if (Int32.TryParse(l.Substring(0, l.IndexOf(',')), out b)) {
							l = newB.ToString() + ",";
						}
						colorKeyFound = false;
						count = 0;
					}

				}

				// check for colorKeys.
				if (l.Contains("ColorMin") ||
					l.Contains("ColorMax") ||
					l.Contains("ConstantColor") ||
					l.Contains("ColorScale") ||
					l.Contains("ColorFade") ||
					l.Contains("TintMin") ||
					l.Contains("TintMax")) {

					// alter the color
					colorKeyFound = true;


				// check for sizeKeys.
				} else if (l.Contains("Radius") && l.Contains("=") && changeSize) {
					l = l.Trim();

					string[] delims = { " = " };
					string[] split = l.Split(delims, 2, StringSplitOptions.None);

					string part1 = split[0];
					string part2 = split[1];

					//note: a radius will never be negative. thus the formula works fine.
					if (l.Contains("m_f")) {
						double currVal = 0;
						if (Double.TryParse(part2, out currVal)) {
							double newVal = currVal + (sizeValue / 100.0) * Math.Abs(currVal);
							if (newVal < 0) {
								// put it at 10% of the currVal
								newVal = currVal*.1;
							}
							l = part1 + " = " + newVal.ToString();
						}
					} else if (l.Contains("m_n")) {
						int currVal = 0;
						if (Int32.TryParse(part2, out currVal)) {
							int newVal = (int)Math.Round(currVal + (sizeValue / 100.0) + Math.Abs(currVal));
							if (newVal < 0) {
								// put it at 10% of the currVal
								newVal = (int)Math.Round(currVal * .1);
							}
							l = part1 + " = " + newVal.ToString();
						}
					}
				}
				newLines.Add(l);
			}

			if (!error) {
				lines = newLines.ToArray();
				File.WriteAllLines(path, lines);
			} else {
				return false;
			}
			return true;
		}
	}
}
