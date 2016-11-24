using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2ModKit.HelperClasses {
	public class Localizer {
		private MainForm mf;

		public Localizer(MainForm mf) {
			this.mf = mf;
			localize();
		}

		public void localize() {
			mf.particleDesignBtn.Text = strings.ParticleDesigner;
			mf.mainFormToolTip.SetToolTip(mf.particleDesignBtn, strings.ParticleDesignerBtnTooltip);

			mf.combineKVBtn.Text = strings.CombineKVFiles;
			mf.mainFormToolTip.SetToolTip(mf.combineKVBtn, strings.CombineKVFilesBtnTooltip);

			mf.unitToAbilityBtn.Text = strings.UnitToAbility;
			mf.mainFormToolTip.SetToolTip(mf.unitToAbilityBtn, strings.UnitToAbilityTooltip);

			mf.generateAddonLangsBtn.Text = strings.GenerateTooltips;
			mf.mainFormToolTip.SetToolTip(mf.generateAddonLangsBtn, strings.GenerateTooltipsBtnTooltip);

			mf.spellLibraryBtn.Text = strings.SpellLibrary;
			mf.mainFormToolTip.SetToolTip(mf.spellLibraryBtn, strings.SpellLibraryBtnTooltip);

			mf.findSoundNameBtn.Text = strings.FindSoundName;
			mf.mainFormToolTip.SetToolTip(mf.findSoundNameBtn, strings.FindSoundNameBtnTooltip);

			mf.mainFormToolTip.SetToolTip(mf.compileCoffeeBtn, strings.CoffeeScriptCompileBtnTooltip);

			mf.mainFormToolTip.SetToolTip(mf.gameTile, strings.GameTileTooltip);
			mf.mainFormToolTip.SetToolTip(mf.contentTile, strings.ContentTileTooltip);

			mf.mainFormToolTip.SetToolTip(mf.customTile1, strings.CustomTileTooltip);
			mf.mainFormToolTip.SetToolTip(mf.customTile2, strings.CustomTileTooltip);
			mf.mainFormToolTip.SetToolTip(mf.customTile3, strings.CustomTileTooltip);
			mf.mainFormToolTip.SetToolTip(mf.customTile4, strings.CustomTileTooltip);
			mf.mainFormToolTip.SetToolTip(mf.customTile5, strings.CustomTileTooltip);

			mf.mainFormToolTip.SetToolTip(mf.vpkTile, strings.VPKTooltip);
			mf.mainFormToolTip.SetToolTip(mf.optionsTile, strings.OptionsTooltip);
			mf.mainFormToolTip.SetToolTip(mf.addonTile, strings.AddonTileTooltip);
			mf.mainFormToolTip.SetToolTip(mf.steamTile, strings.SteamTileTooltip);

			mf.mainFormToolTip.SetToolTip(mf.donateBtn, strings.DonateBtnTooltip);
			mf.mainFormToolTip.SetToolTip(mf.reportBugBtn, strings.ReportBugTooltip);
			mf.mainFormToolTip.SetToolTip(mf.versionLabel, strings.VersionTooltip);

			mf.mainFormToolTip.SetToolTip(mf.githubGoBtn, strings.GithubGoTooltip);




		}
	}
}
