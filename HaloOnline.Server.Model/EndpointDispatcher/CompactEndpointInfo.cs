using Newtonsoft.Json;

namespace HaloOnline.Server.Model.EndpointDispatcher
{
    public class CompactEndpointInfo
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "IP")]
        public string Ip { get; set; }

        public int Port { get; set; }

        /// <summary>
        /// 1 Check client certificate, zipped?
        /// 2
        /// 3 Check client certificate
        /// 4 
        /// </summary>
        public int Protocol { get; set; }
        public bool IsDefault { get; set; }
    }
}
