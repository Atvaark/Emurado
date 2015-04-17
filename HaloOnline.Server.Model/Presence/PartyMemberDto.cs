using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Presence
{
    public class PartyMemberDto
    {
        public UserId User { get; set; }
        public bool IsOwner { get; set; }
    }
}
