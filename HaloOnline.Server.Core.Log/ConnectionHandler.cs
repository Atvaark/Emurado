using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using HaloOnline.Server.Core.Log.Messages;

namespace HaloOnline.Server.Core.Log
{
    public class ConnectionHandler
    {
        private readonly TcpClient _client;
        private readonly int _clientPort;
        private readonly IConnection _connection;
        private readonly NetworkStream _networkStream;
        private ConnectionAsyncResult _connectionAsyncResult;

        public ConnectionHandler(TcpClient client, IConnection connection, int clientPort)
        {
            _client = client;
            _connection = connection;
            _clientPort = clientPort;
            _networkStream = _client.GetStream();
            Debug.WriteLine(_client.Client.RemoteEndPoint + " connected");
        }

        public IAsyncResult BeginConnection(AsyncCallback connectionCallback)
        {
            _connectionAsyncResult = new ConnectionAsyncResult(_connection, connectionCallback);
            // TODO: Pass the result to DoBeginConnection and ReadCallback instead of storing it in a field
            DoBeginConnection();
            return _connectionAsyncResult;
        }

        private void DoBeginConnection()
        {
            try
            {
                byte[] buffer = new byte[_client.ReceiveBufferSize];
                _networkStream.BeginRead(buffer, 0, _client.ReceiveBufferSize, ReadCallback, buffer);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error receiving command: " + e);
                Disconnect();
            }
        }

        private void Disconnect()
        {
            if (_client.Connected)
                _client.Close();
            _connectionAsyncResult.IsCompleted = true;
            _connectionAsyncResult.InvokeCallback();
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                int bytesRead = _networkStream.EndRead(ar);
                var remoteEndPoint = _client.Client.RemoteEndPoint as IPEndPoint;
                if (bytesRead == 0)
                {
                    _networkStream.Close();
                    _client.Close();
                    Debug.WriteLine(remoteEndPoint + " disconnected");
                    Disconnect();
                    return;
                }
                byte[] buffer = ar.AsyncState as byte[];
                ReadCommand(remoteEndPoint, buffer);
                DoBeginConnection();
            }
            catch (IOException)
            {
                Disconnect();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error reading command: " + e);
                Disconnect();
            }
        }

        private void ReadCommand(IPEndPoint endPoint, byte[] buffer)
        {
            MemoryStream stream = new MemoryStream(buffer);
            BinaryReader reader = new BinaryReader(stream, Encoding.ASCII, true);

            int commandSize = reader.ReadInt32();
            MessageType messageType = (MessageType) reader.ReadByte();
            // TODO: Handle log packet sequence number

            // TODO: Enable logging when necessary
            //LogMessage(endPoint, buffer, commandSize, messageType);

            Message message = null;
            switch (messageType)
            {
                case MessageType.Message:
                    break;
                case MessageType.MessageHeartbeat:
                    message = new MessageHearbeat();
                    break;
                case MessageType.MessageLog:
                    break;
                case MessageType.MessageCurrentState:
                    break;
                case MessageType.MessageProfileFrame:
                    break;
                case MessageType.MessageSwdFile:
                    break;
                case MessageType.MessageSourceFile:
                    break;
                case MessageType.MessageSwdRequest:
                    break;
                case MessageType.MessageSourceRequest:
                    break;
                case MessageType.MessageAppControl:
                    break;
                case MessageType.MessagePort:
                    message = new MessagePort();
                    break;
                case MessageType.MessageImageRequest:
                    break;
                case MessageType.MessageImageData:
                    break;
                case MessageType.MessageFontRequest:
                    break;
                case MessageType.MessageFontData:
                    break;
                case MessageType.MessageCompressed:
                    break;
                case MessageType.MessageLogin:
                    message = new MessageLogin();
                    break;
                default:
                    Debug.WriteLine("Unknown message: " + messageType);
                    break;
            }

            // HACK: This is to stop clients from spamming the console
            if (message is MessagePort == false)
                Debug.WriteLine(endPoint + ": " + messageType);
            if (message == null) return;
            message.Read(stream);

            var visitor = new UpdateConnectionMessageVisitor(_connection);
            message.Accept(visitor);

            ReplyWithDummyData(endPoint);
        }

        private byte[] CreateDummyPacket(byte messageType, string content, int packetSize)
        {
            MemoryStream stream = new MemoryStream(new byte[packetSize]);
            BinaryWriter writer = new BinaryWriter(stream, Encoding.ASCII, true);
            byte[] encodedContent = Encoding.ASCII.GetBytes(content);

            stream.Position = 4;
            writer.Write(messageType);
            writer.Write(encodedContent, 0, encodedContent.Length);
            int messageSize = (int) stream.Position;
            stream.Position = 0;
            writer.Write(messageSize);
            return stream.ToArray();
        }

        private void ReplyWithDummyData(IPEndPoint endPoint)
        {
            try
            {
                IPEndPoint clientEndPoint = new IPEndPoint(endPoint.Address, _clientPort);
                byte[] tcpPacket = CreateDummyPacket(1, "Hello, I'm a test TCP packet sent by an emulated server.\0",
                    _client.ReceiveBufferSize);
                _networkStream.Write(tcpPacket, 0, tcpPacket.Length);

                byte[] udpPacket = CreateDummyPacket(16, "Hello, I'm a test UDP packet sent by an emulated server.\0",
                    _client.ReceiveBufferSize);
                UdpClient udpClient = new UdpClient();
                udpClient.Send(udpPacket, udpPacket.Length, clientEndPoint);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error replying to client: " + e);
            }
        }

        private static void LogMessage(IPEndPoint endPoint, byte[] buffer, int commandSize, MessageType messageType)
        {
            byte[] useData = new byte[commandSize];
            Buffer.BlockCopy(buffer, 4, useData, 0, commandSize);
            string connectionDirectory = string.Format("{0}\\log\\message\\{1}_{2}",
                AppDomain.CurrentDomain.BaseDirectory, endPoint.Address, endPoint.Port);
            Directory.CreateDirectory(connectionDirectory);
            var filePath = Path.Combine(connectionDirectory,
                string.Format("{0}_{1:0000}_{2}", messageType, commandSize, Guid.NewGuid()));
            File.WriteAllBytes(filePath, useData);
        }
    }
}
