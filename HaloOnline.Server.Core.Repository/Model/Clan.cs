using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Clan")]
    public class Clan
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Tag { get; set; }

        [InverseProperty("Clan")]
        public virtual IEnumerable<ClanMembership> ClanMembers { get; set; }
    }
}