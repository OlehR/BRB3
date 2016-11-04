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
            Resco.Controls.AdvancedList.RowTemplate rowTemplate1 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell1 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell2 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell3 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate2 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell4 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell5 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell6 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate3 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate4 = new Resco.Controls.AdvancedList.RowTemplate();
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
            this.advancedList.ActiveTemplateIndex = 0;
            this.advancedList.AlternateTemplateIndex = 1;
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
            textCell1.CellSource.ConstantData = "Стан";
            textCell1.Location = new System.Drawing.Point(0, 0);
            textCell1.Name = null;
            textCell1.Size = new System.Drawing.Size(40, 30);
            textCell2.CellSource.ConstantData = "Номер";
            textCell2.Location = new System.Drawing.Point(40, 0);
            textCell2.Name = null;
            textCell2.Size = new System.Drawing.Size(80, 30);
            textCell3.CellSource.ConstantData = "Постачальник";
            textCell3.Location = new System.Drawing.Point(120, 0);
            textCell3.Name = null;
            textCell3.Size = new System.Drawing.Size(-1, 30);
            rowTemplate1.CellTemplates.Add(textCell1);
            rowTemplate1.CellTemplates.Add(textCell2);
            rowTemplate1.CellTemplates.Add(textCell3);
            rowTemplate1.Height = 30;
            rowTemplate1.Name = "rtCaption";
            rowTemplate2.BackColor = System.Drawing.SystemColors.Window;
            textCell4.CellSource.ColumnName = "StatusName";
            textCell4.Location = new System.Drawing.Point(0, 0);
            textCell4.Name = null;
            textCell4.Size = new System.Drawing.Size(40, 30);
            textCell5.CellSource.ColumnName = "number_doc";
            textCell5.Location = new System.Drawing.Point(40, 0);
            textCell5.Name = null;
            textCell5.Size = new System.Drawing.Size(80, 30);
            textCell6.CellSource.ColumnName = "name_supplier";
            textCell6.Location = new System.Drawing.Point(120, 0);
            textCell6.Name = null;
            textCell6.Size = new System.Drawing.Size(-1, 30);
            rowTemplate2.CellTemplates.Add(textCell4);
            rowTemplate2.CellTemplates.Add(textCell5);
            rowTemplate2.CellTemplates.Add(textCell6);
            rowTemplate2.Height = 30;
            rowTemplate2.Name = "rtRow";
            rowTemplate3.Name = "rtRowSelected";
            rowTemplate4.Name = "rtRowComm";
            this.advancedList.Templates.Add(rowTemplate1);
            this.advancedList.Templates.Add(rowTemplate2);
            this.advancedList.Templates.Add(rowTemplate3);
            this.advancedList.Templates.Add(rowTemplate4);
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