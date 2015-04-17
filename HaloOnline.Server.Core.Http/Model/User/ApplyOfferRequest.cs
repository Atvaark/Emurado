using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class ApplyOfferRequest
    {
        [JsonProperty("offerId")]
        public string OfferId { get; set; }
    }
}
