using Dota2ModKit.Features;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit {
	public partial class ParticleDesignForm : MetroForm {
		public MainForm mainForm;
		string[] rgb = null;
		List<Particle> particles = new List<Particle>();

		public ParticleDesignForm(MainForm mainForm, string[] particlePaths) {
			this.mainForm = mainForm;

			InitializeComponent();
			localize();

			// setup hooks
			metroTrackBar1.Maximum = 200;
			metroTrackBar1.Minimum = -100;
			metroTrackBar1.Value = 0;
			metroTrackBar1.ValueChanged += MetroTrackBar1_ValueChanged;

			string suffix = " " + strings.ParticlesSelected + ".";
			if (particlePaths.Length == 1) {
				suffix = " " + strings.ParticleSelected + ".";
			}
			particlesSelectedLabel.Text = particlePaths.Length + suffix;

			foreach (string path in particlePaths) {
				particles.Add(new Particle(path));
			}
		}

		private void MetroTrackBar1_ValueChanged(object sender, EventArgs e) {
			int val = metroTrackBar1.Value;

			if (val < 0) {
				sizeLabel.Text = strings.SizeChange + ": " + metroTrackBar1.Value.ToString() + "%";
			} else {
				sizeLabel.Text = strings.SizeChange + ": +" + metroTrackBar1.Value.ToString() + "%";
			}

			//Debug.WriteLine(metroTrackBar1.Value);
		}

		private void submitBtn_Click(object sender, EventArgs e) {

			bool allSuccess = true;
			foreach (Particle p in particles) {
				bool success = p.alterParticle(this, rgb, metroTrackBar1.Value);
				if (!success) {
					allSuccess = false;
				}
			}
			if (allSuccess) {
				mainForm.text_notification(strings.ParticlesSuccessfullyDesigned, MetroColorStyle.Green, 2500);
			} else {
				mainForm.text_notification(strings.ParticleDesignFailed, MetroColorStyle.Red, 2500);
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void recolorBtn_Click(object sender, EventArgs e) {
			metroRadioButton1.Select();

			rgb = Util.GetRGB();

			if (rgb == null) {
				return;
			}

			rLabel.Text = "R: " + rgb[0];
			gLabel.Text = "G: " + rgb[1];
			bLabel.Text = "B: " + rgb[2];
		}

		void localize() {
			bulkRecolorBtn.Text = strings.BulkRecolor;
			submitBtn.Text = strings.Submit;
			bulkResizeLabel.Text = strings.BulkResize;
			this.Text = strings.ParticleDesigner;
        }
	}
}
