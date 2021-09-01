using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace RestApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "";
            // Maak een api-key aan en plaats dit in apikey.txt (in dezelfde folder als de .exe)
            string currentPath = Directory.GetCurrentDirectory();
            string apikeyFile = Path.Combine(currentPath, "apikey.txt");
            if (!File.Exists(apikeyFile) || apikeyFile.Length == 0) {
                Console.WriteLine("Maak een eigen apikey aan voor de openweathermap api en plaats in apikey.txt");
                Console.WriteLine("Applicatie wordt afgesloten...");
                Console.ReadKey();
                Environment.Exit(0);
            } else {
                apiKey = File.ReadAllText(apikeyFile);
            }

            TcpClient client = new TcpClient();
            client.Connect("api.openweathermap.org", 80);
            NetworkStream stream = client.GetStream();

            //maak de request:
            string request = getWeatherRequest("Breda", apiKey);
            byte[] buffer = Encoding.UTF8.GetBytes(request);


            //verstuur de request:
            stream.Write(buffer, 0, buffer.Length);

            //lees de request:
            var message = new StringBuilder();
            int numberOfBytesRead = 0;
            byte[] receiveBuffer = new byte[1024];

            do
            {
                numberOfBytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                message.AppendFormat("{0}", Encoding.UTF8.GetString(receiveBuffer, 0, numberOfBytesRead));
            }
            while (stream.DataAvailable);


            string response = message.ToString();

            Console.WriteLine("Response: \n" + response);

            //Na de header is er twee keer een regelovergang:
            response = response.Substring(response.IndexOf("\r\n\r\n"));

            dynamic jsonData = JsonConvert.DeserializeObject(response);

            // lees de jsonData:
            Console.WriteLine($"\n\nIn {jsonData.name} is de temp in kelvin: {jsonData.main.temp}");

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();

        }

        // Resultaat van onderstaande request kun je bestuderen in jsonmate.com
        // http://api.openweathermap.org/data/2.5/weather?q=Breda,nl&APPID=091a24d9eee46dc77f03edae09c9d39b
        

        private static string getWeatherRequest(string city, string apiKey)
        {
            return $"GET /data/2.5/weather?q={city},nl&APPID={apiKey} HTTP/1.1\r\n" +
                   "Host: api.openweathermap.org\r\n" +
                   "cache - control: no - cache\r\n\r\n";
            /*return $"GET /data/2.5/weather?q={city}&appid={apiKey} HTTP/1.1\r\n"
                     + "Host: api.openweathermap.org\r\n\r\n";*/
        }

        /*
         * Voor historische data is een betaalde api key nodig :(
         * 
         * http://history.openweathermap.org/data/2.5/history/city?q=Breda,NL&APPID=091a24d9eee46dc77f03edae09c9d39b 
         */
        private static string getWeatherHistory(string city, string apiKey)
        {
            return $"GET /data/2.5/history/city?q={city}&appid={apiKey} HTTP/1.1\r\n"
                     + "Host: history.openweathermap.org\r\n\r\n";
        }
    }
}



// cocktail database API
// http://forum.kodi.tv/showthread.php?tid=235298&pid=2079513#pid2079513

// zoeken per naam: http://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita

//eerst verbinding maken, poort 80
//client.Connect("www.thecocktaildb.com", 80); // geen http
//string request = getRequestCoctail("margarita");
//Console.WriteLine("\n\n\nInstructions: \n");
//            Console.WriteLine(jsonData.drinks[0].strInstructions);

//string request = "GET /api/json/v1/1/search.php?s=margarita HTTP/1.0\r\n" +
//				 "Host: www.thecocktaildb.com\r\n\r\n";
//private static string getRequestCoctail(string coctail)
//{
//    return $"GET /api/json/v1/1/search.php?s={coctail} HTTP/1.0\r\n"
//             + "Host: www.thecocktaildb.com\r\n\r\n";
//}