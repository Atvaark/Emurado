using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.TitleResource
{
    public class GetTitleConfigRawResult
    {
        [JsonProperty("GetTitleConfigRawResult")]
        public ServiceResult<string> Result { get; set; }
    }
}
