using System.Collections.Generic;
using System.Threading.Tasks;
using HaloOnline.Server.Model.Clan;

namespace HaloOnline.Server.Common.Repositories
{
    public interface IClanRepository
    {
        Task CreateAsync(Clan clan);
        Task UpdateAsync(Clan clan);
        Task DeleteAsync(Clan clan);
        Task<Clan> FindByIdAsync(int clanId);
        Task<IEnumerable<Clan>> FindByNamePrefixAsync(string namePrefix);
    }
}