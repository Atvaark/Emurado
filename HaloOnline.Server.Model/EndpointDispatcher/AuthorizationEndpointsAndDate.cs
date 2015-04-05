using System;
using System.Collections.Generic;
using HaloOnline.Server.Model.Serialization;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.EndpointDispatcher
{
    public class AuthorizationEndpointsAndDate
    {
        public AuthorizationEndpointsAndDate()
        {
            Endpoints = new List<CompactEndpointInfo>();
        }

        public List<CompactEndpointInfo> Endpoints { get; set; }

        [JsonConverter(typeof (UnixEpochSecondsJsonConverter))]
        public DateTime DateTime { get; set; }
    }
}
