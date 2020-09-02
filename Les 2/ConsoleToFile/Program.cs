using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ConsoleToFile
{
    class Program
    {
        [STAThread]
        static void Main(string[] args) {

            string path = Directory.GetCurrentDirectory();
            string myDocFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            OpenFileDialog browseFileDialog = new OpenFileDialog();
            browseFileDialog.InitialDirectory = myDocFolder;

            if (browseFileDialog.ShowDialog() == DialogResult.OK) {
                string sourceFile = browseFileDialog.FileName;
                using (StreamReader reader = File.OpenText(sourceFile)) {
                    string line = null;
                    while ((line = reader.ReadLine()) != null) {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
