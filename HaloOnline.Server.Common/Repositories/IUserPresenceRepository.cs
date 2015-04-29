using System.Collections.Generic;
using System.Threading.Tasks;
using HaloOnline.Server.Model.Presence;

namespace HaloOnline.Server.Common.Repositories
{
    public interface IUserPresenceRepository
    {
        Task CreateAsync(UserPresence userPresence);
        Task UpdateAsync(UserPresence userPresence);
        Task DeleteAsync(UserPresence userPresence);
        Task<UserPresence> FindByUserIdAsync(int userId);
        Task<IEnumerable<UserPresence>> FindByState(int state);
        Task<UserPresenceStats> GetUserPresenceStats();
    }
}