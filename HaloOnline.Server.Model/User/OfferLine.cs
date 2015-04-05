using System.Collections.Generic;

namespace HaloOnline.Server.Model.User
{
    public class OfferLine
    {
        public int Duration { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
