using System;
using HaloOnline.Server.Common;
using Microsoft.Owin.Hosting;

namespace HaloOnline.Server.Core.Http
{
    public class ApiSelfHost
    {
        private readonly IServerOptions _options;
        private IDisposable _app;

        public ApiSelfHost(IServerOptions options)
        {
            _options = options;
        }

        public void Start()
        {
            if (_app == null)
            {
                var startOptions = new StartOptions();
                startOptions.Urls.Add("http://+:" + _options.EndpointPort + "/");
                startOptions.Urls.Add("https://+:" + _options.DispatcherPort + "/");
                try
                {
                    _app = WebApp.Start(startOptions
                        , app =>
                        {
                            var startup = new Startup(_options);
                            startup.Configuration(app);
                        });
                }
                catch (Exception e)
                {
                    Console.WriteLine(
                        "Unable to start server. Do you have firewall enabled? Try running as administrator.");
                    Console.WriteLine(e.ToString());
                }

            }
        }

        public void Stop()
        {
            if (_app != null)
            {
                _app.Dispose();
                _app = null;
            }
        }
    }
}
