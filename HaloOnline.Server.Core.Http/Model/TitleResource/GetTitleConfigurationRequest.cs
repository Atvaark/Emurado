using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.TitleResource
{
    public class GetTitleConfigurationRequest
    {
        [JsonProperty("combinationHash")]
        public string CombinationHash { get; set; }
    }
}
