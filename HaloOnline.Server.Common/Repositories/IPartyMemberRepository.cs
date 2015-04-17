using System.Collections.Generic;
using System.Threading.Tasks;
using HaloOnline.Server.Model.Presence;

namespace HaloOnline.Server.Common.Repositories
{
    public interface IPartyMemberRepository
    {
        Task CreateAsync(PartyMember partyMember);
        Task UpdateAsync(PartyMember partyMember);
        Task DeleteAsync(PartyMember partyMember);
        Task<IEnumerable<PartyMember>> FindByPartyId(string partyId);
        Task<IEnumerable<PartyMember>> FindBySessionId(string sessionId);
        Task<PartyMember> FindByUserId(int userId);

    }
}