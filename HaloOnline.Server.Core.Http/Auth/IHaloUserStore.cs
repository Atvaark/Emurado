using Microsoft.AspNet.Identity;

namespace HaloOnline.Server.Core.Http.Auth
{
    public interface IHaloUserStore : IUserStore<HaloUser>, IUserPasswordStore<HaloUser>
    {
    }
}
