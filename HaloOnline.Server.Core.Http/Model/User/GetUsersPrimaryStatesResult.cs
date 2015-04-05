using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetUsersPrimaryStatesResult
    {
        [JsonProperty("GetUsersPrimaryStatesResult")]
        public ServiceResult<List<UserPrimaryStates>> Result { get; set; }
    }
}
