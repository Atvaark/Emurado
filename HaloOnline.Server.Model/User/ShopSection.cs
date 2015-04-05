using System.Collections.Generic;

namespace HaloOnline.Server.Model.User
{
    public class ShopSection
    {
        public string Name { get; set; }
        public List<ShopShelve> Shelves { get; set; }
    }
}
