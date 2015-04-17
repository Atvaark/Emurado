using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class ApplyExternalOfferRequest
    {
        [JsonProperty("externalOfferId")]
        public string ExternalOfferId { get; set; }
    }
}
