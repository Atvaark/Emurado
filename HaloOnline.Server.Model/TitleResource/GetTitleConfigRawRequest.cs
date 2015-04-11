using Newtonsoft.Json;

namespace HaloOnline.Server.Model.TitleResource
{
    public class GetTitleConfigRawRequest
    {
        [JsonProperty("combinationHash")]
        public string CombinationHash { get; set; }
    }
}
