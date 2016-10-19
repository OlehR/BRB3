namespace BRB.Forms
{
    partial class frmWaresScan
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
            this.miSeparator = new System.Windows.Forms.MenuItem();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRigth = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.mplDocNum = new System.Windows.Forms.Label();
            this.mplDocNumCapt = new System.Windows.Forms.Label();
            this.lchBoxAutoScan = new System.Windows.Forms.CheckBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.miMovements);
            // 
            // miMovements
            // 
            this.miMovements.MenuItems.Add(this.miExit);
            this.miMovements.Text = "Додатково";
            // 
            // miExit
            // 
            this.miExit.Text = "Завершення роботи";
            // 
            // miSeparator
            // 
            this.miSeparator.Text = "";
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
            this.labelDown.Location = new System.Drawing.Point(1, 275);
            this.labelDown.Name = "labelDown";
            this.labelDown.Size = new System.Drawing.Size(236, 20);
            // 
            // mplDocNum
            // 
            this.mplDocNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mplDocNum.BackColor = System.Drawing.Color.Gainsboro;
            this.mplDocNum.Location = new System.Drawing.Point(88, 2);
            this.mplDocNum.Name = "mplDocNum";
            this.mplDocNum.Size = new System.Drawing.Size(66, 20);
            // 
            // mplDocNumCapt
            // 
            this.mplDocNumCapt.Location = new System.Drawing.Point(0, 2);
            this.mplDocNumCapt.Name = "mplDocNumCapt";
            this.mplDocNumCapt.Size = new System.Drawing.Size(86, 20);
            this.mplDocNumCapt.Text = "№ накладної:";
            this.mplDocNumCapt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lchBoxAutoScan
            // 
            this.lchBoxAutoScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lchBoxAutoScan.Checked = true;
            this.lchBoxAutoScan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lchBoxAutoScan.Location = new System.Drawing.Point(156, 2);
            this.lchBoxAutoScan.Name = "lchBoxAutoScan";
            this.lchBoxAutoScan.Size = new System.Drawing.Size(82, 20);
            this.lchBoxAutoScan.TabIndex = 0;
            this.lchBoxAutoScan.Text = "АвтоЗбер";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainPanel.Controls.Add(this.mplDocNumCapt);
            this.mainPanel.Controls.Add(this.mplDocNum);
            this.mainPanel.Controls.Add(this.lchBoxAutoScan);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(236, 274);
            // 
            // frmWaresScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.labelDown);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.labelRigth);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "frmWaresScan";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label labelRigth;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelDown;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem miMovements;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.MenuItem miSeparator;
        private System.Windows.Forms.Label mplDocNum;
        private System.Windows.Forms.Label mplDocNumCapt;
        private System.Windows.Forms.CheckBox lchBoxAutoScan;
        private System.Windows.Forms.Panel mainPanel;
    }
}