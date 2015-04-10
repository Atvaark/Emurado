using System;
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
                    var weaponLoadouts = WeaponLoadout.Deserialize(request.Data);
                    break;
                case PublicDataContainerTypes.ArmorLoadouts:
                    var armorLoadouts = ArmorLoadout.Deserialize(request.Data);
                    break;
                case PublicDataContainerTypes.Customizations:
                    var customizations = Customization.Deserialize(request.Data);
                    break;
                default:
                    throw new ArgumentException("ContainerName");
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
            AbstractData data;
            switch (request.ContainerName)
            {
                case PublicDataContainerTypes.WeaponLoadouts:
                    var weaponLoadout = new WeaponLoadout
                    {
                        ActiveLoadoutSlotIndex = 0,
                        LoadoutSlots = Enumerable.Repeat(new WeaponLoadoutSlot
                        {
                            PrimaryWeapon = "assault_rifle",
                            SecondaryWeapon = "magnum",
                            Grenade = "frag_grenade",
                            Unknown1 = "",
                            Unknown2 = "",
                            Unknown3 = "",
                            Unknown4 = "",
                            Unknown5 = ""
                        }
                        , 5).ToList()
                    };
                    data = weaponLoadout.Serialize();
                    break;
                case PublicDataContainerTypes.ArmorLoadouts:
                    var armorLoadout = new ArmorLoadout
                    {
                        ActiveLoadoutSlotIndex = 0,
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
                    var customization = new Customization
                    {
                        Unknown1 = 0,
                        Unknown2 = 0,
                        Unknown3 = 0,
                        Unknown4 = 0,
                        Unknown5 = 0,
                        Unknown6 = 0,
                        Unknown7 = 0,
                        Unknown8 = 0
                    };
                    data = customization.Serialize();
                    break;
                default:
                    throw new ArgumentException("ContainerName");
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
