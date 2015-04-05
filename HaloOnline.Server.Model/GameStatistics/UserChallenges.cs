using System.Collections.Generic;

namespace HaloOnline.Server.Model.GameStatistics
{
    public class UserChallenges
    {
        public int Version { get; set; }
        public List<Challenge> Challenges { get; set; }
    }
}
