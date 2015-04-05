namespace HaloOnline.Server.Core.Http.Auth
{
    public class HaloUser : IHaloUser
    {
        public string UserPasswordHash { get; set; }

        public string Id
        {
            get { return UserId.ToString(); }
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
