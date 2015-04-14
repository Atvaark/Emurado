using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.SessionControl
{
    public class GetSessionBasicDataRequest
    {
        // TODO: Validate if the type of Sessions is correct
        [JsonProperty("sessions")]
        public List<SessionId> Sessions { get; set; }
    }
}
