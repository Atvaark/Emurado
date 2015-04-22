using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace HaloOnline.Server.Core.Log
{
    public class LogListener
    {
        private readonly int _clientPort;
        private readonly object _connectionLock = new object();
        private readonly Dictionary<int, IConnection> _connections;
        private readonly TcpListener _tcpListener;
        private int _nextConnectionId;

        public LogListener(int serverPort, int clientPort)
        {
            _clientPort = clientPort;
            IPHostEntry ipHostEntry = Dns.GetHostEntry("");
            IPAddress ipAddress = ipHostEntry.AddressList.First(a => a.AddressFamily == AddressFamily.InterNetwork);
            _tcpListener = new TcpListener(new IPEndPoint(ipAddress, serverPort));
            _connections = new Dictionary<int, IConnection>();
        }

        public void Start()
        {
            _tcpListener.Start();
            BeginAccept();
        }

        private void BeginAccept()
        {
            _tcpListener.BeginAcceptTcpClient(AcceptTcpClient, null);
        }

        private void AcceptTcpClient(IAsyncResult ar)
        {
            try
            {
                TcpClient client = _tcpListener.EndAcceptTcpClient(ar);

                lock (_connectionLock)
                {
                    int connectionId = _nextConnectionId++;
                    var connection = new Connection(connectionId) {Connected = true};
                    _connections[connectionId] = connection;
                    var connectionHandler = new ConnectionHandler(client, connection, _clientPort);
                    connectionHandler.BeginConnection(DisconnectConnection);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error accepting new client " + e);
            }

            BeginAccept();
        }

        private void DisconnectConnection(IAsyncResult ar)
        {
            IConnection connection = ar.AsyncState as IConnection;
            if (connection == null)
                return;
            connection.Connected = false;

            lock (_connectionLock)
            {
                _connections.Remove(connection.Id);
            }
        }

        public void Stop()
        {
            _tcpListener.Stop();
        }

        public List<IConnection> GetConnectionList()
        {
            lock (_connectionLock)
            {
                return _connections.Values.ToList();
            }
        }
    }
}
