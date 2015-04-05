using System.IO;

namespace HaloOnline.Server.Core.Log.Messages
{
    public class MessagePort : Message
    {
        public override void Read(Stream inputStream)
        {
        }

        public override void Accept(MessageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
