using System.Collections.Generic;

namespace HaloOnline.Server.Model.ArbitraryStorage
{
    public class AdfPackHeader
    {
        public string SessionId { get; set; }
        public string Format { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int PackNumber { get; set; }
        public int Flags { get; set; }
        public int InitTime { get; set; }
        public List<ContextProperty> Context { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}