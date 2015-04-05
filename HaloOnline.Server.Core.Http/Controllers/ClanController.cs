using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Clan;
using HaloOnline.Server.Model.Clan;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class ClanController : ApiController, IClanService
    {
        [HttpPost]
        public ClanCreateResult ClanCreate(ClanCreateRequest request)
        {
            return new ClanCreateResult
            {
                Result = new ServiceResult<UserBaseData>
                {
                    Data = new UserBaseData
                    {
                        User = new UserId
                        {
                            Id = 1
                        },
                        Nickname = "Nickname",
                        BattleTag = "BattleTag",
                        Clan = new ClanId
                        {
                            Id = 1
                        },
                        ClanTag = "ClanTag",
                        Level = 2
                    }
                }
            };
        }

        [HttpPost]
        public ClanGetBaseDataResult ClanGetBaseData(ClanGetBaseDataRequest request)
        {
            return new ClanGetBaseDataResult
            {
                Result = new ServiceResult<List<ClanBaseDataVersioned>>
                {
                    Data = new List<ClanBaseDataVersioned>
                    {
                        new ClanBaseDataVersioned
                        {
                            Clan = new ClanId
                            {
                                Id = 1
                            },
                            Version = 0,
                            BaseData = new ClanBaseData
                            {
                                Name = "ClanName",
                                Description = "Description",
                                Tag = "ClanTag"
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public ClanGetMembershipResult ClanGetMembership(ClanGetMembershipRequest request)
        {
            return new ClanGetMembershipResult
            {
                Result = new ServiceResult<List<ClanMembershipDataVersioned>>
                {
                    Data = new List<ClanMembershipDataVersioned>
                    {
                        new ClanMembershipDataVersioned
                        {
                            Clan = new ClanId
                            {
                                Id = 1
                            },
                            Version = 0,
                            MembershipData = new ClanMembershipData
                            {
                                Members = new List<ClanMember>
                                {
                                    new ClanMember
                                    {
                                        Id = new UserId
                                        {
                                            Id = 1
                                        },
                                        ClanRole = 1
                                    },
                                    new ClanMember
                                    {
                                        Id = new UserId
                                        {
                                            Id = 2
                                        },
                                        ClanRole = 0
                                    },
                                }
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public ClanJoinResult ClanJoin(ClanJoinRequest request)
        {
            return new ClanJoinResult
            {
                Result = new ServiceResult<UserBaseData>
                {
                    Data = new UserBaseData
                    {
                        User = new UserId
                        {
                            Id = 1
                        },
                        Nickname = "Nickame",
                        BattleTag = "BattleTag",
                        Clan = new ClanId
                        {
                            Id = 1
                        },
                        ClanTag = "ClanTag",
                        Level = 2
                    }
                }
            };
        }

        [HttpPost]
        public ClanKickResult ClanKick(ClanKickRequest request)
        {
            return new ClanKickResult
            {
                Result = new ServiceResult<ClanMembershipDataVersioned>
                {
                    Data = new ClanMembershipDataVersioned
                    {
                        Clan = new ClanId
                        {
                            Id = 1
                        },
                        Version = 0,
                        MembershipData = new ClanMembershipData
                        {
                            Members = new List<ClanMember>
                            {
                                new ClanMember
                                {
                                    Id = new UserId
                                    {
                                        Id = 1
                                    },
                                    ClanRole = 1
                                },
                                new ClanMember
                                {
                                    Id = new UserId
                                    {
                                        Id = 2
                                    },
                                    ClanRole = 0
                                }
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public ClanLeaveResult ClanLeave(ClanLeaveRequest request)
        {
            return new ClanLeaveResult
            {
                Result = new ServiceResult<UserBaseData>
                {
                    Data = new UserBaseData
                    {
                        User = new UserId
                        {
                            Id = 1
                        },
                        Nickname = "Nickname",
                        BattleTag = "BattleTag",
                        Clan = new ClanId
                        {
                            Id = 1
                        },
                        ClanTag = "ClanTag",
                        Level = 2
                    }
                }
            };
        }

        [HttpPost]
        public ClanGetByNameResult ClanGetByName(ClanGetByNameRequest request)
        {
            return new ClanGetByNameResult
            {
                Result = new ServiceResult<List<ClanId>>
                {
                    Data = new List<ClanId>
                    {
                        new ClanId
                        {
                            Id = 1
                        }
                    }
                }
            };
        }
    }
}
