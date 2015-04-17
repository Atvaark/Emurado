namespace HaloOnline.Server.Model.SessionControl
{
    public class Session
    {
        public string Id { get; set; }

        public string MapId { get; set; }

        public string ModeId { get; set; }

        public int Started { get; set; }

        public int Finished { get; set; }
    }
}