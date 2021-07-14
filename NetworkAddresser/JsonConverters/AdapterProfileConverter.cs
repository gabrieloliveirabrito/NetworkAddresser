using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NetworkAddresser.JsonConverters
{
    using Lib;

    public class AdapterProfileConverter : JsonConverter<AdapterProfile>
    {
        public override AdapterProfile ReadJson(JsonReader reader, Type objectType, AdapterProfile existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var profile = new AdapterProfile();

            reader.Read();//ID Property Name
            profile.Name = reader.ReadAsString() ?? null;

            reader.Read();//Object-Start
            profile.DHCP = reader.ReadAsBoolean() ?? false;

            reader.Read();//Address Property Name
            profile.Address = serializer.Deserialize<IPAddress>(reader) ?? null;

            reader.Read();//SubnetMask Property Name
            profile.SubnetMask = serializer.Deserialize<IPAddress>(reader) ?? null;

            reader.Read();//Gateway Property Name
            profile.Gateway = serializer.Deserialize<IPAddress>(reader) ?? null;

            reader.Read();//DNS1 Property Name
            profile.DNS1 = serializer.Deserialize<IPAddress>(reader) ?? null;

            reader.Read();//DNS2 Property Name
            profile.DNS2 = serializer.Deserialize<IPAddress>(reader) ?? null;
            reader.Read();//Object-End

            return profile;
        }

        public override void WriteJson(JsonWriter writer, AdapterProfile value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("Name");
            writer.WriteValue(value.Name);

            writer.WritePropertyName("DHCP");
            writer.WriteValue(value.DHCP);

            writer.WritePropertyName("Address");
            serializer.Serialize(writer, value.Address);

            writer.WritePropertyName("SubnetMask");
            serializer.Serialize(writer, value.SubnetMask);

            writer.WritePropertyName("Gateway");
            serializer.Serialize(writer, value.Gateway);

            writer.WritePropertyName("DNS1");
            serializer.Serialize(writer, value.DNS1);

            writer.WritePropertyName("DNS2");
            serializer.Serialize(writer, value.DNS2);

            writer.WriteEndObject();
        }
    }
}
