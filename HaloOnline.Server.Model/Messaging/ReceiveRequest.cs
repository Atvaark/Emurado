using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Messaging
{
    public class ReceiveRequest
    {
        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
    }
}
