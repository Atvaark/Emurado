using Newtonsoft.Json;

namespace HaloOnline.Server.Model.EndpointDispatcher
{
    public class CompactEndpointInfo
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "IP")]
        public string Ip { get; set; }

        public int Port { get; set; }
        public int Protocol { get; set; }
        public bool IsDefault { get; set; }
    }
}
