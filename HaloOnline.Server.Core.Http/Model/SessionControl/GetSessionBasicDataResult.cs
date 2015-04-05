using System.Collections.Generic;
using HaloOnline.Server.Model.SessionControl;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.SessionControl
{
    public class GetSessionBasicDataResult
    {
        [JsonProperty("GetSessionBasicDataResult")]
        public ServiceResult<List<SessionBasicData>> Result { get; set; }
    }
}
