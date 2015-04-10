using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Unused
{
    public class UserTaskScope
    {
        public UserId User { get; set; }
        public TaskId Task { get; set; }
        public int Incr { get; set; }
        public string ScopeId { get; set; }
    }
}