using System;
using System.Net.NetworkInformation;
using System.Collections;
using System.Linq;
using System.Net;

namespace ZTI.Tools
{
    public class Network
    {
        public static IPAddress GetCurrentInterNetworkIP()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var item in interfaces)
            {
                if (item.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    IPInterfaceProperties property = item.GetIPProperties();
                    foreach (UnicastIPAddressInformation ipAddress in property.UnicastAddresses)
                    {
                        if (ipAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return ipAddress.Address;
                        }
                    }
                }
            }

            return null;
        }
    }
}
