using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Clan;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class ClanRepository : IClanRepository
    {
        private readonly HaloDbContext _context;

        public ClanRepository()
        {
            _context = new HaloDbContext();
        }

        public Task CreateAsync(Clan clan)
        {
            var newClan = new Model.Clan
            {
                Name = clan.Name,
                Tag = clan.Tag,
                Description = clan.Description
            };
            _context.Clans.Add(newClan);
            _context.SaveChanges();
            clan.ClanId = newClan.Id;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(Clan clan)
        {
            var foundClan = _context.Clans.Find(clan.ClanId);
            if (foundClan == null) return Task.FromResult(0);
            foundClan.Name = clan.Name;
            foundClan.Tag = clan.Tag;
            foundClan.Description = clan.Description;
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Clan clan)
        {
            var foundClan = _context.Clans.Find(clan.ClanId);
            if (foundClan == null) return Task.FromResult(0);
            _context.Clans.Remove(foundClan);
            return _context.SaveChangesAsync();
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