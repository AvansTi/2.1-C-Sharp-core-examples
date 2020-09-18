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

namespace TestInvokeLabel
{
    public partial class Form1 : Form
    {
 
        public Form1()
        {
            InitializeComponent();

            Thread t = new Thread(new ThreadStart(ChangeLabel));
            t.Start();
        }

        private void ChangeLabel()
        {
            for (int i = 0; i < 100; ++i)
            {
                SetLabelText(i);
                Thread.Sleep(1000);
            }
        }
        private delegate void SetLabelTextDelegate(int number);
        private void SetLabelText(int number)
        {
            Console.WriteLine("SetLabelText is called from the same thread which controls the label: " + this.InvokeRequired.ToString());
        //    label1.Text = number.ToString();
            // Do NOT do this, as we are on a different thread.

            // Check if we need to call BeginInvoke.
            if (this.InvokeRequired)
            {
                // Pass the same function to BeginInvoke,
                // but the call would come on the correct
                // thread and InvokeRequired will be false.
                this.BeginInvoke(new SetLabelTextDelegate(SetLabelText),
                                                 new object[] { number });

                return;
            }
            label1.Text = number.ToString();
        }
    }
}
