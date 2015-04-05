using System.Collections.Generic;
using HaloOnline.Server.Model.Friends;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Friends
{
    public class SubscriptionRemoveResult
    {
        [JsonProperty("SubscriptionRemoveResult")]
        public ServiceResult<List<UserSubscriptions>> Result { get; set; }
    }
}
