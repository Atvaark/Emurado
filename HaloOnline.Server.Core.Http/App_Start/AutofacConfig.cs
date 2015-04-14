﻿using System.IdentityModel.Tokens;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using HaloOnline.Server.Common;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Repository.Repositories;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace HaloOnline.Server.Core.Http
{
    public static class AutofacConfig
    {
        public static IContainer Register(IAppBuilder app, HttpConfiguration config, IServerOptions serverOptions)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            ConfigureServerOptions(containerBuilder, serverOptions);
            ConfigureRepositories(containerBuilder);
            ConfigureDependencies(containerBuilder);
            var container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            return container;
        }

        private static void ConfigureServerOptions(ContainerBuilder containerBuilder, IServerOptions serverOptions)
        {
            containerBuilder.RegisterInstance(serverOptions)
                .SingleInstance()
                .As<IServerOptions>();
        }

        // TODO: Move this in a module class
        private static void ConfigureRepositories(ContainerBuilder builder)
        {
            builder.Register(c => new UserRepository())
                .InstancePerRequest()
                .As<IUserRepository>();

            builder.Register(c => new UserBaseDataRepository())
                .InstancePerRequest()
                .As<IUserBaseDataRepository>();

            builder.Register(c => new UserSubscriptionRepository())
                .InstancePerRequest()
                .As<IUserSubscriptionRepository>();
            
            builder.Register(c => new UserPresenceRepository())
                .InstancePerRequest()
                .As<IUserPresenceRepository>();

            builder.Register(c => new ClanRepository())
                .InstancePerRequest()
                .As<IClanRepository>();

            builder.Register(c => new ClanMembershipRepository())
                .InstancePerRequest()
                .As<IClanMembershipRepository>();
            
            builder.Register(c => new PartyRepository())
                .InstancePerRequest()
                .As<IPartyRepository>();

            builder.Register(c => new PartyMemberRepository())
                .InstancePerRequest()
                .As<IPartyMemberRepository>();

            builder.Register(c => new SessionRepository())
                .InstancePerRequest()
                .As<ISessionRepository>();
            
            builder.Register(c => new HaloUserStore(c.Resolve<IUserRepository>()))
                .InstancePerRequest()
                .As<IHaloUserStore>();
        }

        private static void ConfigureDependencies(ContainerBuilder builder)
        {
            const string validIssuer = "HaloOnlineServer";

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(
                c => new HaloUserManager(
                    new IdentityFactoryOptions<HaloUserManager>(),
                    c.Resolve<IHaloUserStore>()))
                .InstancePerRequest()
                .As<IHaloUserManager>();

            builder.Register(c => new SymmetricKeyIssuerSecurityTokenProvider(
                validIssuer,
                "n9stoFfd/JN6JyVCxwEXYxNSXGDEGSoOcPtd7erDtE4=")) // TODO: Place the secret in a config file
                .SingleInstance()
                .As<IIssuerSecurityTokenProvider>();

            builder.Register(c => new TokenValidationParameters
            {
                IssuerSigningKey = c.Resolve<IIssuerSecurityTokenProvider>().SecurityTokens.First().SecurityKeys.First(),
                ValidateIssuerSigningKey = true,
                ValidIssuer = validIssuer,
                ValidateIssuer = true,
                ValidAudience = "HaloOnlineUser",
                ValidateAudience = true
            })
                .SingleInstance()
                .AsSelf();

            builder.Register(c => new JwtSecurityTokenHandler())
                .SingleInstance()
                .AsSelf();

            builder.Register(
                c => new HaloTokenFormat(c.Resolve<JwtSecurityTokenHandler>(), c.Resolve<TokenValidationParameters>()))
                .SingleInstance()
                .As<ISecureDataFormat<AuthenticationTicket>>();

            builder.Register(c => new HaloAuthorizationServerProvider())
                .SingleInstance()
                .As<IOAuthAuthorizationServerProvider>();
        }
    }
}
