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
    public class XHydraBinaryFormatter : MediaTypeFormatter
    {
        private static readonly Type XHydraBinaryDataType = typeof(XHydraBinaryData);
        private readonly JsonMediaTypeFormatter _jsonFormatter;

        public XHydraBinaryFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-hydra-binary"));
            _jsonFormatter = new JsonMediaTypeFormatter();
        }

        public override bool CanReadType(Type type)
        {
            return XHydraBinaryDataType.IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            try
            {
                XHydraBinaryData xHydraBinaryData = ReadXHydraBinaryData(type, readStream, formatterLogger);
                taskCompletionSource.SetResult(xHydraBinaryData);
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
            return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }

        private XHydraBinaryData ReadXHydraBinaryData(Type type, Stream readStream, IFormatterLogger formatterLogger)
        {
            BinaryReader reader = new BinaryReader(readStream, Encoding.ASCII, true);
            int unknown = reader.ReadInt32();
            int requestSize = reader.ReadInt32();
            int payloadSize = reader.ReadInt32();
            var xHydraBinaryData = (XHydraBinaryData)_jsonFormatter.ReadFromStream(type, readStream, Encoding.ASCII, formatterLogger);
            xHydraBinaryData.Payload = reader.ReadBytes(payloadSize);
            return xHydraBinaryData;
        }
    }
}