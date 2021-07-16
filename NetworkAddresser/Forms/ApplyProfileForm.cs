using NetworkAddresser.Lib;
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
    public partial class ApplyProfileForm : Form
    {
        public Application Application { get; set; }

        public ApplyProfileForm()
        {
            InitializeComponent();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            Hide();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Reload();

            //A strange hack to force form shown on NotifyIcon click
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Reload()
        {
            btnApplyProfile.Enabled = false;
            tvAdapterProfiles.Nodes.Clear();

            foreach (var pair in Application.Configuration.Adapters)
            {
                var adapterNode = tvAdapterProfiles.Nodes.Add(pair.Key.ID);
                foreach (var profile in pair.Value)
                {
                    var profileNode = adapterNode.Nodes.Add(profile.Name);
                    profileNode.Tag = new Tuple<AdapterInfo, AdapterProfile>(pair.Key, profile);
                    profileNode.EnsureVisible();
                }
                adapterNode.EnsureVisible();
            }
        }

        private void tvAdapterProfiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnApplyProfile.Enabled = e.Node.Tag != null;
            btnEditProfile.Enabled = e.Node.Tag != null;
            btnDeleteProfile.Enabled = e.Node.Tag != null;
        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            var frmAdd = new AddProfileForm(Application);
            frmAdd.FormClosed += (s, _) => Reload();
            frmAdd.Show();

            //Hide();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            var item = tvAdapterProfiles.SelectedNode;
            var tuple = (Tuple<AdapterInfo, AdapterProfile>)item.Tag;
            var adapter = tuple.Item1;
            var profile = tuple.Item2;

            var frmEdit = new AddProfileForm(Application, adapter, profile);
            frmEdit.FormClosed += (s, _) => Reload();
            frmEdit.Show();
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this profile? This action is irreversible!", "NetworkAddresser - Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var configuration = Application.Configuration;

                var node = tvAdapterProfiles.SelectedNode;
                var tuple = (Tuple<AdapterInfo, AdapterProfile>)node.Tag;
                var adapter = tuple.Item1;
                var profile = tuple.Item2;

                if(configuration.Adapters.TryGetValue(adapter, out List<AdapterProfile> profiles))
                {
                    profiles.Remove(profile);
                    if (profiles.Count == 0)
                        configuration.Adapters.Remove(adapter);

                    if (Application.SaveConfiguration(configuration))
                        Reload();
                }
            }
        }

        private void btnApplyProfile_Click(object sender, EventArgs e)
        {
            var item = tvAdapterProfiles.SelectedNode;
            var tuple = (Tuple<AdapterInfo, AdapterProfile>)item.Tag;
            var adapter = tuple.Item1;
            var profile = tuple.Item2;

            Application.ApplyProfile(adapter, profile);
            Hide();
        }

        private void btnReloadProfiles_Click(object sender, EventArgs e)
        {
            if (Application.Reload())
            {
                Reload();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Quit();
        }

        private void tvAdapterProfiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = tvAdapterProfiles.SelectedNode;
            if (item != null && item.Tag != null)
            {
                var tuple = (Tuple<AdapterInfo, AdapterProfile>)item.Tag;
                var adapter = tuple.Item1;
                var profile = tuple.Item2;

                Application.ApplyProfile(adapter, profile);
                Hide();
            }
        }
    }
}
