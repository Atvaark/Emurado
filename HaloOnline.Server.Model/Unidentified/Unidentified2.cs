using System.Collections.Generic;

namespace HaloOnline.Server.Model.Unidentified
{
    public class Unidentified2
    {
        public string SessionId { get; set; }
        public string Format { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int PackNumber { get; set; }
        public int Flags { get; set; }
        public int InitTime { get; set; }
        public List<Unidentified3> Context { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}