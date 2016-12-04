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
        int number_doc;
        TypeDoc typeDoc;

        public frmDocGrid(TypeDoc parTypeDoc)
        {
            typeDoc = parTypeDoc;
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
        //Для тесту. Необхідно переробити!
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
            else if (e.KeyValue == HotKey.DocGrid_ListWares) //F3 строки 114
            {
                number_doc = Convert.ToInt32(dt.Rows[advancedList.ActiveRowIndex]["number_doc"]);
                //number_doc = int.Parse(dt.Rows[advancedList.ActiveRowIndex]["number_doc"].ToString());

                // запускаєм форму з товарами frmWaresGrid(TypeDoc, number_doc)
                frmWaresGrid newfrmWaresGrid = new frmWaresGrid(typeDoc, number_doc);
                newfrmWaresGrid.Show();
            }
        }
    }
}