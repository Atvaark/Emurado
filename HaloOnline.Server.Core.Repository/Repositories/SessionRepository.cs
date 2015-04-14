using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.SessionControl;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly HaloDbContext _context;

        public SessionRepository()
        {
            _context = new HaloDbContext();
        }

        public Task CreateAsync(Session session)
        {
            var newSession = new Model.Session
            {
                SessionId = session.SessionId,
                MapId = session.MapId,
                ModeId = session.ModeId,
                Started = session.Started,
                Finished = session.Finished
            };
            _context.Sessions.Add(newSession);
            _context.SaveChanges();
            session.Id = newSession.Id;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(Session session)
        {
            var foundSession = _context.Sessions.Find(session.Id);
            if (foundSession != null)
            {
                foundSession.SessionId = session.SessionId;
                foundSession.MapId = session.MapId;
                foundSession.ModeId = session.ModeId;
                foundSession.Started = session.Started;
                foundSession.Finished = session.Finished;
                _context.SaveChanges();
            }
            return Task.FromResult(0);
        }

        public Task DeleteAsync(Session session)
        {
            var foundSession = _context.Sessions.Find(session.Id);
            if (foundSession != null)
            {
                _context.Sessions.Remove(foundSession);
                _context.SaveChanges();
            }
            return Task.FromResult(0);
        }

        public Task<Session> FindBySessionIdAsync(string sessionId)
        {
            var foundSession = _context.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
            if (foundSession != null)
            {
                return Task.FromResult(new Session
                {
                    Id = foundSession.Id,
                    SessionId = foundSession.SessionId,
                    MapId = foundSession.MapId,
                    ModeId = foundSession.ModeId,
                    Started = foundSession.Started,
                    Finished = foundSession.Finished
                });
            }
            return Task.FromResult<Session>(null);
        }
    }
}