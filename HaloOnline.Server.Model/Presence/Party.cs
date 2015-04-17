namespace HaloOnline.Server.Model.Presence
{
    public class Party
    {
        public string Id { get; set; }

        public int MatchmakeState { get; set; }

        public byte[] GameData { get; set; }
    }
}