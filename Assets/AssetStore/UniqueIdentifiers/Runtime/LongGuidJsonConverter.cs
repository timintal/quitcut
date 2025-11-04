using Newtonsoft.Json;
using System;

namespace UniqueIdentifier
{
    public class LongGuidJsonConverter : JsonConverter<LongGuid>
    {
        public override void WriteJson(JsonWriter writer, LongGuid value, JsonSerializer serializer) => serializer.Serialize(writer, value.ToBase64String());

        public override LongGuid ReadJson(JsonReader reader, Type objectType, LongGuid existingValue, bool hasExistingValue, JsonSerializer serializer) => 
            LongGuid.FromBase64String(serializer.Deserialize<string>(reader));
    }
}