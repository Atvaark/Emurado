using HaloOnline.Server.Common;
using Microsoft.Owin.Diagnostics;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace HaloOnline.Server.App
{
    public class Startup
    {
        private readonly IServerOptions _options;

        public Startup(IServerOptions options)
        {
            _options = options;
        }

        private const string RootDirectory = "wwwroot";

        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage(new ErrorPageOptions
            {
                
            });
            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = false, 
                FileSystem = new AppFileSystem(new PhysicalFileSystem(RootDirectory), _options)
            };
            app.Use(typeof(UrlRewriter));
            app.UseFileServer(options);
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}