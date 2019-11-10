using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoCableLauncher.CoreAudioApi;

namespace NoCableLauncher
{
    class Program
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess,
               bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
          byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
          byte[] lpBuffer, int nSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern
        bool CloseHandle(IntPtr hHandle);

        public static SettingsClass.Settings settings = SettingsClass.Settings.Default;

        public const string steamName = "steam://rungameid/221680";
        private const string exeName = "Rocksmith2014";
        private const int PROCESS_ALL_ACCESS = 0x1F0FFF;

        private static IntPtr offsetVID;
        private static IntPtr offsetPID;
        private static byte[] vid = new byte[2];
        private static byte[] pid = new byte[2];

        //Realtone Cable ID's
        private static readonly byte[] rtVid = { 0xBA, 0x12 };
        private static readonly byte[] rtPid = { 0xFF, 0x0 };

        //Pattern to find cable ID's
        private static readonly byte[] pattern = { rtVid[0], rtVid[1], 0x92, 0x0A, 0x10, 0xC0, 0x11, 0xC0, rtPid[0], rtPid[1] };

        private static int hotkeyID;

        //Game process handle
        private static pInfo procInfo;

        private struct pInfo
        {
            public IntPtr Handle;
            public IntPtr StartAddress;
            public int Size;
        }

        private static bool stopWait = false;
        private static bool gameRunning = false;

        public static int FromHex(string value)
        {
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            return int.Parse(value, NumberStyles.HexNumber);
        }

        public static byte GetByte(string value)
        {
            return Convert.ToByte(value, 16);
        }

        private static byte[] GetDevId(string value)
        {
            return new byte[2]
            {
                GetByte(value.Substring(2)),
                GetByte(value.Substring(0, 2))
            };
        }

        private static bool IsUsbDeviceConnected(string pid, string vid)
        {
            using (var searcher =
              new ManagementObjectSearcher(@"Select * From Win32_USBControllerDevice"))
            {
                using (var collection = searcher.Get())
                {
                    foreach (var device in collection)
                    {
                        var usbDevice = Convert.ToString(device);

                        if (usbDevice.Contains(pid) && usbDevice.Contains(vid))
                            return true;
                    }
                }
            }
            return false;
        }
        private static bool IsDeviceUsbAndConnected(string pid, string vid)
        {
            return ((settings.VID.All(number => number == 0) && settings.PID.All(number => number == 0)) || IsUsbDeviceConnected(settings.PID, settings.VID));
        }

        private static void ExitWithError(string value)
        {
            if (value != string.Empty)
                MessageBox.Show(value, $"{Application.ProductName} Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Environment.Exit(0);
        }

        private static void ReadDeviceValues(bool multiplayer)
        {
            try
            {
                if (IsDeviceUsbAndConnected(settings.PID, settings.VID) && !multiplayer)
                {
                    vid = GetDevId(settings.VID);
                    pid = GetDevId(settings.PID);
                }
                else
                {
                    if (settings.Multiplayer)
                    {
                        vid = GetDevId(settings.VID2);
                        pid = GetDevId(settings.PID2);
                    }
                    else
                    {
                        // Dummy values to prevent the duplicated Rocksmith "real-cables" message
                        vid = pid = new byte[] { 0x01, 0x00 };
                    }
                }
            }
            catch (Exception exc)
            {
                ExitWithError(exc.Message);
            }
        }

        private static void ReadOffsetValues()
        {
            try
            {
                // Getting RAM offsets
                offsetVID = new IntPtr(FromHex(settings.offsetVID));
                offsetPID = new IntPtr(FromHex(settings.offsetPID));
            }
            catch (Exception exc)
            {
                ExitWithError(exc.Message);
            }
        }

        private static void StartGame()
        {
            // Can't hook process at this moment
            // We have to wait while game starts
            if (!settings.isSteam)
            {
                if (File.Exists(settings.gamePath))
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = Path.GetFileNameWithoutExtension(settings.gamePath),
                        WorkingDirectory = Path.GetDirectoryName(settings.gamePath)
                    };

                    Process.Start(startInfo);
                }
                else
                {
                    ExitWithError($"Exe file at \"{settings.gamePath}\" not found, check game path setting.");
                }
            }
            else
                //This do not return game process!
                //Steam starts game with some delay
                Process.Start(steamName);
        }

        //asd

        private static void HookProcess()
        {
            // Waiting 60 seconds, while game starts
            for (int i = 0; i < 60; i++)
            {
                // Delay hotfix
                Thread.Sleep(3000);

                // Finding game process
                Process[] processes = Process.GetProcessesByName(exeName);

                if (processes.Length <= 0) continue;

                // If game process found

                var process = processes[0];

                // Open process for writing
                procInfo.Handle = OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);

                try
                {
                    procInfo.StartAddress = process.Modules[0].BaseAddress;
                    procInfo.Size = process.Modules[0].ModuleMemorySize;
                }
                catch (Exception)
                {
                    continue;
                }


                if (!settings.Multiplayer) return;

                process.EnableRaisingEvents = true;
                process.Exited += process_Exited;
                gameRunning = true;

                return;
            }

            ExitWithError($"Can't find process: {exeName}.exe");
        }

        private static void process_Exited(object sender, EventArgs e)
        {
            gameRunning = false;
            stopWait = true;
        }

        private static bool CheckOffsets()
        {
            int output = 0;
            byte[] retVid = new byte[2];
            byte[] retPid = new byte[2];

            ReadProcessMemory(procInfo.Handle, offsetVID, retVid, 2, ref output);
            ReadProcessMemory(procInfo.Handle, offsetPID, retPid, 2, ref output);

            return (retPid.SequenceEqual(rtPid) && retVid.SequenceEqual(rtVid));
        }


        private static void FindOffsets()
        {
            try
            {
                byte[] buffer = new byte[procInfo.Size];
                int bytesread = 0;
                int counter = 0;

                // Reading exe bytes to buffer
                ReadProcessMemory(procInfo.Handle, procInfo.StartAddress, buffer, procInfo.Size, ref bytesread);

                if (pattern.Length <= buffer.Length)
                {
                    // Finding values by pattern
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        if (buffer[i] == pattern[0])
                        {
                            for (var j = 0; j < pattern.Length; j++)
                            {
                                if (buffer[i + j] == pattern[j])
                                {
                                    counter++;

                                    if (counter == pattern.Length)
                                    {
                                        var result = procInfo.StartAddress + i;

                                        offsetVID = result;
                                        offsetPID = result + (pattern.Length - 2);

                                        // Saving new offsets to settings
                                        settings.offsetVID = offsetVID.ToString("X8");
                                        settings.offsetPID = offsetPID.ToString("X8");
                                        settings.Save();

                                        return;
                                    }
                                }
                                else
                                    counter = 0;
                            }
                        }
                    }
                }

                ExitWithError("Offsets not found!");
            }
            catch (Exception exc)
            {
                ExitWithError(exc.Message);
            }
        }

        private static void Patch()
        {
            try
            {
                //Patching!
                int output = 0;
                WriteProcessMemory(procInfo.Handle, offsetVID, vid, 2, ref output);
                WriteProcessMemory(procInfo.Handle, offsetPID, pid, 2, ref output);
            }
            catch (Exception)
            {
                ExitWithError("Patching error!");
            }
        }

        private static void InitHotKey()
        {
            hotkeyID = HotKeyManager.RegisterHotKey(Keys.M, KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += HotKeyManager_HotKeyPressed;
        }

        private static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            stopWait = true;
        }

        private static bool RequiresCaptureDeviceReenable = false;

        // Disables all recording devices except for the one used in-game
        private static void FixRecordingDevices()
        {
            stopWait = false;

            Common.LoadDeviceList();

            if (Common.devices.Count > 1)
            {
                RequiresCaptureDeviceReenable = true;
                Common.DisableAllCaptureDevicesExcept(settings.GUID1);
            }
        }

        private const string SettingsFileBat = "NCL_EditSettings.bat";

        [STAThread]
        public static void Main(string[] args)
        {
            if(System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show("NoCableLauncher is already running.");
                Application.Exit();
            }

            bool isOpenSettings = false;

            if (args.Length != 0)
            {
                if (args[0] == "-set")
                    isOpenSettings = true;
            }

            // First of all, check if the bat file exists, if not, create it
            if (!File.Exists(SettingsFileBat))
            {
                File.WriteAllText(SettingsFileBat, "start " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe -set");

                // And since there was no Bat file we assume this is the first we are running the program, so let's open the settings directly
                isOpenSettings = true;
            }

            bool isOpenGame = true;

            if (isOpenSettings)
            {
                // Open settings window
                Application.EnableVisualStyles();
                Settings settings = new Settings();
                Application.Run(settings);

                isOpenGame = settings.OpenGameOnClose;
            }

            if (isOpenGame)
            {
                // Hotfix to allow us to use all Recording devices when not in Multiplayer mode
                if (!settings.Multiplayer)
                {
                    FixRecordingDevices();
                }
                else if (IsDeviceUsbAndConnected(settings.PID, settings.VID))
                {
                    // Disable player2 record device
                    if (!Common.SetDeviceState(settings.GUID2))
                        ExitWithError("Player2 Input device is not set!");

                    // Register hotkey and press event
                    InitHotKey();
                }

                // Reading Offsets
                ReadOffsetValues();

                // Reading PID&VID values for Player1
                ReadDeviceValues(false);

                // Launching Rocksmith 2014
                StartGame();

                // Getting process id and setting exit event
                HookProcess();

                // Checking offsets to write
                if (CheckOffsets() == false)
                {
                    if (settings.manualOffsets)
                        ExitWithError("Offsets values are wrong! Set proper values manually in settings or uncheck \"Manual Offsets\" to find it automatically.");
                    else
                        // Find offsets automatically
                        FindOffsets();
                }

                // Patching game
                Patch();

                // If game still running
                if (settings.Multiplayer)
                {
                    // Waiting for hotkey
                    while (!stopWait)
                        Thread.Sleep(100);

                    if (gameRunning)
                    {
                        // Reading PID&VID values for Player2
                        ReadDeviceValues(true);

                        // Patching game for multiplayer
                        Patch();

                        // Enable player2 record device
                        if (!Common.SetDeviceState(settings.GUID2, true))
                            ExitWithError("Player2 Input device is not set!");
                    }

                    // Free hotkey
                    HotKeyManager.UnregisterHotKey(hotkeyID);
                }
                else // !settings.Multiplayer
                {
                    if (Program.settings.SingleplayerMode == 0)
                    {
                        bool okPressed = false;

                        // Process watch
                        var context = TaskScheduler.FromCurrentSynchronizationContext();
                        Task T = Task.Factory.StartNew(() =>
                        {
                            while (true)
                            {
                                Process[] processes = Process.GetProcessesByName(exeName);
                                if (processes.Length <= 0)
                                {
                                    // Ouch
                                    CloseHandle(procInfo.Handle);
                                    Application.Exit();
                                }

                                if (okPressed)
                                    break;

                                Thread.Sleep(50);
                            }
                        });

                        // Wait for the ok prompt
                        MessageBox.Show("After the game is opened and in the main menu, press ALT-TAB to change back to this window and press 'OK'.", "Info");
                        okPressed = true;

                        ReadDeviceValues(true);
                        Patch();

                        Thread.Sleep(500);
                    }
                }

                // Closing game handle
                CloseHandle(procInfo.Handle);

                if (!settings.Multiplayer)
                {
                    if (Program.settings.SingleplayerMode == 1)
                    {
                        // Wait for the game to close so we can re-enable the disabled devices
                        while (true)
                        {
                            Process[] processes = Process.GetProcessesByName(exeName);
                            if (processes.Length <= 0) break;
                            Thread.Sleep(1000);
                        }
                    }

                    if (RequiresCaptureDeviceReenable)
                        Common.ReEnableCaptureDevices();
                }
            }
        }
    }
}
