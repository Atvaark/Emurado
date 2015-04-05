using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.ArbitraryStorage
{
    public class WriteAdfPackResult
    {
        [JsonProperty("WriteADFPackResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
