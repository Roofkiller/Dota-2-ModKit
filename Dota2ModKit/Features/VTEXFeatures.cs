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
	class VTEXFeatures {
		public MainForm mf;
		string dotaDir;

		public VTEXFeatures(MainForm mf) {
			this.mf = mf;
			dotaDir = mf.dotaDir;

		}

		public void compileVTEX() {
			// show dialog to open .tga or .mks file
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Multiselect = true;
			//ofd.Filter = "TGA|*.tga|MKS|*.mks";
			ofd.Filter = "|*.tga;*.mks";
			ofd.Title = "Select .tga Files To Compile";

			string materialsPath = Path.Combine(mf.currAddon.contentPath, "materials");
			if (!Directory.Exists(materialsPath)) {
				Directory.CreateDirectory(materialsPath);
			}
			ofd.InitialDirectory = materialsPath;


			if (!(ofd.ShowDialog() == DialogResult.OK)) {
				return;
			}

			string[] filePaths = ofd.FileNames;

			string saveFolder = materialsPath;

			// Start the conversion process
			foreach (string file in filePaths) {
				string f = file;
				// ensure it's inside content path
				if (!(f.Contains(Path.Combine("content", "dota_addons")))) {
					MetroMessageBox.Show(mf,
						f + " must be inside the content directory of " + mf.currAddon.name,
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);

					return;
				}
				f = f.Substring(f.IndexOf(Path.Combine("content", "dota_addons")) + 20);
				f = f.Substring(f.IndexOf("\\") + 1);
				f = f.Replace('\\', '/');
				// todo: maybe we should put this into some resource text files
				string[] vtexFileStrings =
				{
					"<!-- dmx encoding keyvalues2_noids 1 format vtex 1 -->",
					"\"CDmeVtex\"",
					"{",
					"	\"m_inputTextureArray\" \"element_array\" ",
					"	[",
					"		\"CDmeInputTexture\"",
					"		{",
					"			\"m_name\" \"string\" \"0\"",
					"			\"m_fileName\" \"string\" \"" + f + "\"",
					"			\"m_colorSpace\" \"string\" \"srgb\"",
					"			\"m_typeString\" \"string\" \"2D\"",
					"		}",
					"	]",
					"	\"m_outputTypeString\" \"string\" \"2D\"",
					"	\"m_outputFormat\" \"string\" \"DXT5\"",
					"	\"m_textureOutputChannelArray\" \"element_array\"",
					"	[",
					"		\"CDmeTextureOutputChannel\"",
					"		{",
					"			\"m_inputTextureArray\" \"string_array\"",
					"				[",
					"					\"0\"",
					"				]",
					"			\"m_srcChannels\" \"string\" \"rgba\"",
					"			\"m_dstChannels\" \"string\" \"rgba\"",
					"			\"m_mipAlgorithm\" \"CDmeImageProcessor\"",
					"			{",
					"				\"m_algorithm\" \"string\" \"\"",
					"				\"m_stringArg\" \"string\" \"\"",
					"				\"m_vFloat4Arg\" \"vector4\" \"0 0 0 0\"",
					"			}",
					"			\"m_outputColorSpace\" \"string\" \"srgb\"",
					"		}",
					"	]",
					"}"
				};

				string name = file.Substring(file.LastIndexOf('\\') + 1);
				name = name.Substring(0, name.IndexOf('.'));
				string path = Path.Combine(saveFolder, name + ".vtex");
				File.Create(path).Close();
				File.WriteAllLines(path, vtexFileStrings);
				// resource compiler path
				string resourceCompilerPath = Path.Combine(dotaDir, "game", "bin", "win64", "resourcecompiler.exe");

				Process proc = new Process {
					StartInfo = new ProcessStartInfo {
						FileName = resourceCompilerPath,
						Arguments = "-i \"" + path + "\"",
						UseShellExecute = false,
						RedirectStandardOutput = true,
						CreateNoWindow = true
					}
				};
				proc.Start();
			}

			mf.text_notification(filePaths.Length + " .tga files successfully compiled.", MetroFramework.MetroColorStyle.Green, 2500);
		}

		public void decompileVTEX() {
			//decompileAllVTEX();
			//return;

			string extract = Path.Combine(dotaDir, "game", "dota_imported", "materials");

			if (!Directory.Exists(extract)) {
				Directory.CreateDirectory(extract);
			}

			if (Directory.GetFiles(extract, "*.vtex_c").Length == 0) {
				Process.Start(extract);
				MetroMessageBox.Show(mf, ".vtex_c files must be present in " + extract + " for this to work. Use GCFScape to extract .vtex_c files into this folder.",
					"Note",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select vtex_c Files To Decompile";
			ofd.Multiselect = true;
			ofd.InitialDirectory = Path.Combine(dotaDir, "game", "dota_imported", "materials");
			ofd.Filter = "|*.vtex_c";

			if (ofd.ShowDialog() != DialogResult.OK) {
				return;
			}

			// 9/16/15: resourceinfo.exe uses an old path to retrieve the required file gameinfo.gi. So we need to
			// make sure it's in the right spot.
			string oldPath = Path.Combine(dotaDir, "game", "dota_imported", "gameinfo.gi");
            if (!File.Exists(oldPath)) {
				string newPath = Path.Combine(dotaDir, "game", "dota", "gameinfo.gi");
                if (File.Exists(newPath)) {
					File.Copy(newPath, oldPath);
				} else {
					return;
				}
			}

			string[] vtexCPaths = ofd.FileNames;
			foreach (string path in vtexCPaths) {
				//resourceinfo.exe -i <your vtex_c file> -debug tga -mip
				Process process = new Process();
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				//startInfo.UseShellExecute = true;
				startInfo.FileName = "cmd.exe";
				startInfo.WorkingDirectory = Path.Combine(dotaDir, "game", "bin", "win64");
				startInfo.Arguments = "/c resourceinfo.exe -i \"" + path + "\" -debug tga -mip";
				Debug.WriteLine(startInfo.Arguments);
				process.StartInfo = startInfo;
				process.Start();
				process.WaitForExit();

				// Prepare to move the tga files 
				string vtexcName = path.Substring(path.LastIndexOf('\\') + 1);

				string fold = Path.Combine(mf.currAddon.contentPath, "materials", vtexcName);
				if (!Directory.Exists(fold)) {
					Directory.CreateDirectory(fold);
				}

				//move the tga files
				string[] tgaFiles = Directory.GetFiles(Path.Combine(dotaDir, "game", "bin", "win64"), "*.tga");
				foreach (string file in tgaFiles) {
					string fileName = file.Remove(0, file.LastIndexOf('\\') + 1);
					// prepare for moving file
					string dest = Path.Combine(fold, fileName);
                    if (!File.Exists(dest)) {
						File.Move(file, dest);
					}
				}
			}

			Process.Start(Path.Combine(mf.currAddon.contentPath, "materials"));
		}

		public void decompileAllVTEX() {
			string extract = Path.Combine(dotaDir, "game", "dota", "materials");
			var files = Directory.GetFiles(extract, "*.vtex_c", SearchOption.AllDirectories);
			string matDir = Path.Combine("C:\\Users\\Stephen\\Desktop\\materials");

			foreach (var file in files) {
				// relative path
				string relPath = file.Substring(file.IndexOf("materials") + 10);
				string relDir = relPath.Replace(".vtex_c", "");
				if (relPath.Contains('\\')) {
					relDir = relPath.Substring(0, relPath.LastIndexOf('\\'));
				}
				string vtexcName = file.Substring(file.LastIndexOf('\\') + 1);
				vtexcName = vtexcName.Replace(".vtex_c", "");

				string outputDir = Path.Combine(matDir, relDir);
				if (relDir != vtexcName) {
					outputDir = Path.Combine(matDir, relDir, vtexcName);
				}

				if (!Directory.Exists(outputDir)) {
					Directory.CreateDirectory(outputDir);
				}

				Process process = new Process();
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				//startInfo.UseShellExecute = true;
				startInfo.FileName = "cmd.exe";
				startInfo.WorkingDirectory = Path.Combine(dotaDir, "game", "bin", "win64");
				startInfo.Arguments = "/c resourceinfo.exe -i \"" + file + "\" -debug tga -mip";
				Debug.WriteLine(startInfo.Arguments);
				process.StartInfo = startInfo;
				process.Start();
				process.WaitForExit();

				//move the tga files
				string[] tgaFiles = Directory.GetFiles(Path.Combine(dotaDir, "game", "bin", "win64"), "*.tga");
				foreach (string tgaFile in tgaFiles) {
					string fileName = tgaFile.Remove(0, tgaFile.LastIndexOf('\\') + 1);
					// prepare for moving file
					string dest = Path.Combine(outputDir, fileName);
					if (!File.Exists(dest)) {
						File.Move(tgaFile, dest);
					}
				}
			}	
		}
	}
}
