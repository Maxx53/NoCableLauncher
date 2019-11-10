using System.ComponentModel;
using System.Windows.Forms;

namespace NoCableLauncher
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.steamCheckBox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.p1DeviceCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.p1vidTextBox = new System.Windows.Forms.TextBox();
            this.p1pidTexBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.p1manualCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.offsetVidTextBox = new System.Windows.Forms.TextBox();
            this.offsetPidTextBox = new System.Windows.Forms.TextBox();
            this.player1GroupBox = new System.Windows.Forms.GroupBox();
            this.refreshPictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.manualOffsetsCheckbox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.multiplayerCheckBox = new System.Windows.Forms.CheckBox();
            this.inputDevButton = new System.Windows.Forms.Button();
            this.player2GroupBox = new System.Windows.Forms.GroupBox();
            this.refreshPictureBox2 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.p2manualCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.p2DeviceCombo = new System.Windows.Forms.ComboBox();
            this.p2pidTexBox = new System.Windows.Forms.TextBox();
            this.p2vidTextBox = new System.Windows.Forms.TextBox();
            this.launchGameButton = new System.Windows.Forms.Button();
            this.spOnBoardGroupBox = new System.Windows.Forms.GroupBox();
            this.spDisableEnableRadioButton = new System.Windows.Forms.RadioButton();
            this.spFakeMultiaplyerButton = new System.Windows.Forms.RadioButton();
            this.infoButton2 = new System.Windows.Forms.Button();
            this.infoButton1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Button();
            this.singlePlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.player1GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshPictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.player2GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshPictureBox2)).BeginInit();
            this.spOnBoardGroupBox.SuspendLayout();
            this.singlePlayerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(79, 22);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(233, 20);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.TextChanged += new System.EventHandler(this._SettingsChanged);
            // 
            // steamCheckBox
            // 
            this.steamCheckBox.AutoSize = true;
            this.steamCheckBox.Location = new System.Drawing.Point(79, 48);
            this.steamCheckBox.Name = "steamCheckBox";
            this.steamCheckBox.Size = new System.Drawing.Size(87, 17);
            this.steamCheckBox.TabIndex = 3;
            this.steamCheckBox.Text = "Steam Game";
            this.steamCheckBox.UseVisualStyleBackColor = true;
            this.steamCheckBox.CheckedChanged += new System.EventHandler(this.steamCheckBox_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(318, 22);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(26, 20);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // p1DeviceCombo
            // 
            this.p1DeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p1DeviceCombo.Location = new System.Drawing.Point(67, 23);
            this.p1DeviceCombo.Name = "p1DeviceCombo";
            this.p1DeviceCombo.Size = new System.Drawing.Size(243, 21);
            this.p1DeviceCombo.TabIndex = 8;
            this.p1DeviceCombo.SelectedIndexChanged += new System.EventHandler(this._SettingsChanged);
            this.p1DeviceCombo.SelectionChangeCommitted += new System.EventHandler(this.p1DeviceCombo_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Device";
            // 
            // p1vidTextBox
            // 
            this.p1vidTextBox.Location = new System.Drawing.Point(67, 71);
            this.p1vidTextBox.MaxLength = 4;
            this.p1vidTextBox.Name = "p1vidTextBox";
            this.p1vidTextBox.Size = new System.Drawing.Size(88, 20);
            this.p1vidTextBox.TabIndex = 10;
            this.p1vidTextBox.TextChanged += new System.EventHandler(this.p1vidTextBox_TextChanged);
            // 
            // p1pidTexBox
            // 
            this.p1pidTexBox.Location = new System.Drawing.Point(67, 97);
            this.p1pidTexBox.MaxLength = 4;
            this.p1pidTexBox.Name = "p1pidTexBox";
            this.p1pidTexBox.Size = new System.Drawing.Size(88, 20);
            this.p1pidTexBox.TabIndex = 11;
            this.p1pidTexBox.TextChanged += new System.EventHandler(this.p1pidTexBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "VID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "PID";
            // 
            // p1manualCheckBox
            // 
            this.p1manualCheckBox.AutoSize = true;
            this.p1manualCheckBox.Location = new System.Drawing.Point(67, 50);
            this.p1manualCheckBox.Name = "p1manualCheckBox";
            this.p1manualCheckBox.Size = new System.Drawing.Size(96, 17);
            this.p1manualCheckBox.TabIndex = 9;
            this.p1manualCheckBox.Text = "Manual Values";
            this.p1manualCheckBox.UseVisualStyleBackColor = true;
            this.p1manualCheckBox.CheckedChanged += new System.EventHandler(this.p1manualCheckBox_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.DimGray;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(299, 430);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(67, 24);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.DimGray;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(299, 459);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(67, 24);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Close";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "VID Offset";
            // 
            // offsetVidTextBox
            // 
            this.offsetVidTextBox.Location = new System.Drawing.Point(79, 94);
            this.offsetVidTextBox.Name = "offsetVidTextBox";
            this.offsetVidTextBox.Size = new System.Drawing.Size(86, 20);
            this.offsetVidTextBox.TabIndex = 5;
            this.offsetVidTextBox.TextChanged += new System.EventHandler(this._SettingsChanged);
            // 
            // offsetPidTextBox
            // 
            this.offsetPidTextBox.Location = new System.Drawing.Point(79, 119);
            this.offsetPidTextBox.Name = "offsetPidTextBox";
            this.offsetPidTextBox.Size = new System.Drawing.Size(86, 20);
            this.offsetPidTextBox.TabIndex = 6;
            this.offsetPidTextBox.TextChanged += new System.EventHandler(this._SettingsChanged);
            // 
            // player1GroupBox
            // 
            this.player1GroupBox.Controls.Add(this.refreshPictureBox1);
            this.player1GroupBox.Controls.Add(this.p1manualCheckBox);
            this.player1GroupBox.Controls.Add(this.label3);
            this.player1GroupBox.Controls.Add(this.label4);
            this.player1GroupBox.Controls.Add(this.label2);
            this.player1GroupBox.Controls.Add(this.p1DeviceCombo);
            this.player1GroupBox.Controls.Add(this.p1pidTexBox);
            this.player1GroupBox.Controls.Add(this.p1vidTextBox);
            this.player1GroupBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.player1GroupBox.Location = new System.Drawing.Point(12, 162);
            this.player1GroupBox.Name = "player1GroupBox";
            this.player1GroupBox.Size = new System.Drawing.Size(354, 127);
            this.player1GroupBox.TabIndex = 8;
            this.player1GroupBox.TabStop = false;
            this.player1GroupBox.Text = "Player1 Audio Device";
            // 
            // refreshPictureBox1
            // 
            this.refreshPictureBox1.BackgroundImage = global::NoCableLauncher.Properties.Resources.refresh;
            this.refreshPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshPictureBox1.Location = new System.Drawing.Point(313, 22);
            this.refreshPictureBox1.Name = "refreshPictureBox1";
            this.refreshPictureBox1.Size = new System.Drawing.Size(24, 24);
            this.refreshPictureBox1.TabIndex = 16;
            this.refreshPictureBox1.TabStop = false;
            this.refreshPictureBox1.Click += new System.EventHandler(this.refreshPictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Rocksmith2014";
            this.openFileDialog1.Filter = "Exe files|*.exe";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.manualOffsetsCheckbox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pathTextBox);
            this.groupBox2.Controls.Add(this.browseButton);
            this.groupBox2.Controls.Add(this.multiplayerCheckBox);
            this.groupBox2.Controls.Add(this.offsetVidTextBox);
            this.groupBox2.Controls.Add(this.steamCheckBox);
            this.groupBox2.Controls.Add(this.offsetPidTextBox);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(12, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 151);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game";
            // 
            // manualOffsetsCheckbox
            // 
            this.manualOffsetsCheckbox.AutoSize = true;
            this.manualOffsetsCheckbox.Location = new System.Drawing.Point(79, 71);
            this.manualOffsetsCheckbox.Name = "manualOffsetsCheckbox";
            this.manualOffsetsCheckbox.Size = new System.Drawing.Size(97, 17);
            this.manualOffsetsCheckbox.TabIndex = 8;
            this.manualOffsetsCheckbox.Text = "Manual Offsets";
            this.manualOffsetsCheckbox.UseVisualStyleBackColor = true;
            this.manualOffsetsCheckbox.CheckedChanged += new System.EventHandler(this.manualOffsetsCheckbox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "PID Offset";
            // 
            // multiplayerCheckBox
            // 
            this.multiplayerCheckBox.AutoSize = true;
            this.multiplayerCheckBox.Location = new System.Drawing.Point(195, 48);
            this.multiplayerCheckBox.Name = "multiplayerCheckBox";
            this.multiplayerCheckBox.Size = new System.Drawing.Size(112, 17);
            this.multiplayerCheckBox.TabIndex = 4;
            this.multiplayerCheckBox.Text = "Enable Multiplayer";
            this.multiplayerCheckBox.UseVisualStyleBackColor = true;
            this.multiplayerCheckBox.CheckedChanged += new System.EventHandler(this.multiplayerCheckBox_CheckedChanged);
            // 
            // inputDevButton
            // 
            this.inputDevButton.BackColor = System.Drawing.Color.DimGray;
            this.inputDevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inputDevButton.Location = new System.Drawing.Point(12, 431);
            this.inputDevButton.Name = "inputDevButton";
            this.inputDevButton.Size = new System.Drawing.Size(114, 23);
            this.inputDevButton.TabIndex = 16;
            this.inputDevButton.Text = "Input Devices";
            this.inputDevButton.UseVisualStyleBackColor = false;
            this.inputDevButton.Click += new System.EventHandler(this.inputDevButton_Click);
            // 
            // player2GroupBox
            // 
            this.player2GroupBox.Controls.Add(this.refreshPictureBox2);
            this.player2GroupBox.Controls.Add(this.label12);
            this.player2GroupBox.Controls.Add(this.p2manualCheckBox);
            this.player2GroupBox.Controls.Add(this.label7);
            this.player2GroupBox.Controls.Add(this.label8);
            this.player2GroupBox.Controls.Add(this.label9);
            this.player2GroupBox.Controls.Add(this.p2DeviceCombo);
            this.player2GroupBox.Controls.Add(this.p2pidTexBox);
            this.player2GroupBox.Controls.Add(this.p2vidTextBox);
            this.player2GroupBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.player2GroupBox.Location = new System.Drawing.Point(12, 295);
            this.player2GroupBox.Name = "player2GroupBox";
            this.player2GroupBox.Size = new System.Drawing.Size(355, 128);
            this.player2GroupBox.TabIndex = 8;
            this.player2GroupBox.TabStop = false;
            this.player2GroupBox.Text = "Player2 Audio Device";
            // 
            // refreshPictureBox2
            // 
            this.refreshPictureBox2.BackgroundImage = global::NoCableLauncher.Properties.Resources.refresh;
            this.refreshPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshPictureBox2.Location = new System.Drawing.Point(313, 22);
            this.refreshPictureBox2.Name = "refreshPictureBox2";
            this.refreshPictureBox2.Size = new System.Drawing.Size(24, 24);
            this.refreshPictureBox2.TabIndex = 15;
            this.refreshPictureBox2.TabStop = false;
            this.refreshPictureBox2.Click += new System.EventHandler(this.refreshPictureBox1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(192, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 39);
            this.label12.TabIndex = 6;
            this.label12.Text = "Note: to activate Player 2\r\nin game, go to \"Multiplayer\" \r\nand press Ctrl+M";
            // 
            // p2manualCheckBox
            // 
            this.p2manualCheckBox.AutoSize = true;
            this.p2manualCheckBox.Location = new System.Drawing.Point(67, 50);
            this.p2manualCheckBox.Name = "p2manualCheckBox";
            this.p2manualCheckBox.Size = new System.Drawing.Size(96, 17);
            this.p2manualCheckBox.TabIndex = 13;
            this.p2manualCheckBox.Text = "Manual Values";
            this.p2manualCheckBox.UseVisualStyleBackColor = true;
            this.p2manualCheckBox.CheckedChanged += new System.EventHandler(this.p2manualCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "VID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "PID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Device";
            // 
            // p2DeviceCombo
            // 
            this.p2DeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p2DeviceCombo.Location = new System.Drawing.Point(67, 23);
            this.p2DeviceCombo.Name = "p2DeviceCombo";
            this.p2DeviceCombo.Size = new System.Drawing.Size(243, 21);
            this.p2DeviceCombo.TabIndex = 12;
            this.p2DeviceCombo.SelectedIndexChanged += new System.EventHandler(this._SettingsChanged);
            this.p2DeviceCombo.SelectionChangeCommitted += new System.EventHandler(this.p2DeviceCombo_SelectionChangeCommitted);
            // 
            // p2pidTexBox
            // 
            this.p2pidTexBox.Location = new System.Drawing.Point(67, 97);
            this.p2pidTexBox.MaxLength = 4;
            this.p2pidTexBox.Name = "p2pidTexBox";
            this.p2pidTexBox.Size = new System.Drawing.Size(88, 20);
            this.p2pidTexBox.TabIndex = 14;
            this.p2pidTexBox.TextChanged += new System.EventHandler(this._SettingsChanged);
            // 
            // p2vidTextBox
            // 
            this.p2vidTextBox.Location = new System.Drawing.Point(67, 71);
            this.p2vidTextBox.MaxLength = 4;
            this.p2vidTextBox.Name = "p2vidTextBox";
            this.p2vidTextBox.Size = new System.Drawing.Size(88, 20);
            this.p2vidTextBox.TabIndex = 14;
            this.p2vidTextBox.TextChanged += new System.EventHandler(this._SettingsChanged);
            // 
            // launchGameButton
            // 
            this.launchGameButton.BackColor = System.Drawing.Color.DimGray;
            this.launchGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchGameButton.Location = new System.Drawing.Point(12, 460);
            this.launchGameButton.Name = "launchGameButton";
            this.launchGameButton.Size = new System.Drawing.Size(114, 23);
            this.launchGameButton.TabIndex = 19;
            this.launchGameButton.Text = "Launch Game";
            this.launchGameButton.UseVisualStyleBackColor = false;
            this.launchGameButton.Click += new System.EventHandler(this.launchGameButton_Click);
            // 
            // spOnBoardGroupBox
            // 
            this.spOnBoardGroupBox.Controls.Add(this.spDisableEnableRadioButton);
            this.spOnBoardGroupBox.Controls.Add(this.spFakeMultiaplyerButton);
            this.spOnBoardGroupBox.Controls.Add(this.infoButton2);
            this.spOnBoardGroupBox.Controls.Add(this.infoButton1);
            this.spOnBoardGroupBox.Controls.Add(this.label10);
            this.spOnBoardGroupBox.Controls.Add(this.label13);
            this.spOnBoardGroupBox.Controls.Add(this.label11);
            this.spOnBoardGroupBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.spOnBoardGroupBox.Location = new System.Drawing.Point(12, 295);
            this.spOnBoardGroupBox.Name = "spOnBoardGroupBox";
            this.spOnBoardGroupBox.Size = new System.Drawing.Size(355, 128);
            this.spOnBoardGroupBox.TabIndex = 20;
            this.spOnBoardGroupBox.TabStop = false;
            this.spOnBoardGroupBox.Text = "Single Player Mode - Onboard soundcard";
            this.spOnBoardGroupBox.Visible = false;
            // 
            // spDisableEnableRadioButton
            // 
            this.spDisableEnableRadioButton.AutoSize = true;
            this.spDisableEnableRadioButton.Checked = true;
            this.spDisableEnableRadioButton.Location = new System.Drawing.Point(275, 62);
            this.spDisableEnableRadioButton.Name = "spDisableEnableRadioButton";
            this.spDisableEnableRadioButton.Size = new System.Drawing.Size(14, 13);
            this.spDisableEnableRadioButton.TabIndex = 22;
            this.spDisableEnableRadioButton.TabStop = true;
            this.spDisableEnableRadioButton.UseVisualStyleBackColor = true;
            this.spDisableEnableRadioButton.CheckedChanged += new System.EventHandler(this.spRadioButton_CheckedChanged);
            // 
            // spFakeMultiaplyerButton
            // 
            this.spFakeMultiaplyerButton.AutoSize = true;
            this.spFakeMultiaplyerButton.Location = new System.Drawing.Point(275, 86);
            this.spFakeMultiaplyerButton.Name = "spFakeMultiaplyerButton";
            this.spFakeMultiaplyerButton.Size = new System.Drawing.Size(14, 13);
            this.spFakeMultiaplyerButton.TabIndex = 22;
            this.spFakeMultiaplyerButton.UseVisualStyleBackColor = true;
            this.spFakeMultiaplyerButton.CheckedChanged += new System.EventHandler(this.spRadioButton_CheckedChanged);
            // 
            // infoButton2
            // 
            this.infoButton2.BackColor = System.Drawing.Color.DimGray;
            this.infoButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton2.Location = new System.Drawing.Point(293, 80);
            this.infoButton2.Name = "infoButton2";
            this.infoButton2.Size = new System.Drawing.Size(22, 24);
            this.infoButton2.TabIndex = 21;
            this.infoButton2.Text = "?";
            this.infoButton2.UseVisualStyleBackColor = false;
            this.infoButton2.Click += new System.EventHandler(this.infoButton2_Click);
            // 
            // infoButton1
            // 
            this.infoButton1.BackColor = System.Drawing.Color.DimGray;
            this.infoButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton1.Location = new System.Drawing.Point(293, 56);
            this.infoButton1.Name = "infoButton1";
            this.infoButton1.Size = new System.Drawing.Size(22, 24);
            this.infoButton1.TabIndex = 21;
            this.infoButton1.Text = "?";
            this.infoButton1.UseVisualStyleBackColor = false;
            this.infoButton1.Click += new System.EventHandler(this.infoButton1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(277, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "To prevent duplicated Rocksmith controllers choose one:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(227, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Disable devices and re-enable on game closes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(219, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Prevent game from recognizing more devices";
            // 
            // aboutButton
            // 
            this.aboutButton.BackColor = System.Drawing.Color.DimGray;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Location = new System.Drawing.Point(178, 442);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(67, 24);
            this.aboutButton.TabIndex = 21;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // singlePlayerGroupBox
            // 
            this.singlePlayerGroupBox.Controls.Add(this.label14);
            this.singlePlayerGroupBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.singlePlayerGroupBox.Location = new System.Drawing.Point(12, 295);
            this.singlePlayerGroupBox.Name = "singlePlayerGroupBox";
            this.singlePlayerGroupBox.Size = new System.Drawing.Size(355, 128);
            this.singlePlayerGroupBox.TabIndex = 23;
            this.singlePlayerGroupBox.TabStop = false;
            this.singlePlayerGroupBox.Text = "Single Player Mode";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(67, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(231, 26);
            this.label14.TabIndex = 18;
            this.label14.Text = "Since you are not using the onboard soundcard\r\nthere should be no device conflict" +
    "s.";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(378, 490);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.launchGameButton);
            this.Controls.Add(this.inputDevButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.player1GroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.spOnBoardGroupBox);
            this.Controls.Add(this.player2GroupBox);
            this.Controls.Add(this.singlePlayerGroupBox);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoCableLauncher Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.player1GroupBox.ResumeLayout(false);
            this.player1GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshPictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.player2GroupBox.ResumeLayout(false);
            this.player2GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshPictureBox2)).EndInit();
            this.spOnBoardGroupBox.ResumeLayout(false);
            this.spOnBoardGroupBox.PerformLayout();
            this.singlePlayerGroupBox.ResumeLayout(false);
            this.singlePlayerGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox pathTextBox;
        private CheckBox steamCheckBox;
        private Button browseButton;
        private ComboBox p1DeviceCombo;
        private Label label2;
        private TextBox p1vidTextBox;
        private TextBox p1pidTexBox;
        private Label label3;
        private Label label4;
        private CheckBox p1manualCheckBox;
        private Button saveButton;
        private Button cancelButton;
        private Label label5;
        private TextBox offsetVidTextBox;
        private TextBox offsetPidTextBox;
        private GroupBox player1GroupBox;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox2;
        private GroupBox player2GroupBox;
        private CheckBox p2manualCheckBox;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox p2DeviceCombo;
        private TextBox p2pidTexBox;
        private TextBox p2vidTextBox;
        private CheckBox multiplayerCheckBox;
        private Label label6;
        private Button inputDevButton;
        private Label label12;
        private CheckBox manualOffsetsCheckbox;
        private Button launchGameButton;
        private GroupBox spOnBoardGroupBox;
        private PictureBox refreshPictureBox1;
        private PictureBox refreshPictureBox2;
        private Button aboutButton;
        private Button infoButton1;
        private Label label11;
        private RadioButton spDisableEnableRadioButton;
        private RadioButton spFakeMultiaplyerButton;
        private Button infoButton2;
        private Label label10;
        private Label label13;
        private GroupBox singlePlayerGroupBox;
        private Label label14;
    }
}