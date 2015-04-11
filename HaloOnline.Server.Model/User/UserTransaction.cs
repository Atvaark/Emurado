using System;
using System.Collections.Generic;
using HaloOnline.Server.Model.Serialization;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.User
{
    public class UserTransaction
    {
        [JsonProperty("transactionItems")]
        public List<UserTransactionItem> TransactionItems { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("timeStamp")]
        [JsonConverter(typeof (UnixEpochSecondsJsonConverter))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("operationType")]
        public int OperationType { get; set; }

        [JsonProperty("extendedInfoItems")]
        public List<ExtendedInfoItem> ExtendedInfoItems { get; set; }
    }
}
