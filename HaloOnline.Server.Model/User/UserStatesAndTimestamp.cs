using System;
using System.Collections.Generic;
using HaloOnline.Server.Model.Serialization;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class UserStatesAndTimestamp
    {
        public List<UserState> UserStateList { get; set; }

        [JsonConverter(typeof (UnixEpochSecondsJsonConverter))]
        public DateTime TimeStamp { get; set; }

        public UserId User { get; set; }
        public string Nickname { get; set; }
    }
}
