namespace HaloOnline.Server.Model.Clan
{
    public class ClanBaseDataVersioned
    {
        public ClanId Clan { get; set; }
        public int Version { get; set; }
        public ClanBaseData BaseData { get; set; }
    }
}
