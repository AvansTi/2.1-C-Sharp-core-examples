using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace SimpleTCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1330);
            bool done = false;
            Console.WriteLine("Type 'bye' to end connection");
            while (!done)
            {
                Console.Write("Enter a message to send to server: ");
                string message = Console.ReadLine();

                WriteTextMessage(client, message);

                string response = ReadTextMessage(client);
                Console.WriteLine("Response: " + response);
                done = response.Equals("BYE");
            }
        }

        public static void WriteTextMessage (TcpClient client, string message) {
            var stream = new StreamWriter(client.GetStream(), Encoding.ASCII);
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }

        public static string ReadTextMessage(TcpClient client){
            var stream = new StreamReader(client.GetStream(), Encoding.ASCII);
            {
                return stream.ReadLine();
            }
        }


    }
}
