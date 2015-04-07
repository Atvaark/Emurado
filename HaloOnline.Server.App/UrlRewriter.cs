using System.Threading.Tasks;
using Microsoft.Owin;

namespace HaloOnline.Server.App
{
    /// <summary>
    /// Fixes AngularJS HTML5 routes
    /// </summary>
    public class UrlRewriter : OwinMiddleware
    {
        public UrlRewriter(OwinMiddleware next)
            : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            PathString remainingPath;
            if (!context.Request.Path.Value.Contains(".") &&
                context.Request.Path.StartsWithSegments(new PathString("/app"), out remainingPath) &&
                remainingPath.HasValue &&
                remainingPath.Value.Length > 1)
            {
                context.Request.Path = new PathString("/app");
            }

            await Next.Invoke(context);
        }
    }
}