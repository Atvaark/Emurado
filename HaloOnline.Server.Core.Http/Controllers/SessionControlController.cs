using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.SessionControl;
using HaloOnline.Server.Model.SessionControl;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class SessionControlController : ApiController, ISessionControlService
    {
        [HttpPost]
        public ClientGetStatusResult ClientGetStatus(ClientGetStatusRequest request)
        {
            return new ClientGetStatusResult
            {
                Result = new ServiceResult<ClientStatus>
                {
                    Data = new ClientStatus
                    {
                        Game = new Game
                        {
                            Id = "GameId"
                        },
                        DedicatedServer = new DedicatedServer
                        {
                            ServerId = "ServerId",
                            ServerAddress = "127.0.0.1",
                            Port = 12345
                        }
                    }
                }
            };
        }

        [HttpPost]
        public GetSessionBasicDataResult GetSessionBasicData(GetSessionBasicDataRequest request)
        {
            return new GetSessionBasicDataResult
            {
                Result = new ServiceResult<List<SessionBasicData>>
                {
                    ReturnCode = 0,
                    Data = new List<SessionBasicData>
                    {
                        new SessionBasicData
                        {
                            SessionId = "SessionId",
                            MapId = "MapId",
                            ModeId = "ModeId",
                            Finished = 0,
                            Started = 0
                        }
                    }
                }
            };
        }

        [HttpPost]
        public GetSessionChainResult GetSessionChain(GetSessionChainRequest request)
        {
            return new GetSessionChainResult
            {
                Result = new ServiceResult<List<SessionChain>>
                {
                    Data = new List<SessionChain>
                    {
                        new SessionChain
                        {
                            User = "User",
                            Sessions = new List<Game>
                            {
                                new Game
                                {
                                    Id = "GameId"
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
