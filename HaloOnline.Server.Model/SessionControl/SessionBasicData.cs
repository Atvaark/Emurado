using Newtonsoft.Json;

namespace HaloOnline.Server.Model.SessionControl
{
    public class SessionBasicData
    {
        [JsonProperty("sessionID")]
        public string SessionId { get; set; }

        [JsonProperty("mapID")]
        public string MapId { get; set; }

        [JsonProperty("modeID")]
        public string ModeId { get; set; }

        [JsonProperty("started")]
        public int Started { get; set; }

        [JsonProperty("finished")]
        public int Finished { get; set; }
    }
}
