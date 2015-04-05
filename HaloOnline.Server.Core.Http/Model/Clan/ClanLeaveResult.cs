using HaloOnline.Server.Model.User;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Model.Clan
{
    public class ClanLeaveResult
    {
        [JsonProperty("ClanLeaveResult")]
        public ServiceResult<UserBaseData> Result { get; set; }
    }
}
