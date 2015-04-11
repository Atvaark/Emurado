using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Auth
{
    public class HaloUser : User, IHaloUser
    {
        public string Id 
        {
            get { return UserId.ToString(); }
        }
    }
}
