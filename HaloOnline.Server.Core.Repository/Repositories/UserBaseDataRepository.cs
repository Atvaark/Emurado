using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Clan;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class UserBaseDataRepository : IUserBaseDataRepository
    {
        private readonly IHaloDbContext _context;

        public UserBaseDataRepository(IHaloDbContext context)
        {
            _context = context;
        }

        public Task<UserBaseData> GetByUserIdAsync(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return Task.FromResult<UserBaseData>(null);
            }
            var clanMembership = user.ClanMemberships.FirstOrDefault();
            int clanId;
            string clanTag;
            if (clanMembership == null)
            {
                clanId = 0;
                clanTag = "";
            }
            else
            {
                clanId = clanMembership.ClanId;
                clanTag = clanMembership.Clan.Tag;
            }

            return Task.FromResult(new UserBaseData
            {
                User = new UserId
                {
                    Id = user.Id
                },
                Nickname = user.Nickname,
                BattleTag = user.BattleTag,
                Level = user.Level,
                Clan = new ClanId
                {
                    Id = clanId
                },
                ClanTag = clanTag
            });
        }

        public Task<IEnumerable<UserId>> FindUserIdByNicknameAsync(string nicknamePrefix)
        {
            return Task.FromResult(_context.Users
                .Where(u => u.Nickname.StartsWith(nicknamePrefix))
                .Select(u => new UserId
                {
                    Id = u.Id
                })
                .AsEnumerable());
        }

        public Task SetUserBaseDataAsync(UserBaseData userBaseData)
        {
            var user = _context.Users.Find(userBaseData.User.Id);
            if (user == null)
            {
                return Task.FromResult(0);
            }
            user.Nickname = userBaseData.Nickname;
            user.BattleTag = userBaseData.BattleTag;
            user.Level = userBaseData.Level;
            // TODO: Fix setting ClanId
            //user.ClanId = userBaseData.Clan.Id;
            _context.SaveChanges();
            return Task.FromResult(0);
        }
    }
}
