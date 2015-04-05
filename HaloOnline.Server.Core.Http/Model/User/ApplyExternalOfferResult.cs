using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class ApplyExternalOfferResult
    {
        [JsonProperty("ApplyExternalOfferResult")]
        public ServiceResult<string> Result { get; set; }
    }
}
