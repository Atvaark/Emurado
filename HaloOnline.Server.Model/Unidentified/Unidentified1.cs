using Newtonsoft.Json;

namespace HaloOnline.Server.Model.Unidentified
{
    public class Unidentified1
    {
        public string Expires { get; set; }
        public string BranchName { get; set; }
        public string BranchCombination { get; set; }
        public int SliceDeploymentId { get; set; }
        public string SliceDeploymentName { get; set; }
        public int MatchMakingId { get; set; }
        public int UserId { get; set; }
        public string UserSessionId { get; set; }
        [JsonProperty("DSToken")]
        public string DsToken { get; set; }
        [JsonProperty("MMGroupId")]
        public int MmGroupId { get; set; }
        public int UserProfession { get; set; }
    }
}