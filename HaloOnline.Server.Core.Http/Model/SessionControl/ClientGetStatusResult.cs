using HaloOnline.Server.Model.SessionControl;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.SessionControl
{
    public class ClientGetStatusResult
    {
        [JsonProperty("ClientGetStatusResult")]
        public ServiceResult<ClientStatus> Result { get; set; }
    }
}
