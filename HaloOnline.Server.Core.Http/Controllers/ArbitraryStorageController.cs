using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.ArbitraryStorage;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class ArbitraryStorageController : ApiController, IArbitraryStorageService
    {
        [HttpPost]
        public WriteDiagnosticsDataResult WriteDiagnosticsData(WriteDiagnosticsDataRequest request)
        {
            return new WriteDiagnosticsDataResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public WriteAdfPackResult WriteADFPack(WriteADFPackRequest request)
        {
            return new WriteAdfPackResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }
    }
}
