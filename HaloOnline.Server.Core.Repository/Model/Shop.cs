using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Shop")]
    public class Shop
    {
        public Shop()
        {
            ShopSections = new HashSet<ShopSection>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Race { get; set; }

        public virtual ICollection<ShopSection> ShopSections { get; set; }
    }
}
