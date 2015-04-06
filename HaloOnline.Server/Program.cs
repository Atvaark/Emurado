using System;
using System.Threading;
using HaloOnline.Server.App;
using HaloOnline.Server.Common;
using HaloOnline.Server.Core.Http;
using HaloOnline.Server.Core.Log;

namespace HaloOnline.Server
{
    public class Program
    {

        private static void Main(string[] args)
        {
            var options = new ServerOptions
            {
                DispatcherPort = Properties.Settings.Default.DispatcherPort,
                EndpointHostname = Properties.Settings.Default.EndpointHostname,
                EndpointPort = Properties.Settings.Default.EndpointPort,
                LogPort = Properties.Settings.Default.LogPort,
                AppPort = Properties.Settings.Default.AppPort,
                ClientPort = Properties.Settings.Default.ClientPort
            };
            LogListener logListener = new LogListener(options.LogPort, options.ClientPort);
            ApiSelfHost apiHost = new ApiSelfHost(options);
            AppSelfHost appHost = new AppSelfHost(options);
            apiHost.Start();
            appHost.Start();
            logListener.BeginListen();
            bool listen = true;
            while (listen)
            {
                Console.Clear();
                Console.WriteLine("Halo Online Server");
                Console.WriteLine("Dispatcher port: " + options.DispatcherPort);
                Console.WriteLine("Endpoint port: " + options.EndpointPort);
                Console.WriteLine("App port: " + options.AppPort);
                Console.WriteLine("Log port: " + options.LogPort);
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
            appHost.End();
            apiHost.End();
            logListener.EndListen();
        }
    }
}
