using HaloOnline.Server.Core.Http.Model.SessionControl;
using HaloOnline.Server.Model.SessionControl;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface ISessionControlService
    {
        ClientGetStatusResult ClientGetStatus(ClientGetStatusRequest request);
        GetSessionBasicDataResult GetSessionBasicData(GetSessionBasicDataRequest request);
        GetSessionChainResult GetSessionChain(GetSessionChainRequest request);
    }
}
