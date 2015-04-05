using HaloOnline.Server.Core.Http.Auth;
using Microsoft.AspNet.Identity;

namespace HaloOnline.Server.Core.Http.Interface.Repositories
{
    public interface IUserRepository : IUserStore<HaloUser>, IUserPasswordStore<HaloUser>
    {
    }
}
