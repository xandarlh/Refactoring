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
    public class Network
    {
        public string[] LocalPing()
        {
            // Ping's the local machine.
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send(address);
            string[] stringArray = new string[5];
            if (reply.Status == IPStatus.Success)
            {
                stringArray[0] = "Address: " + reply.Address.ToString();
                stringArray[1] = "RoundTrip time:: " + reply.RoundtripTime.ToString();
                stringArray[2] = "Time to live: " + reply.Options.Ttl.ToString();
                stringArray[3] = "Don't fragment: " + reply.Options.DontFragment.ToString();
                stringArray[4] = "Buffer size: " + reply.Buffer.Length.ToString();
            }
            else
            {
                stringArray[0] = reply.Status.ToString();
            }
            return stringArray;
        }
        public string DisplayDhcpServerAddresses()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            string addressString = "";

            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                if (addresses.Count > 0)
                {
                    addressString += adapter.Description + "\n";
                    foreach (IPAddress address in addresses)
                    {
                        addressString += $"  Dhcp Address ............................ : { address.ToString()} \n";
                    }
                }
            }
            return addressString;
        }
        public string Traceroute(string ipAddressOrHostName)
        {
            IPAddress ipAddress = Dns.GetHostEntry(ipAddressOrHostName).AddressList[0];
            StringBuilder traceResults = new StringBuilder();

            using (Ping pingSender = new Ping())
            {
                PingOptions pingOptions = new PingOptions();
                Stopwatch stopWatch = new Stopwatch();
                byte[] bytes = new byte[32];

                pingOptions.DontFragment = true;
                pingOptions.Ttl = 1;
                int maxHops = 30;

                traceResults.AppendLine(
                    string.Format(
                        "Tracing route to {0} over a maximum of {1} hops:",
                        ipAddress,
                        maxHops));

                traceResults.AppendLine();

                for (int i = 1; i < maxHops + 1; i++)
                {
                    stopWatch.Reset();
                    stopWatch.Start();

                    PingReply pingReply = pingSender.Send(
                        ipAddress,
                        5000,
                        new byte[32], pingOptions);

                    stopWatch.Stop();

                    traceResults.AppendLine(
                        string.Format("{0}\t{1} ms\t{2}",
                        i,
                        stopWatch.ElapsedMilliseconds,
                        pingReply.Address));

                    if (pingReply.Status == IPStatus.Success)
                    {
                        traceResults.AppendLine();
                        traceResults.AppendLine("Trace complete."); break;
                    }
                    pingOptions.Ttl++;
                }
            }
            return traceResults.ToString();
        }
    }
}
