using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class GetItemOffersRequest
    {
        [JsonProperty("items")]
        public List<object> Items { get; set; }
    }
}
