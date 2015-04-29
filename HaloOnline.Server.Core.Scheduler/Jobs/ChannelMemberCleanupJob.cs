using System;
using System.Diagnostics;
using HaloOnline.Server.Common.Repositories;
using Quartz;

namespace HaloOnline.Server.Core.Scheduler.Jobs
{
    // TODO: Schedule the job
    public class ChannelMemberCleanupJob : IJob
    {
        private readonly IUserPresenceRepository _userPresenceRepository;
        private readonly IChannelRepository _channelRepository;

        public ChannelMemberCleanupJob(IUserPresenceRepository userPresenceRepository, IChannelRepository channelRepository)
        {
            _userPresenceRepository = userPresenceRepository;
            _channelRepository = channelRepository;
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                // TODO: Remove offline users.
            }
            catch (Exception e)
            {
                // TODO: Use a logging framework
                Debug.WriteLine("An error occured during channel cleanup", e);
            }
        }
    }
}