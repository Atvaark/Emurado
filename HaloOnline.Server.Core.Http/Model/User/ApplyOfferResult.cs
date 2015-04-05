using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class ApplyOfferResult
    {
        [JsonProperty("ApplyOfferResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
