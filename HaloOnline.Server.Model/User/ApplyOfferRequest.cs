using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class ApplyOfferRequest
    {
        [JsonProperty("offerId")]
        public string OfferId { get; set; }
    }
}
