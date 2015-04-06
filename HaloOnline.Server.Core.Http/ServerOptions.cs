﻿namespace HaloOnline.Server.Core.Http
{
    // TODO: Move to HaloOnline.Server.Common

    public class ServerOptions : IServerOptions
    {
        public string EndpointHostname { get; set; }
        public int EndpointPort { get; set; }
        public int DispatcherPort { get; set; }
        public int LogPort { get; set; }
        public int ClientPort { get; set; }
    }
}