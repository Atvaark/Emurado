namespace HaloOnline.Server.Model.User
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPasswordHash { get; set; }
    }
}