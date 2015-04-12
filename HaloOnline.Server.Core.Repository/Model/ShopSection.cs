using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("ShopSection")]
    public class ShopSection
    {
        public ShopSection()
        {
            ShopSectionShelves = new HashSet<ShopSectionShelve>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ShopId { get; set; }

        public string Name { get; set; }

        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }

        public virtual ICollection<ShopSectionShelve> ShopSectionShelves { get; set; }
    }
}
