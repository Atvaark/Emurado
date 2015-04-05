using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Presence
{
    public class MatchmakeMember
    {
        public UserId User { get; set; }
        public PartyId Party { get; set; }
    }
}
