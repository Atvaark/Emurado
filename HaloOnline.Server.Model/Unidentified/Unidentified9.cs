using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unidentified
{
    public class Unidentified9
    {
        [JsonProperty("LastEventID")]
        public int LastEventId { get; set; }

        public List<Unidentified7> Events { get; set; }
    }
}