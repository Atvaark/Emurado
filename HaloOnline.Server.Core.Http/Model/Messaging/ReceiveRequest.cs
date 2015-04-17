using System.Collections.Generic;
using HaloOnline.Server.Model.Messaging;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Messaging
{
    public class ReceiveRequest
    {
        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
    }
}
