using System.Collections.Generic;
using HaloOnline.Server.Model.EndpointDispatcher;

namespace HaloOnline.Server.Core.Http.Model.EndpointDispatcher
{
    public class GetAuthorizationEndpointsResult
    {
        public ServiceResult<List<CompactEndpointInfo>> Result { get; set; }
    }
}
