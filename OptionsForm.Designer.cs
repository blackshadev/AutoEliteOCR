namespace AutoEliteOCR {
    partial class OptionsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tmpFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.eliteOCRPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deleteScreenshots = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.csvFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.screenshotFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.writeOutButton = new System.Windows.Forms.Button();
            this.commIgnoredLabel = new System.Windows.Forms.Label();
            this.commAcceptedLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.exportCsvRadio = new System.Windows.Forms.RadioButton();
            this.exportBpcRadio = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.userId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userId);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.exportBpcRadio);
            this.groupBox1.Controls.Add(this.exportCsvRadio);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tmpFolder);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.eliteOCRPath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.deleteScreenshots);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.csvFolder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.screenshotFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(310, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 20);
            this.button4.TabIndex = 15;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.TmpBrowse_Click);
            // 
            // tmpFolder
            // 
            this.tmpFolder.Location = new System.Drawing.Point(114, 71);
            this.tmpFolder.Name = "tmpFolder";
            this.tmpFolder.Size = new System.Drawing.Size(199, 20);
            this.tmpFolder.TabIndex = 14;
            this.tmpFolder.TextChanged += new System.EventHandler(this.tmpFolder_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tmp";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(310, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 20);
            this.button3.TabIndex = 12;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.EliteODTBrowse_Click);
            // 
            // eliteOCRPath
            // 
            this.eliteOCRPath.Location = new System.Drawing.Point(114, 19);
            this.eliteOCRPath.Name = "eliteOCRPath";
            this.eliteOCRPath.Size = new System.Drawing.Size(199, 20);
            this.eliteOCRPath.TabIndex = 11;
            this.eliteOCRPath.TextChanged += new System.EventHandler(this.EliteOCR_Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "EliteOCR";
            // 
            // deleteScreenshots
            // 
            this.deleteScreenshots.AutoSize = true;
            this.deleteScreenshots.Location = new System.Drawing.Point(114, 177);
            this.deleteScreenshots.Name = "deleteScreenshots";
            this.deleteScreenshots.Size = new System.Drawing.Size(119, 17);
            this.deleteScreenshots.TabIndex = 7;
            this.deleteScreenshots.Text = "Delete Screenshots";
            this.deleteScreenshots.UseVisualStyleBackColor = true;
            this.deleteScreenshots.CheckedChanged += new System.EventHandler(this.DeleteScreenshots_Changed);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ScreenshotBrowse_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(310, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 20);
            this.button2.TabIndex = 5;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CsvBrowse_Click);
            // 
            // csvFolder
            // 
            this.csvFolder.Location = new System.Drawing.Point(114, 97);
            this.csvFolder.Name = "csvFolder";
            this.csvFolder.Size = new System.Drawing.Size(199, 20);
            this.csvFolder.TabIndex = 3;
            this.csvFolder.TextChanged += new System.EventHandler(this.CsvFolder_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Csv";
            // 
            // screenshotFolder
            // 
            this.screenshotFolder.Location = new System.Drawing.Point(114, 45);
            this.screenshotFolder.Name = "screenshotFolder";
            this.screenshotFolder.Size = new System.Drawing.Size(199, 20);
            this.screenshotFolder.TabIndex = 1;
            this.screenshotFolder.TextChanged += new System.EventHandler(this.ScreenshotFolder_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Screenshots";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Usage";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(120, 57);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(107, 45);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.Stop_Press);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(4, 57);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(107, 45);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.Start_Press);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Please set everything to the correct path and press start";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 105);
            this.panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.writeOutButton);
            this.groupBox3.Controls.Add(this.commIgnoredLabel);
            this.groupBox3.Controls.Add(this.commAcceptedLabel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(233, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 105);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buffer";
            // 
            // writeOutButton
            // 
            this.writeOutButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.writeOutButton.Enabled = false;
            this.writeOutButton.Location = new System.Drawing.Point(3, 57);
            this.writeOutButton.Name = "writeOutButton";
            this.writeOutButton.Size = new System.Drawing.Size(237, 45);
            this.writeOutButton.TabIndex = 4;
            this.writeOutButton.Text = "Write to file";
            this.writeOutButton.UseVisualStyleBackColor = true;
            this.writeOutButton.Click += new System.EventHandler(this.writeOutButton_Click);
            // 
            // commIgnoredLabel
            // 
            this.commIgnoredLabel.AutoSize = true;
            this.commIgnoredLabel.Location = new System.Drawing.Point(130, 41);
            this.commIgnoredLabel.Name = "commIgnoredLabel";
            this.commIgnoredLabel.Size = new System.Drawing.Size(13, 13);
            this.commIgnoredLabel.TabIndex = 3;
            this.commIgnoredLabel.Text = "0";
            // 
            // commAcceptedLabel
            // 
            this.commAcceptedLabel.AutoSize = true;
            this.commAcceptedLabel.Location = new System.Drawing.Point(130, 20);
            this.commAcceptedLabel.Name = "commAcceptedLabel";
            this.commAcceptedLabel.Size = new System.Drawing.Size(13, 13);
            this.commAcceptedLabel.TabIndex = 2;
            this.commAcceptedLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Comodities ignored";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Comodities accepted";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Output Type";
            // 
            // exportCsvRadio
            // 
            this.exportCsvRadio.AutoSize = true;
            this.exportCsvRadio.Location = new System.Drawing.Point(114, 124);
            this.exportCsvRadio.Name = "exportCsvRadio";
            this.exportCsvRadio.Size = new System.Drawing.Size(42, 17);
            this.exportCsvRadio.TabIndex = 17;
            this.exportCsvRadio.TabStop = true;
            this.exportCsvRadio.Text = "csv";
            this.exportCsvRadio.UseVisualStyleBackColor = true;
            this.exportCsvRadio.CheckedChanged += new System.EventHandler(this.ExportTypeChecked);
            // 
            // exportBpcRadio
            // 
            this.exportBpcRadio.AutoSize = true;
            this.exportBpcRadio.Location = new System.Drawing.Point(167, 124);
            this.exportBpcRadio.Name = "exportBpcRadio";
            this.exportBpcRadio.Size = new System.Drawing.Size(43, 17);
            this.exportBpcRadio.TabIndex = 18;
            this.exportBpcRadio.TabStop = true;
            this.exportBpcRadio.Text = "bpc";
            this.exportBpcRadio.UseVisualStyleBackColor = true;
            this.exportBpcRadio.CheckedChanged += new System.EventHandler(this.ExportTypeChecked);
            // 
            // userId
            // 
            this.userId.Location = new System.Drawing.Point(114, 147);
            this.userId.Name = "userId";
            this.userId.Size = new System.Drawing.Size(199, 20);
            this.userId.TabIndex = 20;
            this.userId.TextChanged += new System.EventHandler(this.UserIdChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "UserId (bpc only)";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 305);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "OptionsForm";
            this.Text = "AutoEliteOCR";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox csvFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox screenshotFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox deleteScreenshots;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox eliteOCRPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tmpFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button writeOutButton;
        private System.Windows.Forms.Label commIgnoredLabel;
        private System.Windows.Forms.Label commAcceptedLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton exportBpcRadio;
        private System.Windows.Forms.RadioButton exportCsvRadio;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox userId;
        private System.Windows.Forms.Label label9;

    }
}

