/*
  LICENSE
  -------
  Copyright (C) 2007-2010 Ray Molenkamp

  This source code is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this source code or the software it produces.

  Permission is granted to anyone to use this source code for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this source code must not be misrepresented; you must not
     claim that you wrote the original source code.  If you use this source code
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original source code.
  3. This notice may not be removed or altered from any source distribution.
*/

using System;
using System.Runtime.InteropServices;
using NoCableLauncher.CoreAudioApi.Interfaces;

namespace NoCableLauncher.CoreAudioApi
{
    internal class MMDevice
    {
        private readonly IMMDevice _RealDevice;
        private PropertyStore _PropertyStore;

        private PropertyStore GetPropertyInformation()
        {
            IPropertyStore propstore;
            Marshal.ThrowExceptionForHR(_RealDevice.OpenPropertyStore(EStgmAccess.STGM_READ, out propstore));
            return new PropertyStore(propstore);
        }

 
        public string FriendlyName
        {
            get
            {
                if (_PropertyStore == null)
                    _PropertyStore = GetPropertyInformation();

                var nameGuid = PKEY.PKEY_Device_FriendlyName;
                  //  ? PKEY.PKEY_Device_FriendlyName
                  //  : PKEY.PKEY_Device_DeviceDesc;

                if (_PropertyStore.Contains(nameGuid))
                    return (string)_PropertyStore[nameGuid].PropVariant.GetValue();
                return "Unknown";
            }
        }

        public string HardwareID
        {
            get
            {
                if (_PropertyStore == null)
                    _PropertyStore = GetPropertyInformation();

                var nameGuid = PKEY.PKEY_Device_HadrwareID;

                if (_PropertyStore.Contains(nameGuid))
                    return (string)_PropertyStore[nameGuid].PropVariant.GetValue();
                return "Unknown";
            }
        }

        public string IconPath
        {
            get
            {
                if (_PropertyStore == null)
                    _PropertyStore = GetPropertyInformation();
                if (_PropertyStore.Contains(PKEY.PKEY_DeviceClass_IconPath))
                    return (string)_PropertyStore[PKEY.PKEY_DeviceClass_IconPath].PropVariant.GetValue();
                return "Unknown";
            }
        }

        public string ID
        {
            get
            {
                string Result;
                Marshal.ThrowExceptionForHR(_RealDevice.GetId(out Result));
                return Result;
            }
        }

        internal MMDevice(IMMDevice realDevice)
        {
            _RealDevice = realDevice;
        }
    }
}
