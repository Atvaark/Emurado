using System.IdentityModel.Tokens;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Http.Interface.Repositories;
using HaloOnline.Server.Core.Http.Repository;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace HaloOnline.Server.Core.Http
{
    public static class AutofacConfig
    {
        public static IContainer Register(IAppBuilder app, HttpConfiguration config)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            ConfigureRepositories(containerBuilder);
            ConfigureDependencies(containerBuilder);
            var container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            return container;
        }

        private static void ConfigureRepositories(ContainerBuilder builder)
        {
            builder.Register(c => new UserRepository())
                .SingleInstance()
                .As<IUserRepository>();

            builder.Register(c => new UserBaseDataRepository())
                .SingleInstance()
                .As<IUserBaseDataRepository>();
        }

        private static void ConfigureDependencies(ContainerBuilder builder)
        {
            const string validIssuer = "HaloOnlineServer";

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(
                c => new HaloUserManager(
                    new IdentityFactoryOptions<HaloUserManager>(),
                    c.Resolve<IUserRepository>()))
                //.InstancePerRequest()
                .SingleInstance()
                .As<IHaloUserManager>();

            // BUG: Cyclic reference. Create an option wrapper that has the isue

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
