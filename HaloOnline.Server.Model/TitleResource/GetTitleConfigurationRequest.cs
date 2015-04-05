using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class GetTitleConfigurationRequest
    {
        [JsonProperty("combinationHash")]
        public string CombinationHash { get; set; }
    }
}
