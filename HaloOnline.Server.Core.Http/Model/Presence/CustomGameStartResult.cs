using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class CustomGameStartResult
    {
        [JsonProperty("CustomGameStartResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
