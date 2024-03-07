using System.Collections.Generic;
using System.Configuration;
using MabiSteamLauncher.Properties;

namespace MabiSteamLauncher
{
  partial class Form1
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

        /// <summary>
        /// My Code
        /// </summary>
        // private string steamDirectoryText = Settings.Default.SteamDir;
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLaunch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSteamDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setClientDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMabiShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillAccountListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.brpLaunch = new System.Windows.Forms.GroupBox();
            this.lstAccBox = new System.Windows.Forms.ComboBox();
            this.btnSaveAcc = new System.Windows.Forms.Button();
            this.btnEditAcc = new System.Windows.Forms.Button();
            this.txtPwBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpSwitcher = new System.Windows.Forms.GroupBox();
            this.radFiveThousand = new System.Windows.Forms.RadioButton();
            this.radElevenThousand = new System.Windows.Forms.RadioButton();
            this.lstServerBox = new System.Windows.Forms.ComboBox();
            this.btnSaveIp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnableSwitcher = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.brpLaunch.SuspendLayout();
            this.grpSwitcher.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLaunch.Enabled = false;
            this.btnLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLaunch.ForeColor = System.Drawing.Color.LightGray;
            this.btnLaunch.Location = new System.Drawing.Point(70, 67);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(90, 42);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.settingsToolStripMenuItem, this.directoriesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(366, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.setSteamDirToolStripMenuItem, this.setClientDirToolStripMenuItem, this.setMabiShortcutToolStripMenuItem, this.fillAccountListToolStripMenuItem});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setSteamDirToolStripMenuItem
            // 
            this.setSteamDirToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.setSteamDirToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.setSteamDirToolStripMenuItem.Name = "setSteamDirToolStripMenuItem";
            this.setSteamDirToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.setSteamDirToolStripMenuItem.Text = "Set Steam Dir";
            this.setSteamDirToolStripMenuItem.Click += new System.EventHandler(this.setSteamDirToolStripMenuItem_Click);
            // 
            // setClientDirToolStripMenuItem
            // 
            this.setClientDirToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.setClientDirToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.setClientDirToolStripMenuItem.Name = "setClientDirToolStripMenuItem";
            this.setClientDirToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.setClientDirToolStripMenuItem.Text = "Set Client Dir";
            this.setClientDirToolStripMenuItem.Click += new System.EventHandler(this.setClientDirToolStripMenuItem_Click);
            // 
            // setMabiShortcutToolStripMenuItem
            // 
            this.setMabiShortcutToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.setMabiShortcutToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.setMabiShortcutToolStripMenuItem.Name = "setMabiShortcutToolStripMenuItem";
            this.setMabiShortcutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.setMabiShortcutToolStripMenuItem.Text = "Set Mabi Shortcut";
            this.setMabiShortcutToolStripMenuItem.Click += new System.EventHandler(this.setMabiShortcutToolStripMenuItem_Click);
            // 
            // fillAccountListToolStripMenuItem
            // 
            this.fillAccountListToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fillAccountListToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.fillAccountListToolStripMenuItem.Name = "fillAccountListToolStripMenuItem";
            this.fillAccountListToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.fillAccountListToolStripMenuItem.Text = "Fill Account List";
            this.fillAccountListToolStripMenuItem.Click += new System.EventHandler(this.fillAccountListToolStripMenuItem_Click);
            // 
            // directoriesToolStripMenuItem
            // 
            this.directoriesToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.directoriesToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.directoriesToolStripMenuItem.Name = "directoriesToolStripMenuItem";
            this.directoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.directoriesToolStripMenuItem.Text = "Directories";
            this.directoriesToolStripMenuItem.Click += new System.EventHandler(this.directoriesToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account";
            // 
            // brpLaunch
            // 
            this.brpLaunch.Controls.Add(this.lstAccBox);
            this.brpLaunch.Controls.Add(this.btnSaveAcc);
            this.brpLaunch.Controls.Add(this.btnEditAcc);
            this.brpLaunch.Controls.Add(this.txtPwBox);
            this.brpLaunch.Controls.Add(this.label2);
            this.brpLaunch.Controls.Add(this.label1);
            this.brpLaunch.Controls.Add(this.btnLaunch);
            this.brpLaunch.ForeColor = System.Drawing.Color.LightGray;
            this.brpLaunch.Location = new System.Drawing.Point(12, 26);
            this.brpLaunch.Name = "brpLaunch";
            this.brpLaunch.Size = new System.Drawing.Size(169, 118);
            this.brpLaunch.TabIndex = 5;
            this.brpLaunch.TabStop = false;
            this.brpLaunch.Text = "Launcher";
            // 
            // lstAccBox
            // 
            this.lstAccBox.AllowDrop = true;
            this.lstAccBox.DataSource = new string[0];
            this.lstAccBox.FormattingEnabled = true;
            this.lstAccBox.Location = new System.Drawing.Point(70, 14);
            this.lstAccBox.MaxDropDownItems = 10;
            this.lstAccBox.Name = "lstAccBox";
            this.lstAccBox.Size = new System.Drawing.Size(90, 21);
            this.lstAccBox.TabIndex = 9;
            this.lstAccBox.SelectedIndexChanged += new System.EventHandler(this.lstAccBox_SelectedIndexChanged);
            this.lstAccBox.DropDownClosed += new System.EventHandler(this.lstAccBox_DropDownClosed);
            this.lstAccBox.TextChanged += new System.EventHandler(this.lstAccBox_TextChanged);
            // 
            // btnSaveAcc
            // 
            this.btnSaveAcc.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaveAcc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveAcc.ForeColor = System.Drawing.Color.LightGray;
            this.btnSaveAcc.Location = new System.Drawing.Point(6, 88);
            this.btnSaveAcc.Name = "btnSaveAcc";
            this.btnSaveAcc.Size = new System.Drawing.Size(59, 21);
            this.btnSaveAcc.TabIndex = 8;
            this.btnSaveAcc.Text = "Save";
            this.btnSaveAcc.UseVisualStyleBackColor = false;
            this.btnSaveAcc.Click += new System.EventHandler(this.btnSaveAcc_Click);
            // 
            // btnEditAcc
            // 
            this.btnEditAcc.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEditAcc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditAcc.ForeColor = System.Drawing.Color.LightGray;
            this.btnEditAcc.Location = new System.Drawing.Point(6, 67);
            this.btnEditAcc.Name = "btnEditAcc";
            this.btnEditAcc.Size = new System.Drawing.Size(59, 21);
            this.btnEditAcc.TabIndex = 7;
            this.btnEditAcc.Text = "Edit";
            this.btnEditAcc.UseVisualStyleBackColor = false;
            this.btnEditAcc.Click += new System.EventHandler(this.btnEditAcc_Click);
            // 
            // txtPwBox
            // 
            this.txtPwBox.Enabled = false;
            this.txtPwBox.Location = new System.Drawing.Point(70, 42);
            this.txtPwBox.MaxLength = 15;
            this.txtPwBox.Name = "txtPwBox";
            this.txtPwBox.PasswordChar = '*';
            this.txtPwBox.Size = new System.Drawing.Size(90, 20);
            this.txtPwBox.TabIndex = 6;
            this.txtPwBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pasword";
            // 
            // grpSwitcher
            // 
            this.grpSwitcher.Controls.Add(this.radFiveThousand);
            this.grpSwitcher.Controls.Add(this.radElevenThousand);
            this.grpSwitcher.Controls.Add(this.lstServerBox);
            this.grpSwitcher.Controls.Add(this.btnSaveIp);
            this.grpSwitcher.Controls.Add(this.btnRemove);
            this.grpSwitcher.Controls.Add(this.label3);
            this.grpSwitcher.Controls.Add(this.label4);
            this.grpSwitcher.Controls.Add(this.btnEnableSwitcher);
            this.grpSwitcher.ForeColor = System.Drawing.Color.LightGray;
            this.grpSwitcher.Location = new System.Drawing.Point(186, 26);
            this.grpSwitcher.Name = "grpSwitcher";
            this.grpSwitcher.Size = new System.Drawing.Size(169, 118);
            this.grpSwitcher.TabIndex = 9;
            this.grpSwitcher.TabStop = false;
            this.grpSwitcher.Text = "Server Switcher";
            // 
            // radFiveThousand
            // 
            this.radFiveThousand.Checked = true;
            this.radFiveThousand.Location = new System.Drawing.Point(112, 41);
            this.radFiveThousand.Name = "radFiveThousand";
            this.radFiveThousand.Size = new System.Drawing.Size(56, 24);
            this.radFiveThousand.TabIndex = 12;
            this.radFiveThousand.TabStop = true;
            this.radFiveThousand.Text = "59774";
            this.radFiveThousand.UseVisualStyleBackColor = true;
            this.radFiveThousand.CheckedChanged += new System.EventHandler(this.radBtn_Checked);
            // 
            // radElevenThousand
            // 
            this.radElevenThousand.Location = new System.Drawing.Point(60, 41);
            this.radElevenThousand.Name = "radElevenThousand";
            this.radElevenThousand.Size = new System.Drawing.Size(55, 24);
            this.radElevenThousand.TabIndex = 11;
            this.radElevenThousand.Text = "11000";
            this.radElevenThousand.UseVisualStyleBackColor = true;
            this.radElevenThousand.CheckedChanged += new System.EventHandler(this.radBtn_Checked);
            // 
            // lstServerBox
            // 
            this.lstServerBox.AllowDrop = true;
            this.lstServerBox.FormattingEnabled = true;
            this.lstServerBox.Location = new System.Drawing.Point(60, 14);
            this.lstServerBox.MaxDropDownItems = 10;
            this.lstServerBox.Name = "lstServerBox";
            this.lstServerBox.Size = new System.Drawing.Size(100, 21);
            this.lstServerBox.TabIndex = 10;
            this.lstServerBox.DropDownClosed += new System.EventHandler(this.lstServerBox_DropDownClosed);
            this.lstServerBox.TextChanged += new System.EventHandler(this.LoginIpTxtChanged);
            // 
            // btnSaveIp
            // 
            this.btnSaveIp.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaveIp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveIp.ForeColor = System.Drawing.Color.LightGray;
            this.btnSaveIp.Location = new System.Drawing.Point(6, 88);
            this.btnSaveIp.Name = "btnSaveIp";
            this.btnSaveIp.Size = new System.Drawing.Size(59, 21);
            this.btnSaveIp.TabIndex = 8;
            this.btnSaveIp.Text = "Save";
            this.btnSaveIp.UseVisualStyleBackColor = false;
            this.btnSaveIp.Click += new System.EventHandler(this.btnSaveIp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.ForeColor = System.Drawing.Color.LightGray;
            this.btnRemove.Location = new System.Drawing.Point(6, 67);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 21);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Log Port";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Server IP";
            // 
            // btnEnableSwitcher
            // 
            this.btnEnableSwitcher.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEnableSwitcher.Enabled = false;
            this.btnEnableSwitcher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnableSwitcher.ForeColor = System.Drawing.Color.LightGray;
            this.btnEnableSwitcher.Location = new System.Drawing.Point(70, 67);
            this.btnEnableSwitcher.Name = "btnEnableSwitcher";
            this.btnEnableSwitcher.Size = new System.Drawing.Size(90, 42);
            this.btnEnableSwitcher.TabIndex = 0;
            this.btnEnableSwitcher.Text = "Enable";
            this.btnEnableSwitcher.UseVisualStyleBackColor = false;
            this.btnEnableSwitcher.Click += new System.EventHandler(this.btnEnableSwitcher_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 149);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(366, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.Text = "No Changes Yet";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(366, 171);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpSwitcher);
            this.Controls.Add(this.brpLaunch);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mabi Steam Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.brpLaunch.ResumeLayout(false);
            this.brpLaunch.PerformLayout();
            this.grpSwitcher.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem setClientDirToolStripMenuItem;


        private System.Windows.Forms.RadioButton radElevenThousand;
        private System.Windows.Forms.RadioButton radFiveThousand;

        private System.Windows.Forms.ToolStripMenuItem directoriesToolStripMenuItem;

        private System.Windows.Forms.GroupBox grpSwitcher;
        private System.Windows.Forms.GroupBox brpLaunch;
        
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnSaveAcc;
        private System.Windows.Forms.Button btnEditAcc;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSaveIp;
        private System.Windows.Forms.Button btnEnableSwitcher;

        public System.Windows.Forms.TextBox txtPwBox;

        public System.Windows.Forms.ComboBox lstServerBox;
        public System.Windows.Forms.ComboBox lstAccBox;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setSteamDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMabiShortcutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillAccountListToolStripMenuItem;

        #endregion
    }
}