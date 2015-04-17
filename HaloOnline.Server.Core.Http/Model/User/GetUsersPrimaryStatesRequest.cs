using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetUsersPrimaryStatesRequest
    {
        [JsonProperty("users")]
        public List<UserId> Users { get; set; }
    }
}
