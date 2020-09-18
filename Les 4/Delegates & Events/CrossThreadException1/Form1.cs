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

namespace CrossThreadException1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Voorbeeld voor het opstarten van background workers en 
         * het aanroepen van GUI updates vanuit een andere thread.
         * resultaat: CrossThreadException
         */
 
        private void button_Incorrect_Cross_Thread_Call(object sender, EventArgs e)
        {
            Thread demoThread =
                new Thread(new ThreadStart(this.ThreadProcUnsafe));

            demoThread.Start();
        }

        // Deze methode draait op een worker thread en maakt
        // een onveilige aanroep naar de TextBox control. 
        private void ThreadProcUnsafe()
        {
            Console.WriteLine($"Invoke required for ThreadProcUnsafe: {this.textBox1.InvokeRequired}");

            int result = DelayedAdd(5, 10);
            this.textBox1.Text = "This text was set unsafely. Result: " + result ;
        }


        /*
         * Oplossing 1 Cross Thread Exceptions: 
         * zorg ervoor dat GUI updates aangeroepen worden vanuit de GUI-thread. 
         * Dit kan  door gebruik te maken van Invoke (of BeginInvoke)
         */
 
        delegate void SetTextCallback();

        private void SetText()
        {
            // Met InvokeRequired wordt de Thread ID van de aanroepende Thread
            // vergeleken met de aangeroepen Thread ID
            // Indien deze verschillen is Invoke noodzakelijk.
            Console.WriteLine($"Invoke required for SetText: {this.textBox1.InvokeRequired}");

            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                //SetTextCallback d = () => SetText(); // mbv een lambda expressie.
                this.Invoke(d); // If you want your UI update to complete before proceeding, you use Invoke.  
                //this.BeginInvoke(d); // otherwise BeginInvoke for better responsiveness
            }
            else
            {
                int result = DelayedAdd(5, 10);
                string text = "Deze tekst wordt veilig gewijzigd, door het gebruik te maken van Invoke. Result: " + result;

                this.textBox1.Text = text;
            }
        }

        private void button_Invoke(object sender, EventArgs e)
        {
            Thread demoThread =
               new Thread(new ThreadStart(SetText));
            demoThread.Start();
        }

        /*
         * Oplossing 2 voor Cross Thread Exceptions: indien we de Task Parallel Library gebruiken kunnen we
         * bij starten van een Task aangeven dat we deze op een andere thread starten.
         *
         * In de laatste continuation geven we aan dat we de textBox update op de UI thread starten.
         */
        private void button_OplossingMet_FromTaskEnContext(object sender, EventArgs e)
        {
            // Leg de context van de aanroep vast:
            TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            Task.Factory.StartNew<int>(() => DelayedAdd(5, 10))
            .ContinueWith(t => DelayedAdd(t.Result, 20))
            .ContinueWith(t => DelayedAdd(t.Result, 30))
            .ContinueWith(t => DelayedAdd(t.Result, 50))
            .ContinueWith(t => textBox1.Text = $"Berekening m.b.v. TaskScheduler.FromCurrentSynchronizationContext(): {t.Result.ToString()}"
                            , uiScheduler);
        }

        // Zie hieronder voor een async versie van de methode.
        private int DelayedAdd(int a, int b)
        {
            Thread.Sleep(500);
            return a + b;
        }




        private async void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Invoke required for async method: {this.textBox1.InvokeRequired}");
            int a = await DelayedAddAsync(5, 10);
            int b = await DelayedAddAsync(a, 20);
            int c = await DelayedAddAsync(b, 30);
            int d = await DelayedAddAsync(c, 50);
            textBox1.Text = $"Berekening m.b.v. async/await: {d.ToString()}";
 
        }

        private async Task<int> DelayedAddAsync(int a, int b)
        {
            await Task.Delay(500); 
            return a + b; // new Task<int>(() => DelayedAdd(a, b));
        }

    }
}
