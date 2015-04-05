using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace HaloOnline.Server.Core.Http.Auth
{
    public interface IHaloUserManager
    {
        Task<IdentityResult> AccessFailedAsync(string userId);
        Task<HaloUser> FindAsync(string userName, string password);
        Task<HaloUser> FindByNameAsync(string userName);
        Task<ClaimsIdentity> CreateIdentityAsync(HaloUser user, string authenticationType);
        Task<bool> CheckPasswordAsync(HaloUser user, string password);
        Task<IdentityResult> CreateAsync(HaloUser user, string password);
    }
}
