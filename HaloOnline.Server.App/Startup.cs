using System;
using Microsoft.Owin.Diagnostics;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace HaloOnline.Server.App
{
    public class Startup
    {
        private const string RootDirectory = "public";

        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage(new ErrorPageOptions
            {
                
            });
            var fileSystem = new PhysicalFileSystem(RootDirectory);
            var options = new FileServerOptions
            {
                EnableDirectoryBrowsing = false, 
                FileSystem = fileSystem
            };
            app.Use(typeof(UrlRewriter));
            app.UseFileServer(options);
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}