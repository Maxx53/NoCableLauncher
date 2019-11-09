using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using NoCableLauncher.CoreAudioApi;
using NoCableLauncher.Properties;

namespace NoCableLauncher
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        BindingList<SoundDevice> devices = new BindingList<SoundDevice>();
        private static MMDeviceCollection pDevices;
        private static MMDeviceEnumerator DeviceEnumerator = new MMDeviceEnumerator();
        private static string defaultID = "0000";

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


        private void LoadDeviceList()
        {
            devices.Clear();

            pDevices = DeviceEnumerator.EnumerateAudioEndPoints(EDataFlow.eCapture, EDeviceState.Active);

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

            p1DeviceCombo.DataSource = new BindingList<SoundDevice>(devices);
            p1DeviceCombo.DisplayMember = "Name";

            p2DeviceCombo.DataSource = new BindingList<SoundDevice>(devices);
            p2DeviceCombo.DisplayMember = "Name";

            if (devices.Count == 0)
            {
                MessageBox.Show("Active input devices not found. Click \"Input devices\" for managing your input devices",
                Application.ProductName + " Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private int GetDeviceIndex(string guid)
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


        private void Settings_Load(object sender, EventArgs e)
        {
            Icon = Resources.rs14;

            LoadDeviceList();

            if (Program.settings.manualDev1)
            {
                p1vidTextBox.Text = Program.settings.VID;
                p1pidTexBox.Text = Program.settings.PID;
                p1manualCheckBox.Checked = true;
            }
            else
            {
                if (devices.Count != 0)
                    p1DeviceCombo.SelectedIndex = GetDeviceIndex(Program.settings.GUID1);

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
                if (devices.Count != 0)
                    p2DeviceCombo.SelectedIndex = GetDeviceIndex(Program.settings.GUID2);

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
        }

        private void p1manualCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            p1vidTextBox.ReadOnly = !p1manualCheckBox.Checked;
            p1pidTexBox.ReadOnly = !p1manualCheckBox.Checked;
            p1DeviceCombo.Enabled = !p1manualCheckBox.Checked;
        }

        private void p2manualCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            p2vidTextBox.ReadOnly = !p2manualCheckBox.Checked;
            p2pidTexBox.ReadOnly = !p2manualCheckBox.Checked;
            p2DeviceCombo.Enabled = !p2manualCheckBox.Checked;
        }

        private void manualOffsetsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            offsetPidTextBox.ReadOnly = !manualOffsetsCheckbox.Checked;
            offsetVidTextBox.ReadOnly = !manualOffsetsCheckbox.Checked;
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

            Program.settings.GUID1 = pDevices[p1DeviceCombo.SelectedIndex].ID;
            Program.settings.GUID2 = pDevices[p2DeviceCombo.SelectedIndex].ID;

            Program.settings.Save();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Application.Exit();
        }


        private void steamCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pathTextBox.Text = Program.steamName;
            pathTextBox.ReadOnly = steamCheckBox.Checked;
            browseButton.Enabled = !steamCheckBox.Checked;
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
            Application.Exit();
        }

        private void multiplayerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            player2GroupBox.Enabled = multiplayerCheckBox.Checked;

            if (multiplayerCheckBox.Checked && sender != null)
                DeviceIDcheck();
        }


        private void inputDevButton_Click(object sender, EventArgs e)
        {
            Process.Start("control", "mmsys.cpl,,1");
        }

        private void p1DeviceCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (devices.Count != 0)
            {
                p1vidTextBox.Text = devices[p1DeviceCombo.SelectedIndex].Vid;
                p1pidTexBox.Text = devices[p1DeviceCombo.SelectedIndex].Pid;

                DeviceIDcheck();
            }
        }

        private void p2DeviceCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (devices.Count != 0)
            {
                p2vidTextBox.Text = devices[p2DeviceCombo.SelectedIndex].Vid;
                p2pidTexBox.Text = devices[p2DeviceCombo.SelectedIndex].Pid;

                DeviceIDcheck();
            }
        }

        private void p1DeviceCombo_DropDown(object sender, EventArgs e)
        {
           // LoadDeviceList();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Do you want to save changes?", Application.ProductName + " Settings",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        SaveSettings();
                        break;
                    case DialogResult.No:
                        //Do nothing
                        break;
                }
            }
        }
    }
}
