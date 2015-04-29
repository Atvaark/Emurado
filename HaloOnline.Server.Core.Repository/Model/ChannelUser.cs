using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("ChannelUser")]
    public class ChannelUser
    {
        [Key, Column(Order = 0)]
        public int ChannelId { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        [ForeignKey("ChannelId")]
        public virtual Channel Channel { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}