using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserPrimaryState")]
    public class UserPrimaryState
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public int Xp { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public int Suicides { get; set; }

        public int TotalMatches { get; set; }

        public int Victories { get; set; }

        public int TotalWp { get; set; }

        public int TotalTimePlayed { get; set; }

        public int TotalTimeOnline { get; set; }

        public virtual User User { get; set; }
    }
}
