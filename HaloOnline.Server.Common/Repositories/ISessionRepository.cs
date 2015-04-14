using System.Threading.Tasks;
using HaloOnline.Server.Model.SessionControl;

namespace HaloOnline.Server.Common.Repositories
{
    public interface ISessionRepository
    {
        Task CreateAsync(Session session);
        Task UpdateAsync(Session session);
        Task DeleteAsync(Session session);
        Task<Session> FindBySessionIdAsync(string sessionId);
    }
}