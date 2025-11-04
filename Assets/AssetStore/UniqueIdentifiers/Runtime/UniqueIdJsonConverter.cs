using Newtonsoft.Json;
using System;

namespace UniqueIdentifier
{
    public class UniqueIdJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => typeof(UniqueId).IsAssignableFrom(objectType);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is UniqueId id)
            {
                writer.WriteValue(id.Guid.ToBase64String());
            }
            else
            {
                writer.WriteNull();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                return null;
            }
            
            var guid = LongGuid.FromBase64String(reader.Value?.ToString());
            return Activator.CreateInstance(objectType, guid);
        }
    }
}