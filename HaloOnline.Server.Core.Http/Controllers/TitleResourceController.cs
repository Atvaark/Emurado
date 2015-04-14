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
        public TitleConfigurationResult GetTitleConfiguration(GetTitleConfigurationRequest request)
        {
            return new TitleConfigurationResult
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
                                Name = "InstanceName",
                                ClassName = "InstanceClassName",
                                Parents = new List<string>
                                {
                                    "Parent1",
                                    "Parent2",
                                    "Parent3",
                                },
                                Properties = new List<TitleProperty>
                                {
                                    new TitleProperty
                                    {
                                        Name = "PropertyName1",
                                        Type = 0,
                                        StringValue = "StringPropertyValue"
                                    },
                                    new TitleProperty
                                    {
                                        Name = "PropertyName2",
                                        Type = 0,
                                        FloatValue = 123.45f
                                    },
                                    new TitleProperty
                                    {
                                        Name = "PropertyName3",
                                        Type = 0,
                                        IntegerValue = int.MaxValue
                                    },
                                    new TitleProperty
                                    {
                                        Name = "PropertyName4",
                                        Type = 0,
                                        LongValue = long.MaxValue
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
