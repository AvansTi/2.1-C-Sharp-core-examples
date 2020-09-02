using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpPackageLength
{
    class Program  {
        static void Main(string[] args) {
            int numMessages = 0;
            var messages = new string[2];
            var packetizer = new PacketProtocol(2000);
            packetizer.MessageArrived += message => {
                messages[numMessages] = Encoding.UTF8.GetString(message);
                ++numMessages;
            };
            packetizer.DataReceived(
            PacketProtocol.WrapMessage(Encoding.UTF8.GetBytes("Hello")).Concat(
            PacketProtocol.WrapMessage(Encoding.UTF8.GetBytes("World"))).ToArray());
            foreach (var message in messages) {
                Console.WriteLine(message);
            }
            Console.ReadKey();
        }
    }
}
