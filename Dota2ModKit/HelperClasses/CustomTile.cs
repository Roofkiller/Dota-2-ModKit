using Dota2ModKit.Forms;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ModKit {
	public class CustomTile {
		public MainForm mainForm;
		public MetroTile tile;
		private string path = "";
		public int tileNum = -1;
		public string serializedTileInfo = "";

		public CustomTile(MainForm mainForm, MetroTile tile, int tileNum, string serializedTileInfo) {
			this.mainForm = mainForm;
			this.tile = tile;
			this.tileNum = tileNum;
			this.serializedTileInfo = serializedTileInfo;
			tile.Click += Tile_Click;

			if (serializedTileInfo == "") {
				return;
			}

			var serializedTileInfoArr = serializedTileInfo.Split(',');
			for (int i = 0; i < serializedTileInfoArr.Length; i++) {
				if (i==0) {
					path = serializedTileInfoArr[0];
					if (path == null) {
						return;
					}
					setPath(path);
				} else if (i == 1) {
					tile.Text = serializedTileInfoArr[1];
				}
			}
		}

		public void setPath(string path) {
			this.path = path;
			//mainForm.MetroToolTip1.SetToolTip(tile, path + ". Right-click to edit tile.");
		}

		internal void serialize() {
			serializedTileInfo = path + "," + tile.Text;
		}

		private void Tile_Click(object sender, EventArgs e) {
			if (path != "") {
				Process.Start(path);
			} else {
				// no value defined for this custom tile.
				CustomTileForm ctf = new CustomTileForm(mainForm, this);
				ctf.ShowDialog();
			}
		}

		public void editTile() {
			CustomTileForm ctf = new CustomTileForm(mainForm, this);
			ctf.ShowDialog();
		}

	}
}
