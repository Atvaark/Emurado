using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace HaloOnline.Server.Core.Http
{
    public static class AuthConfig
    {
        public static void Register(IAppBuilder app, IContainer container)
        {
            var oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = container.Resolve<IOAuthAuthorizationServerProvider>(),
                AccessTokenFormat = container.Resolve<ISecureDataFormat<AuthenticationTicket>>()
            };
            app.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);

            var jwtBearerAuthenticationOptions = new JwtBearerAuthenticationOptions
            {
                AllowedAudiences = new List<string>
                {
                    "HaloOnlineUser"
                },
                AuthenticationMode = AuthenticationMode.Active,
                AuthenticationType = "Bearer",
                TokenValidationParameters = container.Resolve<TokenValidationParameters>(),
                IssuerSecurityTokenProviders = new List<IIssuerSecurityTokenProvider>
                {
                    container.Resolve<IIssuerSecurityTokenProvider>()
                },
                TokenHandler = container.Resolve<JwtSecurityTokenHandler>(),
                Provider = new OAuthBearerAuthenticationProvider
                {
                    OnApplyChallenge = context => Task.FromResult(0),
                    OnRequestToken = context =>
                    {
                        var userContext = context.Request.Headers["USER_CONTEXT"];
                        if (!string.IsNullOrWhiteSpace(userContext))
                        {
                            context.Token = userContext;
                        }
                        return Task.FromResult(0);
                    },
                    OnValidateIdentity = context => Task.FromResult(0)
                }
            };
            app.UseJwtBearerAuthentication(jwtBearerAuthenticationOptions);
        }
    }
}
