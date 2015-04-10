using System.IO;

namespace HaloOnline.Server.Model.UserStorage
{
    public class Customization
    {
        public int Unknown1 { get; set; }
        public int Unknown2 { get; set; }
        public int Unknown3 { get; set; }
        public int Unknown4 { get; set; }
        public int Unknown5 { get; set; }
        public int Unknown6 { get; set; }
        public int Unknown7 { get; set; }
        public int Unknown8 { get; set; }


        public AbstractData Serialize()
        {
            MemoryStream dataStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(dataStream);
            writer.Write(Unknown1);
            writer.Write(Unknown2);
            writer.Write(Unknown3);
            writer.Write(Unknown4);
            writer.Write(Unknown5);
            writer.Write(Unknown6);
            writer.Write(Unknown7);
            writer.Write(Unknown8);
            return new AbstractData
            {
                Version = 0,
                Layout = 1,
                Data = dataStream.ToArray()
            };
        }

        public static Customization Deserialize(AbstractData abstractData)
        {
            MemoryStream dataStream = new MemoryStream(abstractData.Data);
            BinaryReader reader = new BinaryReader(dataStream);
            
            var customization = new Customization();
            customization.ParseCustomization(reader);
            return customization;
        }

        private void ParseCustomization(BinaryReader reader)
        {
            Unknown1 = reader.ReadInt32();
            Unknown2 = reader.ReadInt32();
            Unknown3 = reader.ReadInt32();
            Unknown4 = reader.ReadInt32();
            Unknown5 = reader.ReadInt32();
            Unknown6 = reader.ReadInt32();
            Unknown7 = reader.ReadInt32();
            Unknown8 = reader.ReadInt32();
        }

    }
}