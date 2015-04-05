using Newtonsoft.Json;

namespace HaloOnline.Server.Model.GameStatistics
{
    public class GetUserChallengesRequest
    {
        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
