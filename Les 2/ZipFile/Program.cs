using System;
using System.IO.Compression;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZipFileDemo {

    class Program {
        [STAThread]
        static int Main(string[] args) {
            string path = Directory.GetCurrentDirectory();
            var myDocuments = Environment.SpecialFolder.MyDocuments;
            string myDocFolder = Environment.GetFolderPath(myDocuments);

            OpenFileDialog browseFileDialog = new OpenFileDialog();
            browseFileDialog.InitialDirectory = myDocFolder;
            browseFileDialog.Title = "Select a zip file...";

            string sourceZipFile, destFolder;
            if (browseFileDialog.ShowDialog() != DialogResult.OK) {
                return 0;
            }
            sourceZipFile = browseFileDialog.FileName;

            FolderBrowserDialog destFolderDialog = new FolderBrowserDialog();
            destFolderDialog.Description = "Select folder to extract *.cs files";
            destFolderDialog.RootFolder = myDocuments;
            if (destFolderDialog.ShowDialog() != DialogResult.OK) {
                return 0;
            }
            destFolder = destFolderDialog.SelectedPath;
            
            using (ZipArchive archive = ZipFile.OpenRead(sourceZipFile)) {
                foreach (ZipArchiveEntry entry in archive.Entries) {

                    string fullPath = Path.Combine(destFolder, entry.FullName);
                    if (String.IsNullOrEmpty(entry.Name)) {
                        Directory.CreateDirectory(fullPath);
                    } else {
                        if (entry.FullName.EndsWith(".cs", StringComparison.OrdinalIgnoreCase)) {
                            entry.ExtractToFile(fullPath);
                        }
                    }
                }
            }

            return 0;
        }
    }
}
