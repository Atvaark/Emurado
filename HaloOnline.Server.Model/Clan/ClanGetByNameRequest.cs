using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Clan
{
    public class ClanGetByNameRequest
    {
        [JsonProperty("namePrefix")]
        public string NamePrefix { get; set; }

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }
    }
}
