using System.Collections.Generic;
using HaloOnline.Server.Model.EndpointDispatcher;

namespace HaloOnline.Server.Model.Authorization
{
    public class SignIn
    {
        public string AuthorizationToken { get; set; }
        public List<CompactEndpointInfo> TitleServers { get; set; }
        public List<CompactEndpointInfo> DiagnosticServices { get; set; }
    }
}
