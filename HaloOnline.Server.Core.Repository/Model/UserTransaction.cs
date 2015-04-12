using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserTransaction")]
    public class UserTransaction
    {
        public UserTransaction()
        {
            UserTransactionExtendedInfoItems = new HashSet<UserTransactionExtendedInfoItem>();
            UserTransactionItems = new HashSet<UserTransactionItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SessionId { get; set; }

        public string ReferenceId { get; set; }

        public string OfferId { get; set; }

        public DateTime Timestamp { get; set; }

        public int OperationType { get; set; }

        public virtual ICollection<UserTransactionExtendedInfoItem> UserTransactionExtendedInfoItems { get; set; }

        public virtual ICollection<UserTransactionItem> UserTransactionItems { get; set; }
    }
}
