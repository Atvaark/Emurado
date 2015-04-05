using System.IO;
using System.Text;

namespace HaloOnline.Server.Core.Log.Messages
{
    public class MessageHearbeat : Message
    {
        public string ClientComputerName { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }

        public override void Read(Stream inputStream)
        {
            BinaryReader reader = new BinaryReader(inputStream, Encoding.ASCII, true);

            int unknown0 = reader.ReadByte();
            int unknown1 = reader.ReadByte();
            int unknown2 = reader.ReadByte();
            uint unknown3 = reader.ReadUInt32();
            int unknown4 = reader.ReadInt32();
            int unknown5 = reader.ReadInt32();
            int unknown6 = reader.ReadInt32();
            int unknown7 = reader.ReadInt32();
            int unknown8 = reader.ReadInt32();
            int unknown9 = reader.ReadInt32();
            ClientName = reader.ReadCommandString();
            ClientId = reader.ReadCommandString();
            ClientComputerName = reader.ReadCommandString();
        }

        public override void Accept(MessageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
