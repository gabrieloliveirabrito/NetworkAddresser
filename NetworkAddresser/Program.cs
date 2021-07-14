using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

using GFramework.Factories;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace NetworkAddresser
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = new Application())
            {
                application.Init();
                var logger = LoggerFactory.GetLogger("NetworkAddresser");

                try
                {
                    if (!Configuration.Load(out Configuration configuration))
                    {
                        MessageBox.Show("Failed to load the configuration file!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string path = Path.Combine(Environment.CurrentDirectory, configuration.Library);
                    if (!File.Exists(path))
                    {
                        MessageBox.Show("The NetworkAddresser Library (on configuration file) hasn't been found!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var assembly = Assembly.LoadFrom(path);
                    var managerType = assembly.GetTypes().FirstOrDefault(t => t.BaseType == typeof(Lib.AdapterManager));

                    if (managerType == null)
                    {
                        MessageBox.Show("The NetworkAddresser Manager class hasn't been found on the library!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var manager = (Lib.AdapterManager)Activator.CreateInstance(managerType);
                    if(manager == null || !manager.Init())
                    {
                        MessageBox.Show("The NetworkAddresser Manager failed to be initialized!", "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    application.Run(configuration, manager);
                }
                catch (Exception ex)
                {
                    logger.LogFatal(ex);

                    MessageBox.Show("NetworkAddresser exception has been caught!" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "NetworkAddresser - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}