using HaloOnline.Server.Core.Http.Model.TitleResource;
using HaloOnline.Server.Model.TitleResource;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface ITitleResourceService
    {
        TitleConfigurationResult GetTitleConfiguration(GetTitleConfigurationRequest request);
        GetTitleConfigRawResult GetTitleConfigRaw(GetTitleConfigRawRequest request);

        GetTitleTagsPatchConfigurationResult GetTitleTagsPatchConfiguration(
            GetTitleTagsPatchConfigurationRequest request);
    }
}
