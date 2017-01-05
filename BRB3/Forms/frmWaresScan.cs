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
        int type_doc;

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
        /// <summary>
        /// Enablin Full Screen on Load Form Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWaresScan_Load(object sender, EventArgs e)
        {
            //FullScreen.StartFullScreen(this);
            Global.cTerminal.StartScan(this.scanBarcode);
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

        /// <summary>
        /// Disabling FullScreen on Closing Main Form of Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWaresScan_Closing(object sender, CancelEventArgs e)
        {
            //FullScreen.StopFullScreen(this);
        }
        public void fillDataForm()
        {
            if (dr != null)
            {
                //this.mplDocNum.Text = dr["number_doc"].ToString();
                this.mplDocNum.Text = Global.cBL.CurNumDoc.ToString();
                this.mplArticle.Text = dr["code_wares"].ToString();
                this.mplCode.Text = dr["bar_code"].ToString();
                this.mplName.Text = "                      " + dr["name_wares"].ToString();
                mptbAddQty.Text = "";

                if (dr["quantity"] != DBNull.Value)
                {
                    this.mplQtyNow.Text = decimal.Round(Convert.ToDecimal(dr["quantity"]), 3).ToString("0.000");
                }
                else this.mplQtyNow.Text = string.Empty;

                if (dr["price"] != DBNull.Value)
                {
                    this.mptbAddPrice.Text = Proto.DeleteZeroEnds(dr["price"].ToString());
                }
                else this.mptbAddPrice.Text = Proto.DeleteZeroEnds(dr["price_temp"].ToString());

                if (dr["quantity_temp"] != DBNull.Value)
                {
                    type_doc = Convert.ToInt32(dr["type_doc"]);

                    if (type_doc == 3 | type_doc == 8)
                    {
                        mplQtyTempl.Text = string.Empty;
                    }
                    else this.mplQtyTempl.Text = decimal.Round(Convert.ToDecimal(dr["quantity_temp"]), 3).ToString("0.000");
                }
                else mplQtyTempl.Text = string.Empty;
                // TMPPPPPP
                this.mplQtyTempl.Text = decimal.Round(Convert.ToDecimal(dr["quantity_temp"]), 3).ToString("0.000");
            }
            else this.mplDocNum.Text = Global.cBL.CurNumDoc.ToString();
        }

        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(100, (1 + Global.hToolbarTerminal));
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();
            this.mpbtnAdd.Text = mpbtnAdd.Text + " " + HotKey.strWaresScan_Add;
            this.mpbtnCancel.Text = mpbtnCancel.Text + " " + HotKey.strWaresScan_Cancel;

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
                this.mpbtnAdd.Size = new System.Drawing.Size(141 * Global.tCoefficient, 40 * Global.tCoefficient);
                this.mpbtnCancel.Size = new System.Drawing.Size(86 * Global.tCoefficient, 40 * Global.tCoefficient);
            }
           
                                    
        }

        void scanBarcode(string Barcode)
        {
            dr = Global.cBL.FindGoodBarCode(Barcode);
            fillDataForm();
        }

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
        private void btnExit()
        {
            this.Close();
        }
        private void btnAdd()
        {
            
        }
        private void btnCancel()
        {
        }
    }
}