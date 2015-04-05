using HaloOnline.Server.Model.TitleResource;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.TitleResource
{
    public class GetTitleTagsPatchConfigurationResult
    {
        [JsonProperty("GetTitleTagsPatchConfigurationResult")]
        public ServiceResult<TitleTagsPatchConfiguration> Result { get; set; }
    }
}
