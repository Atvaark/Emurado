using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Heartbeat
{
    public class GetServicesStatusRequest
    {
        [JsonProperty(PropertyName = "serviceNames ")]
        public List<string> ServiceNames { get; set; }
    }
}
