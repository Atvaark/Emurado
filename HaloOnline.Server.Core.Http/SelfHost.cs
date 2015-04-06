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
                _app = services.GetService<IHostingStarter>().Start(startOptions);
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
