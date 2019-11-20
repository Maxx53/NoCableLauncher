﻿using System;
using System.Runtime.InteropServices;

namespace NoCableLauncher.CoreAudioApi.Interfaces
{
    [Guid("F8679F50-850A-41CF-9C72-430F290290C8"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPolicyConfig
    {
        [PreserveSig]
        int GetMixFormat(string pszDeviceName, IntPtr ppFormat);

        [PreserveSig]
        int GetDeviceFormat(string pszDeviceName, bool bDefault, IntPtr ppFormat);

        [PreserveSig]
        int ResetDeviceFormat(string pszDeviceName);

        [PreserveSig]
        int SetDeviceFormat(string pszDeviceName, IntPtr pEndpointFormat, IntPtr MixFormat);

        [PreserveSig]
        int GetProcessingPeriod(string pszDeviceName, bool bDefault, IntPtr pmftDefaultPeriod, IntPtr pmftMinimumPeriod);

        [PreserveSig]
        int SetProcessingPeriod(string pszDeviceName, IntPtr pmftPeriod);

        [PreserveSig]
        int GetShareMode(string pszDeviceName, IntPtr pMode);

        [PreserveSig]
        int SetShareMode(string pszDeviceName, IntPtr mode);

        [PreserveSig]
        int GetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

        [PreserveSig]
        int SetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

        [PreserveSig]
        int SetDefaultEndpoint(
    [In] [MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName,
    [In] [MarshalAs(UnmanagedType.U4)] ERole role);

        [PreserveSig]
        int SetEndpointVisibility(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName,
            [In] [MarshalAs(UnmanagedType.Bool)] bool bVisible);
    }
}
