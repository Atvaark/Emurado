using System.IO;
using System.Linq;
using System.Text;

namespace HaloOnline.Server.Model.Presence
{
    public class GameData
    {
        /// <summary>
        /// Player count or state?
        /// </summary>
        public int Unknown0 { get; set; }
        public string Playlist { get; set; }
        public string Unknown1 { get; set; }
        public string GameMode { get; set; }
        
        public byte[] Serialize()
        {
            MemoryStream dataStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(dataStream);
            writer.Write(Unknown0);
            WriteString(writer, Playlist);
            WriteString(writer, Unknown1);
            WriteString(writer, GameMode);
            return dataStream.ToArray();
        }

        public GameData Deserialize(Stream inputStream)
        {
            GameData gameData = new GameData();
            BinaryReader reader = new BinaryReader(inputStream, Encoding.ASCII, true);
            gameData.Parse(reader);
            return gameData;
        }

        private void Parse(BinaryReader reader)
        {
            Unknown0 = reader.ReadInt32();
            Playlist = ParseString(reader);
            Unknown1 = ParseString(reader);
            GameMode = ParseString(reader);
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