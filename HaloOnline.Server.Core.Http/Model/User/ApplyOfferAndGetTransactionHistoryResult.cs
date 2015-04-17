using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class ApplyOfferAndGetTransactionHistoryResult
    {
        [JsonProperty("ApplyOfferAndGetTransactionHistory")]
        public ServiceResult<UserTransactionHistory> Result { get; set; }
    }
}
