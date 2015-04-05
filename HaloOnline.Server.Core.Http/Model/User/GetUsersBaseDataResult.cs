using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetUsersBaseDataResult
    {
        [JsonProperty("GetUsersBaseDataResult")]
        public ServiceResult<List<UserBaseData>> Result { get; set; }
    }
}
