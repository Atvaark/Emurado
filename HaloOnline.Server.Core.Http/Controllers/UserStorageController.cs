using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.UserStorage;
using HaloOnline.Server.Model.User;
using HaloOnline.Server.Model.UserStorage;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class UserStorageController : ApiController, IUserStorageService
    {
        [HttpPost]
        public SetPrivateDataResult SetPrivateData(SetPrivateDataRequest request)
        {
            return new SetPrivateDataResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = false
                }
            };
        }

        [HttpPost]
        public GetPrivateDataResult GetPrivateData(GetPrivateDataRequest request)
        {
            if (request.ContainerName == PublicDataContainerTypes.ArmorLoadouts)
            {
                return new GetPrivateDataResult
                {
                    Result = new ServiceResult<AbstractData>
                    {
                        Data = new AbstractData
                        {
                            Version = 0,
                            Layout = 0,
                            Data = new byte[]
                            {
                            }
                        }
                    }
                };
            }


            return new GetPrivateDataResult
            {
                Result = new ServiceResult<AbstractData>
                {
                    Data = new AbstractData
                    {
                        Version = 0,
                        Layout = 0,
                        Data = new byte[]
                        {
                        }
                    }
                }
            };
        }

        [HttpPost]
        public SetPublicDataResult SetPublicData(SetPublicDataRequest request)
        {
            switch (request.ContainerName)
            {
                case PublicDataContainerTypes.WeaponLoadouts:
                    break;
                case PublicDataContainerTypes.ArmorLoadouts:
                    var test = ArmorLoadout.Deserialize(request.Data);
                    break;
                case PublicDataContainerTypes.Customizations:
                    break;
                default:
                    break;
            }

            return new SetPublicDataResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetPublicDataResult GetPublicData(GetPublicDataRequest request)
        {
            AbstractData data = new AbstractData
            {
                Version = 0,
                Layout = 12,
                Data = new byte[0]
            };
            switch (request.ContainerName)
            {
                case PublicDataContainerTypes.WeaponLoadouts:
                    break;
                case PublicDataContainerTypes.ArmorLoadouts:
                    var armorLoadout = new ArmorLoadout
                    {
                        PrimaryColor = "color_pri_13",
                        SecondaryColor = "color_sec_13",
                        VisorColor = "color_visor_5",
                        LightsColor = "color_lights_3",
                        HologramsColor = "color_holo_3",
                        Slots = Enumerable.Repeat(new ArmorLoadoutSlot
                        {
                            Head = "helmet_air_assault",
                            Shoulders = "shoulder_air_assault",
                            Torso = "chest_air_assault",
                            Hands = "arms_air_assault",
                            Legs = "legs_air_assault",
                            Reserved = ""
                        }, 5).ToList()
                    };
                    data = armorLoadout.Serialize();
                    break;
                case PublicDataContainerTypes.Customizations:
                    break;
                default:
                    break;
            }


            return new GetPublicDataResult
            {
                Result = new ServiceResult<List<PerUser>>
                {
                    Data = new List<PerUser>
                    {
                        new PerUser
                        {
                            User = new UserId
                            {
                                Id = 1
                            },
                            PerUserData = data
                        }
                    }
                }
            };
        }
    }
}
