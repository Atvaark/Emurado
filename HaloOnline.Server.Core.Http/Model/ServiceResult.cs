using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model
{
    public class ServiceResult<T>
    {

        /// <summary>
        /// The error message.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        ///     The return code specifies whether the service call was successful or not.
        ///     0 signifies that the call was successful.
        ///     Any other number signifies an error.
        /// </summary>
        [JsonProperty(PropertyName = "retCode")]
        public int ReturnCode { get; set; }

        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }
    }
}
