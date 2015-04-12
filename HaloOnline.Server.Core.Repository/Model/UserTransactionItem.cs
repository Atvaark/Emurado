using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserTransactionItem")]
    public class UserTransactionItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserTransactionId { get; set; }

        public long DescId { get; set; }

        public string StateName { get; set; }

        public int StateType { get; set; }

        public int OwnType { get; set; }

        public int OperationType { get; set; }

        public int InitialValue { get; set; }

        public int ResultingValue { get; set; }

        public int DeltaValue { get; set; }

        [ForeignKey("UserTransactionId")]
        public virtual UserTransaction UserTransaction { get; set; }
    }
}
