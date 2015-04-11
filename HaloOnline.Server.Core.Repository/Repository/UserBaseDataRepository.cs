using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Clan;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Repository.Repository
{
    public class UserBaseDataRepository : IUserBaseDataRepository
    {
        private readonly HaloDbContext _context;

        public UserBaseDataRepository()
        {
            _context = new HaloDbContext();
        }

        public Task<UserBaseData> GetByUserIdAsync(int userId)
        {
            var baseData = _context.UsersBaseData.Find(userId);
            if (baseData == null)
                return Task.FromResult<UserBaseData>(null);
            return Task.FromResult(new UserBaseData
            {
                User = new UserId
                {
                    Id = baseData.UserId
                },
                Nickname = baseData.Nickname,
                Level = baseData.Level,
                BattleTag = baseData.BattleTag,
                Clan = new ClanId
                {
                    Id = baseData.Clan == null ? 0 : baseData.Clan.Id
                },
                ClanTag = baseData.Clan == null ? "" : baseData.Clan.Tag
            });
        }

        public Task<IEnumerable<UserId>> FindUserIdByNicknameAsync(string nicknamePrefix)
        {
            return Task.FromResult(_context.UsersBaseData
                .Where(u => u.Nickname.StartsWith(nicknamePrefix))
                .Select(u => new UserId()
                {
                    Id = u.UserId
                })
                .AsEnumerable());
        }

        public Task SetUserBaseDataAsync(UserBaseData userBaseData)
        {
            var foundUserBaseData = _context.UsersBaseData.Find(userBaseData.User.Id);
            if (foundUserBaseData == null)
            {
                var newUserBaseData = new Core.Repository.Model.UserBaseData
                {
                    UserId = userBaseData.User.Id,
                    ClanId = userBaseData.Clan.Id,
                    Nickname = userBaseData.Nickname,
                    Level = userBaseData.Level,
                    BattleTag = userBaseData.BattleTag
                };
                _context.UsersBaseData.Add(newUserBaseData);
            }
            else
            {
                foundUserBaseData.UserId = userBaseData.User.Id;
                foundUserBaseData.ClanId = userBaseData.Clan.Id;
                foundUserBaseData.Nickname = userBaseData.Nickname;
                foundUserBaseData.Level = userBaseData.Level;
                foundUserBaseData.BattleTag = userBaseData.BattleTag;
            }
            _context.SaveChanges();
            return Task.FromResult(0);
        }
    }
}
