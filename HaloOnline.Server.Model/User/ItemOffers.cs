using System.Collections.Generic;

namespace HaloOnline.Server.Model.User
{
    public class ItemOffers
    {
        public string ItemId { get; set; }
        public List<string> Requirements { get; set; }
        public List<string> Unlocks { get; set; }
        public List<BundleItem> BundleItems { get; set; }
        public int UnlockedLevel { get; set; }
        public List<OfferLine> OfferLine { get; set; }
    }
}
