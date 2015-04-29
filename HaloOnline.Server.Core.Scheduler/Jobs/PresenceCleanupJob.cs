using System;
using System.Diagnostics;
using HaloOnline.Server.Common.Repositories;
using Quartz;

namespace HaloOnline.Server.Core.Scheduler.Jobs
{
    // TODO: Schedule the job
    public class PresenceCleanupJob : IJob
    {
        private readonly IUserPresenceRepository _userPresenceRepository;

        public PresenceCleanupJob(IUserPresenceRepository userPresenceRepository)
        {
            _userPresenceRepository = userPresenceRepository;
        }
        
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var foundIngameUserPresences = _userPresenceRepository.FindByState(2).Result;
                foreach (var foundIngameUserPresence in foundIngameUserPresences)
                {
                    // TODO: Check if the user is still ingame.
                    foundIngameUserPresence.Data.State = 1;
                    _userPresenceRepository.UpdateAsync(foundIngameUserPresence);
                }

                var foundOnlineUserPresences = _userPresenceRepository.FindByState(1).Result;
                foreach (var foundOnlineUserPresence in foundOnlineUserPresences)
                {
                    // TODO: Check if the user is still online.
                    foundOnlineUserPresence.Data.State = 0;
                    _userPresenceRepository.UpdateAsync(foundOnlineUserPresence);
                }
            }
            catch (Exception e)
            {
                // TODO: Use a logging framework
                Debug.WriteLine("An error occured during user presence cleanup", e);
            }
        }
    }
}