namespace BRB.Forms
{
    partial class frmWaresSearch
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
            this.mplCodeWares = new System.Windows.Forms.Label();
            this.mplNameWares = new System.Windows.Forms.Label();
            this.mptbCodeWares = new System.Windows.Forms.TextBox();
            this.mptbNameWares = new System.Windows.Forms.TextBox();
            this.mpbCancel = new System.Windows.Forms.Button();
            this.mpbCancelFilter = new System.Windows.Forms.Button();
            this.mpbSelect = new System.Windows.Forms.Button();
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
            this.mainPanel.Controls.Add(this.mplCodeWares);
            this.mainPanel.Controls.Add(this.mplNameWares);
            this.mainPanel.Controls.Add(this.mptbCodeWares);
            this.mainPanel.Controls.Add(this.mptbNameWares);
            this.mainPanel.Controls.Add(this.mpbCancel);
            this.mainPanel.Controls.Add(this.mpbCancelFilter);
            this.mainPanel.Controls.Add(this.mpbSelect);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(236, 293);
            // 
            // mplCodeWares
            // 
            this.mplCodeWares.Location = new System.Drawing.Point(5, 7);
            this.mplCodeWares.Name = "mplCodeWares";
            this.mplCodeWares.Size = new System.Drawing.Size(65, 20);
            this.mplCodeWares.Text = "Артикул";
            // 
            // mplNameWares
            // 
            this.mplNameWares.Location = new System.Drawing.Point(5, 33);
            this.mplNameWares.Name = "mplNameWares";
            this.mplNameWares.Size = new System.Drawing.Size(65, 20);
            this.mplNameWares.Text = "Назва";
            // 
            // mptbCodeWares
            // 
            this.mptbCodeWares.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mptbCodeWares.Location = new System.Drawing.Point(73, 5);
            this.mptbCodeWares.Name = "mptbCodeWares";
            this.mptbCodeWares.Size = new System.Drawing.Size(155, 23);
            this.mptbCodeWares.TabIndex = 1;
            // 
            // mptbNameWares
            // 
            this.mptbNameWares.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mptbNameWares.Location = new System.Drawing.Point(73, 31);
            this.mptbNameWares.Name = "mptbNameWares";
            this.mptbNameWares.Size = new System.Drawing.Size(155, 23);
            this.mptbNameWares.TabIndex = 2;
            // 
            // mpbCancel
            // 
            this.mpbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mpbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mpbCancel.Location = new System.Drawing.Point(120, 65);
            this.mpbCancel.Name = "mpbCancel";
            this.mpbCancel.Size = new System.Drawing.Size(110, 40);
            this.mpbCancel.TabIndex = 4;
            this.mpbCancel.Text = "Відміна";
            this.mpbCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mpbCancelFilter
            // 
            this.mpbCancelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mpbCancelFilter.Location = new System.Drawing.Point(5, 113);
            this.mpbCancelFilter.Name = "mpbCancelFilter";
            this.mpbCancelFilter.Size = new System.Drawing.Size(225, 25);
            this.mpbCancelFilter.TabIndex = 5;
            this.mpbCancelFilter.Text = "Скасувати фільтр";
            this.mpbCancelFilter.Click += new System.EventHandler(this.btnCancelFilter_Click);
            // 
            // mpbSelect
            // 
            this.mpbSelect.Location = new System.Drawing.Point(5, 65);
            this.mpbSelect.Name = "mpbSelect";
            this.mpbSelect.Size = new System.Drawing.Size(110, 40);
            this.mpbSelect.TabIndex = 3;
            this.mpbSelect.Text = "Шукати";
            this.mpbSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmWaresSearch
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
            this.Name = "frmWaresSearch";
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
        private System.Windows.Forms.Label mplCodeWares;
        private System.Windows.Forms.TextBox mptbCodeWares;
        private System.Windows.Forms.Label mplNameWares;
        private System.Windows.Forms.TextBox mptbNameWares;
        private System.Windows.Forms.Button mpbSelect;
        private System.Windows.Forms.Button mpbCancel;
        private System.Windows.Forms.Button mpbCancelFilter;
        private System.Windows.Forms.MenuItem mAbout;
        private System.Windows.Forms.MenuItem miExit;


    }
}