using System.Collections.Generic;

namespace HaloOnline.Server.Model.User
{
    public class Shop
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Race { get; set; }
        public List<ShopSection> Sections { get; set; }
    }
}
