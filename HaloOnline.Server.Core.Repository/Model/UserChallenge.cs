using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserChallenge")]
    public class UserChallenge
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ChallengeId { get; set; }

        public DateTime? FinishedAt { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("ChallengeId")]
        public virtual Challenge Challenge { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
