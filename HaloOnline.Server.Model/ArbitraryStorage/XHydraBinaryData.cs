using Newtonsoft.Json;

namespace HaloOnline.Server.Model.ArbitraryStorage
{
    public class XHydraBinaryData
    {
        [JsonIgnore]
        public byte[] Payload { get; set; }
    }
}