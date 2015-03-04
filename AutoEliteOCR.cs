using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoEliteOCR {
    class AutoEliteOCR : Form {

        public bool Running {
            get { return Watcher.Enabled; }
            private set { }
        }
        public delegate void StateChangedHandler(object sender, bool state);
        public event StateChangedHandler StateChanged;

        internal NotifyIcon TrayIcon;
        internal ContextMenu TrayMenu;
        internal OptionsForm OptionsForm;
        internal Watcher Watcher;
        internal MenuItem StartStopMenuItem;
        internal MenuItem WriteOutMenuItem;
        internal CmdRunner Runner;
        internal OutputBuffer Buffer;

        public AutoEliteOCR() {
            Buffer = new OutputBuffer();
            Buffer.CountChanged += (o, acc, ign) => {
                WriteOutMenuItem.Enabled = acc > 0;
            };
            
            OptionsForm = new OptionsForm();
            
            Watcher = new Watcher();
            Watcher.Callback += watcher_Callback;
            
            Runner = new CmdRunner();
            Runner.JobDone += job_Callback;

            // Create a simple tray menu with only one item.
            TrayMenu = new ContextMenu();
            StartStopMenuItem = TrayMenu.MenuItems.Add("Start", StateToggle);
            WriteOutMenuItem = TrayMenu.MenuItems.Add("Write CSV", (sender, args) => WriteOut());
            TrayMenu.MenuItems.Add("Options", OnOptions);
            TrayMenu.MenuItems.Add("Exit", OnExit);
            WriteOutMenuItem.Enabled = false;

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            TrayIcon = new NotifyIcon();
            TrayIcon.Text = "AutoEliteOCR";
            TrayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            // Add menu to tray icon and show it.
            TrayIcon.ContextMenu = TrayMenu;
            TrayIcon.Visible = true;

            StateChanged += ChangeMenuItem;
        }


        public void Message(string s) {
            TrayIcon.BalloonTipText = s;
            TrayIcon.ShowBalloonTip(2000);
        }

        protected void watcher_Callback(string path) {
            string filename = Path.GetFileNameWithoutExtension(path);

            var cmd = new CmdParam {
                Arguments = "-i \"" + path + "\" -o \"" + Path.Combine(Settings.Default.TmpDirectory, filename + ".xml") + "\" -l eng",
                Program = Settings.Default.EliteOCRPath + @"\bin\eliteOCRcmd.exe",
                WorkingDir = Settings.Default.EliteOCRPath,
                UserData = path
            };

            Runner.Add(cmd);
        }

        protected void job_Callback(CmdParam p) {
            string fpath = (string) p.UserData;
            string fname = Path.GetFileNameWithoutExtension(fpath);
            var xml = new XmlDocument();
            xml.Load(Path.Combine(Settings.Default.TmpDirectory, fname + ".xml"));


            try {
                var m = Market.FromXml(xml);
                if (m.SystemName == null || m.SystemName == String.Empty)
                    Message("Systemname not found, did you enable verboseLogging in elite?");
                Buffer.Add(m);
                Message(String.Format(
                    "Added {0} commodities to buffer, ignored {1} due to low confidence",
                    m.Commodities.Count, m.Ignored.Count));
            }
            catch (Exception e) {
                Message("error " + e.Message);
            }
            

            File.Delete(Path.Combine(Settings.Default.TmpDirectory, fname + ".xml"));

            if(Settings.Default.DeleteScreenshots) File.Delete(fpath);

        }

        protected void ChangeMenuItem(object o, bool state) {
            string cap = state ? "Stop" : "Start";
            StartStopMenuItem.Text = cap;
        }

        public void StartWatch() {
            if (!OptionsForm.Valid()) {
                Message("Some directories can't be found, please check the options.");
                return;
            }

            Watcher.Path = Settings.Default.ScreenshotFolder;
            Watcher.Enabled = true;
            if (StateChanged != null) StateChanged(this, true);
        }

        public void StopWatch() {
            Watcher.Enabled = false;
            if (StateChanged != null) StateChanged(this, false);
        }

        public void WriteOut() {
            int i = Buffer.Flush();

            Message("Written " + i + " commodities to file");
        }


        #region MenuEvents

        protected void StateToggle(object sender, EventArgs e) {
            if(Running) StopWatch();
            else StartWatch();
        }

        protected void OnExit(object sender, EventArgs e) { 
            Runner.Stop();
            Buffer.Flush(); 
            Application.Exit(); 
        }

        protected void OnOptions(object sender, EventArgs e) {
            OptionsForm.Show();
        }

        #endregion

        #region WinForm overrides
        protected override void OnLoad(EventArgs e) {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            Message("Started, right-click me to view options.");

            base.OnLoad(e);
        }

        protected override void Dispose(bool isDisposing) {
            if (isDisposing) {
                TrayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
        #endregion
    }
}
