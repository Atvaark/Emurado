using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Clan;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class ClanMembershipRepository : IClanMembershipRepository
    {
        private readonly HaloDbContext _context;

        public ClanMembershipRepository()
        {
            _context = new HaloDbContext();
        }

        public Task CreateAsync(ClanMembership clanMembership)
        {
            _context.ClanMemberships.Add(new Model.ClanMembership
            {
                UserId = clanMembership.UserId,
                ClanId = clanMembership.ClanId,
                Role = clanMembership.Role
            });
            _context.SaveChanges();

            return Task.FromResult(0);
        }

        public Task UpdateAsync(ClanMembership clanMembership)
        {
            var foundClanMembership = _context.ClanMemberships.Find(clanMembership.UserId, clanMembership.ClanId);
            if (foundClanMembership != null)
            {
                foundClanMembership.Role = clanMembership.Role;
            }
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task DeleteAsync(ClanMembership clanMembership)
        {
            var foundClanMembership = _context.ClanMemberships.Find(clanMembership.UserId, clanMembership.ClanId);
            if (foundClanMembership != null)
            {
                _context.ClanMemberships.Remove(foundClanMembership);
            }
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<IEnumerable<ClanMembership>> FindByClanId(int clanId)
        {
            var foundClanMemberships = _context.ClanMemberships.Where(c => c.ClanId == clanId)
                .Select(c => new ClanMembership()
                {
                    UserId = c.UserId,
                    ClanId = c.ClanId,
                    Role = c.Role
                })
                .AsEnumerable();
            return Task.FromResult(foundClanMemberships);
        }

        public Task<IEnumerable<ClanMembership>> FindByUserId(int userId)
        {
            var foundClanMemberships = _context.ClanMemberships.Where(c => c.UserId == userId)
                .Select(c => new ClanMembership()
                {
                    UserId = c.UserId,
                    ClanId = c.ClanId,
                    Role = c.Role
                })
                .AsEnumerable();
            return Task.FromResult(foundClanMemberships);
        }
    }
}