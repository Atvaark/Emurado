using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitlePropertyString : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.String; }
        }

        [JsonProperty("strVal", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

    }
}