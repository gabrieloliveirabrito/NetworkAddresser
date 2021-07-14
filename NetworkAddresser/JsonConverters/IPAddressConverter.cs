using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace NetworkAddresser.JsonConverters
{
    public class IPAddressConverter : JsonConverter<IPAddress>
    {
        public override IPAddress ReadJson(JsonReader reader, Type objectType, IPAddress existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string address = reader.ReadAsString();
            return address == null ? null : IPAddress.Parse(address);
        }

        public override void WriteJson(JsonWriter writer, IPAddress value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
