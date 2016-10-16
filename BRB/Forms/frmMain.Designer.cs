namespace BRB.Forms
{
    partial class frmMain
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
            System.Windows.Forms.ListViewItem lviInvoice = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem lviMAudit = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem lviPriceChecker = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem lviAudit = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem lviComponents = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem lviSettings = new System.Windows.Forms.ListViewItem();
            System.ComponentModel.ComponentResourceManager res = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList();
            this.columnHeader = new System.Windows.Forms.ColumnHeader();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.miMovements = new System.Windows.Forms.MenuItem();
            this.miInvoice = new System.Windows.Forms.MenuItem();
            this.miMAudit = new System.Windows.Forms.MenuItem();
            this.miPriceChecker = new System.Windows.Forms.MenuItem();
            this.miAudit = new System.Windows.Forms.MenuItem();
            this.miComponents = new System.Windows.Forms.MenuItem();
            this.miSettings = new System.Windows.Forms.MenuItem();
            this.miSeparator = new System.Windows.Forms.MenuItem();
            this.miSeparator1 = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.mAbout = new System.Windows.Forms.MenuItem();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRigth = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(Global.icoSize, Global.icoSize);
            this.imageList.Images.Clear();
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_00_" + Global.icoSize.ToString())));
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_01_" + Global.icoSize.ToString())));
            
            // 
            // listView
            // 
            this.listView.Columns.Add(this.columnHeader);
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lviInvoice.Text = "Накладні";
            lviInvoice.ImageIndex = 1;
            this.listView.Items.Add(lviInvoice);
            lviMAudit.Text = "Міні-ревізії";
            this.listView.Items.Add(lviMAudit);
            lviPriceChecker.Text = "Контроль цінників";
            this.listView.Items.Add(lviPriceChecker);
            lviAudit.Text = "Інвентаризація";
            this.listView.Items.Add(lviAudit);
            lviComponents.Text = "Комплектація";
            this.listView.Items.Add(lviComponents);
            lviSettings.Text = "Системні налаштування";
            this.listView.Items.Add(lviSettings);
            this.listView.Location = new System.Drawing.Point(1, 1);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(236, 293);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 0;
            this.listView.Items[0].Focused = true;
            this.listView.Items[0].Selected = true;
            this.listView.View = System.Windows.Forms.View.Details;
            //
            // columnHeader
            // 
            this.columnHeader.Text = "ColumnHeader";
            this.columnHeader.Width = 233;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.miMovements);
            this.mainMenu.MenuItems.Add(this.mAbout);
            // miMovements
            this.miMovements.Text = "Додатково";
            this.miMovements.MenuItems.Add(this.miExit);
            this.miExit.Text = "Завершення роботи";
            this.miMovements.MenuItems.Add(this.miSeparator);
            this.miSeparator.Text = "-";
            this.miMovements.MenuItems.Add(this.miInvoice);
            this.miInvoice.Text = "Накладні";
            this.miMovements.MenuItems.Add(this.miMAudit);
            this.miMAudit.Text = "Міні-ревізії";
            this.miMovements.MenuItems.Add(this.miPriceChecker);
            this.miPriceChecker.Text = "Контроль цінників";
            this.miMovements.MenuItems.Add(this.miAudit);
            this.miAudit.Text = "Інвентарізація";
            this.miMovements.MenuItems.Add(this.miComponents);
            this.miComponents.Text = "Комплектація";
            this.miMovements.MenuItems.Add(this.miSeparator1);
            this.miSeparator1.Text = "-";
            this.miMovements.MenuItems.Add(this.miSettings);
            this.miSettings.Text = "Системні налагтування";
            // mAbout
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
            this.labelDown.Size = new System.Drawing.Size(236, (1 + Global.hToolbarTerminal));
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.labelDown);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.labelRigth);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "BRB++ " + Global.eTypeTerminal.ToString();
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
        private System.Windows.Forms.MenuItem miInvoice;
        private System.Windows.Forms.MenuItem miMAudit;
        private System.Windows.Forms.MenuItem miPriceChecker;
        private System.Windows.Forms.MenuItem miAudit;
        private System.Windows.Forms.MenuItem miComponents;
        private System.Windows.Forms.MenuItem miSettings;
        private System.Windows.Forms.MenuItem mAbout;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.MenuItem miSeparator;
        private System.Windows.Forms.MenuItem miSeparator1;
        private System.Windows.Forms.ImageList imageList;
    }
}