using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Unidentified
{
    /// <summary>
    /// Event
    /// </summary>
    public class Unidentified7 
    {
        public int Event { get; set; }
        public UserId User { get; set; }
        public Unidentified8 UserSignature { get; set; }
        public int TeamId { get; set; }

    }
}