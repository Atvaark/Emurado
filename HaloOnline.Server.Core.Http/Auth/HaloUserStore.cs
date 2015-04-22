using System;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;

namespace HaloOnline.Server.Core.Http.Auth
{
    public class HaloUserStore : IHaloUserStore
    {
        private readonly IUserRepository _userRepository;

        public HaloUserStore(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }

        public Task CreateAsync(HaloUser user)
        {
            return _userRepository.CreateAsync(user);
        }

        public Task UpdateAsync(HaloUser user)
        {
            return _userRepository.UpdateAsync(user);
        }

        public Task DeleteAsync(HaloUser user)
        {
            return _userRepository.UpdateAsync(user);
        }

        public async Task<HaloUser> FindByIdAsync(string userId)
        {
            var foundUser = await _userRepository.FindByIdAsync(userId);
            if (foundUser == null)
            {
                return null;
            }
            return new HaloUser
            {
                UserId = foundUser.UserId,
                UserName = foundUser.UserName,
                UserPasswordHash = foundUser.UserPasswordHash
            };
        }

        public async Task<HaloUser> FindByNameAsync(string userName)
        {
            var foundUser = await _userRepository.FindByNameAsync(userName);
            if (foundUser == null)
            {
                return null;
            }
            return new HaloUser
            {
                UserId = foundUser.UserId,
                UserName = foundUser.UserName,
                UserPasswordHash = foundUser.UserPasswordHash
            };
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
