using HaloOnline.Server.Core.Http.Model.EndpointDispatcher;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IEndpointsDispatcherService
    {
        GetAuthorizationEndpointsResult GetAuthorizationEndpoints(GetAuthorizationEndpointsRequest request);

        GetAuthorizationEndpointsAndDateResult GetAuthorizationEndpointsAndDate(
            GetAuthorizationEndpointsAndDateRequest request);
    }
}
