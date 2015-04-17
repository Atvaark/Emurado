namespace HaloOnline.Server.Model.Presence
{
    public class PartyMember
    {
        public string PartyId { get; set; }

        public int UserId { get; set; }

        public string SessionId { get; set; }

        public bool IsOwner { get; set; } 
    }
}