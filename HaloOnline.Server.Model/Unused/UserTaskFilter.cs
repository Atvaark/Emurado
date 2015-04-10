using System.Collections.Generic;

namespace HaloOnline.Server.Model.Unused
{
    public class UserTaskFilter
    {
        public string PropertyName { get; set; }
        public int Operator { get; set; }
        public int ValueType { get; set; }
        public List<string> StringValues { get; set; }
    }
}