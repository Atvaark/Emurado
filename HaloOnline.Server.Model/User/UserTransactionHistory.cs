using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class UserTransactionHistory
    {
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("transactions")]
        public List<UserTransaction> Transactions { get; set; }
    }
}
