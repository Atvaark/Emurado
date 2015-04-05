using HaloOnline.Server.Model.Presence;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PartyLeaveResult
    {
        [JsonProperty("PartyLeaveResult")]
        public ServiceResult<PartyStatus> Result { get; set; }
    }
}
