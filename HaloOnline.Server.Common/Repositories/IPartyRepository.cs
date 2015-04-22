using System.Collections.Generic;
using System.Threading.Tasks;
using HaloOnline.Server.Model.Presence;

namespace HaloOnline.Server.Common.Repositories
{
    public interface IPartyRepository
    {
        Task CreateAsync(Party party);
        Task UpdateAsync(Party party);
        Task DeleteAsync(Party party);
        Task<Party> FindByPartyIdAsync(string partyId);
        Task<IEnumerable<Party>> FindByMatchmakeStateAsync(int matchmakeState);
    }
}