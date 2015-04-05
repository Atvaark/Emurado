using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Authorization;
using HaloOnline.Server.Model.Authorization;
using HaloOnline.Server.Model.EndpointDispatcher;
using Microsoft.Owin.Security;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class AuthorizationController : ApiController
    {
        private readonly ISecureDataFormat<AuthenticationTicket> _secureDataFormat;
        private readonly IHaloUserManager _userManager;

        public AuthorizationController(IHaloUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> secureDataFormat)
        {
            _userManager = userManager;
            _secureDataFormat = secureDataFormat;
        }

        [HttpPost]
        public SignInResult SignIn([FromBody] SignInRequest request)
        {
            if (request == null)
            {
                return new SignInResult
                {
                    ServiceResult = new ServiceResult<SignIn>
                    {
                        ReturnCode = 1
                    }
                };
            }

            var haloUser = _userManager.FindByNameAsync(request.Login).Result;
            if (haloUser == null)
            {
                return new SignInResult
                {
                    ServiceResult = new ServiceResult<SignIn>
                    {
                        ReturnCode = 1
                    }
                };
            }

            if (_userManager.CheckPasswordAsync(haloUser, request.Password).Result == false)
            {
                _userManager.AccessFailedAsync(haloUser.Id).Wait();
                return new SignInResult
                {
                    ServiceResult = new ServiceResult<SignIn>
                    {
                        ReturnCode = 1
                    }
                };
            }

            var token = AuthenticateUser(haloUser);

            var ip = "localhost";
            var port = 11705;
            var signInResult = new SignInResult
            {
                ServiceResult = new ServiceResult<SignIn>
                {
                    ReturnCode = 0,
                    Data = new SignIn
                    {
                        AuthorizationToken = token,
                        TitleServers = new List<CompactEndpointInfo>
                        {
                            new CompactEndpointInfo
                            {
                                Name = "TitleServer",
                                Ip = ip,
                                Port = port,
                                Protocol = 0,
                                IsDefault = true
                            }
                        },
                        DiagnosticServices = new List<CompactEndpointInfo>
                        {
                            new CompactEndpointInfo
                            {
                                Name = "DiagnosticsService",
                                Ip = ip,
                                Port = port,
                                Protocol = 0,
                                IsDefault = true
                            }
                        }
                    }
                }
            };
            return signInResult;
        }

        private string AuthenticateUser(HaloUser haloUser)
        {
            var authenticationManager = Request.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            var identity = _userManager.CreateIdentityAsync(haloUser, HaloAuthEnvironment.UserContext).Result;
            var authenticationProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(TimeSpan.FromDays(1))
            };
            var ticket = new AuthenticationTicket(identity, authenticationProperties);
            authenticationManager.SignIn(authenticationProperties, identity);
            return _secureDataFormat.Protect(ticket); // TODO: Max size 451 bytes. Doesn't work again.
        }
    }
}
