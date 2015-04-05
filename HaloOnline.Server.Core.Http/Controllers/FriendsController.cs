using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Friends;
using HaloOnline.Server.Model.Friends;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class FriendsController : ApiController, IFriendsService
    {
        [HttpPost]
        public SubscriptionAddResult SubscriptionAdd(SubscriptionAddRequest request)
        {
            return new SubscriptionAddResult
            {
                Result = new ServiceResult<List<UserSubscriptions>>
                {
                    Data = new List<UserSubscriptions>
                    {
                        new UserSubscriptions
                        {
                            User = new UserId
                            {
                                Id = 1
                            },
                            Version = 0,
                            Subscriptions = new UserSubscriptionList
                            {
                                UserList = new List<UserId>
                                {
                                    new UserId
                                    {
                                        Id = 2
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public SubscriptionRemoveResult SubscriptionRemove(SubscriptionRemoveRequest request)
        {
            return new SubscriptionRemoveResult
            {
                Result = new ServiceResult<List<UserSubscriptions>>
                {
                    Data = new List<UserSubscriptions>
                    {
                        new UserSubscriptions
                        {
                            User = new UserId
                            {
                                Id = 1
                            },
                            Version = 0,
                            Subscriptions = new UserSubscriptionList
                            {
                                UserList = new List<UserId>
                                {
                                    new UserId
                                    {
                                        Id = 2
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public GetSubscriptionsResult GetSubscriptions(GetSubscriptionsRequest request)
        {
            return new GetSubscriptionsResult
            {
                Result = new ServiceResult<List<UserSubscriptions>>
                {
                    Data = new List<UserSubscriptions>
                    {
                        new UserSubscriptions
                        {
                            User = new UserId
                            {
                                Id = 1
                            },
                            Version = 0,
                            Subscriptions = new UserSubscriptionList
                            {
                                UserList = new List<UserId>
                                {
                                    new UserId
                                    {
                                        Id = 2
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
