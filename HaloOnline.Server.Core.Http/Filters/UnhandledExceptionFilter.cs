using System.Diagnostics;
using System.Web.Http.Filters;

namespace HaloOnline.Server.Core.Http.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Debug.WriteLine("Unhandled exception: " + actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
    }
}
