using HaloOnline.Server.Core.Http.Model.ArbitraryStorage;

namespace HaloOnline.Server.Core.Http.Interface.Services
{
    public interface IArbitraryStorageService
    {
        WriteDiagnosticsDataResult WriteDiagnosticsData(WriteDiagnosticsDataRequest request);
        WriteAdfPackResult WriteADFPack(WriteADFPackRequest request);
    }
}
