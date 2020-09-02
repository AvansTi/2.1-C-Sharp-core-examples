#define USE_DELIMETER

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using ClientServer;

namespace TcpClientTest
{
    class Program {
        static void Main(string[] args) {
            TcpClient client = new TcpClient("127.0.0.1", 1330);
            NetworkStream networkStream = client.GetStream();

            bool done = false;
            Console.WriteLine("Type 'bye' to end connection");
            while (!done) {
                Console.Write("Enter a message to send to server: ");
                string message = Console.ReadLine();

#if USE_DELIMETER
                // Gebruik van optie 1:
                ClientServerUtil.WriteTextMessage(networkStream, message);
#else   
                // Gebruik van optie 2:
                ClientServerUtil.SendMessage(networkStream, message);
#endif

                string response = ClientServerUtil.ReadTextMessage(networkStream);

                Console.WriteLine("Response: " + response);
                done = response.Equals("BYE");
            }

            client.Close();
            networkStream.Close();
        }


    }
}
