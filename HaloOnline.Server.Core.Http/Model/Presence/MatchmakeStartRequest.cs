using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class MatchmakeStartRequest
    {
        [JsonProperty("playlist")]
        public string Playlist { get; set; }
    }
}
