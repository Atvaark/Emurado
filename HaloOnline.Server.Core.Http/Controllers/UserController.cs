using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.User;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class UserController : ApiController, IUserService
    {
        private readonly IUserBaseDataRepository _userBaseDataRepository;
        private readonly IHaloUserManager _userManager;

        public UserController(IHaloUserManager userManager, IUserBaseDataRepository userBaseDataRepository)
        {
            _userManager = userManager;
            _userBaseDataRepository = userBaseDataRepository;
        }

        [HttpPost]
        public SignOutResult SignOut(SignOutRequest request)
        {
            return new SignOutResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetUsersByNicknameResult GetUsersByNickname(GetUsersByNicknameRequest request)
        {
            var foundUsers = _userBaseDataRepository.FindUserIdByNicknameAsync(request.NicknamePrefix);

            return new GetUsersByNicknameResult
            {
                Result = new ServiceResult<List<UserId>>
                {
                    Data = foundUsers.Result.ToList()
                }
            };
        }

        [HttpPost]
        public NicknameChangeResult NicknameChange(NicknameChangeRequest request)
        {
            return new NicknameChangeResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetUsersBaseDataResult GetUsersBaseData(GetUsersBaseDataRequest request)
        {
            return new GetUsersBaseDataResult
            {
                Result = new ServiceResult<List<UserBaseData>>
                {
                    Data = request.Users.Select(u => _userBaseDataRepository.GetByUserIdAsync(u.Id).Result).ToList()
                }
            };
        }

        [HttpPost]
        public GetUsersPrimaryStatesResult GetUsersPrimaryStates(GetUsersPrimaryStatesRequest request)
        {
            return new GetUsersPrimaryStatesResult
            {
                Result = new ServiceResult<List<UserPrimaryStates>>
                {
                    Data = new List<UserPrimaryStates>
                    {
                        new UserPrimaryStates
                        {
                            User = new UserId
                            {
                                Id = 1
                            },
                            Xp = 500,
                            Kills = 2,
                            Deaths = 3,
                            Assists = 4,
                            Suicides = 5,
                            TotalMatches = 6,
                            Victories = 7,
                            Defeats = 8,
                            TotalWp = 9,
                            TotalTimePlayed = 10,
                            TotalTimeOnline = 11
                        }
                    }
                }
            };
        }

        [HttpPost]
        public GetUserStatesResult GetUserStates(GetUserStatesRequest request)
        {
            return new GetUserStatesResult
            {
                Result = new ServiceResult<UserStatesAndTimestamp>
                {
                    Data = new UserStatesAndTimestamp
                    {
                        UserStateList = new List<UserState>
                        {
                            new UserState // Level progress
                            {
                                OwnType = 0,
                                Value = 20, // TODO: Increasing this will make a broken research panel pop up.
                                StateName = "",
                                StateType = 1
                            },
                            new UserState // Credits
                            {
                                OwnType = 0,
                                Value = 999999,
                                StateName = "",
                                StateType = 2
                            },
                            new UserState // Gold
                            {
                                OwnType = 0,
                                Value = 999999,
                                StateName = "",
                                StateType = 3
                            },
                            new UserState // Level
                            {
                                OwnType = 0,
                                Value = 2,
                                StateName = "",
                                StateType = 9
                            },
                            new UserState // Account rename tokens
                            {
                                OwnType = 0,
                                Value = 0,
                                StateName = "account_rename_token",
                                StateType = 12
                            },
                            new UserState // Class select tokens
                            {
                                OwnType = 0,
                                Value = 2,
                                StateName = "class_select_token",
                                StateType = 12
                            },
                            new UserState 
                            {
                                OwnType = 0,
                                Value = 0,
                                StateName = "armor_loadout_0",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 2,
                                Value = 1,
                                StateName = "armor_loadout_1",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 1,
                                Value = 0,
                                StateName = "armor_loadout_2",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 2,
                                Value = 0,
                                StateName = "armor_loadout_3",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 0,
                                Value = 0,
                                StateName = "armor_loadout_4",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 0,
                                Value = 0,
                                StateName = "weapon_loadout_0",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 0,
                                Value = 0,
                                StateName = "weapon_loadout_1",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 0,
                                Value = 0,
                                StateName = "weapon_loadout_2",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 0,
                                Value = 0,
                                StateName = "weapon_loadout_3",
                                StateType = 0
                            },
                            new UserState
                            {
                                OwnType = 0,
                                Value = 0,
                                StateName = "weapon_loadout_4",
                                StateType = 0
                            }
                        },
                        TimeStamp = DateTime.Now,
                        User = new UserId
                        {
                            Id = 1
                        },
                        Nickname = "Nickname"
                    }
                }
            };
        }

        [HttpPost]
        public GetTransactionHistoryResult GetTransactionHistory(GetTransactionHistoryRequest request)
        {
            return new GetTransactionHistoryResult
            {
                Result = new ServiceResult<UserTransactionHistory>
                {
                    Data = new UserTransactionHistory
                    {
                        TotalResults = 1,
                        Transactions = new List<UserTransaction>
                        {
                            new UserTransaction
                            {
                                TransactionItems = new List<UserTransactionItem>
                                {
                                    new UserTransactionItem
                                    {
                                        StateName = "StateName",
                                        StateType = 0,
                                        OwnType = 0,
                                        OperationType = 0,
                                        InitialValue = 0,
                                        ResultingValue = 0,
                                        DeltaValue = 0,
                                        DescId = 0
                                    }
                                },
                                SessionId = "SessionId",
                                ReferenceId = "ReferenceId",
                                OfferId = "OfferId",
                                Timestamp = DateTime.Now,
                                OperationType = 0,
                                ExtendedInfoItems = new List<ExtendedInfoItem>
                                {
                                    new ExtendedInfoItem
                                    {
                                        Key = "Key",
                                        Value = "Value"
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public ApplyExternalOfferResult ApplyExternalOffer(ApplyExternalOfferRequest request)
        {
            switch (request.ExternalOfferId)
            {
                case "Gold100":
                    break;
                default:
                    break;
            }
            // TODO: Analyze what the return message should contain.

            return new ApplyExternalOfferResult
            {
                Result = new ServiceResult<string>
                {
                    Data = ""
                }
            };
        }

        [HttpPost]
        public ApplyOfferAndGetTransactionHistoryResult ApplyOfferAndGetTransactionHistory(
            ApplyOfferAndGetTransactionHistoryRequest request)
        {
            return new ApplyOfferAndGetTransactionHistoryResult
            {
                Result = new ServiceResult<UserTransactionHistory>
                {
                    Data = new UserTransactionHistory
                    {
                        TotalResults = 1,
                        Transactions =
                        {
                            new UserTransaction
                            {
                                TransactionItems = new List<UserTransactionItem>
                                {
                                    new UserTransactionItem
                                    {
                                        StateName = "StateName",
                                        StateType = 0,
                                        OwnType = 0,
                                        OperationType = 0,
                                        InitialValue = 0,
                                        ResultingValue = 0,
                                        DeltaValue = 0,
                                        DescId = 0
                                    }
                                },
                                SessionId = "SessionId",
                                ReferenceId = "ReferenceId",
                                OfferId = "OfferId",
                                Timestamp = DateTime.Now,
                                OperationType = 0,
                                ExtendedInfoItems = new List<ExtendedInfoItem>
                                {
                                    new ExtendedInfoItem
                                    {
                                        Key = "Key",
                                        Value = "Value"
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public ApplyOfferListAndGetTransactionHistoryResult ApplyOfferListAndGetTransactionHistory(
            ApplyOfferListAndGetTransactionHistoryRequest request)
        {
            return new ApplyOfferListAndGetTransactionHistoryResult
            {
                Result = new ServiceResult<UserTransactionHistory>
                {
                    Data = new UserTransactionHistory
                    {
                        TotalResults = 1,
                        Transactions =
                        {
                            new UserTransaction
                            {
                                TransactionItems = new List<UserTransactionItem>
                                {
                                    new UserTransactionItem
                                    {
                                        StateName = "StateName",
                                        StateType = 0,
                                        OwnType = 0,
                                        OperationType = 0,
                                        InitialValue = 0,
                                        ResultingValue = 0,
                                        DeltaValue = 0,
                                        DescId = 0
                                    }
                                },
                                SessionId = "SessionId",
                                ReferenceId = "ReferenceId",
                                OfferId = "OfferId",
                                Timestamp = DateTime.Now,
                                OperationType = 0,
                                ExtendedInfoItems = new List<ExtendedInfoItem>
                                {
                                    new ExtendedInfoItem
                                    {
                                        Key = "Key",
                                        Value = "Value"
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public ApplyOfferResult ApplyOffer(ApplyOfferRequest request)
        {
            return new ApplyOfferResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public ApplyOfferListResult ApplyOfferList(ApplyOfferListRequest request)
        {
            return new ApplyOfferListResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetItemOffersResult GetItemOffers(GetItemOffersRequest request)
        {
            return new GetItemOffersResult
            {
                Result = new ServiceResult<List<ItemOffers>>
                {
                    Data = new List<ItemOffers>
                    {
                        new ItemOffers
                        {
                            ItemId = "0",
                            Requirements = new List<string>
                            {
                                "Requirement"
                            },
                            Unlocks = new List<string>
                            {
                                "Unlock"
                            },
                            BundleItems = new List<BundleItem>
                            {
                                new BundleItem
                                {
                                    ItemId = "",
                                    Duration = 0
                                }
                            },
                            UnlockedLevel = 0,
                            OfferLine = new List<OfferLine>
                            {
                                new OfferLine
                                {
                                    Duration = 0,
                                    Offers = new List<Offer>
                                    {
                                        new Offer
                                        {
                                            OfferId = "",
                                            Currency = "",
                                            Price = 2,
                                            ExpireAt = 0,
                                            Sale = new Sale
                                            {
                                                Price = 1,
                                                ExpireAt = 0
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public GetShopResult GetShop(GetShopRequest request)
        {
            return new GetShopResult
            {
                Result = new ServiceResult<List<Shop>>
                {
                    ReturnCode = 0,
                    Data = new List<Shop>
                    {
                        new Shop
                        {
                            Name = "shop",
                            Type = "weapons",
                            Race = 0,
                            Sections = new List<ShopSection>
                            {
                                new ShopSection
                                {
                                    Name = ShopSectionTypes.Loadouts,
                                    Shelves = new List<ShopSectionShelve>
                                    {
                                        new ShopSectionShelve
                                        {
                                            Name = ShopShelfTypes.WeaponLoadouts,
                                            IsHot = true,
                                            IsSale = true,
                                            Items = new List<string>
                                            {
                                                ItemNames.AssaultRifleCat,
                                                ItemNames.BattleRifleCat
                                            }
                                        }
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
