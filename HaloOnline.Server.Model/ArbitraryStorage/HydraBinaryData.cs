using Newtonsoft.Json;

namespace HaloOnline.Server.Model.ArbitraryStorage
{
    public class HydraBinaryData
    {
        [JsonIgnore]
        public byte[] Payload { get; set; }
    }
}