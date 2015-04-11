using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("ClanMembership")]
    public class ClanMembership
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int ClanId { get; set; }

        [Column(Order = 2)]
        public int Role { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("ClanId")]
        public virtual Clan Clan { get; set; }
    }
}