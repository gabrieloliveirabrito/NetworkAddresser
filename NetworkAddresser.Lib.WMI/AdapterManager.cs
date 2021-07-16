using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Net;
using GFramework.Factories;
using GFramework.Bases;

namespace NetworkAddresser.Lib.WMI
{
    public class AdapterManager : Lib.AdapterManager
    {
        BaseLogger logger;

        public override bool Init()
        {
            logger = LoggerFactory.GetLogger(this);
            return base.Init();
        }

        public override List<AdapterInfo> FetchEthernetAdapters()
        {
            var adapters = new List<AdapterInfo>();

            using (ManagementObjectSearcher NIC = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter"))
            using (ManagementObjectCollection NICCol = NIC.Get())
            {
                foreach (ManagementObject NICObj in NICCol)
                {
                    var id = NICObj["NetConnectionID"];
                    if (id != null)
                    {
                        var adapter = new AdapterInfo();
                        adapter.ID = id.ToString();
                        adapter.MACAddress = (string)NICObj["MACAddress"];

                        adapters.Add(adapter);
                    }
                }
            }

            return adapters;
        }

        public override AdapterProfile GetDefaultAdapterProfile(AdapterInfo adapter)
        {
            try
            {
                using (ManagementObjectSearcher NIC = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter"))
                using (ManagementObjectCollection NICCol = NIC.Get())
                {
                    foreach (ManagementObject NICObj in NICCol)
                    {
                        var id = NICObj["NetConnectionID"];
                        if (id != null)
                        {
                            using (ManagementObjectSearcher NAC = new ManagementObjectSearcher($"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Caption = '{NICObj["Caption"]}'"))
                            using (ManagementObjectCollection NACCol = NAC.Get())
                            {
                                foreach (ManagementObject NACObj in NACCol)
                                {
                                    if (Convert.ToBoolean(NACObj["IPEnabled"] ?? false))
                                    {
                                        var adapterProfile = new AdapterProfile();

                                        adapterProfile.DHCP = Convert.ToBoolean(NACObj["DHCPEnabled"]);

                                        string[] addresses = (string[])NACObj["IPAddress"];
                                        string[] subnetMasks = (string[])NACObj["IPSubnet"];
                                        string[] gateways = (string[])NACObj["DefaultIPGateway"];
                                        string[] nameservers = (string[])NACObj["DNSServerSearchOrder"];

                                        adapterProfile.Name = "Current Applied";
                                        adapterProfile.Address = IPAddress.Parse(addresses.First());
                                        adapterProfile.SubnetMask = IPAddress.Parse(subnetMasks.First());
                                        adapterProfile.Gateway = gateways == null ? null : IPAddress.Parse(gateways.First());
                                        adapterProfile.DNS1 = nameservers == null || nameservers.Length < 1 ? null : IPAddress.Parse(nameservers[0]);
                                        adapterProfile.DNS2 = nameservers == null || nameservers.Length < 2 ? null : IPAddress.Parse(nameservers[1]);

                                        return adapterProfile;
                                    }
                                }
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                logger.LogFatal(ex);
                return null;
            }
        }

        public override bool ApplyAdapter(AdapterInfo adapter, AdapterProfile profile)
        {
            try
            {
                using (ManagementObjectSearcher NIC = new ManagementObjectSearcher($"SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID = '{adapter.ID}' OR MACAddress = '{adapter.MACAddress}'"))
                using (ManagementObjectCollection NICCol = NIC.Get())
                {
                    ManagementObject NICObj = (from ManagementObject objs in NICCol select objs).First();
                    if (NICObj != null)
                    {
                        using (ManagementObjectSearcher NAC = new ManagementObjectSearcher($"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Caption = '{NICObj["Caption"]}'"))
                        using (ManagementObjectCollection NACCol = NAC.Get())
                        {
                            ManagementObject NACObj = (from ManagementObject objs in NACCol select objs).First();

                            if (profile.DHCP)
                            {
                                NACObj.InvokeMethod("EnableDHCP", null);
                            }
                            else
                            {
                                using (var newIP = NACObj.GetMethodParameters("EnableStatic"))
                                {
                                    if (profile.Address != null)
                                        newIP["IPAddress"] = new[] { profile.Address.ToString() };
                                    if (profile.SubnetMask != null)
                                        newIP["SubnetMask"] = new[] { profile.SubnetMask.ToString() };

                                    NACObj.InvokeMethod("EnableStatic", newIP, null);
                                }

                                if (profile.Gateway != null)
                                {
                                    using (var newGateway = NACObj.GetMethodParameters("SetGateways"))
                                    {
                                        newGateway["DefaultIPGateway"] = new[] { profile.Gateway.ToString() };
                                        newGateway["GatewayCostMetric"] = new[] { 1 };

                                        NACObj.InvokeMethod("SetGateways", newGateway, null);
                                    }
                                }

                                List<string> nameservers = new List<string>();
                                if (profile.DNS1 != null)
                                    nameservers.Add(profile.DNS1.ToString());
                                if (profile.DNS2 != null)
                                    nameservers.Add(profile.DNS2.ToString());

                                using (var newDNS = NACObj.GetMethodParameters("SetDNSServerSearchOrder"))
                                {
                                    newDNS["DNSServerSearchOrder"] = nameservers.ToArray();
                                    NACObj.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                                }
                            }

                            return true;
                        }
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                LoggerFactory.GetLogger(this).LogFatal(ex);
                return false;
            }
        }
    }
}