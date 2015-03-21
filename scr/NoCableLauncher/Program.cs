using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

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

        private const int PROCESS_ALL_ACCESS = 2035711;

        public const string steamName = "steam://rungameid/221680";
        private const string exeName = "Rocksmith2014";

        public static SettingsClass.Settings settings = SettingsClass.Settings.Default;


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
            MessageBox.Show(value, Application.ProductName + " Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                //Open settings window

                Application.EnableVisualStyles();
                Application.Run(new Settings());
            }
            else
            {
                //Launching Rocksmith 2014

                //Prepare and check Settings values

                int offcetVID = 0;
                int offcetPID = 0;
                byte[] vid = new byte[2];
                byte[] pid = new byte[2];

                try
                {
                    //Getting RAM offcets
                    offcetVID = FromHex(settings.offcetVID);
                    offcetPID = FromHex(settings.offcetPID);

                    //Getting device VID & PID
                    vid = GetDevId(settings.VID);
                    pid = GetDevId(settings.PID);

                }
                catch (Exception exc)
                {
                    ExitWithError(exc.Message);
                }


                string exeFile = exeName;

                //Starting game
                if (!settings.isSteam)
                {
                    if (File.Exists(settings.gamePath))
                    {
                        exeFile = Path.GetFileNameWithoutExtension(settings.gamePath);
                        var startInfo = new ProcessStartInfo();
                        startInfo.FileName = exeFile;
                        startInfo.WorkingDirectory = Path.GetDirectoryName(settings.gamePath);

                        Process.Start(startInfo);
                    }
                    else
                    {
                        ExitWithError(string.Format("Exe file at \"{0}\" not found, check game path setting.", settings.gamePath));
                    }
                }
                else
                    Process.Start(steamName);


                //Waiting for process start
                Thread.Sleep(settings.waitTime);

                //Finding game process
                Process[] process = Process.GetProcessesByName(exeFile);

                if (process.Length == 0)
                    ExitWithError(string.Format("Can't find process: {0}.exe", exeFile));

                try
                {
                    //Open process for writing
                    var num = (int)Program.OpenProcess(PROCESS_ALL_ACCESS, false, process[0].Id);

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
        }
    }
}
