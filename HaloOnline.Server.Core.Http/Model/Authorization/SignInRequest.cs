using System.Collections.Generic;
using HaloOnline.Server.Model.Authorization;
using HaloOnline.Server.Model.EndpointDispatcher;

namespace HaloOnline.Server.Core.Http.Model.Authorization
{
    public class SignInRequest
    {
        public SignInRequest()
        {
            Versions = new List<EndpointInfoVersioned>();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Provider { get; set; }
        public Signature Signature { get; set; }
        public List<EndpointInfoVersioned> Versions { get; set; }
    }
}
