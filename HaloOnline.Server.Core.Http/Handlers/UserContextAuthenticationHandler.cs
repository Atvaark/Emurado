using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HaloOnline.Server.Core.Http.Auth;

namespace HaloOnline.Server.Core.Http.Handlers
{
    public class UserContextAuthenticationHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            string userContext;
            var environment = request.GetOwinEnvironment();
            if (TryGetUserContextFromRequestHeader(request, out userContext))
            {
                environment[HaloAuthEnvironment.UserContext] = userContext;
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (TryGetUserContextFromEnvironment(environment, out userContext))
            {
                response.Headers.Add(HaloAuthEnvironment.UserContext, userContext);
            }
            return response;
        }

        private IHaloUserManager ResolveUserManager(HttpRequestMessage request)
        {
            return (IHaloUserManager) request.GetDependencyScope().GetService(typeof (IHaloUserManager));
        }

        private bool TryGetUserContextFromEnvironment(IDictionary<string, object> environment, out string userContext)
        {
            userContext = null;
            object userContextValue;
            if (environment.TryGetValue(HaloAuthEnvironment.UserContext, out userContextValue))
            {
                userContext = userContextValue as string;
                return userContext != null;
            }
            return false;
        }

        private bool TryGetUserContextFromRequestHeader(HttpRequestMessage request, out string userContext)
        {
            IEnumerable<string> userContextHeaderValues;
            userContext = null;
            if (request.Headers.TryGetValues(HaloAuthEnvironment.UserContext, out userContextHeaderValues))
            {
                userContext = userContextHeaderValues.SingleOrDefault();
                return true;
            }
            return false;
        }
    }
}
