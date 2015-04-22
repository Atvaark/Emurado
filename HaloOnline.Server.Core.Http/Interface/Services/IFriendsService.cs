using HaloOnline.Server.Core.Http.Model.Friends;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IFriendsService
    {
        SubscriptionAddResult SubscriptionAdd(SubscriptionAddRequest request);
        SubscriptionRemoveResult SubscriptionRemove(SubscriptionRemoveRequest request);
        GetSubscriptionsResult GetSubscriptions(GetSubscriptionsRequest request);
    }
}
