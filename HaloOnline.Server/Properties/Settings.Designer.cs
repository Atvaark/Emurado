﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18444
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HaloOnline.Server.Properties {
    
    
    [CompilerGenerated()]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("44300")]
        public int DispatcherPort {
            get {
                return ((int)(this["DispatcherPort"]));
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("11705")]
        public int EndpointPort {
            get {
                return ((int)(this["EndpointPort"]));
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("27027")]
        public int LogPort {
            get {
                return ((int)(this["LogPort"]));
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("11774")]
        public int ClientPort {
            get {
                return ((int)(this["ClientPort"]));
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("11700")]
        public int AppPort {
            get {
                return ((int)(this["AppPort"]));
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("localhost")]
        public string EndpointHostname {
            get {
                return ((string)(this["EndpointHostname"]));
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [SpecialSetting(SpecialSetting.ConnectionString)]
        [DefaultSettingValue("Data Source=|DataDirectory|halodb.sqlite")]
        public string HaloDbContext {
            get {
                return ((string)(this["HaloDbContext"]));
            }
        }
    }
}
