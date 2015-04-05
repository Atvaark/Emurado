using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class TitleConfiguration
    {
        [JsonProperty("combinationHash")]
        public string CombinationHash { get; set; }

        [JsonProperty("instances")]
        public List<TitleInstance> Instances { get; set; }
    }
}
