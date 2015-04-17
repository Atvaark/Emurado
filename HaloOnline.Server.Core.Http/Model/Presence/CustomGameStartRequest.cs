using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class CustomGameStartRequest
    {
        [JsonProperty("map")]
        public string Map { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        // TODO: Validate type of MaxPlayers
        [JsonProperty("maxPlayers")]
        public int MaxPlayers { get; set; }
    }
}
