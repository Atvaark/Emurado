using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public abstract class TitleProperty
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public abstract TitlePropertyType Type { get; }
    }
}
