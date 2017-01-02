﻿using System;
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

        public frmWaresGrid(TypeDoc parTypeDoc, int panNumberDoc)
        {
            dt = BL.LoadWaresDocs(parTypeDoc, panNumberDoc);
            InitializeComponent();
            InitializeComponentManual();
            this.Text += panNumberDoc.ToString();
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
            frmWaresScan newfrmWaresScan = new frmWaresScan(); // З передачою номера док
            newfrmWaresScan.Show();
        }
        private void btnScan()
        {
            frmWaresScan newfrmWaresScan = new frmWaresScan(); // пуста форма
            newfrmWaresScan.Show();
        }
        private void btnFilter()
        {
            MessageBox.Show("Filter форми не існує");
        }
    }
}