using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.UserStorage
{
    public class SetPrivateDataResult
    {
        [JsonProperty("SetPrivateDataResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
