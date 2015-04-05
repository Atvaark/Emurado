using System.IO;
using System.Text;

namespace HaloOnline.Server.Core.Log.Messages
{
    public class MessageLogin : Message
    {
        public string LoginMessage { get; set; }
        public int Unknown0 { get; set; }
        public short Unknown1 { get; set; }

        public override void Read(Stream inputStream)
        {
            BinaryReader reader = new BinaryReader(inputStream, Encoding.ASCII, true);
            LoginMessage = reader.ReadCommandString();
            Unknown0 = reader.ReadInt32();
            Unknown1 = reader.ReadInt16();
        }

        public override void Accept(MessageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
