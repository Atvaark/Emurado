using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class Tag
    {
        public string Name { get; set; }
        public int Type { get; set; }

        [JsonProperty("StrVal")]
        public string StringValue { get; set; }

        [JsonProperty("IntVal")]
        public int? IntegerValue { get; set; }

        [JsonProperty("FloatVal")]
        public float? FloatValue { get; set; }
    }
}
