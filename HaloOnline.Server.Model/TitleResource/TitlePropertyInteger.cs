using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitlePropertyInteger : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.Integer; }
        }

        [JsonProperty("intVal", NullValueHandling = NullValueHandling.Ignore)]
        public int? Value { get; set; }
    }
}