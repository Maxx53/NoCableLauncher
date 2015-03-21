using System;
using System.Windows.Forms;
using System.Management;
using System.ComponentModel;


namespace NoCableLauncher
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        BindingList<SoundDevice> devices = new BindingList<SoundDevice>();

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
            devices.Add(new SoundDevice("Default", "0000", "0000"));

            ManagementPath path = new ManagementPath();
            ManagementClass devs = null;
            path.Server = ".";
            path.NamespacePath = @"root\CIMV2";
            path.RelativePath = @"Win32_SoundDevice";
            using (devs = new ManagementClass(new ManagementScope(path), path, new ObjectGetOptions(null, new TimeSpan(0, 0, 0, 2), true)))
            {
                ManagementObjectCollection moc = devs.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    PropertyDataCollection devsProperties = mo.Properties;
                    string devid = devsProperties["DeviceID"].Value.ToString();
                    if (devid.Contains("PID_"))
                    {
                        string vid = devid.Substring(devid.IndexOf("VID_") + 4, 4);
                        string pid = devid.Substring(devid.IndexOf("PID_") + 4, 4);

                        devices.Add(new SoundDevice(devsProperties["Caption"].Value.ToString(), vid, pid));

                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = devices;
            comboBox1.DisplayMember = "Name";

            LoadDeviceList();

            if (Program.settings.manualDev)
            {
                textBox2.Text = Program.settings.VID;
                textBox3.Text = Program.settings.PID;
                checkBox2.Checked = true;
            }
            else
            {

                for (int i = 0; i < devices.Count; i++)
                {
                    if (devices[i].Vid == Program.settings.VID)
                    {
                        comboBox1.SelectedIndex = i;

                        break;
                    }

                }

                comboBox1_SelectedIndexChanged(sender, e);
                checkBox2_CheckedChanged(sender, e);

            }

            checkBox1.Checked = Program.settings.isSteam;

            textBox1.Text = Program.settings.gamePath;
            textBox4.Text = Program.settings.offcetVID;
            textBox5.Text = Program.settings.offcetPID;

        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = !checkBox2.Checked;
            textBox3.ReadOnly = !checkBox2.Checked;
            comboBox1.Enabled = !checkBox2.Checked;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = devices[comboBox1.SelectedIndex].Vid;
            textBox3.Text = devices[comboBox1.SelectedIndex].Pid;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Program.settings.gamePath = textBox1.Text;
            Program.settings.VID = textBox2.Text;
            Program.settings.PID = textBox3.Text;
            Program.settings.offcetVID = textBox4.Text;
            Program.settings.offcetPID = textBox5.Text;
            Program.settings.manualDev = checkBox2.Checked;
            Program.settings.isSteam = checkBox1.Checked;
            Program.settings.Save();

            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = Program.steamName;
            textBox1.ReadOnly = checkBox1.Checked;
            button1.Enabled = !checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
