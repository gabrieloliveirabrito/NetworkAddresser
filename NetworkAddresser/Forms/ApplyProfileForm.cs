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

            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnApplyProfile_Click(object sender, EventArgs e)
        {
            var item = tvAdapterProfiles.SelectedNode;
            var tuple = (Tuple<AdapterInfo, AdapterProfile>)item.Tag;
            var adapter = tuple.Item1;
            var profile = tuple.Item2;

            Application.ApplyProfile(adapter, profile);
        }

        private void tvAdapterProfiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnApplyProfile.Enabled = e.Node.Tag != null;
        }

        private void btnReloadProfiles_Click(object sender, EventArgs e)
        {
            if(Application.Reload())
            {
                OnShown(EventArgs.Empty);
            }
        }
    }
}
