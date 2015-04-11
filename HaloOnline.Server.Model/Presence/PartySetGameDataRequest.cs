using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Presence
{
    public class PartySetGameDataRequest
    {
        [JsonProperty("gameData")]
        public byte[] GameData { get; set; }
    }
}
