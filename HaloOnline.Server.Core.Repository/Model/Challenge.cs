using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Challenge")]
    public class Challenge
    {
        public Challenge()
        {
            ChallengeRewards = new HashSet<ChallengeReward>();
            UserChallenges = new HashSet<UserChallenge>();
        }

        [Key]
        public string Id { get; set; }

        public virtual ICollection<ChallengeReward> ChallengeRewards { get; set; }

        public virtual ICollection<UserChallenge> UserChallenges { get; set; }
    }
}
