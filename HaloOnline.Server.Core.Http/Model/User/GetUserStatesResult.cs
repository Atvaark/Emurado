using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetUserStatesResult
    {
        [JsonProperty("GetUserStatesResult")]
        public ServiceResult<UserStatesAndTimestamp> Result { get; set; }
    }
}
