using System.Collections.Generic;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class GetItemOffersRequest
    {
        // TODO: Validate type of Items
        [JsonProperty("items")]
        public List<string> Items { get; set; }
    }
}
