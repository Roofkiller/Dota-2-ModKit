using Dota2ModKit.HelperClasses;
using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ModKit.Features {
    public class InstalledGameFeatures {
        MainForm mf;
        public string installedCustomsDir = "";
        public Dictionary<string, InstalledGame> installedCustomGames = new Dictionary<string, InstalledGame>();
        public InstalledGameFeatures(MainForm mf) {
            this.mf = mf;
            installedCustomsDir = mf.dotaDir.Substring(0, mf.dotaDir.IndexOf("steamapps") + "steamapps".Length);
            installedCustomsDir = Path.Combine(installedCustomsDir, "workshop", "content", "570");
            retrieveInstalledCustomGames();

            var bar = (MetroScrollBar)mf.installedGamesPanel.Controls[0];
            bar.Theme = MetroThemeStyle.Dark;
            bar.Width = 9;
            int scrollbar_width = bar.Width + 4;
            bar = (MetroScrollBar)mf.installedGamesPanel.Controls[1];
            bar.Theme = MetroThemeStyle.Dark;
            bar.Width = 9;

        }
        public void retrieveInstalledCustomGames() {
            installedCustomGames.Clear();
            var customGameDirs = Directory.GetDirectories(installedCustomsDir);
            foreach (var customGameDir in customGameDirs) {
                var customGame = new InstalledGame(mf, customGameDir);

                if (customGame.vpk == null) {
                    continue;
                }

                installedCustomGames.Add(customGame.workshopID, customGame);
            }
        }
    }
}
