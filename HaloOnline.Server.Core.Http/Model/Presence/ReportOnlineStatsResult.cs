using HaloOnline.Server.Model.Presence;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class ReportOnlineStatsResult
    {
        [JsonProperty("ReportOnlineStatsResult")]
        public ServiceResult<OnlineStats> Result { get; set; }
    }
}
