using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Friends
{
    public class SubscriptionAddRequest
    {
        [JsonProperty("userId")]
        public UserId UserId;
    }
}
