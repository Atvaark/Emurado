using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Repository.Model;
using HaloOnline.Server.Model.User;
using Channel = HaloOnline.Server.Model.Messaging.Channel;
using ChannelMessage = HaloOnline.Server.Model.Messaging.ChannelMessage;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly IHaloDbContext _context;

        public ChannelRepository(IHaloDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Channel channel)
        {
            _context.Channels.Add(new Model.Channel
            {
                Name = channel.Name,
                Type = 0,
                Version = 0
            });
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task AddUserAsync(Channel channel, UserId user)
        {
            var foundChannel = _context
                .Channels
                .FirstOrDefault(c => c.Name == channel.Name);
            if (foundChannel != null)
            {
                foundChannel.Users.Add(new ChannelUser
                {
                    ChannelId = foundChannel.Id,
                    UserId = user.Id
                });
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(0);
        }

        public Task RemoveUserAsync(Channel channel, UserId user)
        {
            var foundChannel = _context
                .Channels
                .FirstOrDefault(c => c.Name == channel.Name);
            if (foundChannel != null)
            {
                var foundChannelUser = foundChannel
                    .Users
                    .FirstOrDefault(u => u.UserId == user.Id);
                foundChannel.Users.Remove(foundChannelUser);
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(0);
        }

        public Task AddMessageAsync(Channel channel, ChannelMessage channelMessage)
        {
            var foundChannel = _context
                .Channels
                .FirstOrDefault(c => c.Name == channel.Name);
            if (foundChannel != null)
            {
                foundChannel.Version++;
                foundChannel.Messages.Add(new Model.ChannelMessage
                {
                    ChannelId = foundChannel.Id,
                    UserId = channelMessage.From.Id,
                    Text = channelMessage.Text,
                    TimeStamp = channelMessage.Timestamp,
                    Version = foundChannel.Version
                });
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(0);
        }

        public Task<Channel> FindByNameAsync(string name)
        {
            var foundChannel = _context
                .Channels
                .FirstOrDefault(c => c.Name == name);
            if (foundChannel == null)
            {
                return Task.FromResult<Channel>(null);
            }
            var result = new Channel()
            {
                Name = foundChannel.Name,
                Version = foundChannel.Version,
                Members = foundChannel.Users.Select(u => new UserId(u.UserId)).ToList(),
                Messages = foundChannel.Messages
                .Select(m => new ChannelMessage
                {
                    From = new UserId(m.UserId),
                    Text = m.Text,
                    Timestamp = m.TimeStamp
                }).ToList()
            };
            return Task.FromResult(result);
        }

        public Task<Channel> FindByNameAndVersionAsync(string name, int minVersion)
        {
            var foundChannel = _context
                .Channels
                .FirstOrDefault(c => c.Name == name);
            if (foundChannel == null)
            {
                return Task.FromResult<Channel>(null);
            }
            var result = new Channel()
            {
                Name = foundChannel.Name,
                Version = foundChannel.Version,
                Members = foundChannel.Users.Select(u => new UserId(u.UserId)).ToList(),
                Messages = foundChannel.Messages.Where(m => m.Version >= minVersion)
                .Select(m => new ChannelMessage
                {
                    From = new UserId(m.UserId),
                    Text = m.Text,
                    Timestamp = m.TimeStamp
                }).ToList()
            };
            return Task.FromResult(result);
        }

        public Task<IEnumerable<string>> FindNamesByUserId(UserId userId)
        {
            var foundUser = _context.Users.FirstOrDefault(u => u.Id == userId.Id);
            if (foundUser == null)
            {
                return Task.FromResult<IEnumerable<string>>(new string[] { });
            }
            var foundChannelNames = foundUser.ChannelUsers.Select(c => c.Channel).Select(c => c.Name).AsEnumerable();
            return Task.FromResult(foundChannelNames);
        }
    }
}