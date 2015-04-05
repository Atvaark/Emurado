namespace HaloOnline.Server.Model.Clan
{
    public class ClanMembershipDataVersioned
    {
        public ClanId Clan { get; set; }
        public int Version { get; set; }
        public ClanMembershipData MembershipData { get; set; }
    }
}
