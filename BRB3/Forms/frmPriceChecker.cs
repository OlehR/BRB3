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
    public partial class frmPriceChecker : Form
    {
        DataRow dr;
        Status st;

        public frmPriceChecker()
        {
            InitializeComponent();
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();

            this.miExit.Text += " " + HotKey.strPriceChecker_Exit;
            this.miAdd.Text += " " + HotKey.strPriceChecker_Add;
            this.miFindAdd.Text += " " + HotKey.strPriceChecker_FindAdd;
            this.miSettings.Text += " " + HotKey.strPriceChecker_Settings;
            this.miSync.Text += " " + HotKey.strPriceChecker_Sync;
            this.mAbout.Text += " " + HotKey.strPriceChecker_About;
            this.mpbAdd.Text += " " + HotKey.strPriceChecker_Add;
            this.mpbFindAdd.Text += " " + HotKey.strPriceChecker_FindAdd;
        
            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;
            else if (Global.eTypeTerminal == TypeTerminal.MotorolaMC75Ax)
            {
                this.mpbAdd.Size = new System.Drawing.Size(110 * Global.tCoefficient, 54 * Global.tCoefficient);
                this.mpbFindAdd.Size = new System.Drawing.Size(110 * Global.tCoefficient, 54 * Global.tCoefficient);
            }
        }

        private void PriceChecker_Load(object sender, EventArgs e)
        {
            Global.cTerminal.StartScan(this.scanBarcode);
        }

        private void PriceChecker_Closed(object sender, EventArgs e)
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

        #region Кнопки/функції ---------------------

        private void DocSerch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.PriceChecker_Exit)
            {
                btnExit();
            }
            if (e.KeyValue == HotKey.PriceChecker_About)
            {
                btnAbout();
            }
            if (e.KeyValue == HotKey.PriceChecker_Add)
            {
                btnAdd();
            }
            if (e.KeyValue == HotKey.PriceChecker_FindAdd)
            {
                btnFindAdd();
            }
            if (e.KeyValue == HotKey.PriceChecker_Settings)
            {
                btnSettings();
            }
            if (e.KeyValue == HotKey.PriceChecker_Sync)
            {
                btnSync();
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
        private void btnSync_Click(object sender, EventArgs e)
        {
            btnSync();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd();
        }
        private void btnFindAdd_Click(object sender, EventArgs e)
        {
            btnFindAdd();
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
            clsDialogBox.InformationBoxShow("Немає форми btnAbout");
        }
        private void btnSync()
        {
            clsDialogBox.InformationBoxShow("Немає форми btnSync");
        }
        private void btnAdd()
        {
            if (st.status == EStatus.FoundByBarCode)
               Global.cData.SavePCh(Global.cBL.CurbcID, Global.cBL.CurBarCode, "2");
            else if (st.status == EStatus.NoFoundByBarCode || st.status == EStatus.NoFoundByCodeWares)
                Global.cData.SavePCh(Global.cBL.CurbcID, Global.cBL.CurBarCode, "0");

            this.mplInfo.Text = "Збережено!";
            this.mpbAdd.Enabled = false;

        }
        private void btnFindAdd()
        {
            if (!mptbArticle.Enabled)
            {
                this.mptbArticle.Enabled = true;
                this.mptbArticle.Visible = true;
                this.mptbArticle.Focus();
                this.mpbFindAdd.Text = "Знайти " + HotKey.strPriceChecker_FindAdd; ;
            }
            else
            {
                int varCodeWares;

                if (mptbArticle.Text.Length > 0 && mptbArticle.Text.Length <= Global.WeightBarCodeWares)
                {
                    try
                    {
                        varCodeWares = Convert.ToInt32(mptbArticle.Text);

                        //this.mptbArticle.Enabled = false;
                        //this.mptbArticle.Visible = false;
                        //this.mpbFindAdd.Text = "Пошук " + HotKey.strPriceChecker_FindAdd; ;
                    }
                    catch
                    {
                        this.mplInfo.Text = "Не коректний код товару";
                        this.mptbArticle.Focus();
                    }
                }
                else
                {
                    this.mplInfo.Text = "Не коректний код товару";
                    this.mptbArticle.Focus();
                }
                
            }
        }
        private void btnSettings()
        {
            clsDialogBox.InformationBoxShow("Немає форми Налаштувань");
        }


        void scanBarcode(string Barcode)
        {
            st = Global.cBL.SerchGoodsPriceCheck(Barcode, out dr);

            if (st.status == EStatus.Ok)
            {
                this.mplInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
                this.mplInfo.ForeColor = System.Drawing.Color.Blue;
                this.mplInfo.Text = "Ціна вірна";
                this.mpbAdd.Enabled = false;
            }
            else if (st.status == EStatus.BadPrice)
            {
                this.mplInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
                this.mplInfo.ForeColor = System.Drawing.Color.Red;
                this.mplInfo.Text = "Ціна не вірна! Збережено.";
                this.mpbAdd.Enabled = false;
            }
            else if (st.status == EStatus.FoundByBarCode)
            {
                this.mplInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
                this.mplInfo.ForeColor = System.Drawing.Color.Green;
                this.mplInfo.Text = "По ШК. Перевірте ціну!";
                this.mpbAdd.Enabled = true;
            }
            else if (st.status == EStatus.NoFoundByBarCode) 
            {
                this.mplInfo.ForeColor = System.Drawing.Color.Red;
                this.mplInfo.Text = "По ШК не знайдено";
                this.mpbAdd.Enabled = true;
            }
            else if (st.status == EStatus.NoFoundByCodeWares) 
            {
                this.mplInfo.ForeColor = System.Drawing.Color.Red;
                this.mplInfo.Text = "По коду не знайдено";
                this.mpbAdd.Enabled = true;
            }

            fillDataForm();

            this.mplBarCode.Text = (st.status == EStatus.NoFoundByCodeWares? string.Empty : Barcode);
            if (st.status == EStatus.NoFoundByCodeWares) 
                this.mplArticle.Text = Barcode.Substring(2, Global.WeightBarCodeWares).TrimStart('0');
        }

        public void fillDataForm()
        {
            if (dr != null)
            {
                this.mplArticle.Text = dr["cpGoodsArticle"].ToString();
                this.mplName.Text = "                 " + dr["cpGoodsName"].ToString();
                this.mplPrice.Text = dr["cpPrice1"].ToString();
                this.mplPriceOpt.Text = dr["cpPrice2"].ToString();
            }
            else
            {
                this.mplArticle.Text = string.Empty;
                this.mplBarCode.Text = string.Empty;
                this.mplName.Text = string.Empty;
                this.mplPrice.Text = string.Empty;
                this.mplPriceOpt.Text = string.Empty;
            }
        }

        #endregion
    }
}