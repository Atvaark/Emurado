using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.SessionControl;
using Quartz;

namespace HaloOnline.Server.Core.Scheduler.Jobs
{
    public class MatchmakingJob : IJob
    {
        private readonly IPartyRepository _partyRepository;
        private readonly IPartyMemberRepository _partyMemberRepository;
        private readonly ISessionRepository _sessionRepository;

        public MatchmakingJob(IPartyRepository partyRepository, IPartyMemberRepository partyMemberRepository, ISessionRepository sessionRepository)
        {
            if (partyRepository == null) throw new ArgumentNullException("partyRepository");
            if (partyMemberRepository == null) throw new ArgumentNullException("partyMemberRepository");
            if (sessionRepository == null) throw new ArgumentNullException("sessionRepository");
            _partyRepository = partyRepository;
            _partyMemberRepository = partyMemberRepository;
            _sessionRepository = sessionRepository;
        }
        
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                // TOOD: Replace with an enum
                const int inQueue = 2;
                var parties = _partyRepository.FindByMatchmakeStateAsync(inQueue).Result;
                List<PartyMember> partyMembers = new List<PartyMember>();
                foreach (var party in parties)
                {
                    var foundPartyMembers = _partyMemberRepository.FindByPartyId(party.Id).Result;
                    partyMembers.AddRange(foundPartyMembers);
                }
            
                // TODO: Add some matchmaking logic
                var matchedPartyMembers = partyMembers.ToList();

                if (!matchedPartyMembers.Any())
                {
                    return;
                }

                var session = new Session
                {
                    Id = Guid.NewGuid().ToString(),
                    MapId = "guardian",
                    ModeId = "slayer"
                };
                _sessionRepository.CreateAsync(session).Wait();

                // TODO: Set party matchmake state to ingame
                foreach (var partyMember in matchedPartyMembers)
                {
                    partyMember.SessionId = session.Id;
                    _partyMemberRepository.UpdateAsync(partyMember).Wait();
                }
            }
            catch (Exception e)
            {
                // TODO: Use a logging framework
                Debug.WriteLine("An error occured during matchmaking", e);
            }
        }
    }
}