using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitlePropertyStringList : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.StringList; }
        }

        [JsonProperty("strList", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Value { get; set; }
    }
}