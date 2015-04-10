using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unused
{
    public class SessionSettings
    {
        [JsonProperty("SessionID")]
        public string SessionId { get; set; }
        public MatchmakeSettings Matchmake { get; set; }
        public CustomGameSettings Custom { get; set; }
    }
}