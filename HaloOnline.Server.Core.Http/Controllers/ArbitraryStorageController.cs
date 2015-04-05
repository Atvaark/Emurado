using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.ArbitraryStorage;
using HaloOnline.Server.Model.ArbitraryStorage;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class ArbitraryStorageController : ApiController, IArbitraryStorageService
    {
        // TODO: Check if this WriteDiagnosticsDataRequest is JSON
        [HttpPost]
        public WriteDiagnosticsDataResult WriteDiagnosticsData(WriteDiagnosticsDataRequest request)
        {
            return new WriteDiagnosticsDataResult
            {
                Result = new ServiceResult<bool>()
            };
        }

        [HttpPost]
        public WriteAdfPackResult WriteADFPack(WriteADFPackRequest request)
        {
            return new WriteAdfPackResult
            {
                Result = new ServiceResult<bool>()
            };
        }
    }
}
