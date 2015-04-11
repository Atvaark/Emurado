using System;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Dependencies;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Auth;
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
                SeedServer(scope);
            }
        }

        private static void SeedServer(IDependencyScope scope)
        {
            var userManager = (IHaloUserManager) scope.GetService(typeof (IHaloUserManager));
            var userBaseDataRepository = (IUserBaseDataRepository) scope.GetService(typeof (IUserBaseDataRepository));
            var clanRepository = (IClanRepository) scope.GetService(typeof (IClanRepository));
            var clanMembershipRepository = (IClanMembershipRepository) scope.GetService(typeof (IClanMembershipRepository));

            try
            {
                var clan = new Clan
                {
                    Name = "Clan1",
                    Description = "First clan",
                    Tag = "TAG"
                };
                clanRepository.CreateAsync(clan).Wait();

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
                        Id = 0
                    },
                    ClanTag = "",
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
                        Id = 0
                    },
                    ClanTag = "",
                    Level = 10,
                    BattleTag = "BattleTag"
                };

                userBaseDataRepository.SetUserBaseDataAsync(testUser1Data);
                userBaseDataRepository.SetUserBaseDataAsync(testUser2Data);

                var testUser1ClanMembership = new ClanMembership
                {
                    UserId = testUser1.UserId,
                    ClanId = clan.ClanId,
                    Role = 1
                };

                clanMembershipRepository.CreateAsync(testUser1ClanMembership).Wait();
            }
            catch (Exception)
            {
                Debug.WriteLine("Server initialization failed.");
            }
        }
    }
}
