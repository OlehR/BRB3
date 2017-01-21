namespace BRB.Forms
{
    partial class frmAdvSettingsDoc
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
            this.mpbExit = new System.Windows.Forms.Button();
            this.mpbSave = new System.Windows.Forms.Button();
            this.mptbDateDoc = new System.Windows.Forms.TextBox();
            this.mptbNumberDoc = new System.Windows.Forms.TextBox();
            this.mplDateDoc = new System.Windows.Forms.Label();
            this.mplNumberDoc = new System.Windows.Forms.Label();
            this.mpcbInsMas = new System.Windows.Forms.CheckBox();
            this.mpcbSumQtyZNP = new System.Windows.Forms.CheckBox();
            this.mpcbChangeDocPost = new System.Windows.Forms.CheckBox();
            this.mpcbPriceWizVat = new System.Windows.Forms.CheckBox();
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
            this.mainPanel.Controls.Add(this.mpbExit);
            this.mainPanel.Controls.Add(this.mpbSave);
            this.mainPanel.Controls.Add(this.mptbDateDoc);
            this.mainPanel.Controls.Add(this.mptbNumberDoc);
            this.mainPanel.Controls.Add(this.mplDateDoc);
            this.mainPanel.Controls.Add(this.mplNumberDoc);
            this.mainPanel.Controls.Add(this.mpcbInsMas);
            this.mainPanel.Controls.Add(this.mpcbSumQtyZNP);
            this.mainPanel.Controls.Add(this.mpcbChangeDocPost);
            this.mainPanel.Controls.Add(this.mpcbPriceWizVat);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(236, 293);
            // 
            // mpbExit
            // 
            this.mpbExit.Location = new System.Drawing.Point(146, 195);
            this.mpbExit.Name = "mpbExit";
            this.mpbExit.Size = new System.Drawing.Size(85, 35);
            this.mpbExit.TabIndex = 8;
            this.mpbExit.Text = "Вийти";
            this.mpbExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // mpbSave
            // 
            this.mpbSave.Location = new System.Drawing.Point(5, 195);
            this.mpbSave.Name = "mpbSave";
            this.mpbSave.Size = new System.Drawing.Size(138, 35);
            this.mpbSave.TabIndex = 7;
            this.mpbSave.Text = "Зберегти";
            this.mpbSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mptbDateDoc
            // 
            this.mptbDateDoc.Location = new System.Drawing.Point(5, 60);
            this.mptbDateDoc.Name = "mptbDateDoc";
            this.mptbDateDoc.Size = new System.Drawing.Size(226, 23);
            this.mptbDateDoc.TabIndex = 2;
            // 
            // mptbNumberDoc
            // 
            this.mptbNumberDoc.Location = new System.Drawing.Point(5, 18);
            this.mptbNumberDoc.Name = "mptbNumberDoc";
            this.mptbNumberDoc.Size = new System.Drawing.Size(226, 23);
            this.mptbNumberDoc.TabIndex = 1;
            // 
            // mplDateDoc
            // 
            this.mplDateDoc.Location = new System.Drawing.Point(5, 44);
            this.mplDateDoc.Name = "mplDateDoc";
            this.mplDateDoc.Size = new System.Drawing.Size(226, 20);
            this.mplDateDoc.Text = "Дата розхідної накл. постач-ка";
            // 
            // mplNumberDoc
            // 
            this.mplNumberDoc.Location = new System.Drawing.Point(5, 3);
            this.mplNumberDoc.Name = "mplNumberDoc";
            this.mplNumberDoc.Size = new System.Drawing.Size(226, 20);
            this.mplNumberDoc.Text = "№ розхідної накл. постачальника";
            // 
            // mpcbInsMas
            // 
            this.mpcbInsMas.Location = new System.Drawing.Point(5, 165);
            this.mpcbInsMas.Name = "mpcbInsMas";
            this.mpcbInsMas.Size = new System.Drawing.Size(226, 20);
            this.mpcbInsMas.TabIndex = 6;
            this.mpcbInsMas.Text = "Вибирати масу з штрик-коду";
            // 
            // mpcbSumQtyZNP
            // 
            this.mpcbSumQtyZNP.Location = new System.Drawing.Point(5, 140);
            this.mpcbSumQtyZNP.Name = "mpcbSumQtyZNP";
            this.mpcbSumQtyZNP.Size = new System.Drawing.Size(226, 20);
            this.mpcbSumQtyZNP.TabIndex = 5;
            this.mpcbSumQtyZNP.Text = "Сумувати кіл-ть в ЗНП";
            // 
            // mpcbChangeDocPost
            // 
            this.mpcbChangeDocPost.Location = new System.Drawing.Point(5, 115);
            this.mpcbChangeDocPost.Name = "mpcbChangeDocPost";
            this.mpcbChangeDocPost.Size = new System.Drawing.Size(226, 20);
            this.mpcbChangeDocPost.TabIndex = 4;
            this.mpcbChangeDocPost.Text = "Потребує заміни док. постач-ка";
            // 
            // mpcbPriceWizVat
            // 
            this.mpcbPriceWizVat.Location = new System.Drawing.Point(5, 90);
            this.mpcbPriceWizVat.Name = "mpcbPriceWizVat";
            this.mpcbPriceWizVat.Size = new System.Drawing.Size(226, 20);
            this.mpcbPriceWizVat.TabIndex = 3;
            this.mpcbPriceWizVat.Text = "Ціни в накладній з ПДВ";
            // 
            // frmAdvSettingsDoc
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
            this.Name = "frmAdvSettingsDoc";
            this.Text = "BRB3";
            this.Load += new System.EventHandler(this.AdvSettingsDoc_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AdvSettingsDoc_KeyUp);
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
        private System.Windows.Forms.Label mplNumberDoc;
        private System.Windows.Forms.TextBox mptbNumberDoc;
        private System.Windows.Forms.Label mplDateDoc;
        private System.Windows.Forms.TextBox mptbDateDoc;
        private System.Windows.Forms.CheckBox mpcbPriceWizVat;
        private System.Windows.Forms.CheckBox mpcbChangeDocPost;
        private System.Windows.Forms.CheckBox mpcbSumQtyZNP;
        private System.Windows.Forms.CheckBox mpcbInsMas;
        private System.Windows.Forms.Button mpbSave;
        private System.Windows.Forms.Button mpbExit;


    }
}