using System.Collections.Generic;
using HaloOnline.Server.Model.Unused;

namespace HaloOnline.Server.Model.Unidentified
{
    /// <summary>
    /// WriteDiagnosticsDataRequest?
    /// </summary>
    public class Header
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