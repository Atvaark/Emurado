using System.Collections.Generic;
using HaloOnline.Server.Model.Friends;

namespace HaloOnline.Server.Core.Http.Model.Friends
{
    public class GetSubscriptionsRequest
    {
        public List<VersionedUserId> Users { get; set; }
    }
}
