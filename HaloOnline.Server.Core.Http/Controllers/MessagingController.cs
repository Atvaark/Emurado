using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Messaging;
using HaloOnline.Server.Model.Messaging;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [Authorize]
    public class MessagingController : ApiController, IMessagingService
    {
        public MessagingController()
        {
            if (Channels == null)
            {
                Channels = new List<Channel>
                {
                    new Channel
                    {
                        Name = "#general_1",
                        Version = 0,
                        Members = new List<UserId>
                        {
                            new UserId
                            {
                                Id = 2
                            }
                        },
                        Messages = new List<ChannelMessage>()
                    },
                    new Channel
                    {
                        Name = "#private_1",
                        Version = 0,
                        Members = new List<UserId>
                        {
                            new UserId
                            {
                                Id = 2
                            }
                        },
                        Messages = new List<ChannelMessage>()
                    },
                    new Channel
                    {
                        Name = "#clan_1",
                        Version = 0,
                        Members = new List<UserId>
                        {
                            new UserId
                            {
                                Id = 2
                            }
                        },
                        Messages = new List<ChannelMessage>()
                    }
                };
            }
        }

        public static List<Channel> Channels { get; set; }

        [HttpPost]
        public JoinChannelsResult JoinChannels(JoinChannelsRequest request)
        {
            foreach (var channel in Channels.Where(c => request.ChannelNames.Contains(c.Name)))
            {
                if (channel.Members.All(m => m.Id != 1))
                {
                    channel.Members.Add(new UserId
                    {
                        Id = 1
                    });
                    channel.Version++;
                }
            }

            return new JoinChannelsResult
            {
                Result = new ServiceResult<List<Channel>>
                {
                    ReturnCode = 0,
                    Data = Channels.Where(c => request.ChannelNames.Contains(c.Name)).ToList()
                }
            };
        }

        [HttpPost]
        public LeaveChannelsResult LeaveChannels(LeaveChannelsRequest request)
        {
            return new LeaveChannelsResult
            {
                Result = new ServiceResult<List<Channel>>
                {
                    ReturnCode = 0,
                    Data = Channels
                }
            };
        }

        [HttpPost]
        public SendResult Send(SendRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);

            var channel = Channels.FirstOrDefault(c => c.Name == request.ChannelName);
            bool sent = false;
            if (channel != null)
            {
                channel.Version++;
                channel.Messages.Add(new ChannelMessage
                {
                    From = new UserId
                    {
                        Id = userId
                    },
                    Text = request.Message, // TODO: Escape # and \ commands
                    Timestamp = DateTime.Now,
                    Version = channel.Version
                });
                sent = true;
            }

            return new SendResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = sent
                }
            };
        }

        [HttpPost]
        public SendServiceMessageResult SendServiceMessage(SendServiceMessageRequest request)
        {
            return new SendServiceMessageResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = false
                }
            };
        }

        [HttpPost]
        public ReceiveResult Receive(ReceiveRequest request)
        {
            List<Channel> requestedChannels =
                request.Channels
                    .Select(
                        requestedChannel =>
                            new
                            {
                                requestedChannel,
                                foundChannel = Channels.FirstOrDefault(c => c.Name == requestedChannel.Name)
                            })
                    .Where(@t => @t.foundChannel != null)
                    .Select(@t => new Channel
                    {
                        Name = @t.foundChannel.Name,
                        Version = @t.foundChannel.Version,
                        Members = @t.foundChannel.Members,
                        Messages = @t.foundChannel.Messages.Where(m => m.Version > @t.requestedChannel.Version).ToList()
                    }).ToList();
            return new ReceiveResult
            {
                Result = new ServiceResult<List<Channel>>
                {
                    ReturnCode = 0,
                    Data = requestedChannels
                }
            };
        }
    }
}
