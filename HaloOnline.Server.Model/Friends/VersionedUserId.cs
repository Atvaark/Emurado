using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Friends
{
    public class VersionedUserId
    {
        public UserId User { get; set; }
        public int Version { get; set; }
    }
}
