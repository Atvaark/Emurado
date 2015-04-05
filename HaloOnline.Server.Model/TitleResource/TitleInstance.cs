using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitleInstance
    {
        public TitleInstance()
        {
            Parents = new List<string>();
            Properties = new List<TitleProperty>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("parents")]
        public List<string> Parents { get; set; }

        [JsonProperty("props")]
        public List<TitleProperty> Properties { get; set; }
    }
}
