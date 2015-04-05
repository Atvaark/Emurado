using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HaloOnline.Server.Core.Http.Handlers
{
    public class DebugPrintHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Debug.WriteLine("Request: " + request.Method  + " " + request.RequestUri);
            if (request.Content.Headers.ContentType.MediaType == "application/json")
            {
                var readAsStringAsync = request.Content.ReadAsStringAsync();
                Debug.WriteLine(readAsStringAsync.Result);
            }
            else
            {
                Debug.WriteLine("Non JSON data recieved");
            }

            var response = await base.SendAsync(request, cancellationToken);

            Debug.WriteLine("Response: " + response.StatusCode);
            Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
            return response;
        }
    }
}
