using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [Authorize]
    public class PresenceController : ApiController, IPresenceService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IPartyRepository _partyRepository;
        private readonly IPartyMemberRepository _partyMemberRepository;
        private readonly IUserPresenceRepository _userPresenceRepository;

        public PresenceController(
            ISessionRepository sessionRepository,
            IPartyRepository partyRepository,
            IPartyMemberRepository partyMemberRepository,
            IUserPresenceRepository userPresenceRepository)
        {
            _sessionRepository = sessionRepository;
            _partyRepository = partyRepository;
            _partyMemberRepository = partyMemberRepository;
            _userPresenceRepository = userPresenceRepository;
        }


        [HttpPost]
        public PresenceDisconnectResult PresenceDisconnect(PresenceDisconnectRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);

            return new PresenceDisconnectResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public PresenceConnectResult PresenceConnect(PresenceConnectRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);
            
            var party = new Party
            {
                Id = Guid.NewGuid().ToString(),
                MatchmakeState = 0,
                GameData = new byte[100]
            };
            _partyRepository.CreateAsync(party).Wait();

            var partyOwner = new PartyMember
            {
                UserId = userId,
                PartyId = party.Id,
                IsOwner = true
            };
            _partyMemberRepository.CreateAsync(partyOwner).Wait();

            var partyStatus = GetPartyStatus(party, new[] { partyOwner });

            return new PresenceConnectResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = partyStatus
                }
            };
        }


        [HttpPost]
        public PresenceGetUsersPresenceResult PresenceGetUsersPresence(PresenceGetUsersPresenceRequest request)
        {
            return new PresenceGetUsersPresenceResult
            {
                Result = new ServiceResult<List<UserPresence>>
                {
                    Data = new List<UserPresence>
                    {
                        new UserPresence
                        {
                            User = new UserId
                            {
                                Id = 1
                            },
                            Data = new UserPresenceData
                            {
                                State = 1,
                                IsInvitable = true
                            }
                        },
                        new UserPresence
                        {
                            User = new UserId
                            {
                                Id = 2
                            },
                            Data = new UserPresenceData
                            {
                                State = 1,
                                IsInvitable = true
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public PartyJoinResult PartyJoin(PartyJoinRequest request)
        {
            return new PartyJoinResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = new PartyStatus
                    {
                        Party = new PartyId
                        {
                            Id = "1"
                        },
                        SessionMembers = new List<PartyMemberDto>
                        {
                            new PartyMemberDto
                            {
                                User = new UserId
                                {
                                    Id = 1
                                },
                                IsOwner = true
                            }
                        },
                        MatchmakeState = 0,
                        GameData = new byte[100]
                    }
                }
            };
        }

        [HttpPost]
        public PartyLeaveResult PartyLeave(PartyLeaveRequest request)
        {
            return new PartyLeaveResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = new PartyStatus
                    {
                        Party = new PartyId
                        {
                            Id = ""
                        },
                        SessionMembers = new List<PartyMemberDto>
                        {
                        },
                        MatchmakeState = 0,
                        GameData = new byte[0]
                    }
                }
            };
        }

        [HttpPost]
        public PartyKickResult PartyKick(PartyKickRequest request)
        {
            return new PartyKickResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = new PartyStatus
                    {
                        Party = new PartyId
                        {
                            Id = "1"
                        },
                        SessionMembers = new List<PartyMemberDto>
                        {
                            new PartyMemberDto
                            {
                                User = new UserId
                                {
                                    Id = 1
                                }
                            }
                        },
                        MatchmakeState = 0,
                        GameData = new byte[100]
                    }
                }
            };
        }

        [HttpPost]
        public PartySetGameDataResult PartySetGameData(PartySetGameDataRequest request)
        {
            PartyMember partyMember;
            if (TryGetUserPartyMember(out partyMember) && partyMember.IsOwner)
            {
                var party = _partyRepository.FindByPartyIdAsync(partyMember.PartyId).Result;
                if (party != null)
                {
                    party.GameData = request.GameData;
                    _partyRepository.UpdateAsync(party).Wait();
                }
            }

            return new PartySetGameDataResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public PartyGetStatusResult PartyGetStatus(PartyGetStatusRequest request)
        {
            PartyMember partyMember;
            Party party;
            IEnumerable<PartyMember> partyMembers;
            if (TryGetUserPartyMember(out partyMember) &&
                TryGetParty(partyMember.PartyId, out party))
            {
                partyMembers = _partyMemberRepository.FindByPartyId(party.Id).Result;
            }
            else
            {
                party = new Party
                {
                    Id = "1",
                    MatchmakeState = 0,
                    GameData = new byte[0]
                };
                partyMembers = new PartyMember[0];
            }
            var partyStatus = GetPartyStatus(party, partyMembers);
            
            return new PartyGetStatusResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = partyStatus
                }
            };
        }

        [HttpPost]
        public CustomGameStartResult CustomGameStart(CustomGameStartRequest request)
        {
            return new CustomGameStartResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public CustomGameStopResult CustomGameStop(CustomGameStopRequest request)
        {
            return new CustomGameStopResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public MatchmakeStartResult MatchmakeStart(MatchmakeStartRequest request)
        {
            // TODO: Set requested playlist for party and change the state to InQueue

            return new MatchmakeStartResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public MatchmakeStopResult MatchmakeStop(MatchmakeStopRequest request)
        {
            // TODO: Reset state to none or forming
            return new MatchmakeStopResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public MatchmakeGetStatusResult MatchmakeGetStatus(MatchmakeGetStatusRequest request)
        {
            return new MatchmakeGetStatusResult
            {
                Result = new ServiceResult<MatchmakeStatus>
                {
                    Data = new MatchmakeStatus
                    {
                        Id = new MatchmakeId
                        {
                            Id = "1"
                        },
                        Members = new List<MatchmakeMember>
                        {
                            new MatchmakeMember
                            {
                                User = new UserId
                                {
                                    Id = 1
                                },
                                Party = new PartyId
                                {
                                    Id = "1"
                                }
                            },
                            new MatchmakeMember
                            {
                                User = new UserId
                                {
                                    Id = 2
                                },
                                Party = new PartyId
                                {
                                    Id = "1"
                                }
                            }
                        },
                        MatchmakeTimer = 0
                    }
                }
            };
        }

        [HttpPost]
        public ReportOnlineStatsResult ReportOnlineStats(ReportOnlineStatsRequest request)
        {
            var userPresenceStats = _userPresenceRepository.GetUserPresenceStats().Result;
            
            return new ReportOnlineStatsResult
            {
                Result = new ServiceResult<OnlineStats>
                {
                    Data = new OnlineStats
                    {
                        UsersMainMenu = userPresenceStats.UsersOnline,
                        UsersQueue = 0,
                        UsersIngame = userPresenceStats.UsersIngame,
                        UsersRematch = 0,
                        MatchmakeSessions = 0
                    }
                }
            };
        }

        [HttpPost]
        public GetPlaylistStatResult GetPlaylistStat(GetPlaylistStatRequest request)
        {
            return new GetPlaylistStatResult
            {
                Result = new ServiceResult<List<PlaylistStat>>
                {
                    Data = new List<PlaylistStat>
                    {
                        new PlaylistStat
                        {
                            Playlist = "playlist1",
                            PlayersNumber = 1
                        },
                        new PlaylistStat
                        {
                            Playlist = "playlist2",
                            PlayersNumber = 2
                        },
                        new PlaylistStat
                        {
                            Playlist = "playlist3",
                            PlayersNumber = 3
                        },
                    }
                }
            };
        }

        private bool TryGetUserPartyMember(out PartyMember partyMember)
        {
            int userId;
            this.TryGetUserId(out userId);
            partyMember = _partyMemberRepository.FindByUserId(userId).Result;
            return partyMember != null;
        }

        private bool TryGetParty(string partyId, out Party party)
        {
            party = _partyRepository.FindByPartyIdAsync(partyId).Result;
            return party != null;
        }

        private PartyStatus GetPartyStatus(Party party, IEnumerable<PartyMember> partyMembers)
        {
            return new PartyStatus
            {
                Party = new PartyId(party.Id),
                MatchmakeState = party.MatchmakeState,
                GameData = party.GameData,
                SessionMembers = partyMembers.Select(p =>
                    new PartyMemberDto
                    {
                        User = new UserId(p.UserId),
                        IsOwner = p.IsOwner
                    }).ToList()
            };
        }
    }
}
