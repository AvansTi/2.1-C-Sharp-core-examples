using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkInfo
{
    class Program {
        public static void Main() {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            // interfaces now contains all the available network interfaces, or an empty array if no interfaces are detected.

            // You might also seen @ symbol before variable. 
            // In such case it allows using special C# keywords as variables.
            foreach (NetworkInterface @interface in interfaces) {
                if (@interface.NetworkInterfaceType == NetworkInterfaceType.Loopback) continue;
                Console.WriteLine(@interface.Description);
                UnicastIPAddressInformationCollection UnicastIPInfoCol = @interface.GetIPProperties().UnicastAddresses;
                foreach (UnicastIPAddressInformation UnicatIPInfo in UnicastIPInfoCol) {
                    Console.WriteLine($"\tIP Address is {UnicatIPInfo.Address}");
                    // __TODO__: Display IPv6 subnet
                    Console.WriteLine($"\tSubnet Mask is {UnicatIPInfo.IPv4Mask}");
                }
            }

            Console.WriteLine("\n\nDefault gateway on this machine:");
            PrintDefaultGateway();

            Console.ReadLine();
        }

        public static void PrintDefaultGateway() {
            var defaultGateway =
                from nics in NetworkInterface.GetAllNetworkInterfaces()
                from props in nics.GetIPProperties().GatewayAddresses
                where nics.OperationalStatus == OperationalStatus.Up
                select props.Address.ToString();

            Console.WriteLine($"\tGateway is {defaultGateway.First()}");
        }
    }
}
