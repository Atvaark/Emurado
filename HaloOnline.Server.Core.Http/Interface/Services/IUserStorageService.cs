using HaloOnline.Server.Core.Http.Model.UserStorage;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IUserStorageService
    {
        SetPrivateDataResult SetPrivateData(SetPrivateDataRequest request);
        GetPrivateDataResult GetPrivateData(GetPrivateDataRequest request);
        SetPublicDataResult SetPublicData(SetPublicDataRequest request);
        GetPublicDataResult GetPublicData(GetPublicDataRequest request);
    }
}
