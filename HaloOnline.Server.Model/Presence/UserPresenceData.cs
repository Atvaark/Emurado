namespace HaloOnline.Server.Model.Presence
{
    public class UserPresenceData
    {
        /// <summary>
        /// 0 Offline
        /// 1 Online
        /// 2 Ingame
        /// </summary>
        public int State { get; set; }
        public bool IsInvitable { get; set; }
    }
}
