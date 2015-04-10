using HaloOnline.Server.Model.Authorization;
using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unused
{
    public class Event 
    {
        [JsonProperty("Event")]
        public int Id { get; set; }
        public UserId User { get; set; }
        public Signature UserSignature { get; set; }
        public int TeamId { get; set; }

    }
}