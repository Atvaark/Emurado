using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Friends;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class UserSubscriptionRepository : IUserSubscriptionRepository
    {
        private readonly IHaloDbContext _context;

        public UserSubscriptionRepository(IHaloDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(UserSubscription userSubscription)
        {
            _context.UserSubscriptions.Add(new Model.UserSubscription
            {
                SubscriberId = userSubscription.UserId,
                SubscribeeId = userSubscription.FriendUserId
            });
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task UpdateAsync(UserSubscription userSubscription)
        {
            var foundUserSubscription = _context.UserSubscriptions.Find(
                userSubscription.UserId,
                userSubscription.FriendUserId);
            if (foundUserSubscription == null) return Task.FromResult(0);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(UserSubscription userSubscription)
        {
            var foundUserSubscription = _context.UserSubscriptions.Find(
                userSubscription.UserId,
                userSubscription.FriendUserId);
            if (foundUserSubscription == null) return Task.FromResult(0);
            _context.UserSubscriptions.Remove(foundUserSubscription);
            return _context.SaveChangesAsync();

        }

        public Task<IEnumerable<UserSubscription>> FindByUserIdAsync(int userId)
        {
            var foundUserSubscriptions = _context.UserSubscriptions
                .Where(u => u.SubscriberId == userId).Select(u => new UserSubscription
                {
                    UserId = u.SubscriberId,
                    FriendUserId = u.SubscribeeId
                })
                .AsEnumerable();
            return Task.FromResult(foundUserSubscriptions);
        }

        public Task<IEnumerable<UserSubscription>> FindByFriendUserIdAsync(int friendUserId)
        {
            var foundUserSubscriptions = _context.UserSubscriptions
                .Where(u => u.SubscribeeId == friendUserId).Select(u => new UserSubscription
                {
                    UserId = u.SubscriberId,
                    FriendUserId = u.SubscribeeId
                })
                .AsEnumerable();
            return Task.FromResult(foundUserSubscriptions);
        }
    }
}
