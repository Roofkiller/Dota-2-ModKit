# Dota 2 ModKit

### [Download the latest version here!](https://github.com/Myll/Dota-2-ModKit/releases)

Dota 2 ModKit is a GUI tool that provides automation for several custom game development tasks:

* Generate addon_language files based on KeyValue files in the scripts/npc folder.
* Bulk modify the color and size of particle systems without the complexities of Valve's Particle Editor Tool.
* Break up scripts/npc KeyValue files into several individual files for better structuring of your custom game.
* Find sound names based on their .vsnd paths (given from the Asset Browser).
* Create Panorama JS files in CoffeeScript
* Instantly access various parts of your custom game with shortcut buttons.
* Browse the SpellLibrary and easily swap between the Lua and KeyValue code of spells.
* Convert .tga to .vtex_c and .vtex_c to .tga.

## Installation

Extract the contents of the .zip into a folder. Run D2ModKit.exe.

## Usage

Here are some gif examples of features:

**[Breaking up and combining KV files](http://gfycat.com/HomelyIncompatibleBangeltiger)**

**[Forking a Barebones addon](http://gfycat.com/SharpFelineAllosaurus)**

**[Generating tooltips](http://gfycat.com/LividSevereElk)**

## Contributing

Unfortunately, since I'm inactive in developing this these days, I don't have the time to review pull requests.

## History

D2ModKit started around October 2014 as a project to provide a GUI to import decompiled particles into your custom game (at the time Valve didn't have a Particle Copy Tool). The project was called ParticleForker, and it was my first experience with C#. I began asking several other members of the community what else could be automated, and started implementing several more features. The project was shortly renamed to Dota 2 ModKit.

## Credits

[Metro WinForms](https://github.com/viperneo/winforms-modernui)

Thank you to these people who have contributed to D2ModKit in some way during its lifetime:

* [Noya](https://github.com/MNoya): Feature ideas
* [RoyAwesome](https://github.com/RoyAwesome): KVLib
* [penguinwizzard](https://github.com/Penguinwizzard): Icon
* [ToraxXx](https://github.com/toraxxx): Decompiled particles
* [XavierCHN](https://github.com/XavierCHN): Helping with VTEX features
* [SebRut](https://github.com/sebrut): Ideas and C# tips.

## License

GNU GPLv3

## Donations

If you feel that D2ModKit is worth some of your money, I'd gladly accept your donation!

[![alt text](http://indigoprogram.org/wp-content/uploads/2012/01/Paypal-Donate-Button.png)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=stephenf%2ebme%40gmail%2ecom&lc=US&item_name=Myll%27s%20Dota%202%20Modding%20Contributions&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted)
