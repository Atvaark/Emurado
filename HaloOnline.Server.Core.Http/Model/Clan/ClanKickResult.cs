using HaloOnline.Server.Model.Clan;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Clan
{
    public class ClanKickResult
    {
        [JsonProperty("ClanKickResult")]
        public ServiceResult<ClanMembershipDataVersioned> Result { get; set; }
    }
}
