using System;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Serialization
{
    public class UnixEpochSecondsJsonConverter : JsonConverter
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((long) Math.Floor((DateTime.UtcNow - UnixEpoch).TotalSeconds)).ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return UnixEpoch.AddSeconds((long) reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (DateTime);
        }
    }
}
