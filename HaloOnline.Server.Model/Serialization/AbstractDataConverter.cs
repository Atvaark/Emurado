using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Serialization
{
    public class AbstractDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                if (serializer.NullValueHandling == NullValueHandling.Include)
                {
                    writer.WriteNull();
                }
                return;
            }

            writer.WriteStartArray();
            byte[] arbitraryData = (byte[]) value;
            writer.WriteRaw(string.Join(",", arbitraryData));
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
            {
                throw new JsonSerializationException("Unexpected token when reading abstract data.");
            }

            var result = new List<byte>();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Integer:
                        result.Add(Convert.ToByte(reader.Value));
                        break;
                    case JsonToken.EndArray:
                        return result.ToArray();
                    default:
                        throw new JsonSerializationException(
                            string.Format("Unexpected token when reading abstract data ({0}).", reader.TokenType));
                }
            }
            throw new JsonSerializationException("Missing end array token when reading abstract data.");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (byte[]);
        }
    }
}
