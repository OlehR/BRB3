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
    public partial class frmDocSearch : Form
    {
        public frmDocSearch()
        {
            InitializeComponent();
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            //this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = Global.curVersionBRB + " " + Global.cBL.CurTypeDoc.ToString() + " DocSearch";

            this.miExit.Text += " " + HotKey.strSearch_Exit;
            this.mpbSelect.Text += " " + HotKey.strSearch_Select;
            this.mpbCancel.Text += " " + HotKey.strSearch_Cancel;
            this.mpbCancelFilter.Text += " " + HotKey.strSearch_CancelFilter;

            if (Global.eTypeTerminal ==TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;
        }

        private void DocSearch_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.mptbNumDoc.Text = string.Empty;
            this.mptbZKPO.Text = string.Empty;
            this.mptbNumDoc.Focus();
            
        }

        #region Кнопки/функції ---------------------

        private void DocSerch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.Up)  // переміщення стрілками треба доробити
            {
                this.mainPanel.SelectNextControl(this, false, true, true, false);
            }
            else if (e.KeyValue == HotKey.Down)
            {
                this.mainPanel.SelectNextControl(this, true, true, true, false);
            }
            else if (e.KeyValue == HotKey.Search_Exit)
            {
                btnExit();
            }
            else if (e.KeyValue == HotKey.Search_Select)
            {
                btnSelect();
            }
            else if (e.KeyValue == HotKey.Search_Cancel)
            {
                btnCancel();
            }
            else if (e.KeyValue == HotKey.Search_CancelFilter)
            {
                btnCancelFilter();
            }
        }

        // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnSelect();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel();
        }
        private void btnCancelFilter_Click(object sender, EventArgs e)
        {
            btnCancelFilter();
        }

        // Функції
        private void btnExit()
        {
            this.Close();
        }
        private void btnSelect()
        {
            Status st = Global.cBL.filterDoc(mptbNumDoc.Text, mptbZKPO.Text);
            if (st.status != EStatus.Ok)
            {
                clsDialogBox.InformationBoxShow(st.StrStatus);

                if (st.status == EStatus.NoCorectZKPO)
                    this.mptbZKPO.Focus();
                else if (st.status == EStatus.NoCorectNumberDoc || st.status == EStatus.NoNumberDocOrZKPO)
                    this.mptbNumDoc.Focus();
                else if (st.status == EStatus.NoFoundRows && !String.IsNullOrEmpty(mptbNumDoc.Text))
                    this.mptbNumDoc.Focus();
                else if (st.status == EStatus.NoFoundRows && !String.IsNullOrEmpty(mptbZKPO.Text))
                    this.mptbZKPO.Focus();
            }
            else
               this.DialogResult = DialogResult.Yes;
            
        }
        private void btnCancel()
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnCancelFilter()
        {
            this.DialogResult = DialogResult.Abort;
        }
        #endregion
    }
}