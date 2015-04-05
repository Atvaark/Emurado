using HaloOnline.Server.Model.Clan;

namespace HaloOnline.Server.Model.User
{
    public class UserBaseData
    {
        public UserId User { get; set; }
        public string Nickname { get; set; }
        public string BattleTag { get; set; }
        public int Level { get; set; }
        public ClanId Clan { get; set; }
        public string ClanTag { get; set; }
    }
}
