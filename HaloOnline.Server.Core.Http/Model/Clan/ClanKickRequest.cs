using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Clan
{
    public class ClanKickRequest
    {
        [JsonProperty("user")]
        public UserId User { get; set; }
    }
}
