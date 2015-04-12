using System.Collections.Generic;
using System.Threading.Tasks;
using HaloOnline.Server.Model.Friends;

namespace HaloOnline.Server.Common.Repositories
{
    public interface IUserSubscriptionRepository
    {
        Task CreateAsync(UserSubscription userSubscription);
        Task UpdateAsync(UserSubscription userSubscription);
        Task DeleteAsync(UserSubscription userSubscription);
        Task<IEnumerable<UserSubscription>> FindByUserIdAsync(int userId);
        Task<IEnumerable<UserSubscription>> FindByFriendUserIdAsync(int friendUserId);
    }
}