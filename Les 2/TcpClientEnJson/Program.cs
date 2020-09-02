using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TcpClientEnJson
{
    class Program
    {

        private static async Task<string> getWeather(string city)
        {
            string weburl = $"http://api.openweathermap.org/data/2.5/weather?q={city},nl&appid=b3baf1776d53256707ba7edb8395c284";

            var json = await new WebClient().DownloadStringTaskAsync(new Uri(weburl));
            return json;

        }

        static void Main(string[] args)
        {
            Task<string> json = getWeather("Breda").Wait();

            //TcpClient client = new TcpClient();
            //client.Connect(@"http://api.openweathermap.org/data/2.5/weather?q=Breda,nl&appid=b3baf1776d53256707ba7edb8395c284", 80);
            //string response = ReadResponse(client);
            Console.WriteLine(json);
        }

        private static string ReadResponse(TcpClient client)
        {
            byte[] buffer = new byte[1024];

            int totalRead = 0;
            do
            {
                int read = client.GetStream().Read(buffer, totalRead, buffer.Length - totalRead);
                totalRead += read;
            } while (client.GetStream().DataAvailable);

            return Encoding.UTF8.GetString(buffer, 0, totalRead);
        }
    }
}
