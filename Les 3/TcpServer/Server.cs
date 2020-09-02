#define USE_DELIMITER

using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.IO;
using ClientServer;

namespace TcpServer
{
    class Program {
        static void Main(string[] args) {
            IPAddress localhost; //= IPAddress.Parse("127.0.0.1");

            bool ipIsOk = IPAddress.TryParse("127.0.0.1", out localhost);
            if (!ipIsOk) {
                Console.WriteLine("ip adres kan niet geparsed worden.");
                Environment.Exit(1);
            }

            TcpListener listener = new TcpListener(localhost, 1330);
            listener.Start();
            Console.WriteLine($@"
                ========================================
                  Server started at {DateTime.Now}
                  Waiting for connection
                ========================================");

            while (true) {

                //AcceptTcpClient waits for a connection from the client
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine($"Accepted client at {DateTime.Now}");
 
                //start a new thread to handle this connection so we can go back 
                //to waiting for another client
                Thread thread = new Thread(HandleClientThread);
                thread.Start(client);
            }
        }

        static void HandleClientThread(object obj) {
            TcpClient client = obj as TcpClient;
            if (client == null)
                return;
            NetworkStream networkStream = client.GetStream();
            
            bool done = false;
            while (!done) {
#if USE_DELIMITER
                // Package protocol optie 1: een \n geeft einde van de boodschap aan.
                string received = ClientServerUtil.ReadTextMessage(networkStream);
#else   
                // Optie 2: geef de lengte mee van de boodschap - uitwerking voor het practicum!
                string received = ClientServerUtil.ReadMessage(networkStream);
#endif

                Console.WriteLine("Received: {0}", received);
                done = received.Equals("bye");
                ClientServerUtil.WriteTextMessage(networkStream, done ? "BYE" : "OK");
            }
            client.Close();
            Console.WriteLine("Connection closed");
            networkStream.Close();
            Console.WriteLine("Networkstream closed");

        }


    }
}
