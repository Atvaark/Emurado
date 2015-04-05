using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Heartbeat;
using HaloOnline.Server.Model.Heartbeat;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class HeartbeatController : ApiController, IHeartbeatService
    {
        [HttpPost]
        public GetServicesStatusResult GetServicesStatus(GetServicesStatusRequest request)
        {
            return new GetServicesStatusResult
            {
                Result = new ServiceResult<List<HeartbeatStatusContract>>
                {
                    ReturnCode = 0,
                    Data = new List<HeartbeatStatusContract>
                    {
                        new HeartbeatStatusContract
                        {
                            Name = "UserService",
                            Quality = 0,
                            Status = 0
                        },
                        new HeartbeatStatusContract
                        {
                            Name = "MessagingService",
                            Quality = 0,
                            Status = 0
                        },
                        new HeartbeatStatusContract
                        {
                            Name = "SessionControlService",
                            Quality = 0,
                            Status = 0
                        },
                        new HeartbeatStatusContract
                        {
                            Name = "PresenceService",
                            Quality = 0,
                            Status = 0
                        },
                        new HeartbeatStatusContract
                        {
                            Name = "GameStatisticsService",
                            Quality = 0,
                            Status = 0
                        }
                    }
                }
            };
        }
    }
}
