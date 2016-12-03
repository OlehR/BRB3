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

        public frmWaresGrid(TypeDoc parTypeDoc, int panNumberDoc)
        {
            dt = Global.cBL.LoadWaresDocs(parTypeDoc, panNumberDoc);
            InitializeComponent();
            InitializeComponentManual();
            this.Text = panNumberDoc.ToString();
        }

        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();
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
            
        }
    }
}