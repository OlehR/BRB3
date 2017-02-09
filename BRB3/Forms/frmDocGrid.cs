using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Resco.Controls;

namespace BRB.Forms
{
    public partial class frmDocGrid : Form
    {
        DataTable dt; 
        DataView dv; // Виборка по фільтру
        int rowIndex;
        int rowIndexFilter;
        bool isFilter;
       
        public frmDocGrid(TypeDoc parTypeDoc)
        {
            dt = Global.cBL.LoadDocs(parTypeDoc);
            InitializeComponent();
            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            //this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();

            this.miExit.Text += " " + HotKey.strDocGrid_Exit;
            this.miWares.Text += " " + HotKey.strDocGrid_Wares;
            this.miMarkDoc.Text += " " + HotKey.strDocGrid_MarkDoc;
            this.miFiltr.Text += " " + HotKey.strDocGrid_Filter;
            this.miWaresScan.Text += " " + HotKey.strDocGrid_WaresScan;
            this.miExtraProperties.Text += " " + HotKey.strDocGrid_ExtraProperties;
            this.miGroupingDoc.Text += " " + HotKey.strDocGrid_GroupingDoc;
            this.miSync.Text += " " + HotKey.strDocGrid_Sync;
            this.miSettings.Text += " " + HotKey.strDocGrid_Settings;

            if (Global.cBL.CurTypeDoc != TypeDoc.SupplyLogistic)
            {
                this.miGroupingDoc.Enabled = false;
            }
        }

        private void frmDocGrid_Activated(object sender, EventArgs e)
        {
            if (isFilter)
            {
                Global.cBL.filterDoc();
                dv = Global.cBL.dvFilterDoc;
                advancedList.DataSource = dv;
            }
            else
            {
                dt = Global.cBL.dtDocs;
                advancedList.DataSource = dt;
            }

            advancedList.ResumeRedraw();

            if (isFilter)
                advancedList.ActiveRowIndex = rowIndexFilter;
            else
                advancedList.ActiveRowIndex = rowIndex;

            try
            {
                // Global.cTerminal.StartScan(this.scanBarcode); //Розкоментарити!!!
            }
            catch { }
        }

        private void frmDocGrid_Load(object sender, EventArgs e)
        {
            try
            {
                //Global.cTerminal.StartScan(this.scanBarcode); // Розкоментарити!!!

                if (Global.eTypeTerminal == TypeTerminal.MotorolaMC75Ax)
                {
                    this.advancedList.FooterRow = new Resco.Controls.AdvancedList.HeaderRow(0, new string[] {
                  resources.GetString("advancedList.FooterRow")});
                    this.advancedList.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(0, new string[] {
                  resources.GetString("advancedList.HeaderRow")});
                }
                else if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                {
                    this.advancedList.FooterRow = new Resco.Controls.AdvancedList.HeaderRow(0, new string[] {
                  resources.GetString("advancedList.FooterRow")});
                    this.advancedList.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(0, new string[] {
                  resources.GetString("advancedList.HeaderRow")});
                }

                advancedList.DataSource = dt;
                advancedList.Focus();

                if (advancedList.DataRows.Count > 0)
                {
                    advancedList.ActiveRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                 this.Close();
               // clsException.EnableException(ex);
                clsDialogBox.ErrorBoxShow("Неможливо зайти в модуль! ");
            }
        }

        private void frmDocGrid_Closed(object sender, EventArgs e)
        {
            try
            {
                Global.cTerminal.StopScan();
            }
            catch (System.Exception ) // --------------------------
            {
                clsDialogBox.ErrorBoxShow("error");
            }
        }


        #region Кнопки/функції ---------------------

        private void advancedList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.Up)
            {
                if (advancedList.DataRows.Count > 0)
                {
                    if (advancedList.ActiveRowIndex - 1 >= 0)
                    {advancedList.ActiveRowIndex = advancedList.ActiveRowIndex - 1;}
                }
            }
            else if (e.KeyValue == HotKey.Down)
            {
                if (advancedList.DataRows.Count > 0)
                {
                    if (advancedList.ActiveRowIndex + 1 < advancedList.DataRows.Count)
                    {advancedList.ActiveRowIndex = advancedList.ActiveRowIndex + 1;}
                }
            }

            else if (e.KeyValue == HotKey.DocGrid_Exit)
            {
                btnExit();
            }
            else if (e.KeyValue == HotKey.DocGrid_Wares)
            {
                btnWares();
            }
            else if (e.KeyValue == HotKey.DocGrid_MarkDoc)
            {
                btnMarkDoc();
            }
            else if (e.KeyValue == HotKey.DocGrid_Filter)
            {
                btnFilter();
            }
            else if (e.KeyValue == HotKey.DocGrid_WaresScan)
            {
                btnWaresScan();
            }
            else if (e.KeyValue == HotKey.DocGrid_ExtraProperties)
            {
                btnExtraProperties();
            }
            else if (e.KeyValue == HotKey.DocGrid_GroupingDoc)
            {
                btnGroupingDoc();
            }
            else if (e.KeyValue == HotKey.DocGrid_Sync)
            {
                btnSync();
            }
            else if (e.KeyValue == HotKey.DocGrid_Settings)
            {
                btnSettings();
            }
        }

        // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            btnAbout();
        }
        private void btnWares_Click(object sender, EventArgs e)
        {
            btnWares();
        }
        private void btnMarkDoc_Click(object sender, EventArgs e)
        {
            btnMarkDoc();
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            btnFilter();
        }
        private void btnWaresScan_Click(object sender, EventArgs e)
        {
            btnWaresScan();
        }
        private void btnExtraProperties_Click(object sender, EventArgs e)
        {
            btnExtraProperties();
        }
        private void btnGroupingDoc_Click(object sender, EventArgs e)
        {
            btnGroupingDoc();
        }
        private void btnSync_Click(object sender, EventArgs e)
        {
            btnSync();
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnSettings();
        }

        // Функції
        private void btnExit()
        {
            this.Close();
        }
        private void btnAbout()
        {
            MessageBox.Show("Немає форми About");
        }
        private void btnWares()
        {
            Global.cTerminal.StopScan();
            if (!isFilter)
                rowIndex = advancedList.ActiveRowIndex;
            else
                rowIndexFilter = advancedList.ActiveRowIndex;

            if (advancedList.ActiveRowIndex >= 0)
            {
                 if (Convert.ToInt32(advancedList.DataRows[advancedList.ActiveRowIndex]["status"]) == 1)
                {
                    clsDialogBox.InformationBoxShow("Документ відмічений для відправлення на сервер і не може бути змінений!");
                    return;
                }
                 try
                 {
                     frmWaresGrid newfrmWaresGrid = new frmWaresGrid(Global.cBL.CurTypeDoc, Convert.ToInt32(advancedList.DataRows[advancedList.ActiveRowIndex]["number_doc"]));
                     newfrmWaresGrid.Show();
                 }
                 catch (Exception ex)
                 {
                     clsException.EnableException(ex);
                 }
            }
            else
            {
                clsDialogBox.InformationBoxShow("Відсутній документ для перегляду!");
            }
        }

        private void btnMarkDoc()
        {
            if (advancedList.ActiveRowIndex >= 0)
            {
                Global.cBL.SetCurDoc(Convert.ToInt32(advancedList.DataRows[advancedList.ActiveRowIndex]["number_doc"]));
                if (!isFilter)
                    rowIndex = advancedList.ActiveRowIndex;
                else
                    rowIndexFilter = advancedList.ActiveRowIndex;

                if (clsDialogBox.ConfirmationBoxShow(Convert.ToInt32(advancedList.DataRows[(isFilter ? rowIndexFilter : rowIndex)]["status"]) == Convert.ToInt32(TypeStatusDoc.NoMark) ?
                    "Відмітити документ для відправки на сервер?":"Зняти з документа відмітку відправки на сервер?") == DialogResult.Yes)
                {
                    TypeStatusDoc varNewStatuaDoc = (Convert.ToInt32(advancedList.DataRows[(isFilter ? rowIndexFilter : rowIndex)]["status"]) == Convert.ToInt32(TypeStatusDoc.NoMark) ?
                                                                    TypeStatusDoc.Mark:TypeStatusDoc.NoMark);
                    Status res=Global.cBL.SetStatusDoc(varNewStatuaDoc);
                    if (res.status != EStatus.Ok)
                        clsDialogBox.ErrorBoxShow(res.StrStatus);
                    else
                    {
                        advancedList.DataRows[(isFilter ? rowIndexFilter : rowIndex)]["status"] = Convert.ToInt32(varNewStatuaDoc);
                        advancedList.DataRows[(isFilter ? rowIndexFilter : rowIndex)]["StatusName"] = (varNewStatuaDoc == TypeStatusDoc.Mark ? "+" : "-");
                        advancedList.DataRows[(isFilter ? rowIndexFilter : rowIndex)].TemplateIndex = (varNewStatuaDoc == TypeStatusDoc.Mark ? 3 : 1);
                        
                        advancedList.ResumeRedraw();
                    }
                }
            }
        }

        private void btnFilter()
        {
            if (!isFilter)
                rowIndex = advancedList.ActiveRowIndex;
            else rowIndexFilter = advancedList.ActiveRowIndex;

            frmDocSearch formSearch = new frmDocSearch();
            DialogResult result = formSearch.ShowDialog();

            if (result == DialogResult.Yes)
            {
                isFilter = true;
                dv = Global.cBL.dvFilterDoc;
                advancedList.DataSource = dv;
                advancedList.ResumeRedraw();
            }
            else if (result == DialogResult.Abort)
            {
                isFilter = false;
                dv = null;
                advancedList.DataSource = dt;
                advancedList.ResumeRedraw();
                advancedList.ActiveRowIndex = rowIndex;
            }
            
        }

        private void btnWaresScan()
        {
            Global.cTerminal.StopScan();
            if (!isFilter)
               rowIndex = advancedList.ActiveRowIndex;
            else 
            rowIndexFilter = advancedList.ActiveRowIndex;

            if (advancedList.ActiveRowIndex >= 0)
            {
                 if (Convert.ToInt32(advancedList.DataRows[advancedList.ActiveRowIndex]["status"]) == 1)
                {
                    clsDialogBox.InformationBoxShow("Документ відмічений для відправлення на сервер і не може бути змінений!");
                    return;
                }
                 try
                 {
                   Global.cBL.LoadWaresDocs(Global.cBL.CurTypeDoc, Convert.ToInt32(advancedList.DataRows[advancedList.ActiveRowIndex]["number_doc"]));
                   frmWaresScan newfrmWaresScan = new frmWaresScan();
                   newfrmWaresScan.Show();
                 }
                
                 catch (Exception ex)
                 {
                     clsException.EnableException(ex);
                 }
            }
            else
            {
                clsDialogBox.InformationBoxShow("Відсутній документ для перегляду!");
            }
        }

        private void btnExtraProperties()
        {
            Global.cBL.SetCurDoc(Convert.ToInt32(advancedList.DataRows[advancedList.ActiveRowIndex]["number_doc"]));

            frmAdvSettingsDoc formAdvSettingsDoc = new frmAdvSettingsDoc();
            formAdvSettingsDoc.Show();
        }
        private void btnGroupingDoc()
        {
            MessageBox.Show("GroupingDoc Ще не реалізовано");
        }
        private void btnSync()
        {
            MessageBox.Show("btnSync Ще не реалізовано");
        }
        private void btnSettings()
        {
            MessageBox.Show("Немає форми Settings");
        }

        // Додаткові функції
        private void advancedList_ValidateData(object sender, Resco.Controls.AdvancedList.ValidateDataArgs e)
        {
            int i = 0;
            try
            { i = Convert.ToInt16(e.DataRow["status"]); }
            catch { }

            if (i == 1)
                e.DataRow.TemplateIndex = 3;
            else
                e.DataRow.TemplateIndex = 1;
        }

        void scanBarcode(string Barcode)
        {
            string iT = Barcode;
        }

        #endregion //Кнопки/функції

    }
}