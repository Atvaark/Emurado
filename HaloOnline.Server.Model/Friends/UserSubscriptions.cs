using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Friends
{
    public class UserSubscriptions
    {
        public UserId User { get; set; }
        public int Version { get; set; }
        public UserSubscriptionList Subscriptions { get; set; }
    }
}
