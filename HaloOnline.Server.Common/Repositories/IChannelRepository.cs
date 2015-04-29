using System.Collections.Generic;
using System.Threading.Tasks;
using HaloOnline.Server.Model.Messaging;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Common.Repositories
{
    public interface IChannelRepository
    {
        Task CreateAsync(Channel channel);
        Task AddUserAsync(Channel channel, UserId user);
        Task RemoveUserAsync(Channel channel, UserId user);
        Task AddMessageAsync(Channel channel, ChannelMessage channelMessage);
        Task<Channel> FindByNameAsync(string name);
        Task<Channel> FindByNameAndVersionAsync(string name, int minVersion);
        Task<IEnumerable<string>> FindNamesByUserId(UserId userId);
    }
}