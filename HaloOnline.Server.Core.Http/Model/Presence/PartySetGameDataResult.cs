using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PartySetGameDataResult
    {
        [JsonProperty("PartySetGameDataResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
