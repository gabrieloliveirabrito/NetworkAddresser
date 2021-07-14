using GFramework.Factories;
using GFramework.LogWriters;
using NetworkAddresser.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WApplication = System.Windows.Forms.Application;

namespace NetworkAddresser
{
    using Forms;

    public class Application : ApplicationContext
    {
        NotifyIcon notify;
        ApplyProfileForm applyForm;
        MenuItem profilesMenuItem;
        Configuration configuration;
        AdapterManager manager;

        public Configuration Configuration => configuration;

        public void Init()
        {
            WApplication.EnableVisualStyles();
            WApplication.SetCompatibleTextRenderingDefault(false);
            LoggerFactory.AddLogWriter<FileLogWriter>();
        }

        public void Run(Configuration configuration, AdapterManager manager)
        {
            this.configuration = configuration;
            this.manager = manager;

            notify = new NotifyIcon();
            notify.Text = "Network Addresser";
            notify.Icon = Icon.ExtractAssociatedIcon(typeof(Application).Assembly.Location);
            notify.ContextMenu = new ContextMenu();
            notify.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    var taskbar = Taskbar.CurrentBounds;
                    var screen = Screen.PrimaryScreen.Bounds;

                    applyForm.Show();
                    applyForm.Location = new Point(screen.Width - applyForm.Size.Width, taskbar.Y - applyForm.Size.Height);
                }
            };

            applyForm = new ApplyProfileForm();
            applyForm.Application = this;

            profilesMenuItem = notify.ContextMenu.MenuItems.Add("Profiles");
            notify.ContextMenu.MenuItems.Add("-");
            notify.ContextMenu.MenuItems.Add("Quit", (s, e) => Quit());
            LoadItems();

            notify.Visible = true;
            WApplication.Run(this);
        }

        public void Quit()
        {
            if (notify != null)
                notify.Visible = false;
            Process.GetCurrentProcess().Kill();
        }

        public bool Reload()
        {
            if (!Configuration.Load(out Configuration configuration))
            {
                MessageBox.Show("Failed to load the configuration file!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                this.configuration = configuration;
                return true;
            }
        }

        void LoadItems()
        {
            profilesMenuItem.MenuItems.Clear();
            profilesMenuItem.MenuItems.Add("Reload Profiles", (s, e) => Reload());
            profilesMenuItem.MenuItems.Add("-");

            foreach (var pair in configuration.Adapters) //Adapters
            {
                var adapterItem = profilesMenuItem.MenuItems.Add(pair.Key.ID);
                adapterItem.Tag = pair.Key;

                foreach (var profile in pair.Value) //Profiles
                {
                    var profileItem = adapterItem.MenuItems.Add(profile.Name, (s, e) =>
                    {
                        var item = (MenuItem)s;
                        var tuple = (Tuple<AdapterInfo, AdapterProfile>)item.Tag;

                        ApplyProfile(tuple.Item1, tuple.Item2);
                    });
                    profileItem.Tag = new Tuple<AdapterInfo, AdapterProfile>(pair.Key, profile);
                }
            }
        }

        public void ApplyProfile(AdapterInfo adapter, AdapterProfile profile)
        {
            if (!manager.ApplyAdapter(adapter, profile))
                MessageBox.Show($"Failed to apply profile {adapter.ID} to adapter {profile.Name}!", "Ethernet Addresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}