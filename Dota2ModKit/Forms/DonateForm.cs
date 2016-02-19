using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dota2ModKit.Forms {
	public partial class DonateForm : MetroForm {
		MainForm mainForm;

		public DonateForm(MainForm mainForm) {
			this.mainForm = mainForm;

			InitializeComponent();

			metroTextBox1.Text =
				"If Dota 2 ModKit greatly helped you in your custom game development endeavors, please consider a donation:" +

				"\r\n\r\nThank you so much!\r\n- Myll";

			label1.Select();
		}

		private void donatePictureBox_Click(object sender, EventArgs e) {
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=BPRL87NAKFP9N&lc=US&item_name=Stephen%20Fournier%2c%20D2ModKit%20Creator&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted");
		}
	}
}
