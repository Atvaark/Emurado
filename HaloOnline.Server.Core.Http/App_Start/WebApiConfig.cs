using System.Web.Http;

namespace HaloOnline.Server.Core.Http
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("HaloServiceApi", "{controller}Service.svc/{action}/{request}",
                new {action = RouteParameter.Optional, request = RouteParameter.Optional}
                );
        }
    }
}
