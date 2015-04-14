using Newtonsoft.Json;

namespace HaloOnline.Server.Model.SessionControl
{
    public class ClientGetStatusRequest
    {
        [JsonProperty("session")]
        public SessionId Session { get; set; }
    }
}
