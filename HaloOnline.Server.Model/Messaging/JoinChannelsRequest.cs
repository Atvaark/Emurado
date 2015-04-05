using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Messaging
{
    public class JoinChannelsRequest
    {
        [JsonProperty(PropertyName = "channelNames")]
        public List<string> ChannelNames { get; set; }
    }
}
