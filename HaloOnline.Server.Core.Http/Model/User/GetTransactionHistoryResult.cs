using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetTransactionHistoryResult
    {
        [JsonProperty("GetTransactionHistoryResult")]
        public ServiceResult<UserTransactionHistory> Result { get; set; }
    }
}
