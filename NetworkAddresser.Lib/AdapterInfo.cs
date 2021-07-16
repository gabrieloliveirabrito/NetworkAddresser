using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NetworkAddresser.Lib
{
    public class AdapterInfo
    {
        public string ID { get; set; }
        public string MACAddress { get; set; }

        public override string ToString()
        {
            return $"ID: {ID} - MAC: {MACAddress}";
        }

        public override bool Equals(object obj)
        {
            if (obj is AdapterInfo)
            {
                var adapter = obj as AdapterInfo;
                return adapter.ID.Equals(ID) && adapter.MACAddress.Equals(MACAddress);
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode() ^ MACAddress.GetHashCode();
        }
    }
}
