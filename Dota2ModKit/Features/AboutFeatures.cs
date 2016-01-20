using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ModKit.Features {
    public class AboutFeatures {
        MainForm mf;
        public AboutFeatures(MainForm mf) {
            this.mf = mf;
            mf.versionTab.Text = "v" + mf.version;
        }
    }
}
