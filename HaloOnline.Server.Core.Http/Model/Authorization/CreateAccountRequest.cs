namespace HaloOnline.Server.Core.Http.Model.Authorization
{
    public class CreateAccountRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
    }
}