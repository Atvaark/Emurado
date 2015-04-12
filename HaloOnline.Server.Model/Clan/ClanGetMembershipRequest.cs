using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Clan
{
    public class ClanGetMembershipRequest
    {
        // TODO: Validate if the type of Clans is correct
        [JsonProperty("clans")]
        public List<ClanId> Clans { get; set; }
    }
}
