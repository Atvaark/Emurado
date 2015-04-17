using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PresenceConnectRequest
    {
        [JsonProperty("gameClientVersion")]
        public string GameClientVersion { get; set; }
    }
}
