using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("ChallengeReward")]
    public class ChallengeReward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ChallengeId { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        [ForeignKey("ChallengeId")]
        public virtual Challenge Challenge { get; set; }
    }
}
