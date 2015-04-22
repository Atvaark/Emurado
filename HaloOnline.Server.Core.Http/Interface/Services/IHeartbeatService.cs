using HaloOnline.Server.Core.Http.Model.Heartbeat;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IHeartbeatService
    {
        GetServicesStatusResult GetServicesStatus(GetServicesStatusRequest request);
    }
}
