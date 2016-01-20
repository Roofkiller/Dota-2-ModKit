using MetroFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit.Features {
	class ParticleFeatures {
		MainForm mf;
        string[] rgb = null;
        List<Particle> particles = new List<Particle>();

        public ParticleFeatures(MainForm mf) {
			this.mf = mf;

            // setup hooks
            this.mf.particlesTrackBar.Maximum = 200;
            this.mf.particlesTrackBar.Minimum = -100;
            this.mf.particlesTrackBar.Value = 0;

            this.mf.particleCopyTutorial.Click += (s, e) => {
                this.mf.fixButton();
                Process.Start("https://developer.valvesoftware.com/wiki/Dota_2_Workshop_Tools/Particle_Copy_Tool");
            };
            this.mf.particleSubmitBtn.Click += (s, e) => {
                this.mf.fixButton();
                if (particles.Count == 0) {
                    MetroMessageBox.Show(this.mf, "No particles selected.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                foreach (Particle p in particles) {
                    p.alterParticle(this.mf, rgb, this.mf.particlesTrackBar.Value);
                }

                setControlsToDefaults();
            };
            this.mf.recolorBtn.Click += (s, e) => {
                this.mf.fixButton();

                rgb = Util.getRGB();

                if (rgb == null) {
                    return;
                }

                this.mf.rLabel.Text = "R: " + rgb[0];
                this.mf.gLabel.Text = "G: " + rgb[1];
                this.mf.bLabel.Text = "B: " + rgb[2];
            };
            this.mf.particlesTrackBar.ValueChanged += (s, e) => {
                int val = this.mf.particlesTrackBar.Value;

                if (val < 0) {
                    this.mf.sizeLabel.Text = "Size change: " + this.mf.particlesTrackBar.Value.ToString() + "%";
                } else {
                    this.mf.sizeLabel.Text = "Size change: +" + this.mf.particlesTrackBar.Value.ToString() + "%";
                }
            };
            this.mf.selectParticlesBtn.Click += (s, e) => {
                this.mf.fixButton();
                string particleDir = Path.Combine(this.mf.currAddon.contentPath, "particles");

                if (!Directory.Exists(particleDir)) {
                    MetroMessageBox.Show(this.mf, particleDir + " doesn't exist!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = particleDir;
                ofd.Multiselect = true;
                ofd.Title = "Select Particles To Design";
                ofd.Filter = "Particle Files (*.vpcf)|*.vpcf";
                DialogResult dr = ofd.ShowDialog();

                if (dr != DialogResult.OK) {
                    return;
                }

                string[] particlePaths = ofd.FileNames;
                this.mf.particlesTextBox1.Text = "";
                foreach (string path in particlePaths) {
                    particles.Add(new Particle(path));
                    this.mf.particlesTextBox1.Text += path.Substring(path.IndexOf("particles\\")) + "\r\n";
                }
            };
		}

        private void setControlsToDefaults() {
            mf.particlesTrackBar.Value = 0;
            mf.particlesTextBox1.Text = "";
            particles.Clear();
            mf.rLabel.Text = "R: ";
            mf.gLabel.Text = "G: ";
            mf.bLabel.Text = "B: ";
        }
    }
}
