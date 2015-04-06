using System.Web.Http;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Http.Interface.Repositories;
using HaloOnline.Server.Model.Clan;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http
{
    public static class HaloServerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            using (var scope = config.DependencyResolver.BeginScope())
            {
                var userManager = (IHaloUserManager) scope.GetService(typeof (IHaloUserManager));
                var userBaseDataRepository =
                    (IUserBaseDataRepository) scope.GetService(typeof (IUserBaseDataRepository));

                HaloUser testUser1 = new HaloUser
                {
                    UserName = "123"
                };
                HaloUser testUser2 = new HaloUser
                {
                    UserName = "456"
                };
                userManager.CreateAsync(testUser1, "123").Wait();
                userManager.CreateAsync(testUser2, "456").Wait();

                UserBaseData testUser1Data = new UserBaseData
                {
                    User = new UserId
                    {
                        Id = testUser1.UserId
                    },
                    Nickname = "User1",
                    Clan = new ClanId
                    {
                        Id = 1
                    },
                    ClanTag = "ClanTag",
                    Level = 2,
                    BattleTag = "BattleTag"
                };

                UserBaseData testUser2Data = new UserBaseData
                {
                    User = new UserId
                    {
                        Id = testUser2.UserId
                    },
                    Nickname = "User2",
                    Clan = new ClanId
                    {
                        Id = 1
                    },
                    ClanTag = "ClanTag",
                    Level = 10,
                    BattleTag = "BattleTag"
                };

                userBaseDataRepository.CreateUserBaseDataAsync(testUser1Data);
                userBaseDataRepository.CreateUserBaseDataAsync(testUser2Data);
            }
        }
    }
}
