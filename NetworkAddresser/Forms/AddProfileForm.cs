using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkAddresser.Forms
{
    using Lib;
    using System.Net;

    public partial class AddProfileForm : Form
    {
        Application application;
        AdapterInfo adapter;
        AdapterProfile profile;

        public AddProfileForm(Application application)
        {
            TopMost = true;
            InitializeComponent();
            this.application = application;
            Reload();
        }

        public AddProfileForm(Application application, AdapterInfo adapter, AdapterProfile profile) : this(application)
        {
            this.adapter = adapter;
            this.profile = profile;

            Text = "NetworkAddresser - Edit Profile";
            cbAdapters.SelectedItem = adapter;
            txtProfileName.Text = profile.Name;
            cbDHCP.Checked = profile.DHCP;
            txtIPAddress.Text = profile.Address.ToString();
            txtSubnet.Text = profile.SubnetMask.ToString();
            txtGateway.Text = profile.Gateway.ToString();
            txtDNS1.Text = profile.DNS2.ToString();
            txtDNS2.Text = profile.DNS2.ToString();
            btnCreateProfile.Text = "Edit profile";
        }

        private void Reload()
        {
            cbAdapters.Items.Clear();
            foreach (var adapter in application.Manager.FetchEthernetAdapters())
                cbAdapters.Items.Add(adapter);
            cbAdapters.SelectedIndex = cbAdapters.Items.Count - 1;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void cbDHCP_CheckedChanged(object sender, EventArgs e)
        {
            txtIPAddress.Enabled = !cbDHCP.Checked;
            txtSubnet.Enabled = !cbDHCP.Checked;
            txtGateway.Enabled = !cbDHCP.Checked;
            txtDNS1.Enabled = !cbDHCP.Checked;
            txtDNS2.Enabled = !cbDHCP.Checked;
        }

        private void btnCreateProfile_Click(object sender, EventArgs e)
        {
            IPAddress dns1 = null, dns2 = null;
            var configuration = application.Configuration;
            var adapter = cbAdapters.SelectedItem as AdapterInfo;

            if (adapter == null)
            {
                MessageBox.Show(this, "The adapter hasn't been selected!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var profile = new AdapterProfile();
            profile.DHCP = cbDHCP.Checked;

            if (txtProfileName.TextLength == 0)
            {
                MessageBox.Show(this, "The Profile Name field is empty!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                profile.Name = txtProfileName.Text;

            if (!IPAddress.TryParse(txtIPAddress.Text, out IPAddress ipAddress))
            {
                MessageBox.Show(this, "The IP Address is not valid IP!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                profile.Address = ipAddress;

            if (!IPAddress.TryParse(txtSubnet.Text, out IPAddress subnetMask))
            {
                MessageBox.Show(this, "The Subnet Mask is not valid IP!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                profile.SubnetMask = subnetMask;

            if (!IPAddress.TryParse(txtGateway.Text, out IPAddress gateway))
            {
                MessageBox.Show(this, "The Gateway is not valid IP!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                profile.Gateway = gateway;

            if (txtDNS1.TextLength > 0 && !IPAddress.TryParse(txtDNS1.Text, out dns1))
            {
                MessageBox.Show(this, "The DNS1 is not valid IP!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                profile.DNS1 = dns1;

            if (txtDNS2.TextLength > 0 && !IPAddress.TryParse(txtDNS2.Text, out dns2))
            {
                MessageBox.Show(this, "The DNS2 is not valid IP!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                profile.DNS2 = dns2;

            if (this.adapter != null && this.profile != null)
            {
                if (configuration.Adapters.TryGetValue(this.adapter, out List<AdapterProfile> oldProfiles))
                {
                    oldProfiles.Remove(this.profile);
                    if (this.adapter != adapter)
                    {
                        if (configuration.Adapters.TryGetValue(adapter, out List<AdapterProfile> newProfiles))
                            newProfiles.Add(profile);
                        else
                        {
                            var profiles = new List<AdapterProfile>();
                            profiles.Add(profile);

                            configuration.Adapters.Add(adapter, profiles);
                        }
                    }
                    else
                    {
                        oldProfiles.Add(profile);
                    }
                }
            }
            else
            {
                if (configuration.Adapters.TryGetValue(adapter, out List<AdapterProfile> newProfiles))
                    newProfiles.Add(profile);
                else
                {
                    var profiles = new List<AdapterProfile>();
                    profiles.Add(profile);

                    configuration.Adapters.Add(adapter, profiles);
                }
            }

            if (!application.SaveConfiguration(configuration))
            {
                MessageBox.Show(this, "Failed to save profile on the configuration!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                Hide();
        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtSubnet.TextLength == 0 && IPAddress.TryParse(txtIPAddress.Text, out IPAddress address))
            {
                var subnetMask = new byte[4];
                var firstOctet = address.GetAddressBytes()[0];

                if (firstOctet <= 126)
                {
                    subnetMask[0] = 255;
                }
                else if (firstOctet >= 127 && firstOctet <= 191)
                {
                    subnetMask[0] = 255;
                    subnetMask[1] = 255;
                }
                else if (firstOctet >= 192 && firstOctet <= 223)
                {
                    subnetMask[0] = 255;
                    subnetMask[1] = 255;
                    subnetMask[2] = 255;
                }

                txtSubnet.Text = new IPAddress(subnetMask).ToString();
            }
        }
    }
}
