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
            resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaresGrid));
            Resco.Controls.AdvancedList.RowTemplate rowTemplate1 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell1 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell2 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell3 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell4 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate2 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell5 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell6 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell7 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell8 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate3 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell9 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell10 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell11 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell12 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell13 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell14 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell15 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell16 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell17 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell18 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell19 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell20 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell21 = new Resco.Controls.AdvancedList.TextCell();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.miMovements = new System.Windows.Forms.MenuItem();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRigth = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.advancedList = new Resco.Controls.AdvancedList.AdvancedList();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.miSeparator = new System.Windows.Forms.MenuItem();
            this.miSeparator1 = new System.Windows.Forms.MenuItem();
            this.miEdit = new System.Windows.Forms.MenuItem();
            this.miScan = new System.Windows.Forms.MenuItem();
            this.miFilter = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.miMovements);
            // 
            // miMovements
            // 
            this.miMovements.Text = "Додатково";
            this.miMovements.MenuItems.Add(this.miExit);
            this.miExit.Text = "Вихід";
            this.miMovements.MenuItems.Add(this.miSeparator);
            this.miSeparator.Text = "-";
            this.miMovements.MenuItems.Add(this.miEdit);
            this.miEdit.Text = "Редагувати";
            this.miMovements.MenuItems.Add(this.miScan);
            this.miScan.Text = "Сканувати";
            this.miMovements.MenuItems.Add(this.miSeparator1);
            this.miSeparator1.Text = "-";
            this.miMovements.MenuItems.Add(this.miFilter);
            this.miFilter.Text = "Пошук по...";
            //
            this.miExit.Click += new System.EventHandler(this.btnExit_Click);
            this.miEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.miScan.Click += new System.EventHandler(this.btnScan_Click);
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
            this.advancedList.FooterRow = new Resco.Controls.AdvancedList.HeaderRow(0, new string[] {
            resources.GetString("advancedList.FooterRow")});
            this.advancedList.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(0, new string[] {
            resources.GetString("advancedList.HeaderRow")});
            this.advancedList.Location = new System.Drawing.Point(1, 1);
            this.advancedList.Name = "advancedList";
            this.advancedList.SelectedTemplateIndex = 2;
            this.advancedList.ShowFooter = true;
            this.advancedList.ShowHeader = true;
            this.advancedList.Size = new System.Drawing.Size(236, 293);
            this.advancedList.TabIndex = 12;
            this.advancedList.TemplateIndex = 1;
            rowTemplate1.BackColor = System.Drawing.SystemColors.ControlDark;
            textCell1.CellSource.ConstantData = "№";
            textCell1.Location = new System.Drawing.Point(0, 0);
            textCell1.Name = "c1_1";
            textCell1.Size = new System.Drawing.Size(20, 16);
            textCell1.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell2.CellSource.ConstantData = "Товар";
            textCell2.Location = new System.Drawing.Point(20, 0);
            textCell2.Name = "c1_2";
            textCell2.Size = new System.Drawing.Size(120, 16);
            textCell2.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell3.CellSource.ConstantData = "Кіл-ть";
            textCell3.Location = new System.Drawing.Point(140, 0);
            textCell3.Name = "c1_3";
            textCell3.Size = new System.Drawing.Size(50, 16);
            textCell3.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell4.CellSource.ConstantData = "Ціна";
            textCell4.Location = new System.Drawing.Point(190, 0);
            textCell4.Name = "c1_4";
            textCell4.Size = new System.Drawing.Size(-1, 16);
            textCell4.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            rowTemplate1.CellTemplates.Add(textCell1);
            rowTemplate1.CellTemplates.Add(textCell2);
            rowTemplate1.CellTemplates.Add(textCell3);
            rowTemplate1.CellTemplates.Add(textCell4);
            rowTemplate1.Name = "rtCaption";
            rowTemplate2.BackColor = System.Drawing.SystemColors.Window;
            textCell5.CellSource.ColumnName = "num_pop";
            textCell5.Location = new System.Drawing.Point(0, 0);
            textCell5.Name = "r1_1";
            textCell5.Size = new System.Drawing.Size(20, 16);
            textCell6.CellSource.ColumnName = "name_wares";
            textCell6.Location = new System.Drawing.Point(20, 0);
            textCell6.Name = "r1_2";
            textCell6.Size = new System.Drawing.Size(120, 16);
            textCell7.CellSource.ColumnName = "quantity";
            textCell7.FormatString = "{0:0.000}";
            textCell7.Location = new System.Drawing.Point(140, 0);
            textCell7.Name = "r1_3";
            textCell7.Size = new System.Drawing.Size(50, 16);
            textCell8.CellSource.ColumnName = "price";
            textCell8.FormatString = "{0:0.000}";
            textCell8.Location = new System.Drawing.Point(190, 0);
            textCell8.Name = "r1_4";
            textCell8.Size = new System.Drawing.Size(-1, 16);
            rowTemplate2.CellTemplates.Add(textCell5);
            rowTemplate2.CellTemplates.Add(textCell6);
            rowTemplate2.CellTemplates.Add(textCell7);
            rowTemplate2.CellTemplates.Add(textCell8);
            rowTemplate2.Name = "rtRow";
            rowTemplate3.BackColor = System.Drawing.SystemColors.Highlight;
            textCell9.CellSource.ColumnName = "num_pop";
            textCell9.Location = new System.Drawing.Point(0, 0);
            textCell9.Name = "rs1_1";
            textCell9.Size = new System.Drawing.Size(20, 16);
            textCell10.CellSource.ColumnName = "name_wares";
            textCell10.Location = new System.Drawing.Point(20, 0);
            textCell10.Name = "rs1_2";
            textCell10.Size = new System.Drawing.Size(-1, 16);
            textCell11.CellSource.ColumnName = "quantity";
            textCell11.FormatString = "{0:0.000}";
            textCell11.Location = new System.Drawing.Point(140, 16);
            textCell11.Name = "rs2_1";
            textCell11.Size = new System.Drawing.Size(50, 16);
            textCell12.CellSource.ColumnName = "price";
            textCell12.FormatString = "{0:0.000}";
            textCell12.Location = new System.Drawing.Point(190, 16);
            textCell12.Name = "rs2_2";
            textCell12.Size = new System.Drawing.Size(-1, 16);
            textCell13.CellSource.ConstantData = "Розх:";
            textCell13.Location = new System.Drawing.Point(0, 32);
            textCell13.Name = "rs3_1";
            textCell13.Size = new System.Drawing.Size(40, 16);
            textCell14.CellSource.ColumnName = "Diff";
            textCell14.FormatString = "{0:0.00}";
            textCell14.Location = new System.Drawing.Point(40, 32);
            textCell14.Name = "rs3_2";
            textCell14.Size = new System.Drawing.Size(50, 16);
            textCell15.CellSource.ConstantData = "Уп:";
            textCell15.Location = new System.Drawing.Point(100, 32);
            textCell15.Name = "rs3_3";
            textCell15.Size = new System.Drawing.Size(25, 16);
            textCell16.CellSource.ColumnName = "abr_unit";
            textCell16.Location = new System.Drawing.Point(125, 32);
            textCell16.Name = "rs3_4";
            textCell16.Size = new System.Drawing.Size(45, 16);
            textCell17.CellSource.ConstantData = "В уп:";
            textCell17.Location = new System.Drawing.Point(170, 32);
            textCell17.Name = "rs3_5";
            textCell17.Size = new System.Drawing.Size(30, 16);
            textCell18.CellSource.ColumnName = "coefficient";
            textCell18.FormatString = "{0:0.000}";
            textCell18.Location = new System.Drawing.Point(200, 32);
            textCell18.Name = "rs3_6";
            textCell18.Size = new System.Drawing.Size(-1, 16);
            textCell19.CellSource.ConstantData = "К-ть і ціна із ЗНП:";
            textCell19.Location = new System.Drawing.Point(0, 48);
            textCell19.Name = "rs4_1";
            textCell19.Size = new System.Drawing.Size(140, 16);
            textCell20.CellSource.ColumnName = "quantity_temp";
            textCell20.FormatString = "{0:0.000}";
            textCell20.Location = new System.Drawing.Point(140, 48);
            textCell20.Name = "rs4_2";
            textCell20.Size = new System.Drawing.Size(50, 16);
            textCell21.CellSource.ColumnName = "price_temp";
            textCell21.FormatString = "{0:0.000}";
            textCell21.Location = new System.Drawing.Point(190, 48);
            textCell21.Name = "rs4_3";
            textCell21.Size = new System.Drawing.Size(-1, 16);
            rowTemplate3.CellTemplates.Add(textCell9);
            rowTemplate3.CellTemplates.Add(textCell10);
            rowTemplate3.CellTemplates.Add(textCell11);
            rowTemplate3.CellTemplates.Add(textCell12);
            rowTemplate3.CellTemplates.Add(textCell13);
            rowTemplate3.CellTemplates.Add(textCell14);
            rowTemplate3.CellTemplates.Add(textCell15);
            rowTemplate3.CellTemplates.Add(textCell16);
            rowTemplate3.CellTemplates.Add(textCell17);
            rowTemplate3.CellTemplates.Add(textCell18);
            rowTemplate3.CellTemplates.Add(textCell19);
            rowTemplate3.CellTemplates.Add(textCell20);
            rowTemplate3.CellTemplates.Add(textCell21);
            rowTemplate3.Height = 64;
            rowTemplate3.Name = "rtRowSelected";
            this.advancedList.Templates.Add(rowTemplate1);
            this.advancedList.Templates.Add(rowTemplate2);
            this.advancedList.Templates.Add(rowTemplate3);
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