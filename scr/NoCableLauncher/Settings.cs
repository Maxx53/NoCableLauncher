using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoCableLauncher.CoreAudioApi;
using NoCableLauncher.Properties;

namespace NoCableLauncher
{
    public partial class Settings : Form
    {
        public bool OpenGameOnClose { get; set; } = false;

        public Settings()
        {
            InitializeComponent();
        }

        private bool loaded = false;

        private bool settingsChanged = false;
        private bool SettingsChanged { 
            get { return settingsChanged; }
            set {
                if(loaded)
                    settingsChanged = value;
            }
        }

        private void LoadDeviceList()
        {
            Common.LoadDeviceList();

            p1DeviceCombo.DataSource = new BindingList<SoundDevice>(Common.devices);
            p1DeviceCombo.DisplayMember = "Name";

            p2DeviceCombo.DataSource = new BindingList<SoundDevice>(Common.devices);
            p2DeviceCombo.DisplayMember = "Name";

            if (Common.devices.Count == 0)
            {
                MessageBox.Show("Active input devices not found. Click \"Input devices\" for managing your input devices",
                Application.ProductName + " Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public class SoundDevice
        {
            public SoundDevice(string name, string vid, string pid)
            {
                Name = name;
                Vid = vid;
                Pid = pid;
            }

            public string Name { get; set; }
            public string Vid { get; set; }
            public string Pid { get; set; }
        }



        private void Settings_Load(object sender, EventArgs e)
        {
            LoadDeviceList();

            if (Program.settings.manualDev1)
            {
                p1vidTextBox.Text = Program.settings.VID;
                p1pidTexBox.Text = Program.settings.PID;
                p1manualCheckBox.Checked = true;
            }
            else
            {
                if (Common.devices.Count != 0)
                    p1DeviceCombo.SelectedIndex = Common.GetDeviceIndex(Program.settings.GUID1);

                p1DeviceCombo_SelectionChangeCommitted(null, null);
                p1manualCheckBox_CheckedChanged(null, e);
            }

            if (Program.settings.manualDev2)
            {
                p2vidTextBox.Text = Program.settings.VID2;
                p2pidTexBox.Text = Program.settings.PID2;
                p2manualCheckBox.Checked = true;
            }
            else
            {
                if (Common.devices.Count != 0)
                    p2DeviceCombo.SelectedIndex = Common.GetDeviceIndex(Program.settings.GUID2);

                p2DeviceCombo_SelectionChangeCommitted(null, null);
                p2manualCheckBox_CheckedChanged(null, e);
            }

            multiplayerCheckBox.Checked = Program.settings.Multiplayer;
            multiplayerCheckBox_CheckedChanged(null, e);

            steamCheckBox.Checked = Program.settings.isSteam;

            pathTextBox.Text = Program.settings.gamePath;

            manualOffsetsCheckbox.Checked = Program.settings.manualOffsets;
            offsetVidTextBox.Text = Program.settings.offsetVID;
            offsetPidTextBox.Text = Program.settings.offsetPID;
            manualOffsetsCheckbox_CheckedChanged(null, e);

            if(Program.settings.SingleplayerMode == 1)
                spDisableEnableRadioButton.Checked = true;
            else
                spFakeMultiaplyerButton.Checked = true;

            CheckIfOnboardDevice();
            loaded = true;
        }

        private void p1manualCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            p1vidTextBox.ReadOnly = !p1manualCheckBox.Checked;
            p1pidTexBox.ReadOnly = !p1manualCheckBox.Checked;
            p1DeviceCombo.Enabled = !p1manualCheckBox.Checked;
            SettingsChanged = true;
        }

        private void p2manualCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            p2vidTextBox.ReadOnly = !p2manualCheckBox.Checked;
            p2pidTexBox.ReadOnly = !p2manualCheckBox.Checked;
            p2DeviceCombo.Enabled = !p2manualCheckBox.Checked;
            SettingsChanged = true;
        }

        private void manualOffsetsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            offsetPidTextBox.ReadOnly = !manualOffsetsCheckbox.Checked;
            offsetVidTextBox.ReadOnly = !manualOffsetsCheckbox.Checked;
            SettingsChanged = true;
        }

        private void DeviceIDcheck()
        {
            if ((p2vidTextBox.Text == p1vidTextBox.Text) && (p1pidTexBox.Text == p2pidTexBox.Text) && multiplayerCheckBox.Checked)
            {
                MessageBox.Show("Player1 and Player2 have the same input device IDs." + Environment.NewLine +
                                "Make it different, otherwise multiplayer will not work!",
                                 Application.ProductName + " Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveSettings()
        {
            DeviceIDcheck();

            Program.settings.gamePath = pathTextBox.Text;
            Program.settings.isSteam = steamCheckBox.Checked;

            Program.settings.offsetVID = offsetVidTextBox.Text;
            Program.settings.offsetPID = offsetPidTextBox.Text;
            Program.settings.manualOffsets = manualOffsetsCheckbox.Checked;

            Program.settings.VID = p1vidTextBox.Text;
            Program.settings.PID = p1pidTexBox.Text;
            Program.settings.manualDev1 = p1manualCheckBox.Checked;

            Program.settings.Multiplayer = multiplayerCheckBox.Checked;

            Program.settings.VID2 = p2vidTextBox.Text;
            Program.settings.PID2 = p2pidTexBox.Text;
            Program.settings.manualDev2 = p2manualCheckBox.Checked;

            Program.settings.GUID1 = Common.GetPDeviceId(p1DeviceCombo.SelectedIndex);
            Program.settings.GUID2 = Common.GetPDeviceId(p2DeviceCombo.SelectedIndex);

            Program.settings.SingleplayerMode = spDisableEnableRadioButton.Checked ? 1 : 0;

            Program.settings.Save();

            SettingsChanged = false;
        }

        private DateTime lastSaveButtonPress;

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();

            // I was bored
            lastSaveButtonPress = DateTime.Now;
            saveButton.BackColor = System.Drawing.Color.DarkGreen;
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            Task T = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(2000);
            }).ContinueWith(t =>
            {
                if (lastSaveButtonPress.AddMilliseconds(1500) < DateTime.Now)
                {
                    saveButton.BackColor = System.Drawing.Color.DimGray;
                }
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, context);
        }


        private void steamCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pathTextBox.Text = Program.steamName;
            pathTextBox.ReadOnly = steamCheckBox.Checked;
            browseButton.Enabled = !steamCheckBox.Checked;
            SettingsChanged = true;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CheckIfSettingsChanged();
            this.Close();
        }

        private void CheckIfOnboardDevice()
        {
            if (!multiplayerCheckBox.Checked)
            {
                if(p1vidTextBox.Text == "0000" && p1pidTexBox.Text == "0000")
                    spOnBoardGroupBox.Visible = true;
                else
                    spOnBoardGroupBox.Visible = false;
            }
            else
                spOnBoardGroupBox.Visible = false;
        }

        private void multiplayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            player2GroupBox.Visible = multiplayerCheckBox.Checked;

            if (multiplayerCheckBox.Checked && sender != null)
                DeviceIDcheck();

            CheckIfOnboardDevice();
            SettingsChanged = true;
        }


        private void inputDevButton_Click(object sender, EventArgs e)
        {
            Process.Start("control", "mmsys.cpl,,1");
        }

        private void p1DeviceCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Common.devices.Count != 0)
            {
                p1vidTextBox.Text = Common.devices[p1DeviceCombo.SelectedIndex].Vid;
                p1pidTexBox.Text = Common.devices[p1DeviceCombo.SelectedIndex].Pid;

                DeviceIDcheck();
            }
        }

        private void p2DeviceCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Common.devices.Count != 0)
            {
                p2vidTextBox.Text = Common.devices[p2DeviceCombo.SelectedIndex].Vid;
                p2pidTexBox.Text = Common.devices[p2DeviceCombo.SelectedIndex].Pid;

                DeviceIDcheck();
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e) { }

        private void refreshPictureBox1_Click(object sender, EventArgs e)
        {
            LoadDeviceList();
        }

        private void CheckIfSettingsChanged()
        {
            if (SettingsChanged)
            {
                var result = MessageBox.Show("Do you want to save changes?", Application.ProductName + " Settings",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        SaveSettings();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void launchGameButton_Click(object sender, EventArgs e)
        {
            CheckIfSettingsChanged();

            OpenGameOnClose = true;
            this.Close();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rocksmith 2014 Launcher by Maxx53\r\nModified by Mywk @ TechCoders.Net\r\n\r\nCredits: phobos2077, janabimustafa, Alexx999", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _SettingsChanged(object sender, EventArgs e)
        {
            SettingsChanged = true;
        }

        private void p1vidTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckIfOnboardDevice();
            _SettingsChanged(sender, e);
        }

        private void p1pidTexBox_TextChanged(object sender, EventArgs e)
        {
            CheckIfOnboardDevice();
            _SettingsChanged(sender, e);
        }

        private void infoButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All audio capture devices except the one used in game will be disabled when the game opens and re-enabled when the game closes.\r\n\r\n" +
                "Note: This prevents you from using other capture devices, for example if you want to be in a call while you play."
                , "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void infoButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All audio capture devices except the one used in-game will be disabled when the game opens.\r\n\r\n" +
                "After the game is opened and you are in the main menu press CTRL-M, this will prevent the game from recognizing any other device and re-enable the disabled ones.\r\n\r\n" +
                "This allows you to use your microphone or any other device outside the game (assuming the game is not in exclusive mode)."
                , "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void spRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Program.settings.SingleplayerMode = spDisableEnableRadioButton.Checked ? 0 : 1;
            _SettingsChanged(sender, e);
        }
    }
}
