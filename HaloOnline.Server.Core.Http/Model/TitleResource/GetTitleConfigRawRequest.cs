using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.TitleResource
{
    public class GetTitleConfigRawRequest
    {
        [JsonProperty("combinationHash")]
        public string CombinationHash { get; set; }
    }
}
