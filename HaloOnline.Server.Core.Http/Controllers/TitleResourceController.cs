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
                                NameId = "playlist_unknown"
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
                                NameId = "Slayer"
                            },
                            new UiDescription("guardian uidesc")
                            {
                                Name = "guardian",
                                NameId = "Guardian"
                            },
                            new GameMode("slayer mode")
                            {
                                Name = "slayer",
                                GameModeId = "slayer",
                                GameModeSecondaryId = "slayer",
                                GameModeRoundTimeLimit = 60
                            },
                            new MapInfo("guardian map info")
                            {
                                Name = "guardian",
                                MapInfoId = "guardian"
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
                            // TODO: Fix or remove this, since it has no effects at the moment.
                            new PlayerLevel("Test player level")
                            {
                                Name = "",
                                LevelIndex = 1,
                                XpUnlock = 2,
                                ItemsRecieved =
                                {
                                    
                                },
                                ItemsUnlocked =
                                {
                                    
                                }
                            },
                            new Playlist("test playlist")
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
