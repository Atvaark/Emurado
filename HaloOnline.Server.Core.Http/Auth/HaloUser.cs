namespace HaloOnline.Server.Core.Http.Auth
{
    public class HaloUser : IHaloUser
    {

        public string Id
        {
            get { return UserId.ToString(); }
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPasswordHash { get; set; }
    }
}
