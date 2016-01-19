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

        public ParticleFeatures(MainForm mainForm) {
			this.mf = mainForm;

            // setup hooks
            mf.particlesTrackBar.Maximum = 200;
            mf.particlesTrackBar.Minimum = -100;
            mf.particlesTrackBar.Value = 0;

            mf.particleCopyTutorial.Click += (s, e) => {
                mf.fixButton();
                Process.Start("https://developer.valvesoftware.com/wiki/Dota_2_Workshop_Tools/Particle_Copy_Tool");
            };
            mf.particleSubmitBtn.Click += (s, e) => {
                mf.fixButton();
                if (particles.Count == 0) {
                    MetroMessageBox.Show(mf, "No particles selected.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                foreach (Particle p in particles) {
                    p.alterParticle(mf, rgb, mf.particlesTrackBar.Value);
                }

                setControlsToDefaults();
            };
            mf.recolorBtn.Click += (s, e) => {
                mf.fixButton();

                rgb = Util.getRGB();

                if (rgb == null) {
                    return;
                }

                mf.rLabel.Text = "R: " + rgb[0];
                mf.gLabel.Text = "G: " + rgb[1];
                mf.bLabel.Text = "B: " + rgb[2];
            };
            mf.particlesTrackBar.ValueChanged += (s, e) => {
                int val = mf.particlesTrackBar.Value;

                if (val < 0) {
                    mf.sizeLabel.Text = "Size change: " + mf.particlesTrackBar.Value.ToString() + "%";
                } else {
                    mf.sizeLabel.Text = "Size change: +" + mf.particlesTrackBar.Value.ToString() + "%";
                }
            };
            mf.selectParticlesBtn.Click += (s, e) => {
                mf.fixButton();
                string particleDir = Path.Combine(mf.currAddon.contentPath, "particles");

                if (!Directory.Exists(particleDir)) {
                    MetroMessageBox.Show(mf, particleDir + " doesn't exist!",
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
                mf.particlesTextBox1.Text = "";
                foreach (string path in particlePaths) {
                    particles.Add(new Particle(path));
                    mf.particlesTextBox1.Text += path.Substring(path.IndexOf("particles\\")) + "\r\n";
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
