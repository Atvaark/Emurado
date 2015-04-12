using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserSubscription")]
    public class UserSubscription
    {
        [Key, Column(Order = 0)]
        public int SubscriberId { get; set; }
        [Key, Column(Order = 1)]
        public int SubscribeeId { get; set; }
        
        [ForeignKey("SubscriberId")]
        public virtual User Subscriber { get; set; }
        [ForeignKey("SubscribeeId")]
        public virtual User Subscribee { get; set; }
    }
}