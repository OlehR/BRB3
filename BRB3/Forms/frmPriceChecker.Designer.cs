namespace BRB.Forms
{
    partial class frmPriceChecker
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
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.button1 = new System.Windows.Forms.Button();
            this.mplLine4 = new System.Windows.Forms.Label();
            this.mplLine3 = new System.Windows.Forms.Label();
            this.mplLine2 = new System.Windows.Forms.Label();
            this.mplInfo = new System.Windows.Forms.Label();
            this.mplPriceOpt = new System.Windows.Forms.Label();
            this.mplPriceOptCapt = new System.Windows.Forms.Label();
            this.mplPrice = new System.Windows.Forms.Label();
            this.mplPriceCapt = new System.Windows.Forms.Label();
            this.mplNameCapt = new System.Windows.Forms.Label();
            this.mplName = new System.Windows.Forms.Label();
            this.mplArticle = new System.Windows.Forms.Label();
            this.mplWaresInfCapt = new System.Windows.Forms.Label();
            this.mplBarCode = new System.Windows.Forms.Label();
            this.mplBarCodeCapt = new System.Windows.Forms.Label();
            this.mplArticleCapt = new System.Windows.Forms.Label();
            this.mplLine1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
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
            this.mainPanel.Controls.Add(this.button2);
            this.mainPanel.Controls.Add(this.statusBar);
            this.mainPanel.Controls.Add(this.button1);
            this.mainPanel.Controls.Add(this.mplLine4);
            this.mainPanel.Controls.Add(this.mplLine3);
            this.mainPanel.Controls.Add(this.mplLine2);
            this.mainPanel.Controls.Add(this.mplInfo);
            this.mainPanel.Controls.Add(this.mplPriceOpt);
            this.mainPanel.Controls.Add(this.mplPriceOptCapt);
            this.mainPanel.Controls.Add(this.mplPrice);
            this.mainPanel.Controls.Add(this.mplPriceCapt);
            this.mainPanel.Controls.Add(this.mplNameCapt);
            this.mainPanel.Controls.Add(this.mplName);
            this.mainPanel.Controls.Add(this.mplArticle);
            this.mainPanel.Controls.Add(this.mplWaresInfCapt);
            this.mainPanel.Controls.Add(this.mplBarCode);
            this.mainPanel.Controls.Add(this.mplBarCodeCapt);
            this.mainPanel.Controls.Add(this.mplArticleCapt);
            this.mainPanel.Controls.Add(this.mplLine1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(236, 293);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 269);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(236, 24);
            this.statusBar.Text = "statusBar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 26);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            // 
            // mplLine4
            // 
            this.mplLine4.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplLine4.Location = new System.Drawing.Point(235, 34);
            this.mplLine4.Name = "mplLine4";
            this.mplLine4.Size = new System.Drawing.Size(1, 125);
            // 
            // mplLine3
            // 
            this.mplLine3.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplLine3.Location = new System.Drawing.Point(1, 34);
            this.mplLine3.Name = "mplLine3";
            this.mplLine3.Size = new System.Drawing.Size(1, 124);
            // 
            // mplLine2
            // 
            this.mplLine2.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplLine2.Location = new System.Drawing.Point(1, 158);
            this.mplLine2.Name = "mplLine2";
            this.mplLine2.Size = new System.Drawing.Size(234, 1);
            // 
            // mplInfo
            // 
            this.mplInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.mplInfo.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.mplInfo.ForeColor = System.Drawing.Color.Blue;
            this.mplInfo.Location = new System.Drawing.Point(3, 162);
            this.mplInfo.Name = "mplInfo";
            this.mplInfo.Size = new System.Drawing.Size(231, 26);
            this.mplInfo.Text = "Ціна не вірна";
            this.mplInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mplPriceOpt
            // 
            this.mplPriceOpt.BackColor = System.Drawing.Color.Gainsboro;
            this.mplPriceOpt.Location = new System.Drawing.Point(72, 135);
            this.mplPriceOpt.Name = "mplPriceOpt";
            this.mplPriceOpt.Size = new System.Drawing.Size(162, 20);
            // 
            // mplPriceOptCapt
            // 
            this.mplPriceOptCapt.Location = new System.Drawing.Point(3, 135);
            this.mplPriceOptCapt.Name = "mplPriceOptCapt";
            this.mplPriceOptCapt.Size = new System.Drawing.Size(69, 20);
            this.mplPriceOptCapt.Text = "Ціна опт.: ";
            this.mplPriceOptCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplPrice
            // 
            this.mplPrice.BackColor = System.Drawing.Color.Gainsboro;
            this.mplPrice.Location = new System.Drawing.Point(72, 113);
            this.mplPrice.Name = "mplPrice";
            this.mplPrice.Size = new System.Drawing.Size(162, 20);
            // 
            // mplPriceCapt
            // 
            this.mplPriceCapt.Location = new System.Drawing.Point(3, 113);
            this.mplPriceCapt.Name = "mplPriceCapt";
            this.mplPriceCapt.Size = new System.Drawing.Size(69, 20);
            this.mplPriceCapt.Text = "Ціна: ";
            this.mplPriceCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplNameCapt
            // 
            this.mplNameCapt.Location = new System.Drawing.Point(3, 67);
            this.mplNameCapt.Name = "mplNameCapt";
            this.mplNameCapt.Size = new System.Drawing.Size(69, 20);
            this.mplNameCapt.Text = "Назва: ";
            this.mplNameCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplName
            // 
            this.mplName.BackColor = System.Drawing.Color.Gainsboro;
            this.mplName.Location = new System.Drawing.Point(4, 67);
            this.mplName.Name = "mplName";
            this.mplName.Size = new System.Drawing.Size(230, 44);
            // 
            // mplArticle
            // 
            this.mplArticle.BackColor = System.Drawing.Color.Gainsboro;
            this.mplArticle.Location = new System.Drawing.Point(72, 45);
            this.mplArticle.Name = "mplArticle";
            this.mplArticle.Size = new System.Drawing.Size(162, 20);
            // 
            // mplWaresInfCapt
            // 
            this.mplWaresInfCapt.Location = new System.Drawing.Point(7, 25);
            this.mplWaresInfCapt.Name = "mplWaresInfCapt";
            this.mplWaresInfCapt.Size = new System.Drawing.Size(142, 20);
            this.mplWaresInfCapt.Text = "Інформація про товар:";
            // 
            // mplBarCode
            // 
            this.mplBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mplBarCode.BackColor = System.Drawing.Color.Gainsboro;
            this.mplBarCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.mplBarCode.Location = new System.Drawing.Point(73, 2);
            this.mplBarCode.Name = "mplBarCode";
            this.mplBarCode.Size = new System.Drawing.Size(162, 20);
            this.mplBarCode.Text = "8032625972082_123456789";
            // 
            // mplBarCodeCapt
            // 
            this.mplBarCodeCapt.Location = new System.Drawing.Point(1, 3);
            this.mplBarCodeCapt.Name = "mplBarCodeCapt";
            this.mplBarCodeCapt.Size = new System.Drawing.Size(69, 20);
            this.mplBarCodeCapt.Text = "Штрих-код:";
            // 
            // mplArticleCapt
            // 
            this.mplArticleCapt.Location = new System.Drawing.Point(3, 45);
            this.mplArticleCapt.Name = "mplArticleCapt";
            this.mplArticleCapt.Size = new System.Drawing.Size(69, 20);
            this.mplArticleCapt.Text = "Артикул: ";
            this.mplArticleCapt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mplLine1
            // 
            this.mplLine1.BackColor = System.Drawing.SystemColors.WindowText;
            this.mplLine1.Location = new System.Drawing.Point(1, 34);
            this.mplLine1.Name = "mplLine1";
            this.mplLine1.Size = new System.Drawing.Size(234, 1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(101, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 26);
            this.button2.TabIndex = 33;
            this.button2.Text = "button2";
            // 
            // frmPriceChecker
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
            this.Name = "frmPriceChecker";
            this.Text = "BRB3";
            this.Load += new System.EventHandler(this.DocSearch_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DocSerch_KeyUp);
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
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuItem mAbout;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.Label mplBarCodeCapt;
        private System.Windows.Forms.Label mplBarCode;
        private System.Windows.Forms.Label mplWaresInfCapt;
        private System.Windows.Forms.Label mplArticleCapt;
        private System.Windows.Forms.Label mplArticle;
        private System.Windows.Forms.Label mplNameCapt;
        private System.Windows.Forms.Label mplName;
        private System.Windows.Forms.Label mplPriceCapt;
        private System.Windows.Forms.Label mplPrice;
        private System.Windows.Forms.Label mplPriceOpt;
        private System.Windows.Forms.Label mplPriceOptCapt;
        private System.Windows.Forms.Label mplInfo;
        private System.Windows.Forms.Label mplLine2;
        private System.Windows.Forms.Label mplLine1;
        private System.Windows.Forms.Label mplLine3;
        private System.Windows.Forms.Label mplLine4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.Button button2;


    }
}