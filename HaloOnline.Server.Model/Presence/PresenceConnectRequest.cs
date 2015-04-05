using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Presence
{
    public class PresenceConnectRequest
    {
        [JsonProperty("gameClientVersion")]
        public string GameClientVersion { get; set; }
    }
}
