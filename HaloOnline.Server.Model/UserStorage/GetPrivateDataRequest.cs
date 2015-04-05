using Newtonsoft.Json;

namespace HaloOnline.Server.Model.UserStorage
{
    public class GetPrivateDataRequest
    {
        [JsonProperty("containerName")]
        public string ContainerName { get; set; }

        [JsonProperty("data")]
        public AbstractData Data { get; set; }
    }
}
