using System.Collections.Generic;

namespace HaloOnline.Server.Model.User
{
    public class ShopSectionShelve
    {
        public string Name { get; set; }
        public bool IsHot { get; set; }
        public bool IsSale { get; set; }
        public List<string> Items { get; set; }
    }
}
