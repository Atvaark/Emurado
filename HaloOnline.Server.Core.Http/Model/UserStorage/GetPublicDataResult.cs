using System.Collections.Generic;
using HaloOnline.Server.Model.UserStorage;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.UserStorage
{
    public class GetPublicDataResult
    {
        [JsonProperty("GetPublicDataResult")]
        public ServiceResult<List<PerUser>> Result { get; set; }
    }
}
