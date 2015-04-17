using System.Collections.Generic;

namespace HaloOnline.Server.Model.Presence
{
    public class PartyStatus
    {
        public PartyId Party { get; set; }

        public List<PartyMemberDto> SessionMembers { get; set; }

        /// <summary>
        /// 0 None
        /// 1 Formation
        /// 2 In Queue
        /// 3 In Game
        /// </summary>
        public int MatchmakeState { get; set; }

        public byte[] GameData { get; set; }
    }
}
