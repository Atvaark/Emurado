using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Presence
{
    public class PartySetGameDataRequest
    {
        // TODO: Base64?
        [JsonProperty("gameData")]
        public byte[] GameData { get; set; }
    }
}
