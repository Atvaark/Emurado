using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Common;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Authorization;
using HaloOnline.Server.Model.Authorization;
using HaloOnline.Server.Model.Clan;
using HaloOnline.Server.Model.EndpointDispatcher;
using HaloOnline.Server.Model.User;
using Microsoft.Owin.Security;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class AuthorizationController : ApiController
    {
        private readonly ISecureDataFormat<AuthenticationTicket> _secureDataFormat;
        private readonly IServerOptions _serverOptions;
        private readonly IHaloUserManager _userManager;
        private readonly IUserBaseDataRepository _userBaseDataRepository;

        public AuthorizationController(
            IServerOptions serverOptions,
            IHaloUserManager userManager,
            IUserBaseDataRepository userBaseDataRepository,
            ISecureDataFormat<AuthenticationTicket> secureDataFormat)
        {
            _serverOptions = serverOptions;
            _userManager = userManager;
            _userBaseDataRepository = userBaseDataRepository;
            _secureDataFormat = secureDataFormat;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateAccount(CreateAccountRequest request)
        {
            var user = new HaloUser
            {
                UserName = request.Username
            };
            var creationResult = await _userManager.CreateAsync(user, request.Password);
            if (creationResult.Succeeded == false)
            {
                return BadRequest(string.Join(", ", creationResult.Errors));
            }
            
            var userBaseData = new UserBaseData
            {
                User = new UserId
                {
                    Id = user.UserId
                },
                Nickname = request.Nickname,
                BattleTag = "",
                Level = 0,
                Clan = new ClanId
                {
                    Id = 0
                },
                ClanTag = ""
            };
            await _userBaseDataRepository.SetUserBaseDataAsync(userBaseData);

            var token = AuthenticateUser(user);
            return Ok(token);
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

            var endpointHostname = _serverOptions.EndpointHostname;
            var endpointPort = _serverOptions.EndpointPort;
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
                                Ip = endpointHostname,
                                Port = endpointPort,
                                Protocol = 0,
                                IsDefault = true
                            }
                        },
                        DiagnosticServices = new List<CompactEndpointInfo>
                        {
                            new CompactEndpointInfo
                            {
                                Name = "DiagnosticsService",
                                Ip = endpointHostname,
                                Port = endpointPort,
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
            return _secureDataFormat.Protect(ticket);
        }
    }
}
