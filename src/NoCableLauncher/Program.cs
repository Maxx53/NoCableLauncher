using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using NoCableLauncher.CoreAudioApi;
using System.Linq;

namespace NoCableLauncher
{
    class Program
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess,
               bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress,
          byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, 
          byte[] lpBuffer, int nSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern
        bool CloseHandle(int handle);

        public static SettingsClass.Settings settings = SettingsClass.Settings.Default;
        private static PolicyConfigClient pPolicyConfig = new PolicyConfigClient();

        public const string steamName = "steam://rungameid/221680";
        private const string exeName = "Rocksmith2014";
        private const int PROCESS_ALL_ACCESS = 2035711;

        private static int offcetVID = 0;
        private static int offcetPID = 0;
        private static byte[] vid = new byte[2];
        private static byte[] pid = new byte[2];

        //Realtone Cable ID's
        private static readonly byte[] rtVid = new byte[2] { 186, 18 };
        private static readonly byte[] rtPid = new byte[2] { 255, 0 };

        //Pattern to find cable ID's
        private static readonly byte[] pattern = new byte[] { rtVid[0], rtVid[1], 146, 10, 16, 192, 17, 192, rtPid[0], rtPid[1] };

        private static int hotkeyID = 0;

        //Game process handle
        private static pInfo procInfo = new pInfo();

        private struct pInfo
        {
            public int Handle;
            public int StartAddress;
            public int Size;
        }


        private static bool stopWait = false;
        private static bool gameRunning = false;


        public static void SetDeviceState(string guid, bool enabled = false)
        {
            if (guid != string.Empty)
            {
                pPolicyConfig.SetEndpointVisibility(guid, enabled);
            }
            else
                ExitWithError("Player2 Input device is not set!");
        }

        public static int FromHex(string value)
        {
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            return Int32.Parse(value, NumberStyles.HexNumber);
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

        private static void ExitWithError(string value)
        {
            if (value != string.Empty)
                MessageBox.Show(value, Application.ProductName + " Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Environment.Exit(0);
        }

        private static void ReadDeviceValues(bool multiplayer)
        {
            try
            {
                //Getting device VID & PID
                if (!multiplayer)
                {
                    vid = GetDevId(settings.VID);
                    pid = GetDevId(settings.PID);
                }
                else
                {
                    vid = GetDevId(settings.VID2);
                    pid = GetDevId(settings.PID2);
                }
            }
            catch (Exception exc)
            {
                ExitWithError(exc.Message);
            }
        }

        private static void ReadOffcetValues()
        {
            try
            {
                //Getting RAM offcets
                offcetVID = FromHex(settings.offcetVID);
                offcetPID = FromHex(settings.offcetPID);
            }
            catch (Exception exc)
            {
                ExitWithError(exc.Message);
            }
        }

        private static void StartGame()
        {
            //Can't hook process at this moment
            //We have to wait while game starts
            if (!settings.isSteam)
            {
                if (File.Exists(settings.gamePath))
                {
                    var startInfo = new ProcessStartInfo();
                    startInfo.FileName = Path.GetFileNameWithoutExtension(settings.gamePath);
                    startInfo.WorkingDirectory = Path.GetDirectoryName(settings.gamePath);

                    Process.Start(startInfo);
                }
                else
                {
                    ExitWithError(string.Format("Exe file at \"{0}\" not found, check game path setting.", settings.gamePath));
                }
            }
            else
                //This do not return game process!
                //Steam starts game with some delay
                Process.Start(steamName);
        }


        private static void HookProcess()
        {
            //Waiting 60 seconds, while game starts
            for (int i = 0; i < 60; i++)
            {
                //Delay hotfix
                Thread.Sleep(3000);

                //Finding game process
                Process[] processes = Process.GetProcessesByName(exeName);

                if (processes.Length > 0)
                {
                    //If game process found

                    var process = processes[0];

                    //Open process for writing
                    procInfo.Handle = (int)Program.OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);
                    procInfo.StartAddress = (int)process.Modules[0].BaseAddress;
                    procInfo.Size = process.Modules[0].ModuleMemorySize;

                    if (settings.Multiplayer)
                    {
                        process.EnableRaisingEvents = true;
                        process.Exited += process_Exited;
                        gameRunning = true;
                    }

                    return;
                }
            }

            ExitWithError(string.Format("Can't find process: {0}.exe", exeName));
        }

        private static void process_Exited(object sender, EventArgs e)
        {
            gameRunning = false;
            stopWait = true;
        }

        private static bool CheckOffcets()
        {
            int output = 0;
            byte[] retVid = new byte[2];
            byte[] retPid = new byte[2];

            ReadProcessMemory(procInfo.Handle, offcetVID, retVid, 2, ref output);
            ReadProcessMemory(procInfo.Handle, offcetPID, retPid, 2, ref output);

            return (retPid.SequenceEqual(rtPid) && retVid.SequenceEqual(rtVid));
        }


        private static void FindOffcets()
        {
            try
            {
                byte[] buffer = new byte[procInfo.Size];
                int bytesread = 0;
                int counter = 0;

                //Reading exe bytes to buffer
                ReadProcessMemory(procInfo.Handle, procInfo.StartAddress, buffer, procInfo.Size, ref bytesread);

                if (pattern.Length <= buffer.Length)
                {
                    //Finding values by pattern
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
                                        var result = i + procInfo.StartAddress;

                                        offcetVID = result;
                                        offcetPID = result + (pattern.Length - 2);

                                        //Saving new offcets to settings
                                        settings.offcetVID = offcetVID.ToString("X8");
                                        settings.offcetPID = offcetPID.ToString("X8");
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

                ExitWithError("Offcets not found!");
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
                WriteProcessMemory(procInfo.Handle, offcetVID, vid, 2, ref output);
                WriteProcessMemory(procInfo.Handle, offcetPID, pid, 2, ref output);
            }
            catch (Exception)
            {
                ExitWithError("Patching error!");
            }
        }

        private static void InitHotKey()
        {
            hotkeyID = HotKeyManager.RegisterHotKey(Keys.M, KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
        }

        private static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            stopWait = true;
        }

        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (args[0] == "-set")
                {
                    //Open settings window
                    Application.EnableVisualStyles();
                    Application.Run(new Settings());
                }    
            }
            else
            {
                if (settings.Multiplayer)
                {
                    //Disable player2 record device
                    SetDeviceState(settings.GUID2, false);

                    //Register hotkey and press event
                    InitHotKey();
                }

                //Reading Offcets
                ReadOffcetValues();

                //Reading PID&VID values for Player1
                ReadDeviceValues(false);

                //Launching Rocksmith 2014
                StartGame();

                //Getting process id and setting exit event
                HookProcess();

                //Checking offcets to write
                if (CheckOffcets() == false)
                {
                    if (settings.manualOffcets)
                        ExitWithError("Offcets values are wrong! Set proper values manually in settings or uncheck \"Manual Offcets\" to find it automatically.");
                    else
                        //Find offcets automatically
                        FindOffcets();
                }

                //Patching game
                Patch();

                if (settings.Multiplayer)
                {
                    //Waiting for hotkey
                    while (!stopWait)
                    {
                        Thread.Sleep(100);
                    }

                    //If game still running
                    if (gameRunning)
                    {
                        //Reading PID&VID values for Player2
                        ReadDeviceValues(true);

                        //Patching game for multiplayer
                        Patch();
                    }

                    //Enable player2 record device
                    SetDeviceState(settings.GUID2, true);

                    //Free hotkey
                    HotKeyManager.UnregisterHotKey(hotkeyID);
                }

                //Closing game handle
                CloseHandle(procInfo.Handle);
            }
        }
    }
}
