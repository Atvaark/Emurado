using HaloOnline.Server.Core.Http.Model.Authorization;
using HaloOnline.Server.Model.Authorization;

namespace
    HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IAuthorizationService
    {
        SignInResult SignIn(SignInRequest request);
    }
}
