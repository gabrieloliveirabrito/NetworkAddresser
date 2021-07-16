using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Net;

namespace NetworkAddresser.Lib
{
    public abstract class AdapterManager
    {
        public virtual bool Init() { return true; }

        public abstract List<AdapterInfo> FetchEthernetAdapters();
        public abstract AdapterProfile GetDefaultAdapterProfile(AdapterInfo adapter);
        public abstract bool ApplyAdapter(AdapterInfo adapter, AdapterProfile profile);
    }
}