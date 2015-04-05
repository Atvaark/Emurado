using System;
using System.Threading;
using HaloOnline.Server.Core.Http;
using HaloOnline.Server.Core.Log;

namespace HaloOnline.Server
{
    public class Program
    {
        private const int ClientPort = 11774;
        private const int LogServerPort = 27027;
        private const int ServiceServerPort = 11705;
        private const int DispatcherServiceServerPort = 44300;

        private static void Main(string[] args)
        {
            LogListener logListener = new LogListener(LogServerPort, ClientPort);
            SelfHost host = new SelfHost(ServiceServerPort, DispatcherServiceServerPort);
            host.Start();
            logListener.BeginListen();
            bool listen = true;
            while (listen)
            {
                Console.Clear();
                Console.WriteLine("Halo Online Server");
                Console.WriteLine("Listening on port " + LogServerPort);
                Console.WriteLine("Press escape to exit");
                Console.WriteLine("");
                Console.WriteLine("Connections:");
                foreach (var connection in logListener.GetConnectionList())
                {
                    string connectionState = connection.Connected ? "connected" : "disconnected";
                    Console.WriteLine("#{0} {1} {2} {3} {4}",
                        connection.Id,
                        connection.ClientId,
                        connection.ClientName,
                        connection.ClientComputerName,
                        connectionState);
                }
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    listen = false;
                Thread.Sleep(100);
            }
            host.End();
            logListener.EndListen();
        }
    }
}
