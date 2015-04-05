using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.UserStorage
{
    public class SetPublicDataResult
    {
        [JsonProperty("SetPublicDataResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
