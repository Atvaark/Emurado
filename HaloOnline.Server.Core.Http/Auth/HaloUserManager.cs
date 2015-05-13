using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace HaloOnline.Server.Core.Http.Auth
{
    public class HaloUserManager : UserManager<HaloUser>, IHaloUserManager
    {
        private readonly IHaloUserStore _store;

        public HaloUserManager(IHaloUserStore haloUserStore)
            : base(haloUserStore)
        {
            _store = haloUserStore;
            PasswordValidator = new PasswordValidator();
        }

        public override Task<ClaimsIdentity> CreateIdentityAsync(HaloUser user, string authenticationType)
        {
            return Task.Run(() => CreateIdentity(user, authenticationType));
        }

        public ClaimsIdentity CreateIdentity(HaloUser user, string authenticationType)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(authenticationType);
            claimsIdentity.AddClaim(new Claim("id", user.Id));
            claimsIdentity.AddClaim(new Claim("username", user.UserName));
            return claimsIdentity;
        }
    }
}
