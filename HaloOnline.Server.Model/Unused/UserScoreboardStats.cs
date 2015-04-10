using System;
using System.Collections.Generic;
using HaloOnline.Server.Model.Serialization;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unused
{
    public class UserScoreboardStats
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
        public List<KeyIntegerValuePair> GameStats { get; set; }
        [JsonProperty("BIEvents")]
        public List<KeyIntegerValuePair> BiEvents { get; set; }
    }
}