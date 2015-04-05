using System.Collections.Generic;
using HaloOnline.Server.Model.Heartbeat;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Heartbeat
{
    public class GetServicesStatusResult
    {
        [JsonProperty("GetServicesStatusResult")]
        public ServiceResult<List<HeartbeatStatusContract>> Result { get; set; }
    }
}
