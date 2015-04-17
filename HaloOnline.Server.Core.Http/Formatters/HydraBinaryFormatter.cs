using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HaloOnline.Server.Model.ArbitraryStorage;

namespace HaloOnline.Server.Core.Http.Formatters
{
    public class HydraBinaryFormatter : MediaTypeFormatter
    {
        private static readonly Type HydraBinaryDataType = typeof(HydraBinaryData);
        private readonly JsonMediaTypeFormatter _jsonFormatter;

        public HydraBinaryFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-hydra-binary"));
            _jsonFormatter = new JsonMediaTypeFormatter();
        }

        public override bool CanReadType(Type type)
        {
            return HydraBinaryDataType.IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            return HydraBinaryDataType.IsAssignableFrom(type);
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            try
            {
                taskCompletionSource.SetResult(ReadXHydraBinaryData(type, readStream, formatterLogger));
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }
            return taskCompletionSource.Task;
        }


        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            return Task.Factory.StartNew(() =>
            {
                WriteXHydraBinaryData(type, value as HydraBinaryData, writeStream);
            });
        }

        private HydraBinaryData ReadXHydraBinaryData(Type type, Stream readStream, IFormatterLogger formatterLogger)
        {
            BinaryReader reader = new BinaryReader(readStream, Encoding.UTF8, true);
            int unknown = reader.ReadInt32();
            int dataSize = reader.ReadInt32();
            int payloadSize = reader.ReadInt32();
            var xHydraBinaryData = (HydraBinaryData)_jsonFormatter.ReadFromStream(type, readStream, Encoding.ASCII, formatterLogger);
            xHydraBinaryData.Payload = reader.ReadBytes(payloadSize);
            return xHydraBinaryData;
        }

        private void WriteXHydraBinaryData(Type type, HydraBinaryData value, Stream writeStream)
        {
            var dataStream = new MemoryStream();
            _jsonFormatter.WriteToStream(type, value, dataStream, Encoding.UTF8);
            BinaryWriter writer = new BinaryWriter(writeStream, Encoding.UTF8, true);
            writer.Write(5);
            writer.Write((int)dataStream.Length);
            writer.Write(value.Payload.Length);
            dataStream.CopyTo(writeStream);
            writer.Write(value.Payload);
        }
    }
}