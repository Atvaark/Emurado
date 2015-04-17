using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Presence
{
    public class GetPlaylistStatRequest
    {
        // TODO: Validate type of Playlists
        [JsonProperty("playlists")]
        public List<string> Playlists { get; set; }
    }
}
