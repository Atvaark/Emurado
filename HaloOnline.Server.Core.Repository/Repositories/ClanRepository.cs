using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Clan;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class ClanRepository : IClanRepository
    {
        private readonly IHaloDbContext _context;

        public ClanRepository(IHaloDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Clan clan)
        {
            var newClan1 = _context.Clans.Create();
            newClan1.Name = clan.Name;
            newClan1.Tag = clan.Tag;
            newClan1.Description = clan.Description;
            await _context.SaveChangesAsync();
            clan.ClanId = newClan1.Id;
        }

        public async Task UpdateAsync(Clan clan)
        {
            var foundClan = _context.Clans.Find(clan.ClanId);
            if (foundClan == null) return;
            foundClan.Name = clan.Name;
            foundClan.Tag = clan.Tag;
            foundClan.Description = clan.Description;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Clan clan)
        {
            var foundClan = _context.Clans.Find(clan.ClanId);
            if (foundClan == null) return;
            _context.Clans.Remove(foundClan);
            await _context.SaveChangesAsync();
        }

        public Task<Clan> FindByIdAsync(int clanId)
        {
            var foundClan = _context.Clans.Find(clanId);
            if (foundClan == null) return Task.FromResult<Clan>(null);
            return Task.FromResult(new Clan
            {
                ClanId = foundClan.Id,
                Name = foundClan.Name,
                Tag = foundClan.Tag,
                Description = foundClan.Description
            });
        }

        public Task<IEnumerable<Clan>> FindByNamePrefixAsync(string namePrefix)
        {
            var foundClans = _context.Clans.Where(c => c.Name.StartsWith(namePrefix))
                .Select(c => new Clan
                {
                    ClanId = c.Id,
                    Name = c.Name,
                    Tag = c.Tag,
                    Description = c.Description
                })
                .AsEnumerable();
            return Task.FromResult(foundClans);
        }
    }
}