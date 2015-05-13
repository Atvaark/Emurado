using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using HaloOnline.Server.App;
using HaloOnline.Server.Common;
using HaloOnline.Server.Core.Http;
using HaloOnline.Server.Core.Log;
using HaloOnline.Server.Core.Scheduler;
using HaloOnline.Server.Properties;

namespace HaloOnline.Server
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var options = new ServerOptions
            {
                DispatcherPort = Settings.Default.DispatcherPort,
                EndpointHostname = Settings.Default.EndpointHostname,
                EndpointPort = Settings.Default.EndpointPort,
                LogPort = Settings.Default.LogPort,
                AppPort = Settings.Default.AppPort,
                ClientPort = Settings.Default.ClientPort,
                Secret = Settings.Default.Secret
            };
            LogListener logHost = new LogListener(options.LogPort, options.ClientPort);
            ApiSelfHost apiHost = new ApiSelfHost(options);
            AppSelfHost appHost = new AppSelfHost(options);
            JobScheduler jobScheduler = new JobScheduler();
            apiHost.Start();
            appHost.Start();
            logHost.Start();
            jobScheduler.Start();
            FixDebugListeners();
            string infoText = GetInfoText(options);
            bool listen = true;
            while (listen)
            {
                Console.Clear();
                Console.Write(infoText);
                foreach (var connection in logHost.GetConnectionList())
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
            jobScheduler.Stop();
            logHost.Stop();
            appHost.Stop();
            apiHost.Stop();
        }

        [Conditional("DEBUG")]
        private static void FixDebugListeners()
        {
            foreach (var listerner in Debug.Listeners.OfType<TextWriterTraceListener>().ToList())
            {
                Debug.Listeners.Remove(listerner);
            }
        }

        private static string GetInfoText(ServerOptions options)
        {
            var infoText = string.Format("Halo Online Server\n" +
                                            "Dispatcher port: {0}\n" +
                                            "Endpoint port: {1}\n" +
                                            "App port: {2}\n" +
                                            "Log port: {3}\n" +
                                            "Press escape to exit\n\n" +
                                            "Connections:\n",
                options.DispatcherPort,
                options.EndpointPort,
                options.AppPort,
                options.LogPort);
            return infoText;
        }
    }
}
