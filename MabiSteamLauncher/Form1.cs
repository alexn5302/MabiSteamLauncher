using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MabiSteamLauncher.Properties;

namespace MabiSteamLauncher
{
    public partial class Form1 : Form
    {
        private HashSet<int> _started = new HashSet<int>();

        private ServerSwitcher _serverSwitcher;
        private SteamLauncher _steamLauncher;
        
        public Form1()
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
            FormClosing += (sender, args) =>
            {
                if (_serverSwitcher != null)
                {
                    _serverSwitcher.Stop();
                    _serverSwitcher = null;
                }
            };
            /*InitializeStuffOutsideOfDesigner();*/
        }

        private void InitializeStuffOutsideOfDesigner()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var accounts = config.AppSettings.Settings.AllKeys;
            var tempLastAccount = Settings.Default.LastAccount;

            if (accounts.Length != 0)
            {
                lstAccBox.DataSource = accounts;
            }

            lstAccBox.SelectedIndex = lstAccBox.FindStringExact(tempLastAccount);
            txtPwBox.Text = GetPassword(tempLastAccount);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var accounts = config.AppSettings.Settings.AllKeys;
            var tempLastAccount = Settings.Default.LastAccount;

            if (accounts.Length != 0)
            {
                lstAccBox.DataSource = accounts;
            }

            if (lstServerBox.Text.Equals(""))
            {
                lstServerBox.DataSource = PopulateIpAdresses();
            }

            lstAccBox.SelectedIndex = lstAccBox.FindStringExact(tempLastAccount);
            txtPwBox.Text = GetPassword(tempLastAccount);
        }
        
        private void btnSaveAcc_Click(object sender, EventArgs e)
        {
            if (!Settings.Default.AltListLocation.Equals(""))
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (DoesAccountExist(lstAccBox.Text))
                {
                    ChangePassword(lstAccBox.Text, txtPwBox.Text);
                }
                else
                {
                    AddAccountToList(lstAccBox.Text, txtPwBox.Text);
                }
                config.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection("appSettings");
            
                lstAccBox.DataSource = null;
                lstAccBox.DataSource = PopulateAccounts();
                lstAccBox.Refresh();
                txtPwBox.Enabled = false;
            }
            else
            {
                MessageBox.Show("Set your \"Logins.csv\" file path in settings.");
            }
        }

        private void AddAccountToList(string account, string password)
        {
            var csvBuilder = new StringBuilder();
            var file = Settings.Default.AltListLocation;

            if (file.Contains("Logins.csv"))
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                using(var reader = new StreamReader(file))
                {
                    csvBuilder.AppendLine(reader.ReadLine());
                    while (!reader.EndOfStream)
                    {
                        
                        var line = reader.ReadLine();
                        
                        var values = line.Split(',');

                        if (values[0].Equals("") || reader.EndOfStream)
                        {
                            csvBuilder.AppendLine(line);
                            csvBuilder.AppendLine($"{account},{password}");
                            break;
                        }
                        else
                        {
                            csvBuilder.AppendLine(line);
                        }
                    }
                    reader.Close();
                    File.WriteAllText(Settings.Default.AltListLocation, csvBuilder.ToString());
                    PopulateUserNameAndPw();
                }
            }
            else
            {
                MessageBox.Show("Something is wrong. List not filled.");
            }
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            txtPwBox.Enabled = true;
        }
        
        private void btnRemove_Click(object sender, EventArgs e)
        {
            var ip = lstServerBox.Text;
            RemoveIpAdress(ip);
            
            lstServerBox.DataSource = null;
            lstServerBox.DataSource = PopulateIpAdresses();
            lstServerBox.Refresh();
        }
        
        private void btnSaveIp_Click(object sender, EventArgs e)
        {
            Settings.Default.IpAdresses += "," + lstServerBox.Text;
            Settings.Default.Save();
            
            var tempText = lstServerBox.Text;
            lstServerBox.DataSource = null;
            lstServerBox.DataSource = PopulateIpAdresses();
            lstServerBox.Refresh();
            
            lstServerBox.SelectedIndex = lstAccBox.FindStringExact(tempText);
        }

        private bool DoesAccountExist(string account)
        {
            var exists = false;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            var accountCount = config.AppSettings.Settings.AllKeys.Length;

            for (var i = 0; i < accountCount; i++)
            {
                if (config.AppSettings.Settings.AllKeys[i].Equals(account))
                {
                    exists = true;
                }
            }
            
            return exists;
        }

        private void RemoveIpAdress(string ip)
        {
            var splitIps = Settings.Default.IpAdresses.Split(',');
            var ipList = new List<string>(splitIps);
            var tempList = new List<string>(ipList);
            
            foreach (var adress in tempList)
            {
                if (adress.Equals(ip)) 
                    ipList.Remove(ip);
            }

            Settings.Default.IpAdresses = "";
            foreach (var adress in ipList)
            {
                if (!Settings.Default.IpAdresses.Equals("")) 
                    Settings.Default.IpAdresses += ",";
                
                Settings.Default.IpAdresses += adress;
            }
            Settings.Default.Save();
        }
        
        private List<string> PopulateIpAdresses()
        {
            if (Settings.Default.IpAdresses.Equals(""))
            {
                Settings.Default.IpAdresses = "35.162.171.43";
            }
            var splitIps = Settings.Default.IpAdresses.Split(',');
            var removeDuplicates = new HashSet<string>(splitIps);

            return new List<string>(removeDuplicates);
        }

        private List<string> PopulateAccounts()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            var splitIps = config.AppSettings.Settings.AllKeys;
            var removeDuplicates = new HashSet<string>(splitIps);

            return new List<string>(removeDuplicates);
        }

        private void lstAccBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            txtPwBox.Text = GetPassword(lstAccBox.Text);
            
            Settings.Default.LastAccount = lstAccBox.Text;
            Settings.Default.LastPassword = txtPwBox.Text;
            Settings.Default.Save();
        }

        private void lstAccBox_TextChanged(object sender, EventArgs e)
        {
            if (lstAccBox.Text.Equals(""))
            {
                btnLaunch.Enabled = false;
            }
            else
            {
                btnLaunch.Enabled = true;
            }
        }

        private void lstAccBox_DropDownClosed(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => { lstAccBox.Select(lstAccBox.Text.Length, 0); }));
        }
        
        private void lstServerBox_DropDownClosed(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => { lstAccBox.Select(lstAccBox.Text.Length, 0); }));
        }

        private void setSteamDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuStrip = (ToolStripMenuItem)sender;
            var name = (string)menuStrip.Name;
            
            var programFiles = Environment.SpecialFolder.ProgramFilesX86.ToString();
            
            var fileBrowser = new OpenFileDialog();
            fileBrowser.Title = "Select your steam.exe file";
            fileBrowser.InitialDirectory = programFiles;
            if (name.Equals("setSteamDirToolStripMenuItem"))
            {
                BeginInvoke((Action) (() =>
                {
                    if (fileBrowser.ShowDialog() == DialogResult.OK)
                    {
                        if (!fileBrowser.FileName.Contains("steam.exe"))
                        {
                            MessageBox.Show("Are you retarded?");
                        }
                        else
                        {
                            Settings.Default.SteamDir = fileBrowser.FileName;
                            Settings.Default.Save();
                            toolStripStatusLabel1.Text = $"Steam path set to {Settings.Default.SteamDir}";
                        }
                    }
                }));

            }
        }
        
        private void setClientDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuStrip = (ToolStripMenuItem)sender;
            var name = (string)menuStrip.Name;
            
            // var programFiles = Environment.SpecialFolder.ProgramFilesX86.ToString();
            
            var fileBrowser = new OpenFileDialog();
            fileBrowser.Title = "Select your client.exe  or morrighan file";
            // fileBrowser.InitialDirectory = programFiles;
            if (name.Equals("setClientDirToolStripMenuItem"))
            {
                BeginInvoke((Action) (() =>
                {
                    if (fileBrowser.ShowDialog() == DialogResult.OK)
                    {
                        if (fileBrowser.FileName.Contains("Client.exe") || fileBrowser.FileName.Contains("Morrighan.exe"))
                        {
                            Settings.Default.ClientDir = fileBrowser.FileName;
                            Settings.Default.Save();
                            toolStripStatusLabel1.Text = $"Client path set to {Settings.Default.ClientDir}";
                        }
                        else
                        {
                            MessageBox.Show($"Are you retarded? {fileBrowser.FileName.Contains("Client.exe")}");
                        }
                    }
                }));

            }
        }

        private void setMabiShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuStrip = (ToolStripMenuItem)sender;
            var name = (string)menuStrip.Name;
            
            var defaultDirectory = Environment.SpecialFolder.Desktop.ToString();
            
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.RootFolder = Environment.SpecialFolder.Desktop;

            if (name.Equals("setMabiShortcutToolStripMenuItem"))
            {
                BeginInvoke((Action) (() =>
                {
                    if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var mabiShortcut = folderBrowser.SelectedPath + @"\Mabinogi.url";
                        Settings.Default.MabiShortcutDir = mabiShortcut;
                        Settings.Default.Save();
                        toolStripStatusLabel1.Text = $"Steam path set to {Settings.Default.MabiShortcutDir}";
                    }
                }));
            }
        }

        private void fillAccountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var defaultDirectory = Environment.SpecialFolder.Desktop.ToString();
            
            var fileBrowser = new OpenFileDialog();
            fileBrowser.Title = "Select your login.csv file";
            fileBrowser.InitialDirectory = defaultDirectory;
            if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!fileBrowser.FileName.Contains("Logins.csv"))
                {
                    MessageBox.Show("Are you retarded?");
                }
                else
                {
                    Settings.Default.AltListLocation = fileBrowser.FileName;
                    Settings.Default.Save();
                    PopulateUserNameAndPw();
                    toolStripStatusLabel1.Text = $"Steam path set to {Settings.Default.AltListLocation}";
                }
            }
        }

        private string GetPassword(string username)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string password;
            try
            {
                password = config.AppSettings.Settings[lstAccBox.Text].Value;
            }
            catch (NullReferenceException)
            {
                password = "";
            }
            
            return password;
        }
        
        private void ChangePassword(string username, string password)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings[username].Value = password;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            lstAccBox.Refresh();
        }

        private void ClearAccountList()
        {
            var file = Settings.Default.AltListLocation;
            
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var accounts = config.AppSettings.Settings.AllKeys;
            foreach (var account in accounts)
            {
                config.AppSettings.Settings.Remove(account);
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            
        }
        
        private void PopulateUserNameAndPw()
        {
            ClearAccountList();
            
            var file = Settings.Default.AltListLocation;

            if (file.Contains("Logins.csv"))
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                using(var reader = new StreamReader(file))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values[0].Equals(""))
                        {
                            reader.Close();
                            break;
                        }
                        
                        config.AppSettings.Settings.Add($"{values[0]}", $"{values[1]}");
                    }
                    reader.Close();
                    config.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection("appSettings");
                    lstAccBox.DataSource = null;
                    lstAccBox.DataSource = PopulateAccounts();
                    lstAccBox.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Something is wrong. List not filled.");
            }
        }

        private void directoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Steam Directory: {Settings.Default.SteamDir}\n" +
                $"Client Directory: {Settings.Default.ClientDir}\n" +
                $"Mabinogi Shortcut: {Settings.Default.MabiShortcutDir}\n" +
                $"Alt Info: {Settings.Default.AltListLocation}\n");
        }
        
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            _steamLauncher = new SteamLauncher();
            _steamLauncher.Launch(lstAccBox.Text, txtPwBox.Text, btnEnableSwitcher.Text);
        }
        
        private void btnEnableSwitcher_Click(object sender, EventArgs e)
        {
            if (_serverSwitcher != null)
            {
                KillServerSwitcher();
                lstServerBox.Enabled = true;
            }
            else
            {
                RunServerSwitcher();
                lstServerBox.Enabled = false;
            }
        }

        private void radBtn_Checked(object sender, EventArgs e)
        {
            if (radElevenThousand.Checked)
            {
                Settings.Default.LogPorts = "11000";
                radFiveThousand.Checked = false;
            }
            else if (radFiveThousand.Checked)
            {
                Settings.Default.LogPorts = "59774";
                radElevenThousand.Checked = false;
            }
            Settings.Default.Save();
            toolStripStatusLabel1.Text = $"Log port set to {Settings.Default.LogPorts}";
        }

        private void LoginIpTxtChanged(object sender, EventArgs e)
        {
            if (lstServerBox.Text.Length >= 7)
            {
                btnEnableSwitcher.Enabled = true;
            }
            else if (lstServerBox.Text.Length < 7)
            {
                btnEnableSwitcher.Enabled = false;
            }
        }

        private void KillServerSwitcher()
        {
            _serverSwitcher.Stop();
            _serverSwitcher = null;
            btnEnableSwitcher.Text = "Enable";
            toolStripStatusLabel1.Text = "Server Switcher Stopped";
        }

        private void RunServerSwitcher()
        {
            _serverSwitcher = new ServerSwitcher(lstServerBox.Text, Settings.Default.LogPorts, Settings.Default.ClientDir);
            _serverSwitcher.Run();
            btnEnableSwitcher.Text = "Disable";
            toolStripStatusLabel1.Text = "Server Switcher running";
        }
    }

    public class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs myMenu)
        {
            if (!myMenu.Item.Selected)
                base.OnRenderMenuItemBackground(myMenu);

            else
            {
                var menuRectangle = new Rectangle(Point.Empty, myMenu.Item.Size);

                //Fill Color
                myMenu.Graphics.FillRectangle(Brushes.Black, menuRectangle);

                // Border Color
                myMenu.Graphics.DrawRectangle(Pens.Black, 1, 0, menuRectangle.Width - 2, menuRectangle.Height - 1);
            }
        }
    }
}