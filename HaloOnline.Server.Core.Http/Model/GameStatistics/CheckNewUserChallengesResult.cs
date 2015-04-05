using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.GameStatistics
{
    public class CheckNewUserChallengesResult
    {
        [JsonProperty("CheckNewUserChallengesResult")]
        public ServiceResult<bool> ServiceResult { get; set; }
    }
}
