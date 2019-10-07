namespace NoCableLauncher
{
    class SettingsClass
    {
        [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
        internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
        {

            private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

            public static Settings Default
            {
                get
                {
                    return defaultInstance;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute(Program.steamName)]
            public string gamePath
            {
                get
                {
                    return ((string)(this["gamePath"]));
                }
                set
                {
                    this["gamePath"] = value;
                }
            }


            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("012DE6EC")]
            public string offcetVID
            {
                get
                {
                    return ((string)(this["offcetVID"]));
                }
                set
                {
                    this["offcetVID"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("012DE6F4")]
            public string offcetPID
            {
                get
                {
                    return ((string)(this["offcetPID"]));
                }
                set
                {
                    this["offcetPID"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("0000")]
            public string PID
            {
                get
                {
                    return ((string)(this["PID"]));
                }
                set
                {
                    this["PID"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("0000")]
            public string VID
            {
                get
                {
                    return ((string)(this["VID"]));
                }
                set
                {
                    this["VID"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("0000")]
            public string PID2
            {
                get
                {
                    return ((string)(this["PID2"]));
                }
                set
                {
                    this["PID2"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("0000")]
            public string VID2
            {
                get
                {
                    return ((string)(this["VID2"]));
                }
                set
                {
                    this["VID2"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("")]
            public string GUID1
            {
                get
                {
                    return ((string)(this["GUID1"]));
                }
                set
                {
                    this["GUID1"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("")]
            public string GUID2
            {
                get
                {
                    return ((string)(this["GUID2"]));
                }
                set
                {
                    this["GUID2"] = value;
                }
            }


            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("True")]
            public bool isSteam
            {
                get
                {
                    return ((bool)(this["isSteam"]));
                }
                set
                {
                    this["isSteam"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("False")]
            public bool Multiplayer
            {
                get
                {
                    return ((bool)(this["Multiplayer"]));
                }
                set
                {
                    this["Multiplayer"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("False")]
            public bool manualOffcets
            {
                get
                {
                    return ((bool)(this["manualOffcets"]));
                }
                set
                {
                    this["manualOffcets"] = value;
                }
            }


            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("False")]
            public bool manualDev1
            {
                get
                {
                    return ((bool)(this["manualDev1"]));
                }
                set
                {
                    this["manualDev1"] = value;
                }
            }

            [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("False")]
            public bool manualDev2
            {
                get
                {
                    return ((bool)(this["manualDev2"]));
                }
                set
                {
                    this["manualDev2"] = value;
                }
            }
        }
    }
}
