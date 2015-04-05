using System.Web.Http;
using HaloOnline.Server.Core.Http.Handlers;

namespace HaloOnline.Server.Core.Http
{
    public class HandlerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new HaloClientContentTypeHandler());
            config.MessageHandlers.Add(new UserContextAuthenticationHandler());
            config.MessageHandlers.Add(new DebugPrintHandler());
        }
    }
}
