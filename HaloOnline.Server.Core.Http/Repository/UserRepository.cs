using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Http.Interface.Repositories;

namespace HaloOnline.Server.Core.Http.Repository
{
    // TODO: Merge UserRepository and UserRepository
    public class UserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<string, HaloUser> _users;
        private int _nextId = 1;

        public UserRepository()
        {
            _users = new ConcurrentDictionary<string, HaloUser>();
        }

        public void Dispose()
        {
        }

        public Task CreateAsync(HaloUser user)
        {
            return Task.Run(() =>
            {
                user.UserId = _nextId++;
                ;
                _users.TryAdd(user.Id, user);
            });
        }

        public Task UpdateAsync(HaloUser user)
        {
            return Task.Run(() =>
            {
                HaloUser currentUser;
                while (_users.TryGetValue(user.Id, out currentUser))
                {
                    if (_users.TryUpdate(user.Id, user, currentUser))
                    {
                        return true;
                    }
                }
                return false;
            });
        }

        public Task DeleteAsync(HaloUser user)
        {
            return Task.Run(() =>
            {
                HaloUser haloUser;
                _users.TryRemove(user.Id, out haloUser);
            });
        }

        public Task<HaloUser> FindByIdAsync(string userId)
        {
            return Task.FromResult(_users.Where(u => u.Key == userId).Select(u => u.Value).FirstOrDefault());
        }

        public Task<HaloUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(_users.Values.FirstOrDefault(u => u.UserName == userName));
        }

        public Task SetPasswordHashAsync(HaloUser user, string passwordHash)
        {
            return Task.Run(() => user.UserPasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(HaloUser user)
        {
            return Task.FromResult(user.UserPasswordHash);
        }

        public Task<bool> HasPasswordAsync(HaloUser user)
        {
            return Task.FromResult(user.UserPasswordHash != null);
        }
    }
}
