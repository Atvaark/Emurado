using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Presence;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly HaloDbContext _context;

        public PartyRepository()
        {
            _context = new HaloDbContext();
        }
        
        public Task CreateAsync(Party party)
        {
            var newParty = new Model.Party
            {
                PartyId = party.Party.Id,
                MatchmakeType = party.MatchmakeState,
                GameData = party.GameData
            };
            _context.Parties.Add(newParty);
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task UpdateAsync(Party party)
        {
            var foundParty = _context.Parties.FirstOrDefault(p => p.PartyId == party.Party.Id);
            if (foundParty != null)
            {
                foundParty.MatchmakeType = party.MatchmakeState;
                foundParty.GameData = party.GameData;
                _context.SaveChanges();
            }
            return Task.FromResult(0);
        }

        public Task DeleteAsync(Party party)
        {
            var foundParty = _context.Parties.FirstOrDefault(p => p.PartyId == party.Party.Id);
            if (foundParty != null)
            {
                _context.Parties.Remove(foundParty);
                _context.SaveChanges();
            }
            return Task.FromResult(0);
        }

        public Task<Party> FindByPartyIdAsync(string partyId)
        {
            var foundParty = _context.Parties.FirstOrDefault(p => p.PartyId == partyId);
            if (foundParty != null)
            {
                return Task.FromResult(new Party
                {
                    Id = foundParty.Id,
                    Party = new PartyId(foundParty.PartyId),
                    MatchmakeState = foundParty.MatchmakeType,
                    GameData = foundParty.GameData
                });
            }
            return Task.FromResult<Party>(null);
        }
    }
}