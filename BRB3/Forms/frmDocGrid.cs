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

        public frmDocGrid(TypeDoc parTypeDoc)
        {
            dt = Global.cBL.LoadDocs(parTypeDoc);
            InitializeComponent();
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();
        }

        private void frmDocGrid_Load(object sender, EventArgs e)
        {
            try
            {
                //RefreshAdvList();
                //this.Text = clsCommon.PropMiniInventoryCaption;
                //this.DialogResult = DialogResult.None;
                //StartScan();

                if (Global.eTypeTerminal == TypeTerminal.MotorolaMC75Ax)
                {
                    this.advancedList.FooterRow = new Resco.Controls.AdvancedList.HeaderRow(3, new string[] {
                  resources.GetString("advancedList.FooterRow")});
                    this.advancedList.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(3, new string[] {
                  resources.GetString("advancedList.HeaderRow")});
                }
                else if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                {
                    this.advancedList.FooterRow = new Resco.Controls.AdvancedList.HeaderRow(3, new string[] {
                  resources.GetString("advancedList.FooterRow")});
                    this.advancedList.HeaderRow = new Resco.Controls.AdvancedList.HeaderRow(3, new string[] {
                  resources.GetString("advancedList.HeaderRow")});
                }

                advancedList.DataSource = dt;
                advancedList.Focus();

                if (advancedList.DataRows.Count > 0)
                {
                    advancedList.ActiveRowIndex = 0;
                }
            }
            catch (System.Exception)
            {
                 this.Close();
                //clsDialogBox.ErrorBoxShow("Неможливо зайти в модуль!");
            }
        }
    }
}