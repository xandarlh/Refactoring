using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Network network = new Network();
            DNS dNS = new DNS();

            IPAddress[] array = Dns.GetHostAddresses("en.wikipedia.org");
            foreach (IPAddress ip in array)
            {
                Console.WriteLine(ip.ToString());
            }


            network.LocalPing();
            Console.WriteLine("start");
            string t = dNS.GetHostnameFromIp("8.8.8.8");
            Console.WriteLine(t);
            Console.WriteLine("slut");
            string adr = dNS.GetIpFromHostname(t);
            Console.WriteLine("Weee " + adr);



            string a = network.Traceroute("8.8.8.8");
            Console.WriteLine("route*** " + a);

            network.DisplayDhcpServerAddresses();


            string hostName = "ZBC-E-ALEX303A";
            //WIN-M69SG2Q0732.test.local
            //ZBC-RG01203MKC

            IPHostEntry hostInfo = Dns.GetHostByName(hostName);

            // Get the IP address list that resolves to the host names contained in the 
            // Alias property.
            IPAddress[] address = hostInfo.AddressList;
            // Get the alias names of the addresses in the IP address list.
            String[] alias = hostInfo.Aliases;

            Console.WriteLine("Host name : " + hostInfo.HostName);
            Console.WriteLine("\nAliases : ");
            for (int index = 0; index < alias.Length; index++)
            {
                Console.WriteLine(alias[index]);
            }
            Console.WriteLine("\nIP address list : ");
            for (int index = 0; index < address.Length; index++)
            {
                Console.WriteLine(address[index]);
            }

            Console.ReadKey();
        }
    }
}
