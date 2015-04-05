using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class ApplyOfferListResult
    {
        [JsonProperty("ApplyOfferListResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
