using System.Collections.Generic;
using HaloOnline.Server.Model.SessionControl;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.SessionControl
{
    public class GetSessionChainResult
    {
        [JsonProperty("GetSessionChainResult")]
        public ServiceResult<List<SessionChain>> Result { get; set; }
    }
}
