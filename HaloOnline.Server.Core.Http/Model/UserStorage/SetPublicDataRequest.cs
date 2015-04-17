using HaloOnline.Server.Model.UserStorage;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.UserStorage
{
    public class SetPublicDataRequest
    {
        [JsonProperty("containerName")]
        public string ContainerName { get; set; }

        [JsonProperty("data")]
        public AbstractData Data { get; set; }
    }
}
