using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    class TitlePropertLong : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.Long; }
        }

        [JsonProperty("longVal", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }
    }
}