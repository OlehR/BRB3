namespace BRB.Forms
{
    partial class frmDocSearch
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
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRigth = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mplNumDoc = new System.Windows.Forms.Label();
            this.mplZKPO = new System.Windows.Forms.Label();
            this.mptbNumDoc = new System.Windows.Forms.TextBox();
            this.mptbZKPO = new System.Windows.Forms.TextBox();
            this.mpbSelect = new System.Windows.Forms.Button();
            this.mpbCancel = new System.Windows.Forms.Button();
            this.mpbCancelFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.miMovements);
            // 
            // miMovements
            // 
            this.miMovements.Text = "Додатково";
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
            // mplNumDoc
            // 
            this.mplNumDoc.Location = new System.Drawing.Point(5, 7);
            this.mplNumDoc.Name = "mplNumDoc";
            this.mplNumDoc.Size = new System.Drawing.Size(63, 20);
            this.mplNumDoc.Text = "№ Док:";
            // 
            // mplZKPO
            // 
            this.mplZKPO.Location = new System.Drawing.Point(5, 33);
            this.mplZKPO.Name = "mplZKPO";
            this.mplZKPO.Size = new System.Drawing.Size(63, 20);
            this.mplZKPO.Text = "ЗКПО:";
            // 
            // mptbNumDoc
            // 
            this.mptbNumDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mptbNumDoc.Location = new System.Drawing.Point(63, 5);
            this.mptbNumDoc.Name = "mptbNumDoc";
            this.mptbNumDoc.Size = new System.Drawing.Size(135, 23);
            this.mptbNumDoc.TabIndex = 7;
            // 
            // mptbZKPO
            // 
            this.mptbZKPO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mptbZKPO.Location = new System.Drawing.Point(63, 31);
            this.mptbZKPO.Name = "mptbZKPO";
            this.mptbZKPO.Size = new System.Drawing.Size(135, 23);
            this.mptbZKPO.TabIndex = 1;
            // 
            // mpbSelect
            // 
            this.mpbSelect.Location = new System.Drawing.Point(5, 63);
            this.mpbSelect.Name = "mpbSelect";
            this.mpbSelect.Size = new System.Drawing.Size(88, 20);
            this.mpbSelect.TabIndex = 2;
            this.mpbSelect.Text = "Шукати [F1]";
            //this.mpbSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // mpbCancel
            // 
            this.mpbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mpbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mpbCancel.Location = new System.Drawing.Point(99, 63);
            this.mpbCancel.Name = "mpbCancel";
            this.mpbCancel.Size = new System.Drawing.Size(102, 20);
            this.mpbCancel.TabIndex = 3;
            this.mpbCancel.Text = "Відміна [F4]";
            // 
            // mpbCancelFilter
            // 
            this.mpbCancelFilter.Location = new System.Drawing.Point(5, 93);
            this.mpbCancelFilter.Name = "mpbCancelFilter";
            this.mpbCancelFilter.Size = new System.Drawing.Size(180, 20);
            this.mpbCancelFilter.TabIndex = 3;
            this.mpbCancelFilter.Text = "Відміна Пошуку";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(1, 1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(236, 293);
            this.mainPanel.Controls.Add(mplNumDoc);
            this.mainPanel.Controls.Add(mplZKPO);
            this.mainPanel.Controls.Add(mptbNumDoc);
            this.mainPanel.Controls.Add(mptbZKPO);
            this.mainPanel.Controls.Add(mpbCancel);
            this.mainPanel.Controls.Add(mpbCancelFilter);
            this.mainPanel.Controls.Add(mpbSelect);
            // 
            // frmDocSearch
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
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "frmDocSearch";
            this.Text = "BRB3";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label labelRigth;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelDown;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem miMovements;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label mplNumDoc;
        private System.Windows.Forms.TextBox mptbNumDoc;
        private System.Windows.Forms.Label mplZKPO;
        private System.Windows.Forms.TextBox mptbZKPO;
        private System.Windows.Forms.Button mpbSelect;
        private System.Windows.Forms.Button mpbCancel;
        private System.Windows.Forms.Button mpbCancelFilter;
        

    }
}