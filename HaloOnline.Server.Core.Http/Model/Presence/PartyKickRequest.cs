using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PartyKickRequest
    {
        [JsonProperty("userID")]
        public string UserId { get; set; }
    }
}
