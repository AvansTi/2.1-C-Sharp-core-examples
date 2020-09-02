#define USE_DELIMETER

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    public class ClientServerUtil  {
        public static Encoding encoding = Encoding.UTF8;

        public static string ReadTextMessage(NetworkStream networkStream) {
            StreamReader stream = new StreamReader(networkStream, encoding);
            return stream.ReadLine();
        }

        public static void WriteTextMessage(NetworkStream networkStream, string message) {
            StreamWriter stream = new StreamWriter(networkStream, encoding);
            stream.WriteLine(message);
            stream.Flush();
        }

        // OPMERKING: nog niet correct. 
        // practicumopdracht: geef de lengte mee bij het versturen van de boodschap en
        // bij lezen lezen lees je:
        // - eerst de lengte (X) van de message
        // - vervolgens lezen tot alle X bytes gelezen zijn.
        public static string ReadMessage(NetworkStream networkStream) {
            byte[] buffer = new byte[256];
            int totalRead = 0;

            //read bytes until stream indicates there are no more
            do {
                int read = networkStream.Read(buffer, totalRead, buffer.Length - totalRead);
                totalRead += read;
                Console.WriteLine("ReadMessage: " + read);
            } while (networkStream.DataAvailable);

            return encoding.GetString(buffer, 0, totalRead);
        }

        public static void SendMessage(NetworkStream networkStream, string message) {
            //make sure the other end decodes with the same format!
            byte[] bytes = encoding.GetBytes(message);
            networkStream.Write(bytes, 0, bytes.Length);
        }
    }
}
