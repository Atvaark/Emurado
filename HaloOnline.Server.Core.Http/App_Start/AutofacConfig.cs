using System.IdentityModel.Tokens;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using HaloOnline.Server.Common;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Repository;
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
            ConfigureDependencies(containerBuilder, serverOptions);
            var container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            return container;
        }
        
        private static void ConfigureDependencies(ContainerBuilder builder, IServerOptions serverOptions)
        {
            const string validIssuer = "HaloOnlineServer";
            
            builder.RegisterInstance(serverOptions)
                .SingleInstance()
                .As<IServerOptions>();

            builder.RegisterModule<RepositoryPerRequestModule>();
            builder.Register(c => new HaloUserStore(c.Resolve<IUserRepository>()))
                .InstancePerRequest()
                .As<IHaloUserStore>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<HaloUserManager>()
                .InstancePerRequest()
                .As<IHaloUserManager>();     

            builder.Register(c => new SymmetricKeyIssuerSecurityTokenProvider(
                validIssuer,
                serverOptions.Secret))
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

            builder.RegisterType<JwtSecurityTokenHandler>()
                .SingleInstance()
                .AsSelf();

            builder.RegisterType<HaloTokenFormat>()
                .SingleInstance()
                .As<ISecureDataFormat<AuthenticationTicket>>();

            builder.RegisterType<HaloAuthorizationServerProvider>()
                .SingleInstance()
                .As<IOAuthAuthorizationServerProvider>();
        }
    }
}
