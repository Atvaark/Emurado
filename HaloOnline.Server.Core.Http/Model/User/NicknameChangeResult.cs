using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class NicknameChangeResult
    {
        [JsonProperty("NicknameChangeResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
