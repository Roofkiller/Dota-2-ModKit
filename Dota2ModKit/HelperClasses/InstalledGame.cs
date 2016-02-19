using KVLib;
using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ModKit.HelperClasses {
    public class InstalledGame {
        MainForm mf;
        public string installationDir,
            workshopID,
            url,
            vpk,
            publish_data,
            name,
            last_updated_time = "Not available",
            fileFriendlyName,
            workshopImagePath,
            changelogUrl;
        public int page, count;
        public double size;
        public Image workshopImage;
        public MetroTile tile;
        public MetroProgressSpinner spinner;
        public MetroColorStyle defaultStyle;

        // settings
        public int WorkshopImgSizeOnWeb;
        public KeyValue addonKV;

        public InstalledGame(MainForm mf, string installationDir) {
            this.mf = mf;
            this.installationDir = installationDir;
            workshopID = installationDir.Substring(installationDir.LastIndexOf('\\') + 1);
            url = "http://steamcommunity.com/sharedfiles/filedetails/?id=" + workshopID;
            workshopImagePath = Path.Combine("Thumbnails", workshopID + ".jpg");
            changelogUrl = "http://steamcommunity.com/sharedfiles/filedetails/changelog/" + workshopID;

            var gameFiles = Directory.GetFiles(installationDir);
            foreach (var file in gameFiles) {
                if (file.EndsWith(".vpk")) {
                    vpk = file;
                } else if (file.EndsWith("publish_data.txt")) {
                    publish_data = file;
                    getPublishDataInfo();
                }
            }
        }
        private void getPublishDataInfo() {
            var txt = File.ReadAllText(publish_data);
            var kv = KVParser.KV1.Parse(txt);
            foreach (var kv2 in kv.Children) {
                if (kv2.Key == "title") {
                    name = kv2.GetString();
                    fileFriendlyName = name.Replace(' ', '_');
                } else if (kv2.Key == "publish_time_readable") {
                    last_updated_time = kv2.GetString();
                }
            }
        }

        public void retrieveWorkshopImage() {
            BackgroundWorker bw = new BackgroundWorker();
            var source = "";
            bw.DoWork += (s, e) => {
                using (WebClient wc = new WebClient()) {
                    var data = wc.DownloadData(url);
                    source = Encoding.ASCII.GetString(data);
                    var signal = "<link rel=\"image_src\" href=\"";
                    var lines = source.Split('\n');
                    foreach (var line in lines) {
                        if (line.StartsWith(signal)) {
                            var imgLink = line.Substring(signal.Length);
                            imgLink = imgLink.Substring(0, imgLink.IndexOf("/?") + 1);

                            long totalBytes = 0;
                            using (var stream = wc.OpenRead(imgLink)) {
                                totalBytes = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);
                            }

                            bool download = false;
                            if (File.Exists(workshopImagePath)) {
                                if (totalBytes != WorkshopImgSizeOnWeb) {
                                    download = true;
                                } else {
                                    Debug.WriteLine("Same image. Not downloading.");
                                }
                            } else {
                                download = true;
                            }
                            if (download) {
                                var byteArr = wc.DownloadData(imgLink);
                                using (MemoryStream ms = new MemoryStream(byteArr)) {
                                    var im = Image.FromStream(ms);
                                    im = new Bitmap(im, new Size(128, 128));
                                    if (Util.TryDeleteFile(workshopImagePath) == null) {
                                        im.Save(workshopImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        WorkshopImgSizeOnWeb = byteArr.Length;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            };

            bw.RunWorkerCompleted += (s, e) => {
                spinner.Visible = false;

                if (File.Exists(workshopImagePath)) {
                    workshopImage = new Bitmap(Image.FromFile(workshopImagePath), tile.Size);
                    // set image
                    tile.UseTileImage = true;
                    tile.TileImage = workshopImage;
                }

                Util.CreateTimer(100, (timer) => {
                    timer.Stop();
                    tile.Refresh();
                });
            };

            bw.RunWorkerAsync();
        }
        internal void initTile() {
            tile.Text = name;

            if (File.Exists(workshopImagePath) && new FileInfo(workshopImagePath).Length > 50) {
                workshopImage = new Bitmap(Image.FromFile(workshopImagePath), tile.Size);
                // set image
                tile.UseTileImage = true;
                tile.TileImage = workshopImage;
                // still have to continue code at this point. what if the author updated the workshop image?
            } else {
                spinner.Visible = true;
            }

            retrieveWorkshopImage();
        }

        internal void deserializeSettings(KeyValue root) {
            foreach (var kv in root.Children) {
                if (kv.Key == "WorkshopImgSizeOnWeb") {
                    WorkshopImgSizeOnWeb = kv.GetInt();
                }
            }
        }
        internal void serializeSettings() {
            addonKV = new KeyValue(workshopID);
            if (WorkshopImgSizeOnWeb != 0) {
                addonKV.AddChild(new KeyValue("WorkshopImgSizeOnWeb").Set(WorkshopImgSizeOnWeb));
            }
        }
        /*public void displaySize() {
            var sizeWorker = new BackgroundWorker();
            string sizeStr = "";
            sizeWorker.DoWork += (s, e) => {
                var size = Util.GetDirectorySize(installationDir) / 1024.0 / 1024.0;
                this.size = size;
                sizeStr = Math.Round(size, 1).ToString();
            };

            sizeWorker.RunWorkerCompleted += (s, e) => {
                mf.htmlToolTip1.SetToolTip(tile, "(<b>" + sizeStr + " MB</b>). Left-click to open " + name + "'s Workshop page. Right-click for more options.<p>" + "Last updated: " + last_updated_time + "</p>");
            };
            sizeWorker.RunWorkerAsync();
        }*/
    }
}
