using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Party")]
    public class Party
    {
        [Key]
        public int Id { get; set; }
        public string PartyId { get; set; }
        public int MatchmakeType { get; set; }
        public byte[] GameData { get; set; }

        [InverseProperty("Party")]
        public virtual ICollection<PartyMember> PartyMembers { get; set; }
    }
}