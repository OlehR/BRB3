namespace BRB.Forms
{
    partial class frmWaresGrid
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
        //Після дизайнера AdvancedList виправити на --> resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocGrid));
        {
            Resco.Controls.AdvancedList.RowTemplate rowTemplate4 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell22 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell23 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell24 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell25 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate5 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell26 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell27 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell28 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell29 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate6 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell30 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell31 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell32 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell33 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell34 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell35 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell36 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell37 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell38 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell39 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell40 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell41 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell42 = new Resco.Controls.AdvancedList.TextCell();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.miMovements = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.miSeparator = new System.Windows.Forms.MenuItem();
            this.miEdit = new System.Windows.Forms.MenuItem();
            this.miScan = new System.Windows.Forms.MenuItem();
            this.miSeparator1 = new System.Windows.Forms.MenuItem();
            this.miFilter = new System.Windows.Forms.MenuItem();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRigth = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.advancedList = new Resco.Controls.AdvancedList.AdvancedList();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.miMovements);
            // 
            // miMovements
            // 
            this.miMovements.MenuItems.Add(this.miExit);
            this.miMovements.MenuItems.Add(this.miSeparator);
            this.miMovements.MenuItems.Add(this.miEdit);
            this.miMovements.MenuItems.Add(this.miScan);
            this.miMovements.MenuItems.Add(this.miSeparator1);
            this.miMovements.MenuItems.Add(this.miFilter);
            this.miMovements.Text = "Додатково";
            // 
            // miExit
            // 
            this.miExit.Text = "Вихід";
            this.miExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // miSeparator
            // 
            this.miSeparator.Text = "-";
            // 
            // miEdit
            // 
            this.miEdit.Text = "Редагувати";
            this.miEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // miScan
            // 
            this.miScan.Text = "Сканувати";
            this.miScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // miSeparator1
            // 
            this.miSeparator1.Text = "-";
            // 
            // miFilter
            // 
            this.miFilter.Text = "Пошук по...";
            this.miFilter.Click += new System.EventHandler(this.btnFilter_Click);
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
            // advancedList
            // 
            this.advancedList.BackColor = System.Drawing.SystemColors.Window;
            this.advancedList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.advancedList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedList.Location = new System.Drawing.Point(1, 1);
            this.advancedList.Name = "advancedList";
            this.advancedList.SelectedTemplateIndex = 2;
            this.advancedList.ShowFooter = true;
            this.advancedList.ShowHeader = true;
            this.advancedList.Size = new System.Drawing.Size(236, 293);
            this.advancedList.TabIndex = 12;
            this.advancedList.TemplateIndex = 1;
            rowTemplate4.BackColor = System.Drawing.SystemColors.ControlDark;
            textCell22.CellSource.ConstantData = "№";
            textCell22.Location = new System.Drawing.Point(0, 0);
            textCell22.Name = "c1_1";
            textCell22.Size = new System.Drawing.Size(20, 16);
            textCell22.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell23.CellSource.ConstantData = "Товар";
            textCell23.Location = new System.Drawing.Point(20, 0);
            textCell23.Name = "c1_2";
            textCell23.Size = new System.Drawing.Size(120, 16);
            textCell23.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell24.CellSource.ConstantData = "Кіл-ть";
            textCell24.Location = new System.Drawing.Point(140, 0);
            textCell24.Name = "c1_3";
            textCell24.Size = new System.Drawing.Size(50, 16);
            textCell24.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell25.CellSource.ConstantData = "Ціна";
            textCell25.Location = new System.Drawing.Point(190, 0);
            textCell25.Name = "c1_4";
            textCell25.Size = new System.Drawing.Size(-1, 16);
            textCell25.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            rowTemplate4.CellTemplates.Add(textCell22);
            rowTemplate4.CellTemplates.Add(textCell23);
            rowTemplate4.CellTemplates.Add(textCell24);
            rowTemplate4.CellTemplates.Add(textCell25);
            rowTemplate4.Name = "rtCaption";
            rowTemplate5.BackColor = System.Drawing.SystemColors.Window;
            textCell26.CellSource.ColumnName = "num_pop";
            textCell26.Location = new System.Drawing.Point(0, 0);
            textCell26.Name = "r1_1";
            textCell26.Size = new System.Drawing.Size(20, 16);
            textCell27.CellSource.ColumnName = "name_wares";
            textCell27.Location = new System.Drawing.Point(20, 0);
            textCell27.Name = "r1_2";
            textCell27.Size = new System.Drawing.Size(120, 16);
            textCell28.CellSource.ColumnName = "quantity";
            textCell28.FormatString = "{0:0.000}";
            textCell28.Location = new System.Drawing.Point(140, 0);
            textCell28.Name = "r1_3";
            textCell28.Size = new System.Drawing.Size(50, 16);
            textCell29.CellSource.ColumnName = "price";
            textCell29.FormatString = "{0:0.000}";
            textCell29.Location = new System.Drawing.Point(190, 0);
            textCell29.Name = "r1_4";
            textCell29.Size = new System.Drawing.Size(-1, 16);
            rowTemplate5.CellTemplates.Add(textCell26);
            rowTemplate5.CellTemplates.Add(textCell27);
            rowTemplate5.CellTemplates.Add(textCell28);
            rowTemplate5.CellTemplates.Add(textCell29);
            rowTemplate5.Name = "rtRow";
            rowTemplate6.BackColor = System.Drawing.SystemColors.Highlight;
            textCell30.CellSource.ColumnName = "num_pop";
            textCell30.Location = new System.Drawing.Point(0, 0);
            textCell30.Name = "rs1_1";
            textCell30.Size = new System.Drawing.Size(20, 16);
            textCell31.CellSource.ColumnName = "name_wares";
            textCell31.Location = new System.Drawing.Point(20, 0);
            textCell31.Name = "rs1_2";
            textCell31.Size = new System.Drawing.Size(-1, 16);
            textCell32.CellSource.ColumnName = "quantity";
            textCell32.FormatString = "{0:0.000}";
            textCell32.Location = new System.Drawing.Point(140, 16);
            textCell32.Name = "rs2_1";
            textCell32.Size = new System.Drawing.Size(50, 16);
            textCell33.CellSource.ColumnName = "price";
            textCell33.FormatString = "{0:0.000}";
            textCell33.Location = new System.Drawing.Point(190, 16);
            textCell33.Name = "rs2_2";
            textCell33.Size = new System.Drawing.Size(-1, 16);
            textCell34.CellSource.ConstantData = "Розх:";
            textCell34.Location = new System.Drawing.Point(0, 32);
            textCell34.Name = "rs3_1";
            textCell34.Size = new System.Drawing.Size(40, 16);
            textCell35.CellSource.ColumnName = "Diff";
            textCell35.FormatString = "{0:0.00}";
            textCell35.Location = new System.Drawing.Point(40, 32);
            textCell35.Name = "rs3_2";
            textCell35.Size = new System.Drawing.Size(50, 16);
            textCell36.CellSource.ConstantData = "Уп:";
            textCell36.Location = new System.Drawing.Point(100, 32);
            textCell36.Name = "rs3_3";
            textCell36.Size = new System.Drawing.Size(25, 16);
            textCell37.CellSource.ColumnName = "abr_unit";
            textCell37.Location = new System.Drawing.Point(125, 32);
            textCell37.Name = "rs3_4";
            textCell37.Size = new System.Drawing.Size(45, 16);
            textCell38.CellSource.ConstantData = "В уп:";
            textCell38.Location = new System.Drawing.Point(170, 32);
            textCell38.Name = "rs3_5";
            textCell38.Size = new System.Drawing.Size(30, 16);
            textCell39.CellSource.ColumnName = "coefficient";
            textCell39.FormatString = "{0:0.000}";
            textCell39.Location = new System.Drawing.Point(200, 32);
            textCell39.Name = "rs3_6";
            textCell39.Size = new System.Drawing.Size(-1, 16);
            textCell40.CellSource.ConstantData = "К-ть і ціна із ЗНП:";
            textCell40.Location = new System.Drawing.Point(0, 48);
            textCell40.Name = "rs4_1";
            textCell40.Size = new System.Drawing.Size(140, 16);
            textCell41.CellSource.ColumnName = "quantity_temp";
            textCell41.FormatString = "{0:0.000}";
            textCell41.Location = new System.Drawing.Point(140, 48);
            textCell41.Name = "rs4_2";
            textCell41.Size = new System.Drawing.Size(50, 16);
            textCell42.CellSource.ColumnName = "price_temp";
            textCell42.FormatString = "{0:0.000}";
            textCell42.Location = new System.Drawing.Point(190, 48);
            textCell42.Name = "rs4_3";
            textCell42.Size = new System.Drawing.Size(-1, 16);
            rowTemplate6.CellTemplates.Add(textCell30);
            rowTemplate6.CellTemplates.Add(textCell31);
            rowTemplate6.CellTemplates.Add(textCell32);
            rowTemplate6.CellTemplates.Add(textCell33);
            rowTemplate6.CellTemplates.Add(textCell34);
            rowTemplate6.CellTemplates.Add(textCell35);
            rowTemplate6.CellTemplates.Add(textCell36);
            rowTemplate6.CellTemplates.Add(textCell37);
            rowTemplate6.CellTemplates.Add(textCell38);
            rowTemplate6.CellTemplates.Add(textCell39);
            rowTemplate6.CellTemplates.Add(textCell40);
            rowTemplate6.CellTemplates.Add(textCell41);
            rowTemplate6.CellTemplates.Add(textCell42);
            rowTemplate6.Height = 64;
            rowTemplate6.Name = "rtRowSelected";
            this.advancedList.Templates.Add(rowTemplate4);
            this.advancedList.Templates.Add(rowTemplate5);
            this.advancedList.Templates.Add(rowTemplate6);
            this.advancedList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.advancedList_KeyUp);
            // 
            // frmWaresGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.advancedList);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.labelDown);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.labelRigth);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "frmWaresGrid";
            this.Text = "BRB3";
            this.Load += new System.EventHandler(this.frmWaresGrid_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label labelRigth;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelDown;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem miMovements;
        private Resco.Controls.AdvancedList.AdvancedList advancedList;
        System.ComponentModel.ComponentResourceManager resources;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.MenuItem miSeparator;
        private System.Windows.Forms.MenuItem miSeparator1;
        private System.Windows.Forms.MenuItem miEdit;
        private System.Windows.Forms.MenuItem miScan;
        private System.Windows.Forms.MenuItem miFilter;

    }
}