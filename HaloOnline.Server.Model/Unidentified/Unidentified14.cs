using System.CodeDom;
using System.Collections.Generic;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Unidentified
{
    public class Unidentified14
    {
        public Unidentified15 Id { get; set; }
        public string EventName { get; set; }

        public List<Unidentified16> Filters { get; set; }

    }

    public class Unidentified16
    {
        public string PropertyName { get; set; }
        public int Operator { get; set; }
        public int ValueType { get; set; }
        public List<string> StringValues { get; set; }
    }

    /// <summary>
    /// Task?
    /// </summary>
    public class Unidentified15
    {
        public int Id { get; set; }
    }

    public class Unidentified17
    {
        public List<Unidentified14> Items { get; set; }
    }

    public class Unidentified18
    {
        public UserId User { get; set; }
        public Unidentified17 UserTasks { get; set; }
    }

    public class Unidentified19
    {
        public UserId User { get; set; }
        public Unidentified15 Task { get; set; }
        public int Incr { get; set; }
        public string ScopeId { get; set; }
    }
}