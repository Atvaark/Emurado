using HaloOnline.Server.Model.EndpointDispatcher;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.EndpointDispatcher
{
    public class GetAuthorizationEndpointsAndDateResult
    {
        [JsonProperty(PropertyName = "GetAuthorizationEndpointsAndDateResult")]
        public ServiceResult<AuthorizationEndpointsAndDate> ServiceResult { get; set; }
    }
}
