using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserData")]
    public class UserData
    {
        [Key]
        public int UserId { get; set; }

        public int UserDataContainerTypeId { get; set; }

        public int Layout { get; set; }

        public int Version { get; set; }

        public byte[] Data { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("UserDataContainerTypeId")]
        public virtual UserDataContainerType UserDataContainerType { get; set; }
    }
}
