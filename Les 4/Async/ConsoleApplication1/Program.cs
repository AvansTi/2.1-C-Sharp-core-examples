using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public ISourceBlock<DownloadedFile> DownloadFiles(string[] fileIds, string securityCookieString, string securityCookieDomain)
        {
            var urls = CreateUrls(fileIds);

            // we have to use TransformManyBlock here, because we want to be able to return 0 or 1 items
            var block = new TransformManyBlock<string, DownloadedFile>(
                async url =>
                {
                    var httpClientHandler = new HttpClientHandler();
                    if (!string.IsNullOrEmpty(securityCookieString))
                    {
                        var securityCookie = new Cookie(FormsAuthentication.FormsCookieName, securityCookieString);
                        securityCookie.Domain = securityCookieDomain;
                        httpClientHandler.CookieContainer.Add(securityCookie);
                    }

                    return await DownloadFile(url, httpClientHandler);
                }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = Properties.Settings.Default.maxConcurrentDownloads });

            foreach (var url in urls)
                block.Post(url);

            block.Complete();

            return block;
        }

        private static async Task<DownloadedFile[]> DownloadFile(string url, HttpClientHandler clientHandler)
        {
            var client = new HttpClient(clientHandler);
            var downloadedFile = new DownloadedFile();

            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync(url);

                if (responseMessage.Content.Headers.ContentDisposition == null)
                    return new DownloadedFile[0];

                downloadedFile.FileName = Path.Combine(
                    Properties.Settings.Default.workingDirectory, responseMessage.Content.Headers.ContentDisposition.FileName);

                if (!Directory.Exists(Properties.Settings.Default.workingDirectory))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.workingDirectory);
                }

                using (var httpStream = await responseMessage.Content.ReadAsStreamAsync())
                using (var filestream = new FileStream(
                    downloadedFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                {
                    await httpStream.CopyToAsync(filestream, 4096);
                }
            }
            // TODO: improve
            catch (Exception ex)
            {
                return new DownloadedFile[0];
            }

            return new[] { downloadedFile };
        }
    }
}
