namespace BRB.Forms
{
    partial class frmDocGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocGrid));
            Resco.Controls.AdvancedList.RowTemplate rowTemplate5 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell18 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell19 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell20 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate6 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell21 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell22 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell23 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate7 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell24 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell25 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell26 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell27 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell28 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell29 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell30 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell31 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell32 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell33 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell34 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate8 = new Resco.Controls.AdvancedList.RowTemplate();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.miMovements = new System.Windows.Forms.MenuItem();
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
            rowTemplate5.BackColor = System.Drawing.SystemColors.ControlDark;
            textCell18.CellSource.ConstantData = "Стан";
            textCell18.Location = new System.Drawing.Point(0, 0);
            textCell18.Name = "c1_1";
            textCell18.Size = new System.Drawing.Size(40, 30);
            textCell18.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell19.CellSource.ConstantData = "Номер";
            textCell19.Location = new System.Drawing.Point(40, 0);
            textCell19.Name = "c1_2";
            textCell19.Size = new System.Drawing.Size(80, 30);
            textCell19.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell20.CellSource.ConstantData = "Постачальник";
            textCell20.Location = new System.Drawing.Point(120, 0);
            textCell20.Name = "c1_3";
            textCell20.Size = new System.Drawing.Size(-1, 30);
            textCell20.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            rowTemplate5.CellTemplates.Add(textCell18);
            rowTemplate5.CellTemplates.Add(textCell19);
            rowTemplate5.CellTemplates.Add(textCell20);
            rowTemplate5.Height = 30;
            rowTemplate5.Name = "rtCaption";
            rowTemplate6.BackColor = System.Drawing.SystemColors.Window;
            textCell21.CellSource.ColumnName = "StatusName";
            textCell21.Location = new System.Drawing.Point(0, 0);
            textCell21.Name = "r1_1";
            textCell21.Size = new System.Drawing.Size(20, 30);
            textCell22.Alignment = Resco.Controls.AdvancedList.Alignment.TopCenter;
            textCell22.CellSource.ColumnName = "number_doc";
            textCell22.Location = new System.Drawing.Point(20, 0);
            textCell22.Name = "r1_2";
            textCell22.Size = new System.Drawing.Size(70, 30);
            textCell23.CellSource.ColumnName = "name_supplier";
            textCell23.Location = new System.Drawing.Point(90, 0);
            textCell23.Name = "r1_3";
            textCell23.Size = new System.Drawing.Size(-1, 30);
            rowTemplate6.CellTemplates.Add(textCell21);
            rowTemplate6.CellTemplates.Add(textCell22);
            rowTemplate6.CellTemplates.Add(textCell23);
            rowTemplate6.Height = 30;
            rowTemplate6.Name = "rtRow";
            textCell24.CellSource.ColumnName = "StatusName";
            textCell24.Location = new System.Drawing.Point(0, 0);
            textCell24.Name = "rs1_1";
            textCell24.Size = new System.Drawing.Size(20, 30);
            textCell25.CellSource.ColumnName = "number_doc";
            textCell25.Location = new System.Drawing.Point(20, 0);
            textCell25.Name = "rs1_2";
            textCell25.Size = new System.Drawing.Size(70, 30);
            textCell26.CellSource.ColumnName = "name_supplier";
            textCell26.Location = new System.Drawing.Point(90, 0);
            textCell26.Name = "rs1_3";
            textCell26.Size = new System.Drawing.Size(-1, 30);
            textCell27.CellSource.ConstantData = "Сум. зам:";
            textCell27.Location = new System.Drawing.Point(0, 30);
            textCell27.Name = "rs2_1";
            textCell27.Size = new System.Drawing.Size(60, 30);
            textCell28.CellSource.ColumnName = "SummaZak";
            textCell28.FormatString = "{0:0.00}";
            textCell28.Location = new System.Drawing.Point(60, 30);
            textCell28.Name = "rs2_2";
            textCell28.Size = new System.Drawing.Size(60, 30);
            textCell29.CellSource.ConstantData = "К-ть тов:";
            textCell29.Location = new System.Drawing.Point(120, 30);
            textCell29.Name = "rs2_3";
            textCell29.Size = new System.Drawing.Size(60, 30);
            textCell30.CellSource.ColumnName = "SumWaresZam";
            textCell30.Location = new System.Drawing.Point(180, 30);
            textCell30.Name = "rs2_4";
            textCell30.Size = new System.Drawing.Size(60, 30);
            textCell31.CellSource.ConstantData = "Сум. прих:";
            textCell31.Location = new System.Drawing.Point(0, 60);
            textCell31.Name = "rs3_1";
            textCell31.Size = new System.Drawing.Size(60, 30);
            textCell32.CellSource.ColumnName = "SummaPrih";
            textCell32.FormatString = "{0:0.00}";
            textCell32.Location = new System.Drawing.Point(60, 60);
            textCell32.Name = "rs3_2";
            textCell32.Size = new System.Drawing.Size(60, 30);
            textCell33.CellSource.ConstantData = "Введено:";
            textCell33.Location = new System.Drawing.Point(120, 60);
            textCell33.Name = "rs3_3";
            textCell33.Size = new System.Drawing.Size(60, 30);
            textCell34.CellSource.ColumnName = "SumWaresInv";
            textCell34.Location = new System.Drawing.Point(180, 60);
            textCell34.Name = "rs3_4";
            textCell34.Size = new System.Drawing.Size(60, 30);
            rowTemplate7.CellTemplates.Add(textCell24);
            rowTemplate7.CellTemplates.Add(textCell25);
            rowTemplate7.CellTemplates.Add(textCell26);
            rowTemplate7.CellTemplates.Add(textCell27);
            rowTemplate7.CellTemplates.Add(textCell28);
            rowTemplate7.CellTemplates.Add(textCell29);
            rowTemplate7.CellTemplates.Add(textCell30);
            rowTemplate7.CellTemplates.Add(textCell31);
            rowTemplate7.CellTemplates.Add(textCell32);
            rowTemplate7.CellTemplates.Add(textCell33);
            rowTemplate7.CellTemplates.Add(textCell34);
            rowTemplate7.Height = 90;
            rowTemplate7.Name = "rtRowSelected";
            rowTemplate8.Name = "rtRowComm";
            this.advancedList.Templates.Add(rowTemplate5);
            this.advancedList.Templates.Add(rowTemplate6);
            this.advancedList.Templates.Add(rowTemplate7);
            this.advancedList.Templates.Add(rowTemplate8);
            // 
            // frmDocGrid
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
            this.Name = "frmDocGrid";
            this.Text = "BRB3";
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
      
    }
}