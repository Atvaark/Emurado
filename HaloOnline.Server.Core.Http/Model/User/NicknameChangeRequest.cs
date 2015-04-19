using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class NicknameChangeRequest
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
    }
}
