namespace NoCableLauncher
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.offcetVidTextBox = new System.Windows.Forms.TextBox();
            this.offcetPidTextBox = new System.Windows.Forms.TextBox();
            this.player1GroupBox = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.defOffcetButton = new System.Windows.Forms.Button();
            this.waitTimeNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.multiplayerCheckBox = new System.Windows.Forms.CheckBox();
            this.inputDevButton = new System.Windows.Forms.Button();
            this.player2GroupBox = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.p2manualCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.p2DeviceCombo = new System.Windows.Forms.ComboBox();
            this.p2pidTexBox = new System.Windows.Forms.TextBox();
            this.p2vidTextBox = new System.Windows.Forms.TextBox();
            this.player1GroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitTimeNumeric)).BeginInit();
            this.player2GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(79, 23);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(233, 20);
            this.pathTextBox.TabIndex = 1;
            // 
            // steamCheckBox
            // 
            this.steamCheckBox.AutoSize = true;
            this.steamCheckBox.Location = new System.Drawing.Point(79, 49);
            this.steamCheckBox.Name = "steamCheckBox";
            this.steamCheckBox.Size = new System.Drawing.Size(87, 17);
            this.steamCheckBox.TabIndex = 2;
            this.steamCheckBox.Text = "Steam Game";
            this.steamCheckBox.UseVisualStyleBackColor = true;
            this.steamCheckBox.CheckedChanged += new System.EventHandler(this.steamCheckBox_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(318, 23);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(26, 20);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // p1DeviceCombo
            // 
            this.p1DeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p1DeviceCombo.Location = new System.Drawing.Point(80, 24);
            this.p1DeviceCombo.Name = "p1DeviceCombo";
            this.p1DeviceCombo.Size = new System.Drawing.Size(264, 21);
            this.p1DeviceCombo.TabIndex = 5;
            this.p1DeviceCombo.DropDown += new System.EventHandler(this.p1DeviceCombo_DropDown);
            this.p1DeviceCombo.SelectionChangeCommitted += new System.EventHandler(this.p1DeviceCombo_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Device";
            // 
            // p1vidTextBox
            // 
            this.p1vidTextBox.Location = new System.Drawing.Point(80, 72);
            this.p1vidTextBox.MaxLength = 4;
            this.p1vidTextBox.Name = "p1vidTextBox";
            this.p1vidTextBox.Size = new System.Drawing.Size(88, 20);
            this.p1vidTextBox.TabIndex = 1;
            // 
            // p1pidTexBox
            // 
            this.p1pidTexBox.Location = new System.Drawing.Point(80, 98);
            this.p1pidTexBox.MaxLength = 4;
            this.p1pidTexBox.Name = "p1pidTexBox";
            this.p1pidTexBox.Size = new System.Drawing.Size(88, 20);
            this.p1pidTexBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "VID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "PID";
            // 
            // p1manualCheckBox
            // 
            this.p1manualCheckBox.AutoSize = true;
            this.p1manualCheckBox.Location = new System.Drawing.Point(80, 51);
            this.p1manualCheckBox.Name = "p1manualCheckBox";
            this.p1manualCheckBox.Size = new System.Drawing.Size(96, 17);
            this.p1manualCheckBox.TabIndex = 2;
            this.p1manualCheckBox.Text = "Manual Values";
            this.p1manualCheckBox.UseVisualStyleBackColor = true;
            this.p1manualCheckBox.CheckedChanged += new System.EventHandler(this.p1manualCheckBox_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(206, 434);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(77, 24);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(289, 434);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(77, 24);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "VID Offcet";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Patch Delay";
            // 
            // offcetVidTextBox
            // 
            this.offcetVidTextBox.Location = new System.Drawing.Point(79, 72);
            this.offcetVidTextBox.Name = "offcetVidTextBox";
            this.offcetVidTextBox.Size = new System.Drawing.Size(86, 20);
            this.offcetVidTextBox.TabIndex = 1;
            // 
            // offcetPidTextBox
            // 
            this.offcetPidTextBox.Location = new System.Drawing.Point(78, 98);
            this.offcetPidTextBox.Name = "offcetPidTextBox";
            this.offcetPidTextBox.Size = new System.Drawing.Size(86, 20);
            this.offcetPidTextBox.TabIndex = 1;
            // 
            // player1GroupBox
            // 
            this.player1GroupBox.Controls.Add(this.p1manualCheckBox);
            this.player1GroupBox.Controls.Add(this.label3);
            this.player1GroupBox.Controls.Add(this.label4);
            this.player1GroupBox.Controls.Add(this.label2);
            this.player1GroupBox.Controls.Add(this.p1DeviceCombo);
            this.player1GroupBox.Controls.Add(this.p1pidTexBox);
            this.player1GroupBox.Controls.Add(this.p1vidTextBox);
            this.player1GroupBox.Location = new System.Drawing.Point(12, 165);
            this.player1GroupBox.Name = "player1GroupBox";
            this.player1GroupBox.Size = new System.Drawing.Size(354, 127);
            this.player1GroupBox.TabIndex = 8;
            this.player1GroupBox.TabStop = false;
            this.player1GroupBox.Text = "Player1 Audio Device";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Rocksmith2014";
            this.openFileDialog1.Filter = "Exe files|*.exe";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.defOffcetButton);
            this.groupBox2.Controls.Add(this.waitTimeNumeric);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pathTextBox);
            this.groupBox2.Controls.Add(this.browseButton);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.multiplayerCheckBox);
            this.groupBox2.Controls.Add(this.offcetVidTextBox);
            this.groupBox2.Controls.Add(this.steamCheckBox);
            this.groupBox2.Controls.Add(this.offcetPidTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 153);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game";
            // 
            // defOffcetButton
            // 
            this.defOffcetButton.Location = new System.Drawing.Point(179, 85);
            this.defOffcetButton.Name = "defOffcetButton";
            this.defOffcetButton.Size = new System.Drawing.Size(77, 24);
            this.defOffcetButton.TabIndex = 5;
            this.defOffcetButton.Text = "To Default";
            this.defOffcetButton.UseVisualStyleBackColor = true;
            this.defOffcetButton.Click += new System.EventHandler(this.defOffcetButton_Click);
            // 
            // waitTimeNumeric
            // 
            this.waitTimeNumeric.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.waitTimeNumeric.Location = new System.Drawing.Point(78, 124);
            this.waitTimeNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.waitTimeNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.waitTimeNumeric.Name = "waitTimeNumeric";
            this.waitTimeNumeric.Size = new System.Drawing.Size(86, 20);
            this.waitTimeNumeric.TabIndex = 4;
            this.waitTimeNumeric.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "PID Offcet";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(176, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "ms";
            // 
            // multiplayerCheckBox
            // 
            this.multiplayerCheckBox.AutoSize = true;
            this.multiplayerCheckBox.Location = new System.Drawing.Point(179, 49);
            this.multiplayerCheckBox.Name = "multiplayerCheckBox";
            this.multiplayerCheckBox.Size = new System.Drawing.Size(112, 17);
            this.multiplayerCheckBox.TabIndex = 2;
            this.multiplayerCheckBox.Text = "Enable Multiplayer";
            this.multiplayerCheckBox.UseVisualStyleBackColor = true;
            this.multiplayerCheckBox.CheckedChanged += new System.EventHandler(this.multiplayerCheckBox_CheckedChanged);
            // 
            // inputDevButton
            // 
            this.inputDevButton.Location = new System.Drawing.Point(12, 435);
            this.inputDevButton.Name = "inputDevButton";
            this.inputDevButton.Size = new System.Drawing.Size(121, 23);
            this.inputDevButton.TabIndex = 6;
            this.inputDevButton.Text = "Input Devices";
            this.inputDevButton.UseVisualStyleBackColor = true;
            this.inputDevButton.Click += new System.EventHandler(this.inputDevButton_Click);
            // 
            // player2GroupBox
            // 
            this.player2GroupBox.Controls.Add(this.label12);
            this.player2GroupBox.Controls.Add(this.p2manualCheckBox);
            this.player2GroupBox.Controls.Add(this.label7);
            this.player2GroupBox.Controls.Add(this.label8);
            this.player2GroupBox.Controls.Add(this.label9);
            this.player2GroupBox.Controls.Add(this.p2DeviceCombo);
            this.player2GroupBox.Controls.Add(this.p2pidTexBox);
            this.player2GroupBox.Controls.Add(this.p2vidTextBox);
            this.player2GroupBox.Location = new System.Drawing.Point(11, 298);
            this.player2GroupBox.Name = "player2GroupBox";
            this.player2GroupBox.Size = new System.Drawing.Size(355, 128);
            this.player2GroupBox.TabIndex = 8;
            this.player2GroupBox.TabStop = false;
            this.player2GroupBox.Text = "Player2 Audio Device";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(202, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 39);
            this.label12.TabIndex = 6;
            this.label12.Text = "Note: to activate Player 2\r\nin game, go to \"Multiplayer\" \r\nand press Ctrl+M";
            // 
            // p2manualCheckBox
            // 
            this.p2manualCheckBox.AutoSize = true;
            this.p2manualCheckBox.Location = new System.Drawing.Point(80, 51);
            this.p2manualCheckBox.Name = "p2manualCheckBox";
            this.p2manualCheckBox.Size = new System.Drawing.Size(96, 17);
            this.p2manualCheckBox.TabIndex = 2;
            this.p2manualCheckBox.Text = "Manual Values";
            this.p2manualCheckBox.UseVisualStyleBackColor = true;
            this.p2manualCheckBox.CheckedChanged += new System.EventHandler(this.p2manualCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "VID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "PID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Device";
            // 
            // p2DeviceCombo
            // 
            this.p2DeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p2DeviceCombo.Location = new System.Drawing.Point(80, 24);
            this.p2DeviceCombo.Name = "p2DeviceCombo";
            this.p2DeviceCombo.Size = new System.Drawing.Size(265, 21);
            this.p2DeviceCombo.TabIndex = 5;
            this.p2DeviceCombo.DropDown += new System.EventHandler(this.p1DeviceCombo_DropDown);
            this.p2DeviceCombo.SelectionChangeCommitted += new System.EventHandler(this.p2DeviceCombo_SelectionChangeCommitted);
            // 
            // p2pidTexBox
            // 
            this.p2pidTexBox.Location = new System.Drawing.Point(80, 98);
            this.p2pidTexBox.MaxLength = 4;
            this.p2pidTexBox.Name = "p2pidTexBox";
            this.p2pidTexBox.Size = new System.Drawing.Size(88, 20);
            this.p2pidTexBox.TabIndex = 1;
            // 
            // p2vidTextBox
            // 
            this.p2vidTextBox.Location = new System.Drawing.Point(80, 72);
            this.p2vidTextBox.MaxLength = 4;
            this.p2vidTextBox.Name = "p2vidTextBox";
            this.p2vidTextBox.Size = new System.Drawing.Size(88, 20);
            this.p2vidTextBox.TabIndex = 1;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 466);
            this.Controls.Add(this.inputDevButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.player2GroupBox);
            this.Controls.Add(this.player1GroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoCableLauncher Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.player1GroupBox.ResumeLayout(false);
            this.player1GroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitTimeNumeric)).EndInit();
            this.player2GroupBox.ResumeLayout(false);
            this.player2GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.CheckBox steamCheckBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ComboBox p1DeviceCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox p1vidTextBox;
        private System.Windows.Forms.TextBox p1pidTexBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox p1manualCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox offcetVidTextBox;
        private System.Windows.Forms.TextBox offcetPidTextBox;
        private System.Windows.Forms.GroupBox player1GroupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox player2GroupBox;
        private System.Windows.Forms.CheckBox p2manualCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox p2DeviceCombo;
        private System.Windows.Forms.TextBox p2pidTexBox;
        private System.Windows.Forms.TextBox p2vidTextBox;
        private System.Windows.Forms.CheckBox multiplayerCheckBox;
        private System.Windows.Forms.NumericUpDown waitTimeNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button defOffcetButton;
        private System.Windows.Forms.Button inputDevButton;
        private System.Windows.Forms.Label label12;
    }
}