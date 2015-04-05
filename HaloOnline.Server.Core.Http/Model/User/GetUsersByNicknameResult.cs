using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetUsersByNicknameResult
    {
        [JsonProperty("GetUsersByNicknameResult")]
        public ServiceResult<List<UserId>> Result { get; set; }
    }
}
