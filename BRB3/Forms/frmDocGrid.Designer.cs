﻿namespace BRB.Forms
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
            //Після дизайнера AdvancedList виправити на --> resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocGrid));
        {
            resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocGrid));
            Resco.Controls.AdvancedList.RowTemplate rowTemplate1 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell1 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell2 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell3 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate2 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell4 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell5 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell6 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate3 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell7 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell8 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell9 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell10 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell11 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell12 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell13 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell14 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell15 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell16 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell17 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.RowTemplate rowTemplate4 = new Resco.Controls.AdvancedList.RowTemplate();
            Resco.Controls.AdvancedList.TextCell textCell18 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell19 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell20 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell21 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell22 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell23 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell24 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell25 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell26 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell27 = new Resco.Controls.AdvancedList.TextCell();
            Resco.Controls.AdvancedList.TextCell textCell28 = new Resco.Controls.AdvancedList.TextCell();
            this.advancedList = new Resco.Controls.AdvancedList.AdvancedList();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.miMovements = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.miSeparator = new System.Windows.Forms.MenuItem();
            this.miWares = new System.Windows.Forms.MenuItem();
            this.miMarkDoc = new System.Windows.Forms.MenuItem();
            this.miFiltr = new System.Windows.Forms.MenuItem();
            this.miWaresScan = new System.Windows.Forms.MenuItem();
            this.miExtraProperties = new System.Windows.Forms.MenuItem();
            this.miGroupingDoc = new System.Windows.Forms.MenuItem();
            this.miSeparator1 = new System.Windows.Forms.MenuItem();
            this.miSync = new System.Windows.Forms.MenuItem();
            this.mAbout = new System.Windows.Forms.MenuItem();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelRigth = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelDown = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SyncCapt = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            textCell1.CellSource.ConstantData = "Стан";
            textCell1.Location = new System.Drawing.Point(0, 0);
            textCell1.Name = "c1_1";
            textCell1.Size = new System.Drawing.Size(40, 16);
            textCell1.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            textCell2.CellSource.ConstantData = "Номер";
            textCell2.Location = new System.Drawing.Point(40, 0);
            textCell2.Name = "c1_2";
            textCell2.Size = new System.Drawing.Size(80, 16);
            textCell2.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            textCell3.CellSource.ConstantData = "Постачальник";
            textCell3.Location = new System.Drawing.Point(120, 0);
            textCell3.Name = "c1_3";
            textCell3.Size = new System.Drawing.Size(-1, 16);
            textCell3.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            rowTemplate1.CellTemplates.Add(textCell1);
            rowTemplate1.CellTemplates.Add(textCell2);
            rowTemplate1.CellTemplates.Add(textCell3);
            rowTemplate1.Name = "rtCaption";
            rowTemplate2.BackColor = System.Drawing.SystemColors.Window;
            textCell4.CellSource.ColumnName = "StatusName";
            textCell4.Location = new System.Drawing.Point(0, 0);
            textCell4.Name = "r1_1";
            textCell4.Size = new System.Drawing.Size(20, 16);
            textCell5.Alignment = Resco.Controls.AdvancedList.Alignment.TopCenter;
            textCell5.CellSource.ColumnName = "number_doc";
            textCell5.Location = new System.Drawing.Point(20, 0);
            textCell5.Name = "r1_2";
            textCell5.Size = new System.Drawing.Size(70, 16);
            textCell6.CellSource.ColumnName = "name_supplier";
            textCell6.Location = new System.Drawing.Point(90, 0);
            textCell6.Name = "r1_3";
            textCell6.Size = new System.Drawing.Size(-1, 16);
            rowTemplate2.CellTemplates.Add(textCell4);
            rowTemplate2.CellTemplates.Add(textCell5);
            rowTemplate2.CellTemplates.Add(textCell6);
            rowTemplate2.Name = "rtRow";
            rowTemplate3.BackColor = System.Drawing.SystemColors.Highlight;
            textCell7.CellSource.ColumnName = "StatusName";
            textCell7.Location = new System.Drawing.Point(0, 0);
            textCell7.Name = "rs1_1";
            textCell7.Size = new System.Drawing.Size(20, 16);
            textCell8.CellSource.ColumnName = "number_doc";
            textCell8.Location = new System.Drawing.Point(20, 0);
            textCell8.Name = "rs1_2";
            textCell8.Size = new System.Drawing.Size(70, 16);
            textCell9.CellSource.ColumnName = "name_supplier";
            textCell9.Location = new System.Drawing.Point(90, 0);
            textCell9.Name = "rs1_3";
            textCell9.Size = new System.Drawing.Size(-1, 16);
            textCell10.CellSource.ConstantData = "Сум. зам:";
            textCell10.Location = new System.Drawing.Point(0, 16);
            textCell10.Name = "rs2_1";
            textCell10.Size = new System.Drawing.Size(60, 16);
            textCell11.CellSource.ColumnName = "SummaZak";
            textCell11.FormatString = "{0:0.00}";
            textCell11.Location = new System.Drawing.Point(60, 16);
            textCell11.Name = "rs2_2";
            textCell11.Size = new System.Drawing.Size(60, 16);
            textCell12.CellSource.ConstantData = "К-ть тов:";
            textCell12.Location = new System.Drawing.Point(120, 16);
            textCell12.Name = "rs2_3";
            textCell12.Size = new System.Drawing.Size(60, 16);
            textCell13.CellSource.ColumnName = "SumWaresZam";
            textCell13.Location = new System.Drawing.Point(180, 16);
            textCell13.Name = "rs2_4";
            textCell13.Size = new System.Drawing.Size(60, 16);
            textCell14.CellSource.ConstantData = "Сум. прих:";
            textCell14.Location = new System.Drawing.Point(0, 32);
            textCell14.Name = "rs3_1";
            textCell14.Size = new System.Drawing.Size(60, 16);
            textCell15.CellSource.ColumnName = "SummaPrih";
            textCell15.FormatString = "{0:0.00}";
            textCell15.Location = new System.Drawing.Point(60, 32);
            textCell15.Name = "rs3_2";
            textCell15.Size = new System.Drawing.Size(60, 16);
            textCell16.CellSource.ConstantData = "Введено:";
            textCell16.Location = new System.Drawing.Point(120, 32);
            textCell16.Name = "rs3_3";
            textCell16.Size = new System.Drawing.Size(60, 16);
            textCell17.CellSource.ColumnName = "SumWaresInv";
            textCell17.Location = new System.Drawing.Point(180, 32);
            textCell17.Name = "rs3_4";
            textCell17.Size = new System.Drawing.Size(60, 16);
            rowTemplate3.CellTemplates.Add(textCell7);
            rowTemplate3.CellTemplates.Add(textCell8);
            rowTemplate3.CellTemplates.Add(textCell9);
            rowTemplate3.CellTemplates.Add(textCell10);
            rowTemplate3.CellTemplates.Add(textCell11);
            rowTemplate3.CellTemplates.Add(textCell12);
            rowTemplate3.CellTemplates.Add(textCell13);
            rowTemplate3.CellTemplates.Add(textCell14);
            rowTemplate3.CellTemplates.Add(textCell15);
            rowTemplate3.CellTemplates.Add(textCell16);
            rowTemplate3.CellTemplates.Add(textCell17);
            rowTemplate3.Height = 48;
            rowTemplate3.Name = "rtRowSelected";
            rowTemplate4.BackColor = System.Drawing.Color.YellowGreen;
            textCell18.CellSource.ColumnName = "StatusName";
            textCell18.Location = new System.Drawing.Point(0, 0);
            textCell18.Name = "rc1_1";
            textCell18.Size = new System.Drawing.Size(20, 16);
            textCell19.CellSource.ColumnName = "number_doc";
            textCell19.Location = new System.Drawing.Point(20, 0);
            textCell19.Name = "rc1_2";
            textCell19.Size = new System.Drawing.Size(70, 16);
            textCell20.CellSource.ColumnName = "name_supplier";
            textCell20.Location = new System.Drawing.Point(90, 0);
            textCell20.Name = "rc1_3";
            textCell20.Size = new System.Drawing.Size(-1, 16);
            textCell21.CellSource.ConstantData = "Сум. зам:";
            textCell21.Location = new System.Drawing.Point(0, 16);
            textCell21.Name = "rc2_1";
            textCell21.Size = new System.Drawing.Size(60, 16);
            textCell22.CellSource.ColumnName = "SummaZak";
            textCell22.FormatString = "{0:0.00}";
            textCell22.Location = new System.Drawing.Point(60, 16);
            textCell22.Name = "rc2_2";
            textCell22.Size = new System.Drawing.Size(60, 16);
            textCell23.CellSource.ConstantData = "К-ть тов:";
            textCell23.Location = new System.Drawing.Point(120, 16);
            textCell23.Name = "rc2_3";
            textCell23.Size = new System.Drawing.Size(60, 16);
            textCell24.CellSource.ColumnName = "SumWaresZam";
            textCell24.Location = new System.Drawing.Point(180, 16);
            textCell24.Name = "rc2_4";
            textCell24.Size = new System.Drawing.Size(60, 16);
            textCell25.CellSource.ConstantData = "Сум. прих:";
            textCell25.Location = new System.Drawing.Point(0, 32);
            textCell25.Name = "rc3_1";
            textCell25.Size = new System.Drawing.Size(60, 16);
            textCell26.CellSource.ColumnName = "SummaPrih";
            textCell26.FormatString = "{0:0.00}";
            textCell26.Location = new System.Drawing.Point(60, 32);
            textCell26.Name = "rc3_2";
            textCell26.Size = new System.Drawing.Size(60, 16);
            textCell27.CellSource.ConstantData = "Введено:";
            textCell27.Location = new System.Drawing.Point(120, 32);
            textCell27.Name = "rc3_3";
            textCell27.Size = new System.Drawing.Size(60, 16);
            textCell28.CellSource.ColumnName = "SumWaresInv";
            textCell28.Location = new System.Drawing.Point(180, 32);
            textCell28.Name = "rc3_4";
            textCell28.Size = new System.Drawing.Size(60, 16);
            rowTemplate4.CellTemplates.Add(textCell18);
            rowTemplate4.CellTemplates.Add(textCell19);
            rowTemplate4.CellTemplates.Add(textCell20);
            rowTemplate4.CellTemplates.Add(textCell21);
            rowTemplate4.CellTemplates.Add(textCell22);
            rowTemplate4.CellTemplates.Add(textCell23);
            rowTemplate4.CellTemplates.Add(textCell24);
            rowTemplate4.CellTemplates.Add(textCell25);
            rowTemplate4.CellTemplates.Add(textCell26);
            rowTemplate4.CellTemplates.Add(textCell27);
            rowTemplate4.CellTemplates.Add(textCell28);
            rowTemplate4.Height = 48;
            rowTemplate4.Name = "rtRowCheck";
            this.advancedList.Templates.Add(rowTemplate1);
            this.advancedList.Templates.Add(rowTemplate2);
            this.advancedList.Templates.Add(rowTemplate3);
            this.advancedList.Templates.Add(rowTemplate4);
            this.advancedList.ValidateData += new Resco.Controls.AdvancedList.ValidateDataEventHandler(this.advancedList_ValidateData);
            this.advancedList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.advancedList_KeyUp);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.miMovements);
            this.mainMenu.MenuItems.Add(this.mAbout);
            // 
            // miMovements
            // 
            this.miMovements.MenuItems.Add(this.miExit);
            this.miMovements.MenuItems.Add(this.miSeparator);
            this.miMovements.MenuItems.Add(this.miWares);
            this.miMovements.MenuItems.Add(this.miMarkDoc);
            this.miMovements.MenuItems.Add(this.miFiltr);
            this.miMovements.MenuItems.Add(this.miWaresScan);
            this.miMovements.MenuItems.Add(this.miExtraProperties);
            this.miMovements.MenuItems.Add(this.miGroupingDoc);
            this.miMovements.MenuItems.Add(this.miSeparator1);
            this.miMovements.MenuItems.Add(this.miSync);
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
            // miWares
            // 
            this.miWares.Text = "Список товарів";
            this.miWares.Click += new System.EventHandler(this.btnWares_Click);
            // 
            // miMarkDoc
            // 
            this.miMarkDoc.Text = "Відмітити\\Зняти відмітку";
            this.miMarkDoc.Click += new System.EventHandler(this.btnMarkDoc_Click);
            // 
            // miFiltr
            // 
            this.miFiltr.Text = "Пошук документа";
            this.miFiltr.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // miWaresScan
            // 
            this.miWaresScan.Text = "Сканування товару";
            this.miWaresScan.Click += new System.EventHandler(this.btnWaresScan_Click);
            // 
            // miExtraProperties
            // 
            this.miExtraProperties.Text = "Дод. властивості";
            this.miExtraProperties.Click += new System.EventHandler(this.btnExtraProperties_Click);
            // 
            // miGroupingDoc
            // 
            this.miGroupingDoc.Text = "Групування документів";
            this.miGroupingDoc.Click += new System.EventHandler(this.btnGroupingDoc_Click);
            // 
            // miSeparator1
            // 
            this.miSeparator1.Text = "-";
            // 
            // miSync
            // 
            this.miSync.Text = "Синхронізація";
            this.miSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // mAbout
            // 
            this.mAbout.Text = "Про ...";
            this.mAbout.Click += new System.EventHandler(this.btnAbout_Click);
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
            // progressBar
            // 
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(10, 140);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(220, 20);
            this.progressBar.Visible = false;
            // 
            // SyncCapt
            // 
            this.SyncCapt.Enabled = false;
            this.SyncCapt.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.SyncCapt.Location = new System.Drawing.Point(10, 115);
            this.SyncCapt.Name = "SyncCapt";
            this.SyncCapt.Size = new System.Drawing.Size(220, 23);
            this.SyncCapt.Text = "Синхронізація...";
            this.SyncCapt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SyncCapt.Visible = false;
            // 
            // frmDocGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.advancedList);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.labelDown);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.labelRigth);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.SyncCapt);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "frmDocGrid";
            this.Text = "BRB3";
            this.Load += new System.EventHandler(this.frmDocGrid_Load);
            this.Closed += new System.EventHandler(this.frmDocGrid_Closed);
            this.Activated += new System.EventHandler(this.frmDocGrid_Activated);
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
        private System.Windows.Forms.MenuItem mAbout;
        private System.Windows.Forms.MenuItem miExit;
        private System.Windows.Forms.MenuItem miSeparator;
        private System.Windows.Forms.MenuItem miSeparator1;
        private System.Windows.Forms.MenuItem miWares;
        private System.Windows.Forms.MenuItem miMarkDoc;
        private System.Windows.Forms.MenuItem miFiltr;
        private System.Windows.Forms.MenuItem miWaresScan;
        private System.Windows.Forms.MenuItem miExtraProperties;
        private System.Windows.Forms.MenuItem miGroupingDoc;
        private System.Windows.Forms.MenuItem miSync;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label SyncCapt;
    }
}