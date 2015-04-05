using Newtonsoft.Json;

namespace HaloOnline.Server.Model.GameStatistics
{
    public class Counter
    {
        public string CounterName { get; set; }

        [JsonProperty("CurrValue")]
        public int CurrentValue { get; set; }

        public int MaxValue { get; set; }
    }
}
