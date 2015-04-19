using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitlePropertyIntegerList : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.IntegerList; }
        }

        [JsonProperty("intList", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> Value { get; set; }
    }
}