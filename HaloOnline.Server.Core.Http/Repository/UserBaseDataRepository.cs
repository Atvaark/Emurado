using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Core.Http.Interface.Repositories;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Repository
{
    public class UserBaseDataRepository : IUserBaseDataRepository
    {
        private readonly Dictionary<int, UserBaseData> _userBaseData;

        public UserBaseDataRepository()
        {
            _userBaseData = new Dictionary<int, UserBaseData>();
        }

        public Task<UserBaseData> GetByUserIdAsync(int userId)
        {
            UserBaseData userBaseData;
            _userBaseData.TryGetValue(userId, out userBaseData);
            return Task.FromResult(userBaseData);
        }

        public Task<IEnumerable<UserId>> FindUserIdByNicknameAsync(string nicknamePrefix)
        {
            return
                Task.FromResult(
                    _userBaseData.Where(d => d.Value.Nickname != null && d.Value.Nickname.StartsWith(nicknamePrefix))
                        .Select(u => u.Value.User));
        }

        public Task CreateUserBaseDataAsync(UserBaseData userBaseData)
        {
            _userBaseData[userBaseData.User.Id] = userBaseData;
            return Task.FromResult(0);
        }
    }
}
