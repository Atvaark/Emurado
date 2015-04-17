using System.Collections.Generic;
using HaloOnline.Server.Model.EndpointDispatcher;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.EndpointDispatcher
{
    public class GetAuthorizationEndpointsAndDateRequest
    {
        public GetAuthorizationEndpointsAndDateRequest()
        {
            Versions = new List<EndpointInfoVersioned>();
        }

        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        [JsonProperty(PropertyName = "versions")]
        public List<EndpointInfoVersioned> Versions { get; set; }
    }
}
