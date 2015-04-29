using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("User")]
    public class User
    {
        public User()
        {
            ClanMemberships = new HashSet<ClanMembership>();
            Subscriptions = new HashSet<UserSubscription>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }

        public string Nickname { get; set; }

        public string BattleTag { get; set; }

        public int Level { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<ChannelUser> ChannelUsers { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<ClanMembership> ClanMemberships { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserChallenge> UserChallenges { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserData> UserDatas { get; set; }

        [InverseProperty("User")]
        public virtual UserPresence UserPresence { get; set; }

        [InverseProperty("User")]
        public virtual UserPrimaryState UserPrimaryState { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserState> UserStates { get; set; }

        [InverseProperty("Subscriber")]
        public virtual ICollection<UserSubscription> Subscriptions { get; set; }

        [InverseProperty("Subscribee")]
        public virtual ICollection<UserSubscription> Subscribers { get; set; }
        
    }
}