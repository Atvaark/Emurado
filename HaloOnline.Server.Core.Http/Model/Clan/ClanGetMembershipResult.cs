using System.Collections.Generic;
using HaloOnline.Server.Model.Clan;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Clan
{
    public class ClanGetMembershipResult
    {
        [JsonProperty("ClanGetMembershipResult")]
        public ServiceResult<List<ClanMembershipDataVersioned>> Result { get; set; }
    }
}
