using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unidentified
{
    public class Unidentified4
    {
        [JsonProperty("SessionID")]
        public string SessionId { get; set; }
        public Unidentified5 Matchmake { get; set; }
        public Unidentified6 Custom { get; set; }
    }
}