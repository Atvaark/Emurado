using System;
using System.IO;
using Microsoft.Owin.FileSystems;

namespace HaloOnline.Server.App
{
    public class AppFileInfo : IFileInfo
    {
        private readonly byte[] _data;
        private readonly string _name;
        private readonly DateTime _lastModified;

        public AppFileInfo(byte[] data, string name, DateTime lastModified)
        {
            _data = data;
            _name = name;
            _lastModified = lastModified;
        }
        
        public Stream CreateReadStream()
        {
            return new MemoryStream(_data, writable: false);
        }

        public long Length
        {
            get { return _data.Length; }
        }

        public string PhysicalPath
        {
            get { return ""; }
        }

        public string Name
        {
            get { return _name; }
        }

        public DateTime LastModified
        {
            get { return _lastModified; }
        }

        public bool IsDirectory
        {
            get { return false; }
        }
    }
}