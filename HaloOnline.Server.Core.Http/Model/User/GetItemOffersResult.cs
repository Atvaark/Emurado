using System.Collections.Generic;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.User
{
    public class GetItemOffersResult
    {
        [JsonProperty("GetItemOffersResult")]
        public ServiceResult<List<ItemOffers>> Result { get; set; }
    }
}
