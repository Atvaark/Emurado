using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitlePropertyObjectList : TitleProperty
    {
        public override TitlePropertyType Type
        {
            get { return TitlePropertyType.Unknown; }
        }

        // TODO: Validate type of ObjectList
        [JsonProperty("objList", NullValueHandling = NullValueHandling.Ignore)]
        public List<TitleInstance> Value { get; set; }
    }
}