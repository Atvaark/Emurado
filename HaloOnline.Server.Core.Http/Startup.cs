using System.Web.Http;
using HaloOnline.Server.Common;
using HaloOnline.Server.Core.Http.Filters;
using Owin;

namespace HaloOnline.Server.Core.Http
{
    public class Startup
    {
        private readonly IServerOptions _serverOptions;

        public Startup(IServerOptions serverOptions)
        {
            _serverOptions = serverOptions;
        }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            HandlerConfig.Register(config);
            config.Filters.Add(new UnhandledExceptionFilter());
            var container = AutofacConfig.Register(app, config, _serverOptions);
            AuthConfig.Register(app, container);
            WebApiConfig.Register(config, _serverOptions);
            HaloServerConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
