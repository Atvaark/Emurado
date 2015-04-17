using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Party")]
    public class Party
    {
        [Key]
        public string Id { get; set; }
        public int MatchmakeState { get; set; }
        public byte[] GameData { get; set; }

        [InverseProperty("Party")]
        public virtual ICollection<PartyMember> PartyMembers { get; set; }
    }
}