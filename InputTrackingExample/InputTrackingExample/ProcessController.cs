using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InputTrackingExample
{
    public class ProcessController : IDisposable
    {
        public ProcessController()
        {
            this.Configuration = new ProcessConfiguration();
        }

        public ProcessConfiguration Configuration { get; }
        protected Dictionary<string, int> NamedList { get; set; }
        protected Dictionary<int, Process> ProcessList { get; set; }

        public void Dispose()
        {
            foreach (var p in this.ProcessList)
            {
                p.Value.Dispose();
            }
        }

        public Dictionary<string, int> GetNamedList()
        {
            if (this.NamedList == null)
            {
                this.NamedList = new Dictionary<string, int>(this.GetProcessList().Count);
            }

            return this.NamedList;
        }

        public Process GetProcessById(int id)
        {
            return this.GetProcessList()[id];
        }

        public int[] GetProcessIds()
        {
            int[] result = this.GetProcessList().Select((kvp) => kvp.Key).ToArray();
            return result;
        }

        public Dictionary<int, Process> GetProcessList()
        {
            if (this.ProcessList == null)
            {
                this.ProcessList = Process.GetProcessesByName(this.Configuration.Name).ToDictionary((p) => p.Id);
            }

            return this.ProcessList;
        }

        public void ParseCommand(string cmd)
        {
            CommandModel cm = CommandModel.Parse(cmd);
            if (cm.IsInitialize)
            {
                foreach (var p in this.GetProcessList())
                {
                    this.SendMessage(p.Key.ToString(), p.Value);
                }
            }
            else if (!string.IsNullOrEmpty(cm.Registration))
            {
                var s = cm.Registration.Split('.');
                var key = Int32.Parse(s[0]);
                if (this.GetProcessList().ContainsKey(key))
                {
                    this.GetNamedList().Add(s[1], key);
                }
            }
            else
            {
                var idx = this.GetNamedList()[cm.Target];
                var p = this.GetProcessById(idx);
                this.SendMessage(cm.GetText(), p);
            }
        }

        private void SendMessage(string cmd, Process p)
        {
            IntPtr child = WindowsHookHelper.GetWindow(p.MainWindowHandle, (IntPtr)WindowCmd.GW_CHILD);
            WindowsHookHelper.SendMessage(child, (IntPtr)WindowCmd.WM_SETTEXT, 0, cmd);
        }
    }
}