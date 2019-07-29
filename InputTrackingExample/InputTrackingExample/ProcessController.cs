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

        protected Dictionary<int, Process> ProcessList { get; set; }

        public void Dispose()
        {
            foreach (var p in this.ProcessList)
            {
                p.Value.Dispose();
            }
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
    }
}