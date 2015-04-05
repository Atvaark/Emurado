using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.UserStorage
{
    public class PerUser
    {
        public UserId User { get; set; }
        public AbstractData PerUserData { get; set; }
    }
}
