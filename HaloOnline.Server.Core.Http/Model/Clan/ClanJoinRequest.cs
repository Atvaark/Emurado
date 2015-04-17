using HaloOnline.Server.Model.Clan;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Clan
{
    public class ClanJoinRequest
    {
        [JsonProperty("clan")]
        public ClanId Clan { get; set; }

        [JsonProperty("inviteData")]
        public string InviteData { get; set; }
    }
}
