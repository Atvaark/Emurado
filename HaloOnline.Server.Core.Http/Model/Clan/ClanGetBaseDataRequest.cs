using System.Collections.Generic;
using HaloOnline.Server.Model.Clan;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Clan
{
    public class ClanGetBaseDataRequest
    {
        // TODO: Verify if the type of Clans is correct
        [JsonProperty("clans")]
        public List<ClanId> Clans { get; set; }
    }
}
