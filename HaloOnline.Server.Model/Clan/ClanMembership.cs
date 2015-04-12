namespace HaloOnline.Server.Model.Clan
{
    public class ClanMembership
    {
        public int UserId { get; set; }

        public int ClanId { get; set; }

        // TODO: Analyze which roles are available
        public int Role { get; set; } 
    }
}