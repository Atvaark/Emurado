using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Messaging
{
    public class SendResult
    {
        [JsonProperty("SendResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
