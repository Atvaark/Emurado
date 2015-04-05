using Newtonsoft.Json;

namespace HaloOnline.Server.Model.SessionControl
{
    public class DedicatedServer
    {
        [JsonProperty("ServerID")]
        public string ServerId { get; set; }

        [JsonProperty("ServerAddr")]
        public string ServerAddress { get; set; }

        public int Port { get; set; }
    }
}
