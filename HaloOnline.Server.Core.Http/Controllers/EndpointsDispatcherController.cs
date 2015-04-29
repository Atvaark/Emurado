using System;
using System.Collections.Generic;
using System.Linq;
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
            var endpoints = request.Versions.Select(s =>
                new CompactEndpointInfo
                {
                    Ip = _serverOptions.EndpointHostname,
                    IsDefault = true,
                    Name = s.ServiceName,
                    Port = _serverOptions.EndpointPort,
                    Protocol = 4
                }).ToList();

            var result = new GetAuthorizationEndpointsAndDateResult
            {
                ServiceResult = new ServiceResult<AuthorizationEndpointsAndDate>
                {
                    ReturnCode = 0,
                    Data = new AuthorizationEndpointsAndDate
                    {
                        DateTime = DateTime.Now,
                        Endpoints = endpoints
                    }
                }
            };
            return result;
        }
    }
}
