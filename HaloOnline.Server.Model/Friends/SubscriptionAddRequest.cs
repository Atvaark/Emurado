using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Friends
{
    public class SubscriptionAddRequest
    {
        [JsonProperty("userId")]
        public UserId UserId;
    }
}
