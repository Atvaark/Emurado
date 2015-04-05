using System;
using System.Collections.Generic;
using HaloOnline.Server.Model.Serialization;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unidentified
{
    public class Unidentified10
    {
        public UserId User { get; set; }
        public int Outcome { get; set; }
        public int Place { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Suicides { get; set; }
        public int Assists { get; set; }
        [JsonConverter(typeof(UnixEpochMillisecondsJsonConverter))]
        public DateTime TimePlayedMs { get; set; }
        public List<Unidentified11> GameStats { get; set; }
        [JsonProperty("BIEvents")]
        public List<Unidentified11> BiEvents { get; set; }
    }
}