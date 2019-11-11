using NoCableLauncher.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static NoCableLauncher.Settings;

namespace NoCableLauncher
{
    public static class Common
    {
        internal static SettingsClass.Settings settings = SettingsClass.Settings.Default;

        public static BindingList<SoundDevice> devices = new BindingList<SoundDevice>();
        private static MMDeviceCollection pDevices;
        private static MMDeviceEnumerator DeviceEnumerator = new MMDeviceEnumerator();
        private static string defaultID = "0000";

        private static PolicyConfigClient pPolicyConfig = new PolicyConfigClient();

        public static string GetPDeviceId(int index)
        {
            return pDevices[index].ID;
        }

        /// <summary>
        /// Gets device VID and PID from given hardware id
        /// </summary>
        /// <param name="hardwareId"></param>
        /// <returns>VID and PID as Tuple</returns>
        public static Tuple<string, string> GetDeviceVidPid(string hardwareId)
        {
            string vid = defaultID;
            string pid = defaultID;

            if (hardwareId.Contains("PID_"))
            {
                vid = hardwareId.Substring(hardwareId.IndexOf("VID_") + 4, 4);
                pid = hardwareId.Substring(hardwareId.IndexOf("PID_") + 4, 4);
            }

            return new Tuple<string, string>(vid, pid);
        }

        public static void LoadDeviceList()
        {
            devices.Clear();

            pDevices = DeviceEnumerator.EnumerateAudioEndPoints(EDataFlow.eCapture, EDeviceState.Active | EDeviceState.Disabled);

            for (int i = 0; i < pDevices.Count; i++)
            {
                var deviceVidPid = GetDeviceVidPid(pDevices[i].HardwareID);
                devices.Add(new SoundDevice(pDevices[i].FriendlyName, deviceVidPid.Item1, deviceVidPid.Item2));
            }

        }

        public static bool SetDeviceState(string guid, bool enabled = false)
        {
            if (guid != string.Empty)
            {
                pPolicyConfig.SetEndpointVisibility(guid, enabled);
                return true;
            }

            return false;
        }

        private static List<string> DisabledEndpoints = new List<string>();

        public static void DisableAllCaptureDevicesExcept(string guid)
        {
            for (int i = 0; i < pDevices.Count; i++)
            {
                if (pDevices[i].DeviceState == EDeviceState.Active && pDevices[i].ID != guid)
                {
                    // We do not need to disable any device that doesn't conflict with the patched vid and pid
                    var deviceVidPid = GetDeviceVidPid(pDevices[i].HardwareID);
                    if (deviceVidPid.Item1 == settings.PID && deviceVidPid.Item2 == settings.VID)
                    {
                        DisabledEndpoints.Add(pDevices[i].ID);
                        SetDeviceState(pDevices[i].ID);
                    }
                }
            }
        }

        public static void ReEnableCaptureDevices()
        {
            foreach (var guid in DisabledEndpoints)
            {
                SetDeviceState(guid, true);
            }
        }

        public static int GetDeviceIndex(string guid)
        {
            if (guid != string.Empty)
            {
                for (int i = 0; i < pDevices.Count; i++)
                {
                    if (pDevices[i].ID == guid)
                    {
                        return i;
                    }
                }
            }

            return 0;
        }

    }
}
