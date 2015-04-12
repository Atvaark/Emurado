using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Friends;
using HaloOnline.Server.Model.Friends;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [Authorize]
    public class FriendsController : ApiController, IFriendsService
    {
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        // HACK: Version should be stored in the repository. Increasing it is required by the client.
        private static int _version;

        public FriendsController(IUserSubscriptionRepository userSubscriptionRepository)
        {
            _userSubscriptionRepository = userSubscriptionRepository;
        }
        
        [HttpPost]
        public SubscriptionAddResult SubscriptionAdd(SubscriptionAddRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);
            _userSubscriptionRepository.CreateAsync(new UserSubscription
            {
                UserId = userId,
                FriendUserId = request.UserId.Id
            }).Wait();

            var subscriptions = GetUserSubscriptions(new[] { new UserId(userId) });

            return new SubscriptionAddResult
            {
                Result = new ServiceResult<List<UserSubscriptions>>
                {
                    Data = subscriptions.ToList()
                }
            };
        }

        [HttpPost]
        public SubscriptionRemoveResult SubscriptionRemove(SubscriptionRemoveRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);

            _userSubscriptionRepository.DeleteAsync(new UserSubscription
            {
                UserId = userId,
                FriendUserId = request.UserId.Id
            }).Wait();

            var subscriptions = GetUserSubscriptions(new[] { new UserId(userId) });

            return new SubscriptionRemoveResult
            {
                Result = new ServiceResult<List<UserSubscriptions>>
                {
                    Data = subscriptions.ToList()
                }
            };
        }

        [HttpPost]
        public GetSubscriptionsResult GetSubscriptions(GetSubscriptionsRequest request)
        {
            // TODO: Handle user subscription version
            var subscriptions = GetUserSubscriptions(request.Users.Select(u => u.User));
            return new GetSubscriptionsResult
            {
                Result = new ServiceResult<List<UserSubscriptions>>
                {
                    Data = subscriptions.ToList()
                }
            };
        }

        private IEnumerable<UserSubscriptions> GetUserSubscriptions(IEnumerable<UserId> users)
        {
            return users.Select(user => new UserSubscriptions
            {
                User = user,
                Version = _version++, // HACK: Subscription version should not be static and should be set kept per user
                Subscriptions = new UserSubscriptionList
                {
                    UserList = _userSubscriptionRepository
                        .FindByUserIdAsync(user.Id)
                        .Result.Select(u => new UserId(u.FriendUserId))
                        .ToList()
                }
            });
        }
    }
}
