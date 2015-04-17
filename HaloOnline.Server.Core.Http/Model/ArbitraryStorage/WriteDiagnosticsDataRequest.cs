using System.Collections.Generic;
using HaloOnline.Server.Model.ArbitraryStorage;
using HaloOnline.Server.Model.Serialization;
using HaloOnline.Server.Model.Unused;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.ArbitraryStorage
{
    public class WriteDiagnosticsDataRequest : HydraBinaryData
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("properties")]
        public List<KeyStringValuePair> Properties { get; set; }

        [JsonProperty("data")]
        [JsonConverter(typeof(AbstractDataConverter))]
        public byte[] Data { get; set; }
    }
}
