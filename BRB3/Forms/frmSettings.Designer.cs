namespace BRB.Forms
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.miMovements = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.mAbout = new System.Windows.Forms.MenuItem();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRigth = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mpTabControl = new System.Windows.Forms.TabControl();
            this.tcMain = new System.Windows.Forms.TabPage();
            this.tclDownload = new System.Windows.Forms.Label();
            this.tclFile = new System.Windows.Forms.Label();
            this.tclFileCapt = new System.Windows.Forms.Label();
            this.tclDownloadCapt = new System.Windows.Forms.Label();
            this.tctbTMInvTM = new System.Windows.Forms.TextBox();
            this.tclTMInvDef = new System.Windows.Forms.Label();
            this.tctbTMInvDoc = new System.Windows.Forms.TextBox();
            this.tclTMInvCapt = new System.Windows.Forms.Label();
            this.tclTM = new System.Windows.Forms.Label();
            this.tclTMCapt = new System.Windows.Forms.Label();
            this.tclSerialCapt = new System.Windows.Forms.Label();
            this.tcDevNameCapt = new System.Windows.Forms.Label();
            this.tclSerial = new System.Windows.Forms.Label();
            this.tclDeviceName = new System.Windows.Forms.Label();
            this.tcDataBase = new System.Windows.Forms.TabPage();
            this.tcdbBottonCleanDB = new System.Windows.Forms.Button();
            this.tcdbSync = new System.Windows.Forms.TextBox();
            this.tcdbSyncCapt = new System.Windows.Forms.Label();
            this.tcdbBase = new System.Windows.Forms.TextBox();
            this.tcdbBaseCapt = new System.Windows.Forms.Label();
            this.tcdbProgressBar = new System.Windows.Forms.ProgressBar();
            this.mainPanel.SuspendLayout();
            this.mpTabControl.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tcDataBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.miMovements);
            this.mainMenu.MenuItems.Add(this.mAbout);
            // 
            // miMovements
            // 
            this.miMovements.MenuItems.Add(this.miExit);
            this.miMovements.Text = "Додатково";
            // 
            // miExit
            // 
            this.miExit.Text = "Вихід";
            this.miExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // mAbout
            // 
            this.mAbout.Text = "Про ...";
            // 
            // labelLeft
            // 
            this.labelLeft.BackColor = System.Drawing.SystemColors.Window;
            this.labelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLeft.Location = new System.Drawing.Point(0, 0);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(1, 295);
            // 
            // labelRigth
            // 
            this.labelRigth.BackColor = System.Drawing.SystemColors.Window;
            this.labelRigth.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelRigth.Location = new System.Drawing.Point(237, 0);
            this.labelRigth.Name = "labelRigth";
            this.labelRigth.Size = new System.Drawing.Size(1, 295);
            // 
            // labelTop
            // 
            this.labelTop.BackColor = System.Drawing.SystemColors.Window;
            this.labelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTop.Location = new System.Drawing.Point(1, 0);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(236, 1);
            // 
            // labelDown
            // 
            this.labelDown.BackColor = System.Drawing.SystemColors.Window;
            this.labelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelDown.Location = new System.Drawing.Point(1, 294);
            this.labelDown.Name = "labelDown";
            this.labelDown.Size = new System.Drawing.Size(236, 1);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mpTabControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(236, 293);
            // 
            // mpTabControl
            // 
            this.mpTabControl.Controls.Add(this.tcMain);
            this.mpTabControl.Controls.Add(this.tcDataBase);
            this.mpTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mpTabControl.Location = new System.Drawing.Point(0, 0);
            this.mpTabControl.Name = "mpTabControl";
            this.mpTabControl.SelectedIndex = 0;
            this.mpTabControl.Size = new System.Drawing.Size(236, 293);
            this.mpTabControl.TabIndex = 3;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tclDownload);
            this.tcMain.Controls.Add(this.tclFile);
            this.tcMain.Controls.Add(this.tclFileCapt);
            this.tcMain.Controls.Add(this.tclDownloadCapt);
            this.tcMain.Controls.Add(this.tctbTMInvTM);
            this.tcMain.Controls.Add(this.tclTMInvDef);
            this.tcMain.Controls.Add(this.tctbTMInvDoc);
            this.tcMain.Controls.Add(this.tclTMInvCapt);
            this.tcMain.Controls.Add(this.tclTM);
            this.tcMain.Controls.Add(this.tclTMCapt);
            this.tcMain.Controls.Add(this.tclSerialCapt);
            this.tcMain.Controls.Add(this.tcDevNameCapt);
            this.tcMain.Controls.Add(this.tclSerial);
            this.tcMain.Controls.Add(this.tclDeviceName);
            this.tcMain.Location = new System.Drawing.Point(4, 25);
            this.tcMain.Name = "tcMain";
            this.tcMain.Size = new System.Drawing.Size(228, 264);
            this.tcMain.Text = "Основні";
            // 
            // tclDownload
            // 
            this.tclDownload.BackColor = System.Drawing.Color.Gainsboro;
            this.tclDownload.Location = new System.Drawing.Point(107, 120);
            this.tclDownload.Name = "tclDownload";
            this.tclDownload.Size = new System.Drawing.Size(116, 20);
            this.tclDownload.Text = "Folder";
            // 
            // tclFile
            // 
            this.tclFile.BackColor = System.Drawing.Color.Gainsboro;
            this.tclFile.Location = new System.Drawing.Point(80, 97);
            this.tclFile.Name = "tclFile";
            this.tclFile.Size = new System.Drawing.Size(143, 20);
            this.tclFile.Text = "File";
            // 
            // tclFileCapt
            // 
            this.tclFileCapt.Location = new System.Drawing.Point(3, 97);
            this.tclFileCapt.Name = "tclFileCapt";
            this.tclFileCapt.Size = new System.Drawing.Size(75, 20);
            this.tclFileCapt.Text = "Файл: ";
            this.tclFileCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tclDownloadCapt
            // 
            this.tclDownloadCapt.Location = new System.Drawing.Point(3, 120);
            this.tclDownloadCapt.Name = "tclDownloadCapt";
            this.tclDownloadCapt.Size = new System.Drawing.Size(100, 20);
            this.tclDownloadCapt.Text = "Завантажувати: ";
            this.tclDownloadCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tctbTMInvTM
            // 
            this.tctbTMInvTM.Location = new System.Drawing.Point(151, 73);
            this.tctbTMInvTM.MaxLength = 4;
            this.tctbTMInvTM.Name = "tctbTMInvTM";
            this.tctbTMInvTM.Size = new System.Drawing.Size(45, 23);
            this.tctbTMInvTM.TabIndex = 9;
            this.tctbTMInvTM.Text = "????";
            // 
            // tclTMInvDef
            // 
            this.tclTMInvDef.Location = new System.Drawing.Point(139, 74);
            this.tclTMInvDef.Name = "tclTMInvDef";
            this.tclTMInvDef.Size = new System.Drawing.Size(10, 20);
            this.tclTMInvDef.Text = "-";
            this.tclTMInvDef.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tctbTMInvDoc
            // 
            this.tctbTMInvDoc.Location = new System.Drawing.Point(107, 73);
            this.tctbTMInvDoc.MaxLength = 2;
            this.tctbTMInvDoc.Name = "tctbTMInvDoc";
            this.tctbTMInvDoc.Size = new System.Drawing.Size(30, 23);
            this.tctbTMInvDoc.TabIndex = 1;
            this.tctbTMInvDoc.Text = "??";
            // 
            // tclTMInvCapt
            // 
            this.tclTMInvCapt.Location = new System.Drawing.Point(3, 74);
            this.tclTMInvCapt.Name = "tclTMInvCapt";
            this.tclTMInvCapt.Size = new System.Drawing.Size(100, 20);
            this.tclTMInvCapt.Text = "Інвентаризація: ";
            this.tclTMInvCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tclTM
            // 
            this.tclTM.BackColor = System.Drawing.Color.Gainsboro;
            this.tclTM.Location = new System.Drawing.Point(80, 51);
            this.tclTM.Name = "tclTM";
            this.tclTM.Size = new System.Drawing.Size(143, 20);
            this.tclTM.Text = "TM";
            // 
            // tclTMCapt
            // 
            this.tclTMCapt.Location = new System.Drawing.Point(3, 51);
            this.tclTMCapt.Name = "tclTMCapt";
            this.tclTMCapt.Size = new System.Drawing.Size(75, 20);
            this.tclTMCapt.Text = "Майданчик: ";
            this.tclTMCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tclSerialCapt
            // 
            this.tclSerialCapt.Location = new System.Drawing.Point(3, 28);
            this.tclSerialCapt.Name = "tclSerialCapt";
            this.tclSerialCapt.Size = new System.Drawing.Size(75, 20);
            this.tclSerialCapt.Text = "Серійний№: ";
            this.tclSerialCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tcDevNameCapt
            // 
            this.tcDevNameCapt.Location = new System.Drawing.Point(3, 5);
            this.tcDevNameCapt.Name = "tcDevNameCapt";
            this.tcDevNameCapt.Size = new System.Drawing.Size(75, 20);
            this.tcDevNameCapt.Text = "ТЗД: ";
            this.tcDevNameCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tclSerial
            // 
            this.tclSerial.BackColor = System.Drawing.Color.Gainsboro;
            this.tclSerial.Location = new System.Drawing.Point(80, 28);
            this.tclSerial.Name = "tclSerial";
            this.tclSerial.Size = new System.Drawing.Size(143, 20);
            this.tclSerial.Text = "Serial";
            // 
            // tclDeviceName
            // 
            this.tclDeviceName.BackColor = System.Drawing.Color.Gainsboro;
            this.tclDeviceName.Location = new System.Drawing.Point(80, 5);
            this.tclDeviceName.Name = "tclDeviceName";
            this.tclDeviceName.Size = new System.Drawing.Size(143, 20);
            this.tclDeviceName.Text = "DeviceName";
            // 
            // tcDataBase
            // 
            this.tcDataBase.Controls.Add(this.tcdbProgressBar);
            this.tcDataBase.Controls.Add(this.tcdbBottonCleanDB);
            this.tcDataBase.Controls.Add(this.tcdbSync);
            this.tcDataBase.Controls.Add(this.tcdbSyncCapt);
            this.tcDataBase.Controls.Add(this.tcdbBase);
            this.tcDataBase.Controls.Add(this.tcdbBaseCapt);
            this.tcDataBase.Location = new System.Drawing.Point(4, 25);
            this.tcDataBase.Name = "tcDataBase";
            this.tcDataBase.Size = new System.Drawing.Size(228, 264);
            this.tcDataBase.Text = "База";
            // 
            // tcdbBottonCleanDB
            // 
            this.tcdbBottonCleanDB.Location = new System.Drawing.Point(3, 94);
            this.tcdbBottonCleanDB.Name = "tcdbBottonCleanDB";
            this.tcdbBottonCleanDB.Size = new System.Drawing.Size(222, 30);
            this.tcdbBottonCleanDB.TabIndex = 4;
            this.tcdbBottonCleanDB.Text = "Очистити Базу Даних";
            this.tcdbBottonCleanDB.Click += new System.EventHandler(this.btnCleanDB_Click);
            // 
            // tcdbSync
            // 
            this.tcdbSync.BackColor = System.Drawing.Color.Gainsboro;
            this.tcdbSync.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tcdbSync.Location = new System.Drawing.Point(3, 64);
            this.tcdbSync.Name = "tcdbSync";
            this.tcdbSync.Size = new System.Drawing.Size(222, 23);
            this.tcdbSync.TabIndex = 0;
            this.tcdbSync.Text = "tcdbSync";
            // 
            // tcdbSyncCapt
            // 
            this.tcdbSyncCapt.Location = new System.Drawing.Point(3, 46);
            this.tcdbSyncCapt.Name = "tcdbSyncCapt";
            this.tcdbSyncCapt.Size = new System.Drawing.Size(100, 20);
            this.tcdbSyncCapt.Text = "Сервер: ";
            // 
            // tcdbBase
            // 
            this.tcdbBase.BackColor = System.Drawing.Color.Gainsboro;
            this.tcdbBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tcdbBase.Location = new System.Drawing.Point(3, 23);
            this.tcdbBase.Name = "tcdbBase";
            this.tcdbBase.Size = new System.Drawing.Size(222, 23);
            this.tcdbBase.TabIndex = 2;
            this.tcdbBase.Text = "tcdbBase";
            // 
            // tcdbBaseCapt
            // 
            this.tcdbBaseCapt.Location = new System.Drawing.Point(3, 5);
            this.tcdbBaseCapt.Name = "tcdbBaseCapt";
            this.tcdbBaseCapt.Size = new System.Drawing.Size(100, 20);
            this.tcdbBaseCapt.Text = "База: ";
            // 
            // tcdbProgressBar
            // 
            this.tcdbProgressBar.Location = new System.Drawing.Point(3, 135);
            this.tcdbProgressBar.Name = "tcdbProgressBar";
            this.tcdbProgressBar.Size = new System.Drawing.Size(222, 20);
            this.tcdbProgressBar.Enabled = false;
            this.tcdbProgressBar.Visible = false;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.labelDown);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.labelRigth);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "BRB3";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyUp);
            this.mainPanel.ResumeLayout(false);
            this.mpTabControl.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tcDataBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label labelRigth;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelDown;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem miMovements;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label tclDeviceName;
        private System.Windows.Forms.MenuItem mAbout;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.Label tclSerial;
        private System.Windows.Forms.TabControl mpTabControl;
        private System.Windows.Forms.TabPage tcMain;
        private System.Windows.Forms.TabPage tcDataBase;
        private System.Windows.Forms.Label tcDevNameCapt;
        private System.Windows.Forms.Label tclSerialCapt;
        private System.Windows.Forms.Label tclTMCapt;
        private System.Windows.Forms.Label tclTM;
        private System.Windows.Forms.Label tclTMInvCapt;
        private System.Windows.Forms.TextBox tctbTMInvDoc;
        private System.Windows.Forms.Label tclTMInvDef;
        private System.Windows.Forms.TextBox tctbTMInvTM;
        private System.Windows.Forms.Label tclDownloadCapt;
        private System.Windows.Forms.Label tclFileCapt;
        private System.Windows.Forms.Label tclFile;
        private System.Windows.Forms.Label tclDownload;
        private System.Windows.Forms.Label tcdbBaseCapt;
        private System.Windows.Forms.TextBox tcdbBase;
        private System.Windows.Forms.Label tcdbSyncCapt;
        private System.Windows.Forms.TextBox tcdbSync;
        private System.Windows.Forms.Button tcdbBottonCleanDB;
        private System.Windows.Forms.ProgressBar tcdbProgressBar;


    }
}