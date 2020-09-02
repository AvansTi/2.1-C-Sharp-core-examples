using System;
using System.Net.Sockets;
using Newtonsoft.Json;
using CLientServerUtil;

namespace TcpClient
{
    class Program
    {
        /*
         * Opmerking: deze applicatie demonstreert een vereenvoudigde Tcp communicatie 
         * waarbij een json object geserialized wordt naar een byte[].
         * 
         * Maar hierbij wordt er van uitgegaan dat de boodschap gecommuniceerd
         * wordt met één read en één write. Deze aanname is voor Tcp niet correct!
         */

        static void Main(string[] args)
        {

            Console.WriteLine(@"
            ================================
            =   Enter details and submit   =
            ================================");

            // Get the details from the user, and store them.
            Person person = new Person();

            Console.Write("Enter your name: ");
            person.Name = Console.ReadLine();
            Console.Write("Enter your email address: ");
            person.Email = Console.ReadLine();
            Console.Write("Enter your message: ");
            person.Message = Console.ReadLine();

            string personToJSON = person.ToJSON();
            // Send the message
            byte[] bytes = sendMessage(System.Text.Encoding.Unicode.GetBytes(personToJSON));
            string answer = MyUtil.cleanMessage(bytes);
            Console.WriteLine(answer);

            Console.Read();
        }

        private static byte[] sendMessage(byte[] messageBytes)
        {
            const int bytesize = 1024;
            try
            {
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("127.0.0.1", 1234); // Create a new connection
                NetworkStream stream = client.GetStream();

                stream.Write(messageBytes, 0, messageBytes.Length); // Write the bytes
                Console.WriteLine(@"
            ================================
            =   Connected to the server    =
            ================================

                Waiting for response...");

                messageBytes = new byte[bytesize];

                stream.Read(messageBytes, 0, messageBytes.Length);

                // Clean up
                stream.Dispose();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return messageBytes;
        }

    }

}
