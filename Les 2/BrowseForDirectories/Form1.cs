using System;
using System.Windows.Forms;

namespace BrowseForDirectories
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        private void buttonBrowse1_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                textBoxFilename1.Text = fbd.SelectedPath;
            }

        }
    }
}
