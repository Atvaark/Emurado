using System;
using System.Collections.Generic;
using HaloOnline.Server.Model.Serialization;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.GameStatistics
{
    public class UserChallenge
    {
        public string ChallengeId { get; set; }
        public int Progress { get; set; }
        public List<UserChallengeCounter> Counters { get; set; }
        [JsonConverter(typeof(UnixEpochMillisecondsJsonConverter))]
        public DateTime FinishedAtUnixMilliseconds { get; set; }
        [JsonConverter(typeof(UnixEpochMillisecondsJsonConverter))]
        public DateTime StartDateUnixMilliseconds { get; set; }
        [JsonConverter(typeof(UnixEpochMillisecondsJsonConverter))]
        public DateTime EndDateUnixMilliseconds { get; set; }
        public List<ChallengeReward> Rewards { get; set; }
    }
}
