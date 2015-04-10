using System;
using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Common;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.EndpointDispatcher;
using HaloOnline.Server.Model.EndpointDispatcher;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class EndpointsDispatcherController : ApiController, IEndpointsDispatcherService
    {
        private readonly IServerOptions _serverOptions;

        public EndpointsDispatcherController(IServerOptions serverOptions)
        {
            _serverOptions = serverOptions;
        }

        [HttpPost]
        public GetAuthorizationEndpointsResult GetAuthorizationEndpoints(
            [FromBody] GetAuthorizationEndpointsRequest request)
        {
            return new GetAuthorizationEndpointsResult
            {
                Result = new ServiceResult<List<CompactEndpointInfo>>
                {
                    Data = new List<CompactEndpointInfo>()
                }
            };
        }

        [HttpPost]
        public GetAuthorizationEndpointsAndDateResult GetAuthorizationEndpointsAndDate(
            GetAuthorizationEndpointsAndDateRequest request)
        {
            var endpointHostname = _serverOptions.EndpointHostname;
            var endpointPort = _serverOptions.EndpointPort;
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
                                Ip = endpointHostname,
                                Port = endpointPort, // TODO: Use the secure port for the authorization service
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "EndpointsDispatcherService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "FriendsService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "GameStatisticsService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "HeartbeatService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "MessagingService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "PresenceService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "SessionControlService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "TitleResourceService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "UserStorageService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "ClanService",
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 4,
                                IsDefault = true
                            },
                            new CompactEndpointInfo
                            {
                                Name = "ArbitraryStorageService",
                                Ip = endpointHostname,
                                Port = endpointPort,
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
