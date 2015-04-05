using HaloOnline.Server.Model.Authorization;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Authorization
{
    public class SignInResult
    {
        [JsonProperty(PropertyName = "SignInResult")]
        public ServiceResult<SignIn> ServiceResult { get; set; }
    }
}
