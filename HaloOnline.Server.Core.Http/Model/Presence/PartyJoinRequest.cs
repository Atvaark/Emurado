using HaloOnline.Server.Model.Presence;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PartyJoinRequest
    {
        [JsonProperty("party")]
        public PartyId Party { get; set; }

        [JsonProperty("inviteData")]
        public string InviteData { get; set; }
    }
}
