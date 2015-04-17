using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Friends
{
    public class SubscriptionRemoveRequest
    {
        [JsonProperty("userId")]
        public UserId  UserId { get; set; }
    }
}
