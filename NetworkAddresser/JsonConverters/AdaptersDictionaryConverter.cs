using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAddresser.JsonConverters
{
    using Lib;

    class AdapterModel
    {
        public AdapterInfo Adapter { get; set; }
        public List<AdapterProfile> Profiles { get; set; }
    }

    public class AdaptersDictionaryConverter : JsonConverter<Dictionary<AdapterInfo, List<AdapterProfile>>>
    {
        public override Dictionary<AdapterInfo, List<AdapterProfile>> ReadJson(JsonReader reader, Type objectType, Dictionary<AdapterInfo, List<AdapterProfile>> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var models = serializer.Deserialize<List<AdapterModel>>(reader);

            return models.ToDictionary(m => m.Adapter, m => m.Profiles);
        }

        public override void WriteJson(JsonWriter writer, Dictionary<AdapterInfo, List<AdapterProfile>> value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach (var pair in value)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("Adapter");
                serializer.Serialize(writer, pair.Key);

                writer.WritePropertyName("Profiles");
                serializer.Serialize(writer, pair.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
}
