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
    public partial class frmAdvSettingsDoc : Form
    {
        public frmAdvSettingsDoc()
        {
            InitializeComponent();
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            //this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = Global.curVersionBRB + " " + Global.cBL.CurTypeDoc.ToString() + " AdvSetDoc";

            this.miExit.Text += " " + HotKey.strAdvSettingsDoc_Exit;
            this.mpbExit.Text += " " + HotKey.strAdvSettingsDoc_Exit;
            this.mpbSave.Text += " " + HotKey.strAdvSettingsDoc_Save;


            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;

            if (Global.eTypeTerminal == TypeTerminal.MotorolaMC75Ax)
            {
                this.mpbSave.Size = new System.Drawing.Size(138 * Global.tCoefficient, 50 * Global.tCoefficient);
                this.mpbExit.Size = new System.Drawing.Size(85 * Global.tCoefficient, 50 * Global.tCoefficient);
            }
        }

        private void AdvSettingsDoc_Load(object sender, EventArgs e)
        {
            if (Global.cBL.CurDoc != null)
            {
                if (Global.cBL.CurDoc["number_out_invoice"] != DBNull.Value)
                    this.mptbNumberDoc.Text = Global.cBL.CurDoc["number_out_invoice"].ToString();
                if (Global.cBL.CurDoc["date_out_invoice"] != DBNull.Value)
                    this.mptbDateDoc.Text = Convert.ToDateTime(Global.cBL.CurDoc["date_out_invoice"]).ToShortDateString();
                if (Global.cBL.CurDoc["flag_price_with_vat"] != DBNull.Value)
                    this.mpcbPriceWizVat.Checked = (Convert.ToInt32(Global.cBL.CurDoc["flag_price_with_vat"]) == 1 ? true : false);
                if (Global.cBL.CurDoc["flag_change_doc_sup"] != DBNull.Value)
                    this.mpcbChangeDocSup.Checked = (Convert.ToInt32(Global.cBL.CurDoc["flag_change_doc_sup"]) == 1 ? true : false);
                if (Global.cBL.CurDoc["flag_sum_qty_doc"] != DBNull.Value)
                    this.mpcbSumQtyZNP.Checked = (Convert.ToInt32(Global.cBL.CurDoc["flag_sum_qty_doc"]) == 1 ? true : false);
                if (Global.cBL.CurDoc["flag_insert_weigth_from_barcode"] != DBNull.Value)
                    this.mpcbInsMas.Checked = (Convert.ToInt32(Global.cBL.CurDoc["flag_insert_weigth_from_barcode"]) == 1 ? true : false);
            }

        }

        #region Кнопки/функції ---------------------

        private void AdvSettingsDoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.AdvSettingsDoc_Exit)
            {
                btnExit();
            }
            else if (e.KeyValue == HotKey.AdvSettingsDoc_Save)
            {
                btnSave();
            }

        }

        // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave();
        }
       

        // Функції
        private void btnExit()
        {
            this.Close();
        }
        private void btnSave()
        {
            Status st = Global.cBL.saveAdvSetDoc(this.mptbNumberDoc.Text, this.mptbDateDoc.Text, Convert.ToInt32(this.mpcbPriceWizVat.Checked), Convert.ToInt32(this.mpcbChangeDocSup.Checked),
                                                                                                 Convert.ToInt32(this.mpcbSumQtyZNP.Checked), Convert.ToInt32(this.mpcbInsMas.Checked));
            if (st.status != EStatus.Ok)
            {
                clsDialogBox.InformationBoxShow(st.StrStatus);

                if (st.status == EStatus.NoCorectDate)
                    this.mptbDateDoc.Focus();
            }
            else
                if (clsDialogBox.ConfirmationBoxShow("Зміни збережено! Вийти?") == DialogResult.Yes)
                    this.Close();
        }


        #endregion

       
    }
}