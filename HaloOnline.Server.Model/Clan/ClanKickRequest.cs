using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Clan
{
    public class ClanKickRequest
    {
        [JsonProperty("user")]
        public UserId User { get; set; }
    }
}
