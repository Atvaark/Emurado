using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Messaging
{
    public class SendRequest
    {
        [JsonProperty("channelName")]
        public string ChannelName { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
