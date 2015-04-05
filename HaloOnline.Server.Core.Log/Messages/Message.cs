using System.IO;

namespace HaloOnline.Server.Core.Log.Messages
{
    public abstract class Message
    {
        public abstract void Read(Stream inputStream);
        public abstract void Accept(MessageVisitor visitor);
    }
}
