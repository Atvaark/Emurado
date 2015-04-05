using System;
using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.EndpointDispatcher;
using HaloOnline.Server.Model.EndpointDispatcher;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class EndpointsDispatcherController : ApiController, IEndpointsDispatcherService
    {
        [HttpPost]
        public GetAuthorizationEndpointsResult GetAuthorizationEndpoints(
            [FromBody] GetAuthorizationEndpointsRequest request)
        {
            return new GetAuthorizationEndpointsResult
            {
                Result = new ServiceResult<List<CompactEndpointInfo>>
                {
                    Data = new List<CompactEndpointInfo>
                    {
                        new CompactEndpointInfo
                        {
                            Name = "",
                            Ip = "",
                            Port = 0,
                            Protocol = 0,
                            IsDefault = false
                        }
                    }
                }
            };
        }

        [HttpPost]
        public GetAuthorizationEndpointsAndDateResult GetAuthorizationEndpointsAndDate(
            [FromBody] GetAuthorizationEndpointsAndDateRequest request)
        {
            var port = 11705;
            var ip = "localhost";
            var result = new GetAuthorizationEndpointsAndDateResult
            {
                ServiceResult = new ServiceResult<AuthorizationEndpointsAndDate>
                {
                    ReturnCode = 0,
                    Data = new AuthorizationEndpointsAndDate
                    {
                        DateTime = DateTime.Now,
                        Endpoints =
                        {
                            new CompactEndpointInfo
                            {
                                Name = "AuthorizationService",
                                Ip = ip,
                                Port = port, // TODO: Use the secure port for the authorization service
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "EndpointsDispatcherService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "FriendsService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "GameStatisticsService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "HeartbeatService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "MessagingService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "PresenceService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "SessionControlService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "TitleResourceService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "UserStorageService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "ClanService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "ArbitraryStorageService",
                                Ip = ip,
                                Port = port,
                                Protocol = 4,
                                IsDefault = true
                            }
                        }
                    }
                }
            };
            return result;
        }
    }
}
