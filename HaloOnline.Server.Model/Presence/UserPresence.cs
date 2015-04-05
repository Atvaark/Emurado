using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Presence
{
    public class UserPresence
    {
        public UserId User { get; set; }
        public UserPresenceData Data { get; set; }
    }
}
