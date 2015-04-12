using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserTransactionExtendedInfoItem")]
    public class UserTransactionExtendedInfoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserTransactionId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        [ForeignKey("UserTransactionId")]
        public virtual UserTransaction UserTransaction { get; set; }
    }
}
