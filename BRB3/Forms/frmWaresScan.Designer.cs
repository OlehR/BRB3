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
            this.mpchBoxAutoScan = new System.Windows.Forms.CheckBox();
            this.mplBorderTop = new System.Windows.Forms.Label();
            this.mplBorderDown = new System.Windows.Forms.Label();
            this.mplBorderLeft = new System.Windows.Forms.Label();
            this.mplBorderRight = new System.Windows.Forms.Label();
            this.mplAddWaresTxt = new System.Windows.Forms.Label();
            this.mplArticle = new System.Windows.Forms.Label();
            this.mplArticleCapt = new System.Windows.Forms.Label();
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
            this.labelDown.Location = new System.Drawing.Point(1, 294);
            this.labelDown.Name = "labelDown";
            this.labelDown.Size = new System.Drawing.Size(236, 1);
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
            // mpchBoxAutoScan
            // 
            this.mpchBoxAutoScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mpchBoxAutoScan.Checked = true;
            this.mpchBoxAutoScan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mpchBoxAutoScan.Location = new System.Drawing.Point(156, 2);
            this.mpchBoxAutoScan.Name = "mpchBoxAutoScan";
            this.mpchBoxAutoScan.Size = new System.Drawing.Size(82, 20);
            this.mpchBoxAutoScan.TabIndex = 0;
            this.mpchBoxAutoScan.Text = "АвтоЗбер";
            // 
            // mplBorderTop
            // 
            this.mplBorderTop.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplBorderTop.Location = new System.Drawing.Point(1, 32);
            this.mplBorderTop.Name = "mplBorderTop";
            this.mplBorderTop.Size = new System.Drawing.Size(235, 1);
            // 
            // mplBorderDown
            // 
            this.mplBorderDown.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplBorderDown.Location = new System.Drawing.Point(1, 290);
            this.mplBorderDown.Name = "mplBorderDown";
            this.mplBorderDown.Size = new System.Drawing.Size(235, 1);
            // 
            // mplBorderLeft
            // 
            this.mplBorderLeft.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplBorderLeft.Location = new System.Drawing.Point(1, 32);
            this.mplBorderLeft.Name = "mplBorderLeft";
            this.mplBorderLeft.Size = new System.Drawing.Size(1, 231);
            // 
            // mplBorderRight
            // 
            this.mplBorderRight.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplBorderRight.Location = new System.Drawing.Point(235, 32);
            this.mplBorderRight.Name = "mplBorderRight";
            this.mplBorderRight.Size = new System.Drawing.Size(1, 231);
            // 
            // mplAddWaresTxt
            // 
            this.mplAddWaresTxt.Location = new System.Drawing.Point(5, 23);
            this.mplAddWaresTxt.Name = "mplAddWaresTxt";
            this.mplAddWaresTxt.Size = new System.Drawing.Size(126, 18);
            this.mplAddWaresTxt.Text = "Додавання товару:";
            this.mplAddWaresTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mplArticle
            // 
            this.mplArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mplArticle.BackColor = System.Drawing.Color.Gainsboro;
            this.mplArticle.Location = new System.Drawing.Point(89, 43);
            this.mplArticle.Name = "mplArticle";
            this.mplArticle.Size = new System.Drawing.Size(145, 20);
            // 
            // mplArticleCapt
            // 
            this.mplArticleCapt.Location = new System.Drawing.Point(19, 43);
            this.mplArticleCapt.Name = "mplArticleCapt";
            this.mplArticleCapt.Size = new System.Drawing.Size(63, 20);
            this.mplArticleCapt.Text = "Артикул:";
            this.mplArticleCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mplDocNumCapt);
            this.mainPanel.Controls.Add(this.mplDocNum);
            this.mainPanel.Controls.Add(this.mpchBoxAutoScan);
            this.mainPanel.Controls.Add(this.mplBorderLeft);
            this.mainPanel.Controls.Add(this.mplBorderRight);
            this.mainPanel.Controls.Add(this.mplAddWaresTxt);
            this.mainPanel.Controls.Add(this.mplArticleCapt);
            this.mainPanel.Controls.Add(this.mplArticle);
            this.mainPanel.Controls.Add(this.mplBorderTop);
            this.mainPanel.Controls.Add(this.mplBorderDown);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(236, 293);
            // 
            // frmWaresScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
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
            this.Load += new System.EventHandler(this.frmWaresScan_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmWaresScan_Closing);
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
        private System.Windows.Forms.CheckBox mpchBoxAutoScan;
        private System.Windows.Forms.Label mplBorderTop;
        private System.Windows.Forms.Label mplBorderDown;
        private System.Windows.Forms.Label mplBorderLeft;
        private System.Windows.Forms.Label mplBorderRight;
        private System.Windows.Forms.Label mplAddWaresTxt;
        private System.Windows.Forms.Label mplArticleCapt;
        private System.Windows.Forms.Label mplArticle;
        private System.Windows.Forms.Panel mainPanel;
    }
}