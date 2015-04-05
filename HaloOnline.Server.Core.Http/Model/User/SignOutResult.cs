using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class SignOutResult
    {
        [JsonProperty("SignOutResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
