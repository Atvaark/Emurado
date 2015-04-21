using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class ApplyOfferAndGetTransactionHistoryRequest
    {
        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("historyFromTime")]
        public int HistoryFromTime { get; set; }

        [JsonProperty("historyMaxResults")]
        public int HistoryMaxResults { get; set; }

    }
}
