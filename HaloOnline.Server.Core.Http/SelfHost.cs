using System;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Hosting.Services;
using Microsoft.Owin.Hosting.Starter;

namespace HaloOnline.Server.Core.Http
{
    public class SelfHost
    {
        private readonly IServerOptions _options;
        private IDisposable _app;

        public SelfHost(IServerOptions options)
        {
            _options = options;
        }

        public void Start()
        {
            if (_app == null)
            {
                var services = (ServiceProvider)ServicesFactory.Create();
                services.AddInstance<IServerOptions>(_options);
                var startOptions = new StartOptions();
                startOptions.Urls.Add("http://+:" + _options.EndpointPort + "/");
                startOptions.Urls.Add("https://+:" + _options.DispatcherPort + "/");
                try
                {
                    _app = services.GetService<IHostingStarter>().Start(startOptions);
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        "Unable to start server. Do you have firewall enabled? Try running as administrator.");
                    Console.WriteLine(e.ToString());
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
