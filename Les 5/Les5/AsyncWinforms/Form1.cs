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

namespace AsyncWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_nonAsync_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            txt_Message.Text += $"{DateTime.Now.ToLongTimeString()}: Finished {Environment.NewLine}";
        }

        public async Task<string> WaitAsynchronoislyAsync()
        {
            await Task.Delay(5000);
            return $"{DateTime.Now.ToLongTimeString()}: Finished {Environment.NewLine}";
        }

        private async void btn_async_Click(object sender, EventArgs e)
        {
            string result = await WaitAsynchronoislyAsync();

            txt_Message.Text += result;
        }
    }
}
