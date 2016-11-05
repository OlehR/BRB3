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
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaresGrid));
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
            rowTemplate1.BackColor = System.Drawing.SystemColors.ControlDark;
            textCell1.CellSource.ConstantData = "№";
            textCell1.Location = new System.Drawing.Point(0, 0);
            textCell1.Name = "c1_1";
            textCell1.Size = new System.Drawing.Size(20, 30);
            textCell1.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell2.CellSource.ConstantData = "Товар";
            textCell2.Location = new System.Drawing.Point(20, 0);
            textCell2.Name = "c1_2";
            textCell2.Size = new System.Drawing.Size(120, 30);
            textCell2.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell3.CellSource.ConstantData = "Кіл-ть";
            textCell3.Location = new System.Drawing.Point(140, 0);
            textCell3.Name = "c1_3";
            textCell3.Size = new System.Drawing.Size(50, 30);
            textCell3.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            textCell4.CellSource.ConstantData = "Ціна";
            textCell4.Location = new System.Drawing.Point(190, 0);
            textCell4.Name = "c1_4";
            textCell4.Size = new System.Drawing.Size(-1, 30);
            textCell4.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            rowTemplate1.CellTemplates.Add(textCell1);
            rowTemplate1.CellTemplates.Add(textCell2);
            rowTemplate1.CellTemplates.Add(textCell3);
            rowTemplate1.CellTemplates.Add(textCell4);
            rowTemplate1.Height = 30;
            rowTemplate1.Name = "rtCaption";
            rowTemplate2.BackColor = System.Drawing.SystemColors.Window;
            textCell5.CellSource.ColumnName = "num_pop";
            textCell5.Location = new System.Drawing.Point(0, 0);
            textCell5.Name = "r1_1";
            textCell5.Size = new System.Drawing.Size(20, 30);
            textCell6.CellSource.ColumnName = "name_wares";
            textCell6.Location = new System.Drawing.Point(20, 0);
            textCell6.Name = "r1_2";
            textCell6.Size = new System.Drawing.Size(120, 30);
            textCell7.CellSource.ColumnName = "quantity";
            textCell7.FormatString = "{0:0.000}";
            textCell7.Location = new System.Drawing.Point(140, 0);
            textCell7.Name = "r1_3";
            textCell7.Size = new System.Drawing.Size(50, 30);
            textCell8.CellSource.ColumnName = "price";
            textCell8.FormatString = "{0:0.000}";
            textCell8.Location = new System.Drawing.Point(190, 0);
            textCell8.Name = "r1_4";
            textCell8.Size = new System.Drawing.Size(-1, 30);
            rowTemplate2.CellTemplates.Add(textCell5);
            rowTemplate2.CellTemplates.Add(textCell6);
            rowTemplate2.CellTemplates.Add(textCell7);
            rowTemplate2.CellTemplates.Add(textCell8);
            rowTemplate2.Height = 30;
            rowTemplate2.Name = "rtRow";
            this.advancedList.Templates.Add(rowTemplate1);
            this.advancedList.Templates.Add(rowTemplate2);
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