using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserBaseData")]
    public class UserBaseData
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int? ClanId { get; set; }

        [ForeignKey("ClanId")]
        public virtual Clan Clan { get; set; }

        public string Nickname { get; set; }

        public string BattleTag { get; set; }

        public int Level { get; set; }
    }
}