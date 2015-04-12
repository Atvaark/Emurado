using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("ShopSectionShelveItem")]
    public class ShopSectionShelveItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ShopSectionShelveId { get; set; }

        public string Name { get; set; }

        [ForeignKey("ShopSectionShelveId")]
        public virtual ShopSectionShelve ShopSectionShelve { get; set; }
    }
}
