using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEliteOCR {
    public class Watcher {
        public string Path {
            get { return fWatcher.Path; }
            set {
                fWatcher.EnableRaisingEvents = false;
                fWatcher.Path = value;
            }
        }

        public bool Enabled {
            get { return fWatcher.EnableRaisingEvents; }
            set { fWatcher.EnableRaisingEvents = value; }
        }

        private FileSystemWatcher fWatcher;

        public delegate void CallbackHandler(string fname);
        public event CallbackHandler Callback;

        public Watcher() {
            fWatcher = new FileSystemWatcher();
            fWatcher.Created += FileCreated;
            Enabled = false;
        }

        protected void FileCreated(object sender, FileSystemEventArgs e) {
            if(Callback != null) Callback(e.FullPath);
        }


    }
}
