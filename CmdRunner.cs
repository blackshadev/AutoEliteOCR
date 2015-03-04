using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoEliteOCR {
    public class CmdRunner {
        private Thread t;
        private Queue<CmdParam> Queue;
        private Queue<CmdParam> Done;
        private bool IsStopped = false;

        public delegate void Callback(CmdParam c);
        public event Callback JobDone;

        public CmdRunner() {
            Queue = new Queue<CmdParam>();
            Done = new Queue<CmdParam>();
            t = new Thread(Start);
            t.Start();
        }

        protected void Start() {
 
            while (!IsStopped) {
                CmdParam item = null;
                
                
                lock (Queue) {
                    // Gets item from queue
                    while (Queue.Count == 0) {
                        if (IsStopped) return;
                        Monitor.Wait(Queue);
                    }
                    item = Queue.Dequeue();
                }

                Execute(item);
            }
        }

        protected void Execute(CmdParam item) {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = item.WorkingDir;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            // Do not create the black window.
            startInfo.CreateNoWindow = true;
            startInfo.FileName = item.Program;
            startInfo.Arguments = item.Arguments;
            process.StartInfo = startInfo;
            process.Start();

            item.Stdout = process.StandardOutput.ReadToEnd();

            item.IsDone = true;
            if (JobDone != null) JobDone(item);
            //lock (Done) {
            //    Done.Enqueue(item);
            //}
        }

        public void Add(CmdParam p) {
            lock (Queue) {
                Queue.Enqueue(p);
                Monitor.Pulse(Queue);
            }
        }

        public void Stop() {
            IsStopped = true;
            lock (Queue) {
                Monitor.PulseAll(Queue);
            }

            t.Join();
        }
    }

    public class CmdParam {
        public string WorkingDir;
        public string Program;
        public string Arguments;
        public bool IsDone;
        public string Stdout;
        public object UserData;
    }
}
