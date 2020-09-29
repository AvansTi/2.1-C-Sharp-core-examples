using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;

namespace AsyncLoadWebsiteWpf
{
    public class WebsiteAsyncModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public WebsiteModel Website { get; set; } = new WebsiteModel();

        public ObservableCollection<WebsiteModel> Websites { get; set; } = new ObservableCollection<WebsiteModel>();


        public WebsiteAsyncModelView()
        {
            Init();
        }

        public void Init()
        {
            Websites.Clear();
            Websites.Add(new WebsiteModel { Url = "http://www.nu.nl" });
            Websites.Add(new WebsiteModel { Url = "https://www.reddit.com" });
            Websites.Add(new WebsiteModel { Url = "https://bb.avans.nl" });
            Websites.Add(new WebsiteModel { Url = "https://github.com/avansti" });
            Websites.Add(new WebsiteModel { Url = "https://www.google.com" });
        }

        private ICommand resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (resetCommand == null)
                    resetCommand = new RelayCommand((pm) => { Init(); });

                return resetCommand;
            }
        }


        private ICommand loadNonAsyncCommand;
        public ICommand LoadNonAsyncCommand
        {
            get
            {
                if (loadNonAsyncCommand == null)
                {
                    loadNonAsyncCommand = new RelayCommand(
                        p => { RunDownloadSync(); },
                        p => { return true; });
                }
                return loadNonAsyncCommand;
            }
        }


        private IAsyncCommand loadAsyncCommand;
        public IAsyncCommand LoadAsyncCommand
        {
            get
            {
                if (loadAsyncCommand == null)
                {
                    loadAsyncCommand = new AsyncCommand(RunDownloadParallelAsync);
                }
                return loadAsyncCommand;
            }
        }


        private void RunDownloadSync()
        {

            foreach (var website in Websites)
            {
                DownloadWebsite(website);
                Debug.WriteLine($"Load of url {website.Url} took {website.LoadTime} seconds");
                //ReportWebsiteInfo(results);
            }
        }


        private void DownloadWebsite(WebsiteModel website)
        {
            WebClient client = new WebClient();

            var clock = Stopwatch.StartNew();
            website.Content = client.DownloadString(website.Url);
            clock.Stop();
            website.LoadTime = clock.ElapsedMilliseconds;
        }

        private async Task DownloadWebsiteAsync(WebsiteModel website)
        {
            WebClient client = new WebClient();

            var clock = Stopwatch.StartNew();
            website.Content = await client.DownloadStringTaskAsync(website.Url);
            clock.Stop();
            website.LoadTime = clock.ElapsedMilliseconds;
        }



        private async Task RunDownloadAsync()
        {
            foreach (var website in Websites)
            {
                await Task.Run(() => DownloadWebsite(website));
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            var tasks = new List<Task>();

            foreach (var website in Websites)
            {
                tasks.Add(DownloadWebsiteAsync(website));
            }

            await Task.WhenAll(tasks);
        }
    }
}
