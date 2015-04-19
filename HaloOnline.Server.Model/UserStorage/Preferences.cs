using System.IO;
using System.Text;

namespace HaloOnline.Server.Model.UserStorage
{
    public class Preferences
    {
        public int LastReadNewsUnknownValue { get; set; }
        public string LastReadNewsName { get; set; }


        public AbstractData Serialize()
        {
            return new AbstractData();
        }

        public static Preferences Deserialize(AbstractData abstractData)
        {
            MemoryStream dataStream = new MemoryStream(abstractData.Data);
            BinaryReader reader = new BinaryReader(dataStream);
            Preferences preferences = new Preferences();
            dataStream.Position = 32772;
            preferences.ReadLastReadNews(reader);
            return preferences;;
        }

        private void ReadLastReadNews(BinaryReader reader)
        {
            LastReadNewsUnknownValue = reader.ReadInt32();
            LastReadNewsName = ParseString(reader);
        }



        private string ParseString(BinaryReader reader)
        {
            byte[] stringBuffer = reader.ReadBytes(32);
            return Encoding.ASCII.GetString(stringBuffer).TrimEnd('\0');
        }
    }
}