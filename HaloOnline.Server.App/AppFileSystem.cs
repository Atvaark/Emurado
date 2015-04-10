﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HaloOnline.Server.Common;
using Microsoft.Owin.FileSystems;

namespace HaloOnline.Server.App
{
    public class AppFileSystem : IFileSystem
    {
        private readonly IFileSystem _fileSystem;
        private readonly IFileInfo _environmentScript;
        private const string EnvironmentScriptFileName = "app.environment.js";
        private const string EnvironmentScriptSubpath = "/app/scripts/" + EnvironmentScriptFileName; 
        
        public AppFileSystem(IFileSystem fileSystem, IServerOptions serverOptions)
        {
            _fileSystem = fileSystem;
            _environmentScript = GenerateEnvironmentScript(serverOptions);
        }

        public bool TryGetFileInfo(string subpath, out IFileInfo fileInfo)
        {
            if (subpath == EnvironmentScriptSubpath)
            {
                fileInfo = _environmentScript;
                return true;
            }
            var tryGetFileInfo = _fileSystem.TryGetFileInfo(subpath, out fileInfo);
            return tryGetFileInfo;
        }

        private IFileInfo GenerateEnvironmentScript(IServerOptions serverOptions)
        {
            StringWriter scriptWriter = new StringWriter();
            scriptWriter.Write(
                "(function (){" +
                "\"use strict\";" +
                "var app = angular.module('app');" +
                "app.constant('endpointServer', 'http://" + serverOptions.EndpointHostname + ":" + serverOptions.EndpointPort + "');" +
                "})();");
            return new AppFileInfo(Encoding.UTF8.GetBytes(scriptWriter.ToString()), EnvironmentScriptFileName, DateTime.Now);
        }

        public bool TryGetDirectoryContents(string subpath, out IEnumerable<IFileInfo> contents)
        {
            return _fileSystem.TryGetDirectoryContents(subpath, out contents);
        }
    }
}