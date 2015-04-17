using System.Collections.Generic;
using HaloOnline.Server.Model.SessionControl;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.SessionControl
{
    public class GetSessionBasicDataRequest
    {
        // TODO: Validate if the type of Sessions is correct
        [JsonProperty("sessions")]
        public List<SessionId> Sessions { get; set; }
    }
}
