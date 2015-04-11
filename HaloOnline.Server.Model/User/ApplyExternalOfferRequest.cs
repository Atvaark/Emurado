using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class ApplyExternalOfferRequest
    {
        [JsonProperty("externalOfferId")]
        public string ExternalOfferId { get; set; }
    }
}
