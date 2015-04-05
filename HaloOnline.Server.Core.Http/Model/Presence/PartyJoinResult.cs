using HaloOnline.Server.Model.Presence;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PartyJoinResult
    {
        [JsonProperty("PartyJoinResult")]
        public ServiceResult<PartyStatus> Result { get; set; }
    }
}
