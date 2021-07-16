using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net;
using GFramework.Factories;
using System.Diagnostics;
using System.Security;
using GFramework.Bases;

namespace NetworkAddresser.Lib.Netsh
{
    public class AdapterManager : Lib.AdapterManager
    {
        BaseLogger logger;
        Process shellProcess;

        public override bool Init()
        {
            logger = LoggerFactory.GetLogger(this);
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                shellProcess = Process.Start(startInfo);
                shellProcess.OutputDataReceived += (s, e) => logger.LogInfo(e.Data);
                shellProcess.ErrorDataReceived += (s, e) => logger.LogError(e.Data);
                shellProcess.BeginOutputReadLine();
                shellProcess.BeginErrorReadLine();

                return base.Init();
            }
            catch (Exception ex)
            {
                logger.LogFatal(ex);
                return false;
            }
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
                if (profile.DHCP)
                {
                    shellProcess.StandardInput.WriteLine($"netsh interface ipv4 set address \"{adapter.ID}\" dhcp");
                    shellProcess.StandardInput.WriteLine($"netsh interface ipv4 set dns \"{adapter.ID}\" dhcp");
                }
                else
                {
                    shellProcess.StandardInput.WriteLine($"netsh interface ipv4 set address \"{adapter.ID}\" static {profile.Address} {profile.SubnetMask} {profile.Gateway}");
                    shellProcess.StandardInput.WriteLine($"netsh interface ipv4 add dnsservers \"{adapter.ID}\" address={profile.DNS1} index=1");
                    shellProcess.StandardInput.WriteLine($"netsh interface ipv4 add dnsservers \"{adapter.ID}\" address={profile.DNS2} index=2");
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.LogFatal(ex);
                return false;
            }
        }
    }
}