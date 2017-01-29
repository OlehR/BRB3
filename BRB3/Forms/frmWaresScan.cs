using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BRB.Forms
{
    public partial class frmWaresScan : Form
    {
        DataRow dr;
       
        public frmWaresScan(int panCodeWares)
        {
            dr = Global.cBL.FindGoodCode(panCodeWares);
            InitializeComponent();
            InitializeComponentManual();
        }

        public frmWaresScan()
        {
            dr = null;
            InitializeComponent();
            InitializeComponentManual();
        }
       
        private void frmWaresScan_Load(object sender, EventArgs e)
        {
            //Global.cTerminal.StartScan(this.scanBarcode); //Розкоментувати!!!!
            fillDataForm();
        }

        private void frmWaresScan_Closed(object sender, EventArgs e)
        {
            try
            {
                Global.cTerminal.StopScan();
            }
            catch (System.Exception) // --------------------------
            {
                clsDialogBox.ErrorBoxShow(e.ToString());
            }
        }

        private void frmWaresScan_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mplArticle.Text != string.Empty)
            {
                //if (clsDialogBox.ConfirmationBoxShow("Завершити сканування товарів?") == DialogResult.Yes)
                DialogResult result = clsDialogBox.ConfirmationBoxShow("Є незбережений товар. Продовжити?");
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        public void fillDataForm()
        {
            if (dr != null)
            {
                this.mplDocNum.Text = Global.cBL.CurNumDoc.ToString();
                this.mplArticle.Text = dr["code_wares"].ToString();
                this.mplCode.Text = dr["bar_code"].ToString();
                this.mplName.Text = "                      " + dr["name_wares"].ToString();
                this.mptbAddQty.Text = "";

                if (dr["quantity"] != DBNull.Value)
                {
                    this.mplQtyNow.Text = decimal.Round(Proto.ToDecimal(dr["quantity"].ToString()), 3).ToString("0.000");
                }
                else this.mplQtyNow.Text = string.Empty;

                if (dr["price"] != DBNull.Value)
                {
                    this.mptbAddPrice.Text = Proto.DeleteZeroEnds(dr["price"].ToString());
                }
                else this.mptbAddPrice.Text = Proto.DeleteZeroEnds(dr["price_temp"].ToString());

                if (dr["quantity_temp"] != DBNull.Value)
                {
                    if (Global.cBL.CurTypeDoc == TypeDoc.SupplyLogistic || Global.cBL.CurTypeDoc == TypeDoc.Inventories)
                    {
                        mplQtyTempl.Text = string.Empty;
                    }
                    else this.mplQtyTempl.Text = decimal.Round(Proto.ToDecimal(dr["quantity_temp"].ToString()), 3).ToString("0.000");
                }
                else mplQtyTempl.Text = string.Empty;

                if (dr["term"] != DBNull.Value)
                {
                    decimal d = Convert.ToDecimal(dr["term"]);
                    int prom = (int)d;
                    prom = prom * 2 / 3;
                    DateTime dd = Convert.ToDateTime(Global.TimeSync).Date;  // замінити на дату знп?й
                    dd = dd.AddDays(prom);
                    mplDateReal.Text = dd.Date.ToString();
                    mplDateReal.BackColor = System.Drawing.Color.YellowGreen; 
                }
                else
                {
                    mplDateReal.Text = DateTime.Now.Date.ToString();
                    mplDateReal.BackColor = System.Drawing.Color.YellowGreen;
                }

                // TMPPPPPP Витерти!!!!
                this.mplQtyTempl.Text = decimal.Round(Proto.ToDecimal(dr["quantity_temp"].ToString()), 3).ToString("0.000");
            }
            else
            {
                this.mplDocNum.Text = Global.cBL.CurNumDoc.ToString();
                this.mplArticle.Text = string.Empty;
                this.mplCode.Text = string.Empty;
                this.mplName.Text = string.Empty;
                this.mptbAddQty.Text = string.Empty;
                this.mplQtyNow.Text = string.Empty;
                this.mptbAddPrice.Text = string.Empty;
                this.mplQtyTempl.Text = string.Empty;

                this.mplDateReal.Text = string.Empty;
                this.mplDateReal.BackColor = System.Drawing.Color.Gainsboro;
                //this.mpcbTempl.Text = string.Empty;
            }
        }

        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(100, (1 + Global.hToolbarTerminal));
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();
            this.mpbtnAdd.Text = mpbtnAdd.Text + " " + HotKey.strWaresScan_Add;
            this.mpbtnCancel.Text = mpbtnCancel.Text + " " + HotKey.strWaresScan_Cancel;
            this.miExit.Text = miExit.Text + " " + HotKey.strWaresScan_Exit;


            // BitatekIT8000 примусово вставляє тулбар
            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
            {
                this.mplBorderDown.Location = new System.Drawing.Point(1, (263 - Global.hToolbarTerminal));
                this.mplBorderLeft.Size = new System.Drawing.Size(1, (231 - Global.hToolbarTerminal));
                this.mplBorderRight.Size = new System.Drawing.Size(1, (231 - Global.hToolbarTerminal));
            }
            // Для MotorolaMC75Ax робимо великі кнопки
            if (Global.eTypeTerminal == TypeTerminal.MotorolaMC75Ax)
            {
                this.mpbtnAdd.Size = new System.Drawing.Size(138 * Global.tCoefficient, 45 * Global.tCoefficient);
                this.mpbtnCancel.Size = new System.Drawing.Size(85 * Global.tCoefficient, 45 * Global.tCoefficient);
            }
        }
        #region Кнопки/функції ---------------------

        // По гарячих кнопках
        private void WaresScan_KeyUp(object sender, KeyEventArgs e)
        {
             if (e.KeyValue == HotKey.WaresScan_Add)
             {
                 btnAdd();
             }
             else if (e.KeyValue == HotKey.WaresScan_Cancel)
             {
                 btnCancel();
             }
             else if (e.KeyValue == HotKey.WaresScan_Exit)
             {
                 btnExit();
             }
        }

        // Клік по пункту меню
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }

     // Функції
        void scanBarcode(string Barcode)
        {
            dr = Global.cBL.FindGoodBarCode(Barcode);
            fillDataForm();
        }

        private void btnExit()
        {
            this.Close();
            //if (clsDialogBox.ConfirmationBoxShow("Завершити сканування товарів?") == DialogResult.Yes)
        }

        private void btnAdd()
        {
            Status st = Global.cBL.SaveGoods(mplArticle.Text,mptbAddQty.Text, mptbAddPrice.Text);
            if (st.status != EStatus.Ok)
                clsDialogBox.InformationBoxShow(st.StrStatus);
            
            if(st.status==EStatus.QuantityCanNotBeFractional|| st.status==EStatus.QuantityTooMuch || st.status==EStatus.NoQuantity || st.status==EStatus.NoCorectQuantity)
                mptbAddQty.Focus();
            else if(st.status==EStatus.PriceTooLong || st.status==EStatus.NoCorectPrice || st.status==EStatus.NoPrice)
                mptbAddPrice.Focus();
            else if (st.status == EStatus.Ok)
            {
                dr = null;
                fillDataForm();
            }
        }
    
        private void btnCancel()
        {
            if (dr == null)
                btnExit();
            else
            {
                dr = null;
                fillDataForm();
            }
        }

        #endregion 
    }
}