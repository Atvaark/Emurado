using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class MatchmakeStopResult
    {
        [JsonProperty("MatchmakeStopResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
