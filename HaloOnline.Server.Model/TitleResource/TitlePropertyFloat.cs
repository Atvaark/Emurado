using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitlePropertyFloat : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.Float; }
        }

        [JsonProperty("floatVal", NullValueHandling = NullValueHandling.Ignore)]
        public float? Value { get; set; }

    }
}