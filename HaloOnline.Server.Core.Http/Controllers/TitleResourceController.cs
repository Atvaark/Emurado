using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.TitleResource;
using HaloOnline.Server.Model.TitleResource;

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
                            new TitleInstance
                            {
                              Name  = "playlist1 uidesc",
                              ClassName = TitleInstanceConstants.UiDescClassName,
                              Properties = new List<TitleProperty>
                              {
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.TitleInstanceName,
                                      Value = "playlist1"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiNameId,
                                      Value = "playlist_unknown"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiDescId,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiDescShortId,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIcon,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIconMed,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIconBig,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiVideo,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescItemQuality,
                                      Value = ""
                                  },
                              }
                            },
                            new TitleInstance
                            {
                              Name  = "helmet_air_assault uidesc",
                              ClassName = TitleInstanceConstants.UiDescClassName,
                              Properties = new List<TitleProperty>
                              {
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.TitleInstanceName,
                                      Value = "helmet_air_assault"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiNameId,
                                      Value = "air_assault_name"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiDescId,
                                      Value = "air_assault_desc_short"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiDescShortId,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIcon,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIconMed,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIconBig,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiVideo,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescItemQuality,
                                      Value = ""
                                  },
                              }
                            },
                            new TitleInstance
                            {
                              Name  = "slayer uidesc",
                              ClassName = TitleInstanceConstants.UiDescClassName,
                              Properties = new List<TitleProperty>
                              {
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.TitleInstanceName,
                                      Value = "slayer"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiNameId,
                                      Value = "Slayer"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiDescId,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiDescShortId,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIcon,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIconMed,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIconBig,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiVideo,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescItemQuality,
                                      Value = ""
                                  },
                              }
                            },
                            new TitleInstance
                            {
                              Name  = "guardian uidesc",
                              ClassName = TitleInstanceConstants.UiDescClassName,
                              Properties = new List<TitleProperty>
                              {
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.TitleInstanceName,
                                      Value = "guardian"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiNameId,
                                      Value = "Guardian"
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiDescId,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiDescShortId,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIcon,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIconMed,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiIconBig,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescUiVideo,
                                      Value = ""
                                  },
                                  new TitlePropertyString
                                  {
                                      Name = TitleInstanceConstants.UiDescItemQuality,
                                      Value = ""
                                  },
                              }
                            },
                            new TitleInstance
                            {
                                Name = "slayer mode",
                                ClassName = TitleInstanceConstants.GameModeClassName,
                                Properties = new List<TitleProperty>
                                {
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Value = "slayer"
                                    },
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.GameModeId,
                                        Value = "slayer"
                                    },
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.GameModeSecondaryId,
                                        Value = "slayer"
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.GameModeRoundTimeLimit,
                                        Value = 60
                                    },
                                }
                            },
                            new TitleInstance
                            {
                                Name = "guardian map",
                                ClassName = TitleInstanceConstants.MapInfoClassName,
                                Properties = new List<TitleProperty>
                                {
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Value = "guardian"
                                    },
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.MapInfoId,
                                        Value = "guardian"
                                    },
                                }
                            },
                            new TitleInstance
                            {
                              Name  = "pink color",
                              ClassName = TitleInstanceConstants.ColorClassName,
                              Properties = new List<TitleProperty>
                              {
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Value = "color_pri_13"
                                    },
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.ColorType,
                                        Value = TitleInstanceConstants.ColorTypePrimary,
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.ColorR,
                                        Value = 255
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.ColorG,
                                        Value = 20
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.ColorB,
                                        Value = 147
                                    },
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.ColorUiListId,
                                        Value = ""
                                    }

                              }
                            },
                            new TitleInstance
                            {
                                Name = "MOTD Saturday",
                                ClassName = TitleInstanceConstants.MotdClassName,
                                Properties = new List<TitleProperty>
                                {
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Value = TitleInstanceConstants.MotdSaturday
                                    },
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.MotdUiDescId,
                                        Value = "This is the message of the day."
                                    }
                                }
                            },
                            new TitleInstance
                            {
                                Name = "Test player level", // TODO: Fix or remove this, since it has no effects at the moment.
                                ClassName = TitleInstanceConstants.PlayerLevelClassName,
                                Properties = new List<TitleProperty>
                                {
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Value = ""
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.PlayerLevelLevelIndex,
                                        Value = 1
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.PlayerLevelXpUnlock,
                                        Value = 2
                                    },
                                    new TitlePropertyStringList()
                                    {
                                        Name = TitleInstanceConstants.PlayerLevelItemsRecieved,
                                        Value = new List<string>()
                                    },
                                    new TitlePropertyStringList
                                    {
                                        Name = TitleInstanceConstants.PlayerLevelItemsUnlocked,
                                        Value = new List<string>()
                                    },
                                }
                            },
                            new TitleInstance()
                            {
                              Name  = "playlist",
                              ClassName = TitleInstanceConstants.PlaylistClassName,
                              Properties = new List<TitleProperty>
                              {
                                    new TitlePropertyString
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Value = "playlist1"
                                    },
                                    new TitlePropertyStringList
                                    {
                                        Name = TitleInstanceConstants.PlaylistGameModeCollection,
                                        Value = new List<string>
                                        {
                                            "slayer"
                                        }
                                    },
                                    new TitlePropertyStringList()
                                    {
                                        Name = TitleInstanceConstants.PlaylistMapCollection,
                                        Value = new List<string>
                                        {
                                            "guardian"
                                        }
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.PlaylistMinPlayers,
                                        Value = 1
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.PlaylistMaxPlayers,
                                        Value = 2
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.PlaylistMaxParty,
                                        Value = 2
                                    },
                                    new TitlePropertyInteger
                                    {
                                        Name = TitleInstanceConstants.PlaylistIsTeamPlaylist,
                                        Value = 0
                                    }
                              }
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
