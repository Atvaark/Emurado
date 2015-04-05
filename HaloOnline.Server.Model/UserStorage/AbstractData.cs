using HaloOnline.Server.Model.Serialization;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.UserStorage
{
    public class AbstractData
    {
        public int Layout { get; set; }
        public int Version { get; set; }

        [JsonConverter(typeof (AbstractDataConverter))]
        public byte[] Data { get; set; }
    }
}
