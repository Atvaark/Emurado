using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.GameStatistics
{
    public class GetUserChallengesRequest
    {
        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
