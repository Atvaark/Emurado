using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHaloDbContext _context;

        public UserRepository(IHaloDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(User user)
        {
            var newUser = new Model.User
            {
                Name = user.UserName,
                PasswordHash = user.UserPasswordHash
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            user.UserId = newUser.Id;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(User user)
        {
            var foundUser = _context.Users.Find(user.UserId);
            if (foundUser != null)
            {
                foundUser.Name = user.UserName;
                foundUser.PasswordHash = user.UserPasswordHash;
            }
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task DeleteAsync(User user)
        {
            var foundUser = _context.Users.Find(user.UserId);
            if (foundUser != null)
            {
                _context.Users.Remove(foundUser);
            }
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<User> FindByIdAsync(string userId)
        {
            var foundUser = _context.Users.Find(userId);
            if (foundUser == null) return Task.FromResult<User>(null);
            var result = new User
            {
                UserId = foundUser.Id,
                UserName = foundUser.Name,
                UserPasswordHash = foundUser.PasswordHash
            };
            return Task.FromResult(result);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var foundUser = _context.Users.FirstOrDefault(u => u.Name == userName);
            if (foundUser == null) return Task.FromResult<User>(null);
            var result = new User
            {
                UserId = foundUser.Id,
                UserName = foundUser.Name,
                UserPasswordHash = foundUser.PasswordHash
            };
            return Task.FromResult(result);
        }
    }
}