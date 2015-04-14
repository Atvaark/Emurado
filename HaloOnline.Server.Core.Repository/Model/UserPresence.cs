using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserPresence")]
    public class UserPresence
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public int State { get; set; }

        public bool IsInvitable { get; set; }

        public virtual User User { get; set; }
    }
}