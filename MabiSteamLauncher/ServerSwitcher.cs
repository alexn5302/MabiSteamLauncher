using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MabiSteamLauncher
{
    public class ServerSwitcher
    {
        private HashSet<int> _started = new HashSet<int>();

        private string targetIp;
        private string targetLogPort;
        private string clientPath;
        private readonly string defaultLogIP = "35.162.171.43";
        private readonly string defaultLogPort = "11000";

        public ServerSwitcher(string targetIp, string targetLogPort, string clientPath)
        {
            if (targetIp.Equals("") || targetLogPort.Equals(""))
            {
                this.targetIp = defaultLogIP;
                this.targetLogPort = defaultLogPort;
            }
            else
            {
                this.targetIp = targetIp;
                this.targetLogPort = targetLogPort; 
            }

            this.clientPath = clientPath;
        }

        private bool _running = false;

        public void Run()
        {
            _running = true;
            Init();
            Thread thread = new Thread(() =>
            {
                while (_running)
                {
                    CheckForNewLaunches();
                    Thread.Sleep(200);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public void Stop()
        {
            _running = false;
        }

        private bool CheckForNewLaunches()
        {
            Process[] processlist = Process.GetProcesses();
            var newSet = new HashSet<int>();
            foreach (Process theprocess in processlist)
            {
                if (!_running) break;
                if (theprocess.ProcessName.StartsWith("Client"))
                {
                    newSet.Add(theprocess.Id);
                    if (_started.Contains(theprocess.Id)) continue;
                    Relaunch(theprocess.Id);
                    return false;
                }
            }
            _started = newSet;
            return true;
        }

        private void Relaunch(int processId)
        {
            var q = string.Format("select CommandLine from Win32_Process where ProcessId='{0}'", processId);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(q);
            ManagementObjectCollection result = searcher.Get();
        
            foreach (ManagementObject obj in result)
            {
                var client = (string) obj["CommandLine"];
                Process proc = Process.GetProcessById(processId);
                if (client.Contains("35.162.171.43"))
                {
                    proc.Kill();
                    client = client.Replace("35.162.171.43", targetIp);
                    client = client.Replace("11000", targetLogPort);
                    var cmdArgs = CommandLineToArgs(client);
                    var argStr = new StringBuilder();
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        argStr.Append(cmdArgs[i]);
                        argStr.Append(' ');
                    }

                    var processLoc = clientPath;//cmdArgs[0];
                    var totalArgs = argStr.ToString();
                    var processStart = new ProcessStartInfo(); 
                    processStart.WorkingDirectory = Path.GetDirectoryName(processLoc);
                    processStart.FileName = processLoc;
                    processStart.Arguments = totalArgs;
                    Process.Start(processStart);
                }
            }
        }
        private void Init()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.StartsWith("Client"))
                {
                    _started.Add(theprocess.Id);
                }
            }
        }

        [DllImport("shell32.dll", SetLastError = true)]
        static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

        public static string[] CommandLineToArgs(string commandLine)
        {
            int argc;
            var argv = CommandLineToArgvW(commandLine, out argc);
            if (argv == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception();
            try
            {
                var args = new string[argc];
                for (var i = 0; i < args.Length; i++)
                {
                    var p = Marshal.ReadIntPtr(argv, i * IntPtr.Size);
                    args[i] = Marshal.PtrToStringUni(p);
                }

                return args;
            }
            finally
            {
                Marshal.FreeHGlobal(argv);
            }
        }
    }
}
