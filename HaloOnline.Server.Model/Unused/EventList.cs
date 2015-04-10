using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unused
{
    public class EventList
    {
        [JsonProperty("LastEventID")]
        public int LastEventId { get; set; }

        public List<Event> Events { get; set; }
    }
}