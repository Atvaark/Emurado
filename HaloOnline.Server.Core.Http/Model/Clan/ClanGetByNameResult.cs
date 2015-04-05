using System.Collections.Generic;
using HaloOnline.Server.Model.Clan;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Clan
{
    public class ClanGetByNameResult
    {
        [JsonProperty("ClanGetByNameResult")]
        public ServiceResult<List<ClanId>> Result { get; set; }
    }
}
