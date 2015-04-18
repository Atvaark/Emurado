using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    // TODO: Make this class abstract and create a subclass for each type in TitlePropertyType
    public class TitleProperty
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TitlePropertyType Type { get; set; }

        [JsonProperty("strVal", NullValueHandling = NullValueHandling.Ignore)]
        public string StringValue { get; set; }

        [JsonProperty("intVal", NullValueHandling = NullValueHandling.Ignore)]
        public int? IntegerValue { get; set; }

        [JsonProperty("longVal", NullValueHandling = NullValueHandling.Ignore)]
        public long? LongValue { get; set; }

        [JsonProperty("floatVal", NullValueHandling = NullValueHandling.Ignore)]
        public float? FloatValue { get; set; }

        [JsonProperty("strList", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> StringList { get; set; }

        [JsonProperty("intList", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> IntegerList { get; set; }

        [JsonProperty("floatList", NullValueHandling = NullValueHandling.Ignore)]
        public List<float> FloatList { get; set; }

        // TODO: Validate type of ObjectList
        [JsonProperty("objList", NullValueHandling = NullValueHandling.Ignore)]
        public List<TitleInstance> ObjectList { get; set; }
    }
}
