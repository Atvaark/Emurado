using HaloOnline.Server.Model.TitleResource;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.TitleResource
{
    public class GetTitleConfigurationResult
    {
        [JsonProperty("GetTitleConfigurationResult")]
        public ServiceResult<TitleConfiguration> Result { get; set; }
    }
}
