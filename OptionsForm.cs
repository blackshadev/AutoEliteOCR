using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoEliteOCR {
    public partial class OptionsForm : Form {
        private bool IsLoaded = false;

        public OptionsForm() {
            InitializeComponent();
            
        }

        public bool Valid() {
            return 
                Directory.Exists(Settings.Default.CsvFolder) &&
                Directory.Exists(Settings.Default.EliteOCRPath + "\\bin") &&
                Directory.Exists(Settings.Default.ScreenshotFolder) &&
                Directory.Exists(Settings.Default.TmpDirectory);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            Program.AutoEliteOcr.Buffer.CountChanged += BufferCountChanged;

            screenshotFolder.Text = Settings.Default.ScreenshotFolder;
            csvFolder.Text = Settings.Default.CsvFolder;
            eliteOCRPath.Text = Settings.Default.EliteOCRPath;
            tmpFolder.Text = Settings.Default.TmpDirectory;
            deleteScreenshots.CheckState = Settings.Default.DeleteScreenshots
                ? CheckState.Checked
                : CheckState.Unchecked;
            exportCsvRadio.Checked = Settings.Default.ExportType == "csv";
            exportBpcRadio.Checked = Settings.Default.ExportType == "bpc";
            userId.Text = Settings.Default.UserId;

            IsLoaded = true;
            Program.AutoEliteOcr.StateChanged += delegate(object sender, bool state) {
                UpdateState();
            };
            UpdateState();
            
        }

        private void UpdateState() {
            bool state = Program.AutoEliteOcr.Running;

            stopButton.Enabled = state;
            startButton.Enabled = !state;

            button1.Enabled = !state;
            button2.Enabled = !state;
            button3.Enabled = !state;
            button4.Enabled = !state;
            screenshotFolder.Enabled = !state;
            csvFolder.Enabled = !state;
            eliteOCRPath.Enabled = !state;
            tmpFolder.Enabled = !state;
            deleteScreenshots.Enabled = !state;
        }

        private void BufferCountChanged(object s, int acc, int ign) {
            Invoke((MethodInvoker)delegate {
                commAcceptedLabel.Text = acc.ToString();
                commIgnoredLabel.Text = ign.ToString();

                writeOutButton.Enabled = (acc > 0);
            });
        }

        private void ScreenshotBrowse_Click(object sender, EventArgs e) {
            var res = folderBrowserDialog.ShowDialog();

            if (res == DialogResult.OK) {
                screenshotFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void EliteODTBrowse_Click(object sender, EventArgs e) {
            var res = folderBrowserDialog.ShowDialog();

            if (res == DialogResult.OK) {
                eliteOCRPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void CsvBrowse_Click(object sender, EventArgs e) {
            var res = folderBrowserDialog.ShowDialog();

            if (res == DialogResult.OK) {
                csvFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void TmpBrowse_Click(object o, EventArgs e) {
            var res = folderBrowserDialog.ShowDialog();

            if (res == DialogResult.OK) {
                tmpFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void DeleteScreenshots_Changed(object sender, EventArgs e) {
            Settings.Default.DeleteScreenshots = deleteScreenshots.CheckState == CheckState.Checked;
        }

        private void CsvFolder_Changed(object sender, EventArgs e) {
            if (!IsLoaded) return;
            Settings.Default.CsvFolder = csvFolder.Text;
            Settings.Default.Save();
        }


        private void ScreenshotFolder_Changed(object sender, EventArgs e) {
            if (!IsLoaded) return;
            Settings.Default.ScreenshotFolder = screenshotFolder.Text;
            Settings.Default.Save();
        }

        private void tmpFolder_Changed(object sender, EventArgs e) {
            if (!IsLoaded) return;
            Settings.Default.TmpDirectory = tmpFolder.Text;
            Settings.Default.Save();
        }

        private void EliteOCR_Changed(object sender, EventArgs e) {
            if (!IsLoaded) return;
            Settings.Default.EliteOCRPath = eliteOCRPath.Text;
            Settings.Default.Save();
        }


        private void Start_Press(object s, EventArgs e) {
            Program.AutoEliteOcr.StartWatch();
            
        }

        private void Stop_Press(object s, EventArgs e) {
            Program.AutoEliteOcr.StopWatch();   
        }

        private void ExportTypeChecked(object s, EventArgs e) { 
            string type = exportCsvRadio.Checked ? "csv" : "bpc";

            Settings.Default.ExportType = type;
            Settings.Default.Save();
        }

        private void UserIdChanged(object s, EventArgs e) {
            Settings.Default.UserId = userId.Text;
            Settings.Default.Save();
        }

        #region Overrides

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();

                Program.AutoEliteOcr.Message("Minimized in system tray.");
            }
        }

        #endregion

        private void writeOutButton_Click(object sender, EventArgs e) {
            Program.AutoEliteOcr.WriteOut();
        }
    }
}
