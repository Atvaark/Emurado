using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class GetUsersPrimaryStatesRequest
    {
        [JsonProperty("users")]
        public List<UserId> Users { get; set; }
    }
}
