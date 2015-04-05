using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Messaging
{
    public class SendServiceMessageResult
    {
        [JsonProperty("SendServiceMessageResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
