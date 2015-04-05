using System.Collections.Generic;
using HaloOnline.Server.Model.Presence;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PresenceGetUsersPresenceResult
    {
        [JsonProperty("PresenceGetUsersPresenceResult")]
        public ServiceResult<List<UserPresence>> Result { get; set; }
    }
}
