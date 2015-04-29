using System;
using HaloOnline.Server.Model.Serialization;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Messaging
{
    public class ChannelMessage
    {
        public UserId From { get; set; }

        public string Text { get; set; }

        [JsonConverter(typeof (UnixEpochMillisecondsJsonConverter))]
        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public int Version { get; set; }
    }
}
