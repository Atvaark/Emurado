using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.TitleResource;
using HaloOnline.Server.Model.TitleResource;
using HaloOnline.Server.Model.TitleResource.TitleConfigurations;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class TitleResourceController : ApiController, ITitleResourceService
    {
        // Gets called every 10 minutes by each client
        [HttpPost]
        public GetTitleConfigurationResult GetTitleConfiguration(GetTitleConfigurationRequest request)
        {
            return new GetTitleConfigurationResult
            {
                Result = new ServiceResult<TitleConfiguration>
                {
                    ReturnCode = 0,
                    Data = new TitleConfiguration
                    {
                        CombinationHash = "",
                        Instances = new List<TitleInstance>
                        {
                            new UiDescription("playlist1 uidesc")
                            {
                                Name = "playlist1",
                                NameId = "playlist_1",
                                Icon = "Guardian_300x200"
                            },
                            new UiDescription("playlist2 uidesc")
                            {
                                Name = "playlist2",
                                NameId = "playlist_2"
                            },
                            new UiDescription("playlist3 uidesc")
                            {
                                Name = "playlist3",
                                NameId = "playlist_3"
                            },
                            new UiDescription("helmet_air_assault uidesc")
                            {
                                Name = "helmet_air_assault",
                                NameId = "air_assault_name",
                                DescriptionId = "air_assault_desc",
                                DescriptionShortId = "air_assault_desc_short"
                            },
                            new UiDescription("slayer uidesc")
                            {
                                Name = "slayer",
                                NameId = "slayer",
                                Icon = "slayerMode"
                            },
                            new UiDescription("team_slayer uidesc")
                            {
                                Name = "team_slayer",
                                NameId = "team_slayer",
                                Icon = "slayerMode"
                            },
                            new UiDescription("ctf uidesc")
                            {
                                Name = "ctf",
                                NameId = "ctf",
                                Icon = "dominionMode"
                            },
                            new UiDescription("guardian uidesc")
                            {
                                Name = "guardian",
                                NameId = "guardian",
                                Icon = "Guardian_300x200"
                            },
                            new UiDescription("s3d_turf uidesc")
                            {
                                Name = "s3d_turf",
                                NameId = "s3d_turf",
                                Icon = "turf_300x200"
                            },
                            new UiDescription("s3d_avalanche uidesc")
                            {
                                Name = "s3d_avalanche",
                                NameId = "s3d_avalanche",
                                Icon = "Avalanche_300x200"
                            },
                            new UiDescription("ad1 uidesc")
                            {
                                Name = "ad1",
                                NameId = "ad1",
                                Icon = "ad1",
                                IconMedium = "ad1",
                                IconBig = "ad1"
                            },
                            new UiDescription("ad2 uidesc")
                            {
                                Name = "ad2",
                                NameId = "ad2",
                                Icon = "ad2",
                                IconMedium = "ad2",
                                IconBig = "ad2"
                            },
                            new UiDescription("ad3 uidesc")
                            {
                                Name = "ad3",
                                NameId = "ad3",
                                Icon = "ad3",
                                IconMedium = "ad3",
                                IconBig = "ad3"
                            },
                            new UiDescription("ad4 uidesc")
                            {
                                Name = "ad4",
                                NameId = "ad4",
                                Icon = "ad4",
                                IconMedium = "ad4",
                                IconBig = "ad4"
                            },
                            new UiDescription("ad5 uidesc")
                            {
                                Name = "ad5",
                                NameId = "ad5",
                                Icon = "ad5",
                                IconMedium = "ad5",
                                IconBig = "ad5"
                            },
                            new UiDescription("assault_rifle uidesc")
                            {
                                Name = "assault_rifle",
                                NameId = "assault_rifle",
                                Icon = "weapon_primary_assault_rifle"
                            },
                            new UiDescription("weapon_secondary_magnum uidesc")
                            {
                                Name = "magnum",
                                NameId = "magnum",
                                Icon = "weapon_secondary_magnum"
                            },
                            new UiDescription("frag_grenade uidesc")
                            {
                                Name = "frag_grenade",
                                NameId = "frag_grenade",
                                Icon = "grenade_frag_grenade"
                            },
                            new UiDescription("plasma_grenade uidesc")
                            {
                                Name = "plasma_grenade",
                                NameId = "plasma_grenade",
                                Icon = "grenade_plasma_grenade"
                            },
                            new UiDescription("rank_0 uidesc")
                            {
                                Name = "rank_0",
                                NameId = "rank_0",
                                Icon = "rank001_private_4"
                            },
                            new UiDescription("rank_1 uidesc")
                            {
                                Name = "rank_1",
                                NameId = "rank_1",
                                Icon = "rank002_private_3"
                            },
                            new UiDescription("rank_2 uidesc")
                            {
                                Name = "rank_2",
                                NameId = "rank_2",
                                Icon = "rank003_private_2"
                            },
                            new GameMode("slayer mode")
                            {
                                Name = "slayer",
                                GameModeId = "slayer",
                                GameModeRoundTimeLimit = 7
                            },
                            new GameMode("team_slayer mode") // TODO: Does this really exist?
                            {
                                Name = "team_slayer",
                                GameModeId = "team_slayer",
                                GameModeRoundTimeLimit = 7
                            },
                            new GameMode("ctf mode")
                            {
                                Name = "ctf",
                                GameModeId = "ctf",
                                GameModeRoundTimeLimit = 7
                            },
                            new MapInfo("guardian map info")
                            {
                                Name = "guardian",
                                MapInfoId = "guardian"
                            },
                            new MapInfo("s3d_turf map info")
                            {
                                Name = "s3d_turf",
                                MapInfoId = "s3d_turf"
                            },
                            new MapInfo("s3d_avalanche map info")
                            {
                                Name = "s3d_avalanche",
                                MapInfoId = "s3d_avalanche"
                            },
                            new Weapon("assault_rifle weapon")
                            {
                                Name  = "assault_rifle",
                                SecondaryId = "",
                                Type = "weapon_primary"
                            },
                            new Weapon("magnum weapon")
                            {
                                Name  = "magnum",
                                SecondaryId = "",
                                Type = "weapon_secondary"
                            },
                            new Grenade("frag_grenade grenade")
                            {
                                Name = "frag_grenade",
                                Id = ""
                            },
                            new Grenade("plasma_grenade grenade")
                            {
                                Name = "plasma_grenade",
                                Id = ""
                            },
                            new SuitColor("pink primary color")
                            {
                                Name = "color_pri_13",
                                ColorType = SuitColorType.Primary,
                                Color = Color.DeepPink
                            },
                            new MessageOfTheDay("MOTD Saturday")
                            {
                                Day = DayOfWeek.Saturday,
                                MotdUiDescId = "This is the message of the day."
                            },
                            new PlayerLevel("player level 0")
                            {
                                Name = "rank_0",
                                LevelIndex = 0,
                                XpUnlock = 100,
                            },
                            new PlayerLevel("player level 1")
                            {
                                Name = "rank_1",
                                LevelIndex = 1,
                                XpUnlock = 200,
                            },
                            new PlayerLevel("player level 2")
                            {
                                Name = "rank_2",
                                LevelIndex = 2,
                                XpUnlock = 400,
                            },
                            new PlayerLevel("player level 3")
                            {
                                Name = "rank_3",
                                LevelIndex = 3,
                                XpUnlock = 800,
                            },
                            new Challenge("challenge1")
                            {
                                Name = "challenge1"
                            },
                            new AccountLabel("accountLabel1")
                            {
                                Name = "accountLabel1"
                            },
                            new Playlist("test playlist1")
                            {
                                Name = "playlist1",
                                GameModeCollection =
                                {
                                    "slayer"
                                },
                                MapCollection =
                                {
                                    "guardian"
                                },
                                MinPlayers = 1,
                                MaxPlayers = 8,
                                MaxParty = 2,
                                IsTeamPlaylist = false
                            },
                            new Playlist("test playlist2")
                            {
                                Name = "playlist2",
                                GameModeCollection =
                                {
                                    "team_slayer"
                                },
                                MapCollection =
                                {
                                    "s3d_turf"
                                },
                                MinPlayers = 1,
                                MaxPlayers = 8,
                                MaxParty = 4,
                                IsTeamPlaylist = true
                            },
                            new Playlist("test playlist3")
                            {
                                Name = "playlist3",
                                GameModeCollection =
                                {
                                    "ctf"
                                },
                                MapCollection =
                                {
                                    "s3d_avalanche"
                                },
                                MinPlayers = 1,
                                MaxPlayers = 8,
                                MaxParty = 4,
                                IsTeamPlaylist = true
                            },
                            //// Disabled because it's an annoying popup after logging in
                            //new News("test news")
                            //{
                            //    Name = "news1",
                            //    SortIndex = 5,
                            //    Poster = "poster1",
                            //    TimeStamp = DateTime.Now,
                            //    Text = "text1"
                            //},
                            new Advertisement("ad1")
                            {
                                Name = "ad1",
                                SortIndex = 0,
                                Url = "http://www.google.com/?q=ad1",
                                Timer = 2.0f
                            },
                            new Advertisement("ad2")
                            {
                                Name = "ad2",
                                SortIndex = 1,
                                Url = "http://www.google.com/?q=ad2",
                                Timer = 2.0f
                            },
                            new Advertisement("ad3")
                            {
                                Name = "ad3",
                                SortIndex = 2,
                                Url = "http://www.google.com/?q=ad3",
                                Timer = 2.0f
                            },
                            new Advertisement("ad4")
                            {
                                Name = "ad4",
                                SortIndex = 3,
                                Url = "http://www.google.com/?q=ad4",
                                Timer = 2.0f
                            },
                            new Advertisement("ad5")
                            {
                                Name = "ad5",
                                SortIndex = 4,
                                Url = "http://www.google.com/?q=ad5",
                                Timer = 2.0f
                            },
                            new MultiplayerDefaults("mpdefaults")
                            {
                                Name = "mpdefaults",
                                DefaultPlaylist = "playlist1",
                                DefaultMap = "guardian",
                                DefaultGameMode = "slayer"
                            }
                        }
                    }
                }
            };
        }

        [HttpPost]
        public GetTitleConfigRawResult GetTitleConfigRaw(GetTitleConfigRawRequest request)
        {
            return new GetTitleConfigRawResult
            {
                Result = new ServiceResult<string>
                {
                    Data = ""
                }
            };
        }

        [HttpPost]
        public GetTitleTagsPatchConfigurationResult GetTitleTagsPatchConfiguration(
            GetTitleTagsPatchConfigurationRequest request)
        {
            return new GetTitleTagsPatchConfigurationResult
            {
                Result = new ServiceResult<TitleTagsPatchConfiguration>
                {
                    Data = new TitleTagsPatchConfiguration
                    {
                        CombinationHash = "",
                        Tags = new List<Tag>
                        {
                            new Tag
                            {
                                Name = "TagName",
                                Type = 0,
                                StringValue = "",
                                IntegerValue = 0,
                                FloatValue = 0
                            }
                        }
                    }
                }
            };
        }
    }
}
