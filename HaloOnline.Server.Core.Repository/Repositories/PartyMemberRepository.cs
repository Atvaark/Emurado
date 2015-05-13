using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Presence;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class PartyMemberRepository : IPartyMemberRepository
    {
        private readonly IHaloDbContext _context;

        public PartyMemberRepository(IHaloDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(PartyMember partyMember)
        {
            var newPartyMember = new Model.PartyMember
            {
                UserId = partyMember.UserId,
                PartyId = partyMember.PartyId,
                SessionId = partyMember.SessionId,
                IsOwner = partyMember.IsOwner
            };

            _context.PartyMembers.Add(newPartyMember);
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task UpdateAsync(PartyMember partyMember)
        {
            var foundPartyMember = _context.PartyMembers.Find(partyMember.PartyId, partyMember.UserId);
            if (foundPartyMember != null)
            {
                foundPartyMember.SessionId = partyMember.SessionId;
                foundPartyMember.IsOwner = partyMember.IsOwner;
                _context.SaveChanges();
            }
            return Task.FromResult(0);
        }

        public Task DeleteAsync(PartyMember partyMember)
        {
            var foundPartyMember = _context.PartyMembers.Find(partyMember.PartyId, partyMember.UserId);
            if (foundPartyMember != null)
            {
                _context.PartyMembers.Remove(foundPartyMember);
                _context.SaveChanges();
            }
            return Task.FromResult(0);
        }

        public Task<IEnumerable<PartyMember>> FindByPartyId(string partyId)
        {
            var foundPartyMembers = _context.PartyMembers.Where(p => p.PartyId == partyId)
                .Select(p => new PartyMember
                {
                    PartyId = p.PartyId,
                    UserId = p.UserId,
                    SessionId = p.SessionId,
                    IsOwner = p.IsOwner
                })
                .AsEnumerable();
            return Task.FromResult(foundPartyMembers);
        }

        public Task<IEnumerable<PartyMember>> FindBySessionId(string sessionId)
        {
            var foundPartyMembers = _context.PartyMembers.Where(p => p.SessionId == sessionId)
                .Select(p => new PartyMember
                {
                    PartyId = p.PartyId,
                    UserId = p.UserId,
                    SessionId = p.SessionId,
                    IsOwner = p.IsOwner
                })
                .AsEnumerable();
            return Task.FromResult(foundPartyMembers);
        }

        public Task<PartyMember> FindByUserId(int userId)
        {
            var foundPartyMember = _context.PartyMembers.Where(p => p.UserId == userId)
                .Select(p => new PartyMember
                {
                    PartyId = p.PartyId,
                    UserId = p.UserId,
                    SessionId = p.SessionId,
                    IsOwner = p.IsOwner
                })
                .FirstOrDefault();
            return Task.FromResult(foundPartyMember);
        }
    }
}