using HaloOnline.Server.Model.UserStorage;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.UserStorage
{
    public class GetPrivateDataResult
    {
        [JsonProperty("GetPrivateDataResult")]
        public ServiceResult<AbstractData> Result { get; set; }
    }
}
