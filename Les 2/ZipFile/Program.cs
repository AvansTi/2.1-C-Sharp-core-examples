using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace ZipFileDemo
{

    class Program {
        [STAThread]
        static int Main(string[] args) {
            string path = Directory.GetCurrentDirectory();
            var myDocuments = Environment.SpecialFolder.MyDocuments;
            string myDocFolder = Environment.GetFolderPath(myDocuments);

            OpenFileDialog browseFileDialog = new OpenFileDialog
            {
                InitialDirectory = myDocFolder,
                Title = "Select a zip file..."
            };

            string sourceZipFile, destFolder;
            if (browseFileDialog.ShowDialog() != DialogResult.OK) {
                return 0;
            }
            sourceZipFile = browseFileDialog.FileName;

            FolderBrowserDialog destFolderDialog = new FolderBrowserDialog
            {
                Description = "Select folder to extract *.cs files",
                RootFolder = myDocuments
            };
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
