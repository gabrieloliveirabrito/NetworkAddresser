using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GFramework.Factories;

namespace NetworkAddresser
{
    using Lib;
    using JsonConverters;

    public class Configuration
    {
        public static JsonSerializerSettings SerializerSettings
        {
            get => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Converters = new List<JsonConverter> {
                    new IPAddressConverter(), 
                    new AdaptersDictionaryConverter(), 
                    new AdapterProfileConverter(), 
                },
            };
        }

        public string Library { get; set; }
        public Dictionary<AdapterInfo, List<AdapterProfile>> Adapters { get; set; }

        public static bool Load(out Configuration configuration)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "configuration.json");

                configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(path), SerializerSettings);
                return true;
            }
            catch(Exception ex)
            {
                LoggerFactory.GetLogger<Configuration>().LogFatal(ex);

                configuration = null;
                return false;
            }
        }

        public static bool Save(Configuration configuration)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "configuration.json");
                string json = JsonConvert.SerializeObject(configuration, SerializerSettings);

                if (File.Exists(path))
                    File.Delete(path);

                using (var writer = File.CreateText(path))
                    writer.Write(json);
                return true;
            }
            catch (Exception ex)
            {
                LoggerFactory.GetLogger<Configuration>().LogFatal(ex);

                configuration = null;
                return false;
            }
        }
    }
}
