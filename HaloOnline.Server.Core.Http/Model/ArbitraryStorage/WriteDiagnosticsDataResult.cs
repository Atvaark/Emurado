using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.ArbitraryStorage
{
    public class WriteDiagnosticsDataResult
    {
        [JsonProperty("WriteDiagnosticsDataResult")]
        public ServiceResult<bool> Result { get; set; }
    }
}
