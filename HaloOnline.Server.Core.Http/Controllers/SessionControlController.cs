using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.SessionControl;
using HaloOnline.Server.Model.SessionControl;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class SessionControlController : ApiController, ISessionControlService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionControlController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        
        [HttpPost]
        public ClientGetStatusResult ClientGetStatus(ClientGetStatusRequest request)
        {
            return new ClientGetStatusResult
            {
                Result = new ServiceResult<ClientStatus>
                {
                    Data = new ClientStatus
                    {
                        Game = new SessionId
                        {
                            Id = "7A0E225D-B2F0-4AD3-BFEA-21404AA29DC3"
                        },
                        DedicatedServer = new DedicatedServer
                        {
                            ServerId = "F461B3D8-C3BC-42B9-AE12-E8A9EBD610CE",
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
            IEnumerable<SessionBasicData> sessionBasicData = request.Sessions
                .Select(session => _sessionRepository.FindBySessionIdAsync(session.Id).Result)
                .Where(basicData => basicData != null)
                .Select(session => new SessionBasicData
                {
                    SessionId = session.Id,
                    MapId = session.MapId,
                    ModeId = session.ModeId,
                    Started = session.Started,
                    Finished = session.Finished
                });

            return new GetSessionBasicDataResult
            {
                Result = new ServiceResult<List<SessionBasicData>>
                {
                    ReturnCode = 0,
                    Data = sessionBasicData.ToList()
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
                            User = "CEFDB7DA-95A1-4F66-A1D5-529A9081A676",
                            Sessions = new List<SessionId>
                            {
                                new SessionId
                                {
                                    Id = "D99A01C5-E9B5-467F-8FBE-E3168F3DE4EC"
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
