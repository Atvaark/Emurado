using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitlePropertyFloatList : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.FloatList; }
        }

        [JsonProperty("floatList", NullValueHandling = NullValueHandling.Ignore)]
        public List<float> Value { get; set; }
    }
}