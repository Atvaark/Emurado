using System.Collections.Generic;
using HaloOnline.Server.Model.Messaging;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Messaging
{
    public class LeaveChannelsResult
    {
        [JsonProperty("LeaveChannelsResult")]
        public ServiceResult<List<Channel>> Result { get; set; }
    }
}
