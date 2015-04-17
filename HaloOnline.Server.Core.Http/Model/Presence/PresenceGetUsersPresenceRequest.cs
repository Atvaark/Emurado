using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PresenceGetUsersPresenceRequest
    {
        [JsonProperty("users")]
        public List<UserId> Users { get; set; }
    }
}
