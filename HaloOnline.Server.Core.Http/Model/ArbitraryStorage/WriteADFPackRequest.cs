using HaloOnline.Server.Model.ArbitraryStorage;
using HaloOnline.Server.Model.Serialization;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.ArbitraryStorage
{
    public class WriteADFPackRequest : HydraBinaryData
    {
        [JsonProperty("header")]
        public AdfPackHeader Header { get; set; }

        [JsonProperty("entries")]
        [JsonConverter(typeof(AbstractDataConverter))]
        public byte[] Entries { get; set; }

        [JsonProperty("data")]
        [JsonConverter(typeof(AbstractDataConverter))]
        public byte[] Data { get; set; }
    }
}