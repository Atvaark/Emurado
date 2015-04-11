using System.Threading.Tasks;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Common.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DelteAsync(User user);
        Task<User> FindByIdAsync(string userId);
        Task<User> FindByNameAsync(string userName);
    }
}