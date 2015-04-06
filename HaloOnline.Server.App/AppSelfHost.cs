﻿using System;
using HaloOnline.Server.Common;
using Microsoft.Owin.Hosting;

namespace HaloOnline.Server.App
{
    public class AppSelfHost
    {
        private readonly IServerOptions _options;
        private IDisposable _app;

        public AppSelfHost(IServerOptions options)
        {
            _options = options;
        }

        public void Start()
        {
            if (_app == null)
            {
                var startOptions = new StartOptions();
                startOptions.Urls.Add("http://+:" + _options.AppPort + "/");
                try
                {
                    _app = WebApp.Start<Startup>(startOptions);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to start server." +
                                      "Do you have firewall enabled?" +
                                      "Try running as administrator.");
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