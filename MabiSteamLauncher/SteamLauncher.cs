using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MabiSteamLauncher.Properties;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace MabiSteamLauncher
{
    public class SteamLauncher
    {
        private bool _steamOpen;
        private bool _steamLoginOpen;
        private bool _steamConnectorOpen;
        private bool _newClientOpen;

        private Dictionary<int, string> _countBeforeLaunch = new Dictionary<int, string>();

        
        
        public void Launch(string account, string password, string serverSwitcher)
        {

            _steamLoginOpen = false;
            _steamOpen = false;
            _steamConnectorOpen = false;

            _countBeforeLaunch = CheckClientCount();
            
            var thread = new Thread(() =>
            {
                CloseSteam();
                Thread.Sleep(200);
            
                LaunchSteam(account, password);
                // WaitForSteamLogin();
                WaitForSteam();
                LaunchMabi();
                WaitForMabiToOpen();
                CloseSteam();
            });
            thread.IsBackground = true;
            thread.Start();
        }
        
        public void LaunchSteam(string username, string password)
        {
            // var accountInfo = GetNextAccountInfo();
            var totalArgs = $"-login {username} {password}";
            var processStart = new ProcessStartInfo();
            processStart.FileName = Settings.Default.SteamDir;
            processStart.Arguments = totalArgs;
            Process.Start(processStart);
        }

        public void LaunchMabi()
        {
            var processStart = new ProcessStartInfo();
            processStart.FileName = Settings.Default.MabiShortcutDir;
            Process.Start(processStart);
        }

        public void CloseSteam()
        {
            var runningProcesses = Process.GetProcessesByName("steam");
            foreach (var process in runningProcesses)
            {
                process.Kill();
            }
        }
        
        /*private (string, string) GetNextAccountInfo()
        {
            return (_account, _password);
        }*/

        private void CheckSteamProcess()
        {
            var processlist = Process.GetProcesses();
            foreach (var theprocess in processlist)
            {
                var mainWindowName = theprocess.MainWindowTitle.ToLower();
                if (mainWindowName.Contains("steam"))
                {
                    if (mainWindowName.Equals("steam") || (mainWindowName.Contains("steam") && mainWindowName.Contains("News")))
                    {
                        _steamOpen = true;
                        _steamLoginOpen = false;
                    }
                    else if (mainWindowName.Contains("steam login"))
                    {
                        _steamLoginOpen = true;
                    }
                    else if (mainWindowName.Contains("connector"))
                    {
                        _steamConnectorOpen = true;
                        _steamLoginOpen = false;
                    }
                }
            }
        }

        private void WaitForSteamLogin()
        {
            while (!_steamLoginOpen)
            {
                Thread.Sleep(200);
                CheckSteamProcess();
            }
        }

        private void WaitForSteam()
        {
            while (!_steamOpen)
            {
                Thread.Sleep(200);
                CheckSteamProcess();
            }
        }

        private void WaitForSteamConnector()
        {
            while (!_steamConnectorOpen)
            {
                Thread.Sleep(200);
                CheckSteamProcess();
            }
        }
        
        public void WaitForMabiToOpen()
        {
            while (!_newClientOpen)
            {
                Thread.Sleep(200);
                var clientsOpen = CheckClientCount();
                if (_countBeforeLaunch.Count != clientsOpen.Count)
                {
                    var newWindowOpening = true;
                    var idToCheck = 0;

                    var listWithFirstId = CheckClientCount();
                    while (newWindowOpening)
                    {
                        Thread.Sleep(200);
                        if (idToCheck == 0)
                        {
                            foreach (var client in clientsOpen)           
                            {
                                if (client.Value.Equals(""))
                                {
                                    idToCheck = client.Key;
                                    listWithFirstId = CheckClientCount();
                                }
                            }
                        }
                        else
                        {
                            foreach (var process in listWithFirstId)
                            {
                                if (process.Key == idToCheck)
                                {
                                    var clientOpen = false;
                                    while (!clientOpen)
                                    {
                                        Thread.Sleep(200);
                                        var anotherProcessCheck = CheckClientCount();
                                        foreach (var client in anotherProcessCheck)
                                        {
                                            if (!_countBeforeLaunch.ContainsKey(client.Key) && !client.Value.Equals(""))
                                            {
                                                clientOpen = true;
                                            }
                                        }
                                    }
                                    newWindowOpening = false;
                                    _newClientOpen = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public Dictionary<int,string> CheckClientCount()
        {
            var idSet = new Dictionary<int,string>();
            var processlist = Process.GetProcessesByName("Client");
            foreach (var process in processlist)
            {
                idSet.Add(process.Id, process.MainWindowTitle);
            }
            return idSet;
        }
    }
}