using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HaloOnline.Server.Model.UserStorage
{
    public class ArmorLoadout
    {
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string VisorColor { get; set; }
        public string LightsColor { get; set; }
        public string HologramsColor { get; set; }
        public List<ArmorLoadoutSlot> Slots { get; set; }
        // TODO: Move to a serialization class. This is not a concern of the class.

        public AbstractData Serialize()
        {
            MemoryStream dataStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(dataStream);
            WriteString(writer, PrimaryColor);
            WriteString(writer, SecondaryColor);
            WriteString(writer, VisorColor);
            WriteString(writer, LightsColor);
            WriteString(writer, HologramsColor);
            foreach (var slot in Slots)
            {
                WriteString(writer, slot.Head);
                WriteString(writer, slot.Shoulders);
                WriteString(writer, slot.Torso);
                WriteString(writer, slot.Hands);
                WriteString(writer, slot.Legs);
                WriteString(writer, slot.Reserved);
            }
            writer.Write(0);
            AbstractData abstractData = new AbstractData
            {
                Version = 1,
                Layout = 1,
                Data = dataStream.ToArray()
            };
            return abstractData;
        }

        public static ArmorLoadout Deserialize(AbstractData abstractData)
        {
            MemoryStream dataStream = new MemoryStream(abstractData.Data);
            BinaryReader reader = new BinaryReader(dataStream);
            ArmorLoadout armorLoadout = new ArmorLoadout();
            armorLoadout.ParseColors(reader);
            armorLoadout.ParseLoadoutSlots(reader);
            return armorLoadout;
        }

        private string ParseString(BinaryReader reader)
        {
            reader.ReadInt32();
            byte[] stringBuffer = reader.ReadBytes(28);
            return Encoding.ASCII.GetString(stringBuffer).TrimEnd('\0');
        }

        private void WriteString(BinaryWriter writer, string data)
        {
            writer.Write(0);
            var nulls = (28 - data.Length%29);
            var s = data + new string(Enumerable.Repeat('\0', nulls).ToArray());
            var bytes = Encoding.ASCII.GetBytes(s);
            writer.Write(bytes);
        }

        private void ParseColors(BinaryReader reader)
        {
            PrimaryColor = ParseString(reader);
            SecondaryColor = ParseString(reader);
            VisorColor = ParseString(reader);
            LightsColor = ParseString(reader);
            HologramsColor = ParseString(reader);
        }

        private void ParseLoadoutSlots(BinaryReader reader)
        {
            List<ArmorLoadoutSlot> loadoutSlots = new List<ArmorLoadoutSlot>();
            for (int i = 0; i < 5; i++)
            {
                ArmorLoadoutSlot loadoutSlot = ParseLoadoutSlot(reader);
                loadoutSlots.Add(loadoutSlot);
            }
            Slots = loadoutSlots;
        }

        private ArmorLoadoutSlot ParseLoadoutSlot(BinaryReader reader)
        {
            ArmorLoadoutSlot slot = new ArmorLoadoutSlot
            {
                Head = ParseString(reader),
                Shoulders = ParseString(reader),
                Torso = ParseString(reader),
                Hands = ParseString(reader),
                Legs = ParseString(reader),
                Reserved = ParseString(reader)
            };

            return slot;
        }
    }
}
