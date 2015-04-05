using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace HaloOnline.Server.Core.Http.Handlers
{
    public class HaloClientContentTypeHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Content.Headers.ContentType == null)
            {
                bool malformedJsonContentType = request.Content.Headers
                    .Where(h => h.Key == "Content-Type")
                    .SelectMany(h => h.Value)
                    .Any(t => t == "application/json;charset=utf-8;");
                if (malformedJsonContentType)
                {
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    request.Content.Headers.ContentEncoding.Add("utf-8");
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
