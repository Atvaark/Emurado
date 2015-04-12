using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserChallengeCounter")]
    public class UserChallengeCounter
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ChallengeId { get; set; }

        public string Name { get; set; }

        public int CurrentValue { get; set; }

        public int MaxValue { get; set; }
    }
}
