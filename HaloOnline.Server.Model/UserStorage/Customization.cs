using System.IO;
using System.Linq;
using System.Text;

namespace HaloOnline.Server.Model.UserStorage
{
    public class Customization
    {
        /// <summary>
        /// Big icon next to the username.
        /// </summary>
        public string AccountLabel { get; set; }
        
        public AbstractData Serialize()
        {
            MemoryStream dataStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(dataStream);
            WriteString(writer, AccountLabel);
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
            AccountLabel = ParseString(reader);
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