using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class PartySetGameDataRequest
    {
        [JsonProperty("gameData")]
        public byte[] GameData { get; set; }
    }
}
