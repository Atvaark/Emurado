using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserDataContainerType")]
    public class UserDataContainerType
    {
        public UserDataContainerType()
        {
            UserData = new HashSet<UserData>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Key { get; set; }

        public bool Public { get; set; }

        public virtual ICollection<UserData> UserData { get; set; }
    }
}
