using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class UserPrimaryStates
    {
        public UserId User { get; set; }
        public int Xp { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int Suicides { get; set; }
        public int TotalMatches { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }

        [JsonProperty("TotalWP")]
        public int TotalWp { get; set; }

        public int TotalTimePlayed { get; set; }
        public int TotalTimeOnline { get; set; }
    }
}
