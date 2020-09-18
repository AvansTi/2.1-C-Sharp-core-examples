using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadWebsitesAsync
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Btn_LoadSync_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();

            RunDownloadSync();

            timer.Stop();
            var time = timer.ElapsedMilliseconds;

            txt_Logging.Text += $"Total execution time {time} ms";
        }

        private async void Btn_LoadAsync_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();

            RunDownloadAsync();
            //await RunDownloadAsync();

            timer.Stop();
            var time = timer.ElapsedMilliseconds;

            txt_Logging.Text += $"Total execution time {time} ms";
        }

        private async void Btn_LoadParallelAsync_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();

            await RunDownloadParallelAsync();

            timer.Stop();
            var time = timer.ElapsedMilliseconds;

            txt_Logging.Text += $"Total execution time {time} ms";
        }

        public IList<String> PrepData() {
            txt_Logging.Text = String.Empty;
            IList<String> websites = new List<string>();
            websites.Add("http://www.nu.nl");
            websites.Add("https://www.reddit.com");
            websites.Add("https://bb.avans.nl");
            websites.Add("https://github.com/avansti");
            websites.Add("https://www.google.com");

            return websites;
        }


        private void RunDownloadSync() {
            IList<String> websites = PrepData();

            foreach (var website in websites)
            {
                WebsiteDataModel results = DownloadWebsite(website);
                ReportWebsiteInfo(results);
            }
        }


        private WebsiteDataModel DownloadWebsite(string website)
        {
            WebsiteDataModel model = new WebsiteDataModel();
            WebClient client = new WebClient();

            model.WebsiteUrl = website;
            var clock = Stopwatch.StartNew();
            model.WebsiteData = client.DownloadString(website);
            clock.Stop();
            model.DownloadTime = clock.ElapsedMilliseconds;

            return model;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string website)
        {
            WebsiteDataModel model = new WebsiteDataModel();
            WebClient client = new WebClient();

            model.WebsiteUrl = website;
            var clock = Stopwatch.StartNew();
            model.WebsiteData = await client.DownloadStringTaskAsync(website);
            clock.Stop();
            model.DownloadTime = clock.ElapsedMilliseconds;

            return model;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            txt_Logging.Text += $"{data.WebsiteUrl} downloaded: " +
                                $"{data.WebsiteData.Length} characters long " +
                                $" execution time: {data.DownloadTime} ms" +
                                $"{Environment.NewLine}";
        }


        private async Task RunDownloadAsync()
        {
            IList<String> websites = PrepData();

            foreach (var website in websites)
            {
                WebsiteDataModel results = await Task.Run(() => DownloadWebsite(website));
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            var websites = PrepData();
            var tasks = new List<Task<WebsiteDataModel>>();

            foreach (var website in websites)
            {
                tasks.Add(DownloadWebsiteAsync(website));
            }

            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                ReportWebsiteInfo(result);
            }
        }
    }
}
