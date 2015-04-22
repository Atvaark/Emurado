using HaloOnline.Server.Core.Http.Model.TitleResource;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface ITitleResourceService
    {
        GetTitleConfigurationResult GetTitleConfiguration(GetTitleConfigurationRequest request);
        GetTitleConfigRawResult GetTitleConfigRaw(GetTitleConfigRawRequest request);

        GetTitleTagsPatchConfigurationResult GetTitleTagsPatchConfiguration(
            GetTitleTagsPatchConfigurationRequest request);
    }
}
