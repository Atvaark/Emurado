using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetUsersByNicknameRequest
    {
        [JsonProperty("nicknamePrefix")]
        public string NicknamePrefix { get; set; }

        // public int search_area

        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }
    }
}
