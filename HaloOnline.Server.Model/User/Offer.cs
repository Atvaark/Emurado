namespace HaloOnline.Server.Model.User
{
    public class Offer
    {
        public string OfferId { get; set; }
        public string Currency { get; set; }
        public int Price { get; set; }
        public int ExpireAt { get; set; }
        public Sale Sale { get; set; }
    }
}
