using System.Web.Http;
using HaloOnline.Server.Core.Http.Filters;
using Owin;

namespace HaloOnline.Server.Core.Http
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            HandlerConfig.Register(config);
            config.Filters.Add(new UnhandledExceptionFilter());
            var container = AutofacConfig.Register(app, config);
            AuthConfig.Register(app, container);
            WebApiConfig.Register(config);
            HaloServerConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
