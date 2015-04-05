using HaloOnline.Server.Model.Presence;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class MatchmakeGetStatusResult
    {
        [JsonProperty("MatchmakeGetStatusResult")]
        public ServiceResult<MatchmakeStatus> Result { get; set; }
    }
}
