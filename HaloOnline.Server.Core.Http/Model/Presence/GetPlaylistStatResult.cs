using System.Collections.Generic;
using HaloOnline.Server.Model.Presence;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Presence
{
    public class GetPlaylistStatResult
    {
        [JsonProperty("GetPlaylistStatResult")]
        public ServiceResult<List<PlaylistStat>> Result { get; set; }
    }
}
