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
    public class PCInfo
    {
        public string GetHostAliases(string hostName)
        {
            IPHostEntry hostInfo = Dns.GetHostEntry(hostName);
            
            // Get the alias names of the addresses in the IP address list.
            String[] alias = hostInfo.Aliases;

            string aliases = "\nAliases : ";
            for (int index = 0; index < alias.Length; index++)
            {
                aliases += alias[index] + "\n";
            }
            return aliases;
        }
        public string GetHostAddresses(string hostName)
        {           
            IPHostEntry hostInfo = Dns.GetHostByName(hostName);
            IPAddress[] address = hostInfo.AddressList;

            string addresses = "\nIP address list : \n";
            for (int index = 0; index < address.Length; index++)
            {
                addresses += address[index] + "\n";
            }
            return addresses;
        }
    }
}
