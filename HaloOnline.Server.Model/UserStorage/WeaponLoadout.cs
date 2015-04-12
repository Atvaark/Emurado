using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HaloOnline.Server.Model.UserStorage
{
    public class WeaponLoadout
    {
        public WeaponLoadout()
        {
            LoadoutSlots = new List<WeaponLoadoutSlot>();
        }

        public List<WeaponLoadoutSlot> LoadoutSlots { get; set; }
        public int ActiveLoadoutSlotIndex { get; set; }
        
        public AbstractData Serialize()
        {
            MemoryStream dataStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(dataStream);
            writer.Write(ActiveLoadoutSlotIndex);
            foreach (var slot in LoadoutSlots)
            {
                WriteString(writer, slot.PrimaryWeapon);
                WriteString(writer, slot.SecondaryWeapon);
                WriteString(writer, slot.Grenades);
                WriteString(writer, slot.Booster);
                WriteString(writer, slot.ConsumableFirst);
                WriteString(writer, slot.ConsumableSecond);
                WriteString(writer, slot.ConsumableThird);
                WriteString(writer, slot.ConsumableFourth);
            }
            return new AbstractData
            {
                Version = 0,
                Layout = 1,
                Data = dataStream.ToArray()
            };
        }


        // TODO: Cleanup serialization methods and move them to their own class
        public static WeaponLoadout Deserialize(AbstractData abstractData)
        {
            MemoryStream dataStream = new MemoryStream(abstractData.Data);
            BinaryReader reader = new BinaryReader(dataStream);
            WeaponLoadout weaponLoadout = new WeaponLoadout();
            weaponLoadout.ParseWeaponLoadoutSlots(reader);
            return weaponLoadout;
        }

        private void ParseWeaponLoadoutSlots(BinaryReader reader)
        {
            List<WeaponLoadoutSlot> loadoutSlots = new List<WeaponLoadoutSlot>();
            for (int i = 0; i < 5; i++)
            {
                var loadoutSlot = ParseWeaponLoadoutSlot(reader);
                loadoutSlots.Add(loadoutSlot);
            }
            LoadoutSlots = loadoutSlots;
        }
        
        private WeaponLoadoutSlot ParseWeaponLoadoutSlot(BinaryReader reader)
        {
            return new WeaponLoadoutSlot
            {
                PrimaryWeapon = ParseString(reader),
                SecondaryWeapon = ParseString(reader),
                Grenades = ParseString(reader),
                Booster = ParseString(reader),
                ConsumableFirst = ParseString(reader)
            };
        }

        private string ParseString(BinaryReader reader)
        {
            byte[] stringBuffer = reader.ReadBytes(32);
            return Encoding.ASCII.GetString(stringBuffer).TrimEnd('\0');
        }

        private void WriteString(BinaryWriter writer, string data)
        {
            var nulls = (32 - data.Length % 33);
            var s = data + new string(Enumerable.Repeat('\0', nulls).ToArray());
            var bytes = Encoding.ASCII.GetBytes(s);
            writer.Write(bytes);
        }
    }
}