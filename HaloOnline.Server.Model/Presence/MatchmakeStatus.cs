using System.Collections.Generic;

namespace HaloOnline.Server.Model.Presence
{
    public class MatchmakeStatus
    {
        public MatchmakeId Id { get; set; }
        public List<MatchmakeMember> Members { get; set; }
        public int MatchmakeTimer { get; set; }
    }
}
