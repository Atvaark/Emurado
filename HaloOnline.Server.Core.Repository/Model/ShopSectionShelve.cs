using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("ShopSectionShelve")]
    public class ShopSectionShelve
    {
        public ShopSectionShelve()
        {
            ShopSectionShelveItems = new HashSet<ShopSectionShelveItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ShopSectionId { get; set; }

        public string Name { get; set; }

        public bool IsHot { get; set; }

        public bool IsSale { get; set; }

        [ForeignKey("ShopSectionId")]
        public virtual ShopSection ShopSection { get; set; }

        public virtual ICollection<ShopSectionShelveItem> ShopSectionShelveItems { get; set; }
    }
}
