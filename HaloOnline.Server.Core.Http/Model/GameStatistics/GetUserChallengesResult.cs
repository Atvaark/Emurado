using HaloOnline.Server.Model.GameStatistics;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.GameStatistics
{
    public class GetUserChallengesResult
    {
        [JsonProperty("GetUserChallengesResult")]
        public ServiceResult<UserChallenges> Result { get; set; }
    }
}
