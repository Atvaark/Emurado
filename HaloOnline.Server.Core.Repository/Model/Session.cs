using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Session")]
    public class Session
    {
        [Key]

        public string Id { get; set; }
        
        public string MapId { get; set; }
        
        public string ModeId { get; set; }
        
        public int Started { get; set; }
        
        public int Finished { get; set; }

        [InverseProperty("Session")]
        public virtual ICollection<PartyMember> SessionMembers { get; set; }

    }
}