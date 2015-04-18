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
                                Name = "slayer mode",
                                ClassName = TitleInstanceConstants.GameModeClassName,
                                Parents = new List<string>(),
                                Properties = new List<TitleProperty>
                                {
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Type = TitlePropertyType.String,
                                        StringValue = "slayer"
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.GameModeId,
                                        Type = TitlePropertyType.String,
                                        StringValue = "slayer"
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.GameModeSecondaryId,
                                        Type = TitlePropertyType.String,
                                        StringValue = "slayer"
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.GameModeRoundTimeLimit,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 60
                                    },
                                }
                            },
                            new TitleInstance
                            {
                                Name = "guardian map",
                                ClassName = TitleInstanceConstants.MapInfoClassName,
                                Parents = new List<string>(),
                                Properties = new List<TitleProperty>
                                {
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Type = TitlePropertyType.String,
                                        StringValue = "guardian"
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.MapInfoId,
                                        Type = TitlePropertyType.String,
                                        StringValue = "guardian"
                                    },
                                }
                            },
                            new TitleInstance
                            {
                              Name  = "pink color",
                              ClassName = TitleInstanceConstants.ColorClassName,
                              Parents = new List<string>(),
                              Properties = new List<TitleProperty>
                              {
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Type = TitlePropertyType.String,
                                        StringValue = "color_pri_13"
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.ColorType,
                                        Type = TitlePropertyType.String,
                                        StringValue = TitleInstanceConstants.ColorTypePrimary,
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.ColorR,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 255
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.ColorG,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 20
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.ColorB,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 147
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.ColorUiListId,
                                        Type = TitlePropertyType.String,
                                        StringValue = ""
                                    }

                              }
                            },
                            new TitleInstance
                            {
                                Name = "MOTD Saturday",
                                ClassName = TitleInstanceConstants.MotdClassName,
                                Parents = new List<string>(),
                                Properties = new List<TitleProperty>
                                {
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Type = TitlePropertyType.String,
                                        StringValue = TitleInstanceConstants.MotdSaturday
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.MotdUiDescId,
                                        Type = TitlePropertyType.String,
                                        StringValue = "This is the message of the day."
                                    }
                                }
                            },
                            new TitleInstance
                            {
                                Name = "Test player level", // TODO: Fix or remove this, since it has no effects at the moment.
                                ClassName = TitleInstanceConstants.PlayerLevelClassName,
                                Parents = new List<string>(),
                                Properties = new List<TitleProperty>
                                {
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Type = TitlePropertyType.String,
                                        StringValue = ""
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlayerLevelLevelIndex,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 1
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlayerLevelXpUnlock,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 2
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlayerLevelItemsRecieved,
                                        Type = TitlePropertyType.StringList,
                                        StringList = new List<string>()
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlayerLevelItemsUnlocked,
                                        Type = TitlePropertyType.StringList,
                                        StringList = new List<string>()
                                    },
                                }
                            },
                            new TitleInstance()
                            {
                              Name  = "playlist",
                              ClassName = TitleInstanceConstants.PlaylistClassName,
                              Parents = new List<string>(),
                              Properties = new List<TitleProperty>
                              {
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.TitleInstanceName,
                                        Type = TitlePropertyType.String,
                                        StringValue = "playlist1"
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlaylistGameModeCollection,
                                        Type = TitlePropertyType.String, // TODO: Valdiate type. (Is probably a string list.)
                                        StringValue = "" 
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlaylistMapCollection,
                                        Type = TitlePropertyType.String, // TODO: Valdiate type. (Is probably a string list.)
                                        StringValue = ""
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlaylistMinPlayers,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 1
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlaylistMaxPlayers,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 2
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlaylistMaxParty,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 2
                                    },
                                    new TitleProperty
                                    {
                                        Name = TitleInstanceConstants.PlaylistIsTeamPlaylist,
                                        Type = TitlePropertyType.Integer,
                                        IntegerValue = 1
                                    },
                                    
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
