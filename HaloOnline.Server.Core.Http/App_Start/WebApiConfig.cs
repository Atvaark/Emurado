using System.Web.Http;
using System.Web.Http.Cors;
using HaloOnline.Server.Common;
using HaloOnline.Server.Core.Http.Formatters;

namespace HaloOnline.Server.Core.Http
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IServerOptions serverOptions)
        {
            // TODO: Only enable cors for the web app
            //var cors = new EnableCorsAttribute(serverOptions.EndpointHostname + ":" + 11700, "*", "*");
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("HaloServiceApi", "{controller}Service.svc/{action}/{request}",
                new { action = RouteParameter.Optional, request = RouteParameter.Optional }
                );
            
            config.Formatters.Add(new HydraBinaryFormatter());
        }
    }
}
