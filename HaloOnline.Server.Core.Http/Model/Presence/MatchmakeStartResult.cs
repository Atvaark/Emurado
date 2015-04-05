using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class MatchmakeStartResult
    {
        [JsonProperty("MatchmakeStartResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
