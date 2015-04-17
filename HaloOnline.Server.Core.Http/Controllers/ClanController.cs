using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Clan;
using HaloOnline.Server.Model.Clan;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    // TODO: Change hard coded return values to calls to the clan repository
    [Authorize]
    public class ClanController : ApiController, IClanService
    {
        private readonly IClanRepository _clanRepository;
        private readonly IClanMembershipRepository _clanMembershipRepository;
        private readonly IUserBaseDataRepository _userBaseDataRepository;

        // HACK: Clan version should be saved in the repository
        private static int _version;

        public ClanController(
            IClanRepository clanRepository, 
            IClanMembershipRepository clanMembershipRepository, 
            IUserBaseDataRepository userBaseDataRepository)
        {
            _clanRepository = clanRepository;
            _clanMembershipRepository = clanMembershipRepository;
            _userBaseDataRepository = userBaseDataRepository;
        }

        [HttpPost]
        public ClanCreateResult ClanCreate(ClanCreateRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);

            Clan newClan = new Clan
            {
                Name = request.Name,
                Tag = request.Tag,
                Description = request.Description
            };

            _clanRepository.CreateAsync(newClan).Wait();
            var leaderMembership = new ClanMembership
            {
                ClanId = newClan.ClanId,
                UserId = userId,
                Role = 1
            };
            _clanMembershipRepository.CreateAsync(leaderMembership).Wait();

            var leaderBaseData = _userBaseDataRepository.GetByUserIdAsync(userId).Result;

            return new ClanCreateResult
            {
                Result = new ServiceResult<UserBaseData>
                {
                    Data = leaderBaseData
                }
            };
        }

        [HttpPost]
        public ClanGetBaseDataResult ClanGetBaseData(ClanGetBaseDataRequest request)
        {
            var clanBaseData = (request.Clans.Select(c => c.Id)
                .Select(clanId => _clanRepository.FindByIdAsync(clanId).Result)
                .Where(clan => clan != null)
                .Select(clan => new ClanBaseDataVersioned
                {
                    Clan = new ClanId(clan.ClanId),
                    Version = _version++,
                    BaseData = new ClanBaseData
                    {
                        Name = clan.Name,
                        Description = clan.Description,
                        Tag = clan.Tag
                    }
                }));
            
            return new ClanGetBaseDataResult
            {
                Result = new ServiceResult<List<ClanBaseDataVersioned>>
                {
                    Data = clanBaseData.ToList()
                }
            };
        }
        
        [HttpPost]
        public ClanGetMembershipResult ClanGetMembership(ClanGetMembershipRequest request)
        {
            var clanMembershipDataVersioned = request.Clans
                .Select(c => _clanRepository.FindByIdAsync(c.Id).Result)
                .Where(c => c != null)
                .Select(GetClanMembershipDataVersioned);
            return new ClanGetMembershipResult
            {
                Result = new ServiceResult<List<ClanMembershipDataVersioned>>
                {
                    Data = clanMembershipDataVersioned.ToList()
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
            // TODO: Check if the current user has permission to kick members
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
            int userId;
            this.TryGetUserId(out userId);

            var clanMembership = _clanMembershipRepository.FindByUserId(userId).Result.FirstOrDefault();
            if (clanMembership != null)
            {
                _clanMembershipRepository.DeleteAsync(clanMembership).Wait();
            }

            var userBaseData = _userBaseDataRepository.GetByUserIdAsync(userId).Result;

            return new ClanLeaveResult
            {
                Result = new ServiceResult<UserBaseData>
                {
                    Data = userBaseData
                }
            };
        }

        [HttpPost]
        public ClanGetByNameResult ClanGetByName(ClanGetByNameRequest request)
        {
            var foundClans = _clanRepository.FindByNamePrefixAsync(request.NamePrefix)
                .Result
                .Select(c => new ClanId(c.ClanId));
            
            return new ClanGetByNameResult
            {
                Result = new ServiceResult<List<ClanId>>
                {
                    Data = foundClans.ToList()
                }
            };
        }


        private ClanMembershipDataVersioned GetClanMembershipDataVersioned(Clan clan)
        {
            var clanMembers = _clanMembershipRepository.FindByClanId(clan.ClanId)
                .Result
                .Select(m => new ClanMember
                {
                    Id = new UserId(m.UserId),
                    ClanRole = m.Role
                });

            return new ClanMembershipDataVersioned
            {
                Clan = new ClanId(clan.ClanId),
                Version = _version++,
                MembershipData = new ClanMembershipData
                {
                    Members = clanMembers.ToList()
                }
            };
        }
    }
}
