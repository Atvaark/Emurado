using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class PresenceController : ApiController, IPresenceService
    {
        [HttpPost]
        public PresenceDisconnectResult PresenceDisconnect(PresenceDisconnectRequest request)
        {
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
            return new PresenceConnectResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = new PartyStatus
                    {
                        Party = new PartyId
                        {
                            Id = "1"
                        },
                        SessionMembers = new List<SessionMember>
                        {
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 1
                                },
                                IsOwner = true
                            },
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 2
                                },
                                IsOwner = false
                            }
                        },
                        MatchmakeState = 0,
                        GameData = new byte[100]
                    }
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
                        SessionMembers = new List<SessionMember>
                        {
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 1
                                },
                                IsOwner = true
                            },
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 1
                                },
                                IsOwner = false
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
                            Id = "1"
                        },
                        SessionMembers = new List<SessionMember>
                        {
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 1
                                }
                            },
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 2
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
                        SessionMembers = new List<SessionMember>
                        {
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 1
                                }
                            },
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 2
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
            return new PartyGetStatusResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = new PartyStatus
                    {
                        Party = new PartyId
                        {
                            Id = "1"
                        },
                        SessionMembers = new List<SessionMember>
                        {
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 1
                                }
                            },
                            new SessionMember
                            {
                                User = new UserId
                                {
                                    Id = 2
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
            return new ReportOnlineStatsResult
            {
                Result = new ServiceResult<OnlineStats>
                {
                    Data = new OnlineStats
                    {
                        UsersMainMenu = 2,
                        UsersQueue = 0,
                        UsersIngame = 0,
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
                            Playlist = "A0937033-31C7-47BF-A739-9FCB8CF8E071",
                            PlayersNumber = 8
                        },
                        new PlaylistStat
                        {
                            Playlist = "edge_name",
                            PlayersNumber = 2
                        },

                    }
                }
            };
        }
    }
}
