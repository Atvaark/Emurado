using System;
using Microsoft.Owin.Hosting;

namespace HaloOnline.Server.Core.Http
{
    public class SelfHost
    {
        private readonly int _dispatcherPort;
        private readonly int _servicePort;
        private IDisposable _app;

        public SelfHost(int servicePort, int dispatcherPort)
        {
            _servicePort = servicePort;
            _dispatcherPort = dispatcherPort;
        }

        public void Start()
        {
            if (_app == null)
            {
                var startOptions = new StartOptions();
                startOptions.Urls.Add("http://+:" + _servicePort + "/");
                startOptions.Urls.Add("https://+:" + _dispatcherPort + "/");
                try
                {
                    _app = WebApp.Start<Startup>(startOptions);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to start server. Do you have firewall enabled? Try running as administrator.");
                    Console.WriteLine(e.Message);
                }
                
            }
        }

        public void End()
        {
            if (_app != null)
            {
                _app.Dispose();
                _app = null;
            }
        }
    }
}
