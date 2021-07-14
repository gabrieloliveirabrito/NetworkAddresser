using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NetworkAddresser.Lib
{
    public class AdapterProfile
    {
        public string Name { get; set; }
        public bool DHCP { get; set; }
        public IPAddress Address { get; set; }
        public IPAddress SubnetMask { get; set; }
        public IPAddress Gateway { get; set; }
        public IPAddress DNS1 { get; set; }
        public IPAddress DNS2 { get; set; }
    }
}
