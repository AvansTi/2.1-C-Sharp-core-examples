using System;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using CLientServerUtil;

namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Loopback, 1234);
            TcpListener listener = new TcpListener(ep);
            listener.Start();

            Console.WriteLine(@"
            ========================================
             Started listening requests at:
                 {0}:{1}
            ========================================", 
            ep.Address, ep.Port);

            // Run the loop continously; this is the server.
            while (true)
            {
                const int bytesize = 1024;

                string message = null;
                byte[] buffer = new byte[bytesize];

                var sender = listener.AcceptTcpClient();
                sender.GetStream().Read(buffer, 0, bytesize);

                // Read the message, and perform different actions
                message = MyUtil.cleanMessage(buffer);

                // Save the data sent by the client;
                Person person = JsonConvert.DeserializeObject<Person>(message); // Deserialize

                Console.WriteLine($"{person.Name} (email: {person.Email}) sends message:\n\t{person.Message}");

                //Send response to the client:
                byte[] bytes = System.Text.Encoding.Unicode.GetBytes("Thank you for your message, " + person.Name);
                sender.GetStream().Write(bytes, 0, bytes.Length); // Send the response
            }
        }

  
        // Sends the message string using the bytes provided.
        private static void sendMessage(byte[] bytes, TcpClient client)
        {
            client.GetStream()
                .Write(bytes, 0, 
                bytes.Length); // Send the stream
        }
    }

   
}
