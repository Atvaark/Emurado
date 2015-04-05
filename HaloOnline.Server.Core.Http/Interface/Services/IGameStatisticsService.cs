using HaloOnline.Server.Core.Http.Model.GameStatistics;
using HaloOnline.Server.Model.GameStatistics;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IGameStatisticsService
    {
        CheckNewUserChallengesResult CheckNewUserChallenges(CheckNewUserChallengesRequest request);
        GetUserChallengesResult GetUserChallenges(GetUserChallengesRequest request);
    }
}
