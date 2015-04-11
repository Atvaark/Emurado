using HaloOnline.Server.Model.UserStorage;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unidentified
{
    public class Unidentified2
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("entries")]
        public object Entries { get; set; }

        [JsonProperty("data")]
        public AbstractData Data { get; set; }
    }
}