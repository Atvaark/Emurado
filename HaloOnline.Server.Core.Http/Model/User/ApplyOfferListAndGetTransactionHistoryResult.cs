using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class ApplyOfferListAndGetTransactionHistoryResult
    {
        [JsonProperty("ApplyOfferListAndGetTransactionHistoryResult")]
        public ServiceResult<UserTransactionHistory> Result { get; set; }
    }
}
