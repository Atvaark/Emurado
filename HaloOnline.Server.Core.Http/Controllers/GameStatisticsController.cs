using System;
using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.GameStatistics;
using HaloOnline.Server.Model.GameStatistics;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class GameStatisticsController : ApiController, IGameStatisticsService
    {
        [HttpPost]
        public CheckNewUserChallengesResult CheckNewUserChallenges([FromBody] CheckNewUserChallengesRequest request)
        {
            return new CheckNewUserChallengesResult
            {
                ServiceResult = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetUserChallengesResult GetUserChallenges(GetUserChallengesRequest request)
        {
            return new GetUserChallengesResult
            {
                Result = new ServiceResult<UserChallenges>
                {
                    Data = new UserChallenges
                    {
                        Version = 0,
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeId = "challenge_0",
                                Progress = 1,
                                Counters = new List<Counter>
                                {
                                    new Counter
                                    {
                                        CounterName = "gp_p0_engineer_kill_counter",
                                        CurrentValue = 1,
                                        MaxValue = 5
                                    }
                                },
                                FinishedAtUnixMilliseconds = DateTime.Now,
                                StartDateUnixMilliseconds = DateTime.Now,
                                EndDateUnixMilliseconds = DateTime.Now,
                                Rewards = new List<Reward>
                                {
                                    new Reward
                                    {
                                        Name = "tech_reward",
                                        Count = 10
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
