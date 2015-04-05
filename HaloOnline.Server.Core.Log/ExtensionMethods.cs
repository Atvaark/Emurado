using System.IO;

namespace HaloOnline.Server.Core.Log
{
    internal static class ExtensionMethods
    {
        internal static string ReadCommandString(this BinaryReader reader)
        {
            int size = reader.ReadInt32();
            return new string(reader.ReadChars(size));
        }
    }
}
