using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.UserStorage
{
    public class GetPublicDataRequest
    {
        [JsonProperty("users")]
        public List<UserId> Users { get; set; }

        [JsonProperty("containerName")]
        public string ContainerName { get; set; }
    }
}
