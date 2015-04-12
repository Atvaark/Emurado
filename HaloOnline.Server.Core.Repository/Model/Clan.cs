using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Clan")]
    public class Clan
    {
        public Clan()
        {
            ClanMemberships = new HashSet<ClanMembership>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Tag { get; set; }

        [InverseProperty("Clan")]
        public virtual ICollection<ClanMembership> ClanMemberships { get; set; }
    }
}