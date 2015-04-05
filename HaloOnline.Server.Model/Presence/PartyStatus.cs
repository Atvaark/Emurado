using System.Collections.Generic;

namespace HaloOnline.Server.Model.Presence
{
    public class PartyStatus
    {
        public PartyId Party { get; set; }
        public List<SessionMember> SessionMembers { get; set; }
        public int MatchmakeState { get; set; }
        public byte[] GameData { get; set; }
    }
}
