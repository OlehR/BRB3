using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BRB.Forms
{
    public partial class frmWaresGrid : Form
    {
        DataTable dt;
        
        public frmWaresGrid(TypeDoc parTypeDoc, int parNumberDoc)
        {
            dt = Global.cBL.LoadWaresDocs(parTypeDoc, parNumberDoc);
            InitializeComponent();
            InitializeComponentManual();
            this.Text += parNumberDoc.ToString();
        }

        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();

            this.miExit.Text += " " + HotKey.strWaresGrid_Exit;
            this.miEdit.Text += " " + HotKey.strWaresGrid_Edit;
            this.miScan.Text += " " + HotKey.strWaresGrid_Scan;
            this.miFilter.Text += " " + HotKey.strWaresGrid_Filter;
        }
        private void frmWaresGrid_Load(object sender, EventArgs e)
        {
            this.advancedList.FooterRow = new Resco.Controls.AdvancedList.HeaderRow(0, new string[] {
                  resources.GetString("advancedList.FooterRow")});
            this.advancedList.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(0, new string[] {
                  resources.GetString("advancedList.HeaderRow")}); 

            advancedList.DataSource = dt;
            advancedList.Focus();

            if (advancedList.DataRows.Count > 0)
            {
                advancedList.ActiveRowIndex = 0;
            }
        }

        private void frmWaresGrid_Activated(object sender, EventArgs e)
        {
            dt = Global.cBL.dtWaresDoc;
            advancedList.DataSource = dt;
            advancedList.ResumeRedraw();
        }

        private void advancedList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.Up)
            {
                // Up
                if (advancedList.DataRows.Count > 0)
                {
                    if (advancedList.ActiveRowIndex - 1 >= 0)
                    { advancedList.ActiveRowIndex = advancedList.ActiveRowIndex - 1; }
                }
            }
            else if (e.KeyValue == HotKey.Down)
            {
                if (advancedList.DataRows.Count > 0)
                {
                    if (advancedList.ActiveRowIndex + 1 < advancedList.DataRows.Count)
                    { advancedList.ActiveRowIndex = advancedList.ActiveRowIndex + 1; }
                }
            }

            else if (e.KeyValue == HotKey.DocGrid_Exit)
            {
                btnExit();
            }
            
        }

        // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit();
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            btnScan();
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            btnFilter();
        }

        // Функції
        private void btnExit()
        {
            this.Close();
        }
        private void btnEdit()
        {
            if (Global.cBL.IsEditWaresManual(Convert.ToInt32(advancedList.DataRows[advancedList.ActiveRowIndex]["code_wares"])))
            {
                frmWaresScan newfrmWaresScan = new frmWaresScan(Convert.ToInt32(advancedList.DataRows[advancedList.ActiveRowIndex]["code_wares"]));
                newfrmWaresScan.Show();
            }
            else clsDialogBox.InformationBoxShow("Ручне редагування к-ті товару заборонено!");
        }
        private void btnScan()
        {
            frmWaresScan newfrmWaresScan = new frmWaresScan();
            newfrmWaresScan.Show();
        }
        private void btnFilter()
        {
            MessageBox.Show("Filter форми не існує");
        }
    }
}