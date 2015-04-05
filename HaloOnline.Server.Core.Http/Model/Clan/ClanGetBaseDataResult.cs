using System.Collections.Generic;
using HaloOnline.Server.Model.Clan;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Clan
{
    public class ClanGetBaseDataResult
    {
        [JsonProperty("ClanGetBaseDataResult")]
        public ServiceResult<List<ClanBaseDataVersioned>> Result { get; set; }
    }
}
