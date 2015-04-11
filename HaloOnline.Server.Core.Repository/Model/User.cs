using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }
        
        public string Nickname { get; set; }

        public string BattleTag { get; set; }

        public int Level { get; set; }
        
        [InverseProperty("User")]
        public virtual ICollection<ClanMembership> ClanMemberships { get; set; }
        [InverseProperty("Subscriber")]
        public virtual ICollection<UserSubscription> Subscriptions { get; set; }
    }
}