using System.Collections.Generic;
using System.Threading.Tasks;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Interface.Repositories
{
    public interface IUserBaseDataRepository
    {
        Task<UserBaseData> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserId>> FindUserIdByNicknameAsync(string nicknamePrefix);
        Task CreateUserBaseDataAsync(UserBaseData userBaseData);
    }
}
