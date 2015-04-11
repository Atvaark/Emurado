using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Presence
{
    public class MatchmakeStartRequest
    {
        [JsonProperty("playlist")]
        public string Playlist { get; set; }
    }
}
