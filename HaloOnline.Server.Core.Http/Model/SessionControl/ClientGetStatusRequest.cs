using HaloOnline.Server.Model.SessionControl;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.SessionControl
{
    public class ClientGetStatusRequest
    {
        [JsonProperty("session")]
        public SessionId Session { get; set; }
    }
}
