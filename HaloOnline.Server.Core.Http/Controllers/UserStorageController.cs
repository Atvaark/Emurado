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
            switch (request.ContainerName)
            {
                case DataContainerTypes.Preferences:
                    var preferences = Preferences.Deserialize(request.Data);
                    break;
                default:
                    throw new ArgumentException("ContainerName");
            }
            return new SetPrivateDataResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetPrivateDataResult GetPrivateData(GetPrivateDataRequest request)
        {
            AbstractData data;
            switch (request.ContainerName)
            {
                case  DataContainerTypes.Preferences:
                    var preference = new Preferences
                    {
                        LastReadNewsUnknownValue = 1,
                        LastReadNewsName = "news1"
                    };
                    data = preference.Serialize();
                    break;
                default:
                    throw new ArgumentException("ContainerName");
            }
            return new GetPrivateDataResult
            {
                Result = new ServiceResult<AbstractData>
                {
                    Data = data
                }
            };
        }

        [HttpPost]
        public SetPublicDataResult SetPublicData(SetPublicDataRequest request)
        {
            switch (request.ContainerName)
            {
                case DataContainerTypes.WeaponLoadouts:
                    var weaponLoadouts = WeaponLoadout.Deserialize(request.Data);
                    break;
                case DataContainerTypes.ArmorLoadouts:
                    var armorLoadouts = ArmorLoadout.Deserialize(request.Data);
                    break;
                case DataContainerTypes.Customizations:
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
                case DataContainerTypes.WeaponLoadouts:
                    var weaponLoadout = new WeaponLoadout
                    {
                        ActiveLoadoutSlotIndex = 0,
                        LoadoutSlots = Enumerable.Repeat(new WeaponLoadoutSlot
                        {
                            PrimaryWeapon = "assault_rifle",
                            SecondaryWeapon = "magnum",
                            Grenades = "frag_grenade",
                            Booster = "",
                            ConsumableFirst = "",
                            ConsumableSecond = "",
                            ConsumableThird = "",
                            ConsumableFourth = ""
                        }
                        , 5).ToList()
                    };
                    data = weaponLoadout.Serialize();
                    break;
                case DataContainerTypes.ArmorLoadouts:
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
                            Accessory = ""
                        }, 5).ToList()
                    };
                    data = armorLoadout.Serialize();
                    break;
                case DataContainerTypes.Customizations:
                    var customization = new Customization
                    {
                        AccountLabel = "account_label"
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
