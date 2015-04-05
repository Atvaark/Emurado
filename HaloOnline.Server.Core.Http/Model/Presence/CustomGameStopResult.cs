using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class CustomGameStopResult
    {
        [JsonProperty("CustomGameStopResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
