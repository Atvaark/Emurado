using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Owin;
using Microsoft.Owin.Security.OAuth;

namespace HaloOnline.Server.Core.Http.Auth
{
    // BUG: Not called anywhere
    public class HaloAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
        {
            return base.AuthorizeEndpoint(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            IHaloUserManager haloUserManager =
                (IHaloUserManager) context.OwinContext.GetAutofacLifetimeScope().Resolve(typeof (IHaloUserManager));


            // BUG: Find out how this is done via AutoFac
            HaloUser user = await haloUserManager.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_login", "The user name or password is incorrect.");
            }
            else
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("id", user.Id));
                identity.AddClaim(new Claim("username", user.UserName));
                context.Validated(identity);
            }
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult(0);
        }
    }
}
