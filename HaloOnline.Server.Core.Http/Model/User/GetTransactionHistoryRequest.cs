using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetTransactionHistoryRequest
    {
        [JsonProperty("fromTime")]
        public int FromTime { get; set; }

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }
    }
}
