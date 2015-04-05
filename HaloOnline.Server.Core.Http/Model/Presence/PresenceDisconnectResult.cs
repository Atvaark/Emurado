using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PresenceDisconnectResult
    {
        [JsonProperty("PresenceDisconnectResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
