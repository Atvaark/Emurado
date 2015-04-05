using System.Security.Claims;
using System.Threading.Tasks;
using HaloOnline.Server.Core.Http.Interface.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HaloOnline.Server.Core.Http.Auth
{
    public class HaloUserManager : UserManager<HaloUser>, IHaloUserManager
    {
        private readonly IUserRepository _repository;

        public HaloUserManager(
            IdentityFactoryOptions<HaloUserManager> options,
            IUserRepository userRepository)
            : base(userRepository)
        {
            _repository = userRepository;
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
