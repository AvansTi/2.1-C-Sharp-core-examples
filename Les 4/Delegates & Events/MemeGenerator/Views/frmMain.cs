using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemeGenerator.Presenters;

namespace MemeGenerator
{
    public partial class frmMain : Form
    {
        private MemePresenter presenter;
        public frmMain()
        {
            presenter = new MemePresenter();
            InitializeComponent();
            lbl_TopText.Parent = pictureBox1;
            memeModelBindingSource.DataSource = presenter.MemeModel;
        }

        private void btn_GenerateMeme_Click(object sender, EventArgs e)
        {
            //lbl_TopText.Text = txt_EnterTopText.Text;
            Thread thread = new Thread(GenerateMeme);
            thread.Start();
        }

        private void GenerateMeme()
        {
            btnReset.Text = "Hallo Klas!";
        }

        private void txt_EnterTopText_TextChanged(object sender, EventArgs e)
        {
            //lbl_TopText.Text = txt_EnterTopText.Text;
            //MessageBox.Show("Stop eens met typen!");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            presenter.Reset();
        }
    }
}
