﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PNPController.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool backgroundWorker1_ProgressChanged {
            get {
                return ((bool)(this["backgroundWorker1_ProgressChanged"]));
            }
            set {
                this["backgroundWorker1_ProgressChanged"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public string backgroundWorkerUpdateDRO_ProgressChanged {
            get {
                return ((string)(this["backgroundWorkerUpdateDRO_ProgressChanged"]));
            }
            set {
                this["backgroundWorkerUpdateDRO_ProgressChanged"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("36.7")]
        public double SettingBoardOffsetX {
            get {
                return ((double)(this["SettingBoardOffsetX"]));
            }
            set {
                this["SettingBoardOffsetX"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("74.7")]
        public double SettingBoardOffsetY {
            get {
                return ((double)(this["SettingBoardOffsetY"]));
            }
            set {
                this["SettingBoardOffsetY"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.6")]
        public double SettingPCBThickness {
            get {
                return ((double)(this["SettingPCBThickness"]));
            }
            set {
                this["SettingPCBThickness"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("12000")]
        public int SettingFeedRate {
            get {
                return ((int)(this["SettingFeedRate"]));
            }
            set {
                this["SettingFeedRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("750")]
        public int SettingTimeMS {
            get {
                return ((int)(this["SettingTimeMS"]));
            }
            set {
                this["SettingTimeMS"] = value;
            }
        }
    }
}