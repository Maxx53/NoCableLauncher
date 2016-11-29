using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using NoCableLauncher.CoreAudioApi;

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

        public static SettingsClass.Settings settings = SettingsClass.Settings.Default;
        private static PolicyConfigClient pPolicyConfig = new PolicyConfigClient();

        public const string steamName = "steam://rungameid/221680";
        private const string exeName = "Rocksmith2014";
        private const int PROCESS_ALL_ACCESS = 2035711;

        private static int offcetVID = 0;
        private static int offcetPID = 0;
        private static byte[] vid = new byte[2];
        private static byte[] pid = new byte[2];

        private static int hotkeyID = 0;
        private static int processID = 0;

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

        private static void GetDeviceValues(bool multiplayer)
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

        private static void GetOffcetValues()
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
                Process.Start(steamName);
        }

        private static void HookProcess()
        {
            //Finding game process
            Process[] processes = Process.GetProcessesByName(exeName);

            if (processes.Length == 0)
                ExitWithError(string.Format("Can't find process: {0}.exe", exeName));

            var process = processes[0];
            processID = process.Id;

            if (settings.Multiplayer)
            {
                process.EnableRaisingEvents = true;
                process.Exited += process_Exited;
                gameRunning = true;
            }
        }

        private static void process_Exited(object sender, EventArgs e)
        {
            gameRunning = false;
            stopWait = true;
        }


        private static void Patch()
        {
            try
            {
                //Open process for writing
                var num = (int)Program.OpenProcess(PROCESS_ALL_ACCESS, false, processID);

                //Patching!
                int output = 0;
                WriteProcessMemory(num, offcetVID, vid, 2, ref output);
                WriteProcessMemory(num, offcetPID, pid, 2, ref output);
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

                //Getting Offcets
                GetOffcetValues();

                //Getting PID&VID values for Player1
                GetDeviceValues(false);

                //Launching Rocksmith 2014
                StartGame();

                //Waiting while game starting
                Thread.Sleep(settings.waitTime);

                //Getting process id and setting exit event
                HookProcess();

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
                        //Getting PID&VID values for Player2
                        GetDeviceValues(true);

                        //Patching game for multiplayer
                        Patch();
                    }

                    //Enable player2 record device
                    SetDeviceState(settings.GUID2, true);

                    //Free hotkey
                    HotKeyManager.UnregisterHotKey(hotkeyID);
                }
            }
        }

    }
}
