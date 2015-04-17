using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.TitleResource
{
    public class GetTitleTagsPatchConfigurationRequest
    {
        [JsonProperty(PropertyName = "combinationHash")]
        public string CombinationHash { get; set; }
    }
}
