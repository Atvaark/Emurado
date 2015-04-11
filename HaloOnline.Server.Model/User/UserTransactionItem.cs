using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class UserTransactionItem
    {
        [JsonProperty("stateName")]
        public string StateName { get; set; }

        [JsonProperty("stateType")]
        public int StateType { get; set; }

        [JsonProperty("ownType")]
        public int OwnType { get; set; }

        [JsonProperty("operationType")]
        public int OperationType { get; set; }

        [JsonProperty("initialValue")]
        public int InitialValue { get; set; }

        [JsonProperty("resultingValue")]
        public int ResultingValue { get; set; }

        [JsonProperty("deltaValue")]
        public int DeltaValue { get; set; }

        [JsonProperty("descId")]
        public int DescId { get; set; }
    }
}
