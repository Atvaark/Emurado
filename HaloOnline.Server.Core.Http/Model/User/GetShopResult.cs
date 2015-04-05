using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetShopResult
    {
        [JsonProperty("GetShopResult")]
        public ServiceResult<List<Shop>> Result { get; set; }
    }
}
