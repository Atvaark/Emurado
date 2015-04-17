using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("PartyMember")]
    public class PartyMember
    {
        [Key, Column(Order = 0)]
        public string PartyId { get; set; }
        [Key, Column(Order = 1)]
        public int UserId { get; set; }
        [Column(Order = 2)]
        public string SessionId { get; set; }
        [Column(Order = 3)]
        public bool IsOwner { get; set; }

        [ForeignKey("PartyId")]
        public virtual Party Party { get; set; }
        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}