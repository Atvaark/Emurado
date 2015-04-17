using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.SessionControl
{
    public class GetSessionChainRequest
    {
        // TODO: Validate type of Users 
        public List<UserId> Users { get; set; }

        // TODO: Validate type of Depth 
        [JsonProperty("depth")]
        public List<object> Depth { get; set; }
    }
}
