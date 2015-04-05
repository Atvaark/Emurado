using System.Collections.Generic;

namespace HaloOnline.Server.Model.Friends
{
    public class GetSubscriptionsRequest
    {
        public List<VersionedUserId> Users { get; set; }
    }
}
