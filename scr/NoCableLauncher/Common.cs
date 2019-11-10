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
        public static BindingList<SoundDevice> devices = new BindingList<SoundDevice>();
        private static MMDeviceCollection pDevices;
        private static MMDeviceEnumerator DeviceEnumerator = new MMDeviceEnumerator();
        private static string defaultID = "0000";

        private static PolicyConfigClient pPolicyConfig = new PolicyConfigClient();

        public static string GetPDeviceId(int index)
        {
            return pDevices[index].ID;
        }

        public static void LoadDeviceList()
        {
            devices.Clear();

            pDevices = DeviceEnumerator.EnumerateAudioEndPoints(EDataFlow.eCapture, EDeviceState.Active | EDeviceState.Disabled);

            for (int i = 0; i < pDevices.Count; i++)
            {
                string devid = pDevices[i].HardwareID;

                string vid = defaultID;
                string pid = defaultID;

                if (devid.Contains("PID_"))
                {
                    vid = devid.Substring(devid.IndexOf("VID_") + 4, 4);
                    pid = devid.Substring(devid.IndexOf("PID_") + 4, 4);
                }

                devices.Add(new SoundDevice(pDevices[i].FriendlyName, vid, pid));
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
                    DisabledEndpoints.Add(pDevices[i].ID);
                    SetDeviceState(pDevices[i].ID);
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
