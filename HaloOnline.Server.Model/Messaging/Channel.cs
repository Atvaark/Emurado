using System.Collections.Generic;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Messaging
{
    public class Channel
    {
        public string Name { get; set; }
        public int Version { get; set; }
        public List<ChannelMessage> Messages { get; set; }
        public List<UserId> Members { get; set; }
    }
}
