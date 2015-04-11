using System.Collections.Generic;
using System.Threading.Tasks;
using HaloOnline.Server.Model.Clan;

namespace HaloOnline.Server.Common.Repositories
{
    public interface IClanMembershipRepository
    {
        Task CreateAsync(ClanMembership clanMembership);
        Task UpdateAsync(ClanMembership clanMembership);
        Task DeleteAsync(ClanMembership clanMembership);
        Task<IEnumerable<ClanMembership>> FindByClanId(int clanId);
        Task<IEnumerable<ClanMembership>> FindByUserId(int userId);
    }
}