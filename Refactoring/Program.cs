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

            PCInfo pCInfo = new PCInfo();

            string hostName = "ZBC-E-ALEX303A";
            

            Console.WriteLine(pCInfo.GetHostAddresses(hostName));

            Console.WriteLine(pCInfo.GetHostAliases(hostName));

            
            Console.ReadKey();
        }
    }
}
