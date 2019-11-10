using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NoCableLauncher
{
    class SettingsClass
    {
        [CompilerGenerated]
        [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
        internal sealed class Settings : ApplicationSettingsBase
        {

            private static Settings defaultInstance = ((Settings)(Synchronized(new Settings())));

            public static Settings Default
            {
                get
                {
                    return defaultInstance;
                }
            }

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue(Program.steamName)]
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


            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("012DE6EC")]
            public string offsetVID
            {
                get
                {
                    return ((string)(this["offsetVID"]));
                }
                set
                {
                    this["offsetVID"] = value;
                }
            }

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("012DE6F4")]
            public string offsetPID
            {
                get
                {
                    return ((string)(this["offsetPID"]));
                }
                set
                {
                    this["offsetPID"] = value;
                }
            }

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("0000")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("0000")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("0000")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("0000")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("")]
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


            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("True")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("False")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("False")]
            public bool manualOffsets
            {
                get
                {
                    return ((bool)(this["manualOffsets"]));
                }
                set
                {
                    this["manualOffsets"] = value;
                }
            }


            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("False")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("False")]
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

            [SettingsProvider(typeof(PortableSettingsProvider))]
            [UserScopedSetting]
            [DebuggerNonUserCode]
            [DefaultSettingValue("0")]
            public int SingleplayerMode
            {
                get
                {
                    return ((int)(this["SingleplayerMode"]));
                }
                set
                {
                    this["SingleplayerMode"] = value;
                }
            }

        }
    }
}
