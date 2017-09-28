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
            this.Text = Global.curVersionBRB + " Контроль цінників";

            this.miExit.Text += " " + HotKey.strPriceChecker_Exit;
            this.miAdd.Text += " " + HotKey.strPriceChecker_Add;
            this.miFindAdd.Text += " " + HotKey.strPriceChecker_FindAdd;
            this.miSync.Text += " " + HotKey.strPriceChecker_Sync;
            this.mAbout.Text += " " + HotKey.strPriceChecker_About;
            this.mpbAdd.Text += " " + HotKey.strPriceChecker_Add;
            this.mpbFindAdd.Text += " " + HotKey.strPriceChecker_FindAdd;
            this.mpbCancel.Text += " " + HotKey.strPriceChecker_Cancel;
        
            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;
            else if (Global.eTypeTerminal == TypeTerminal.MotorolaMC75Ax)
            {
                this.mpbAdd.Size = new System.Drawing.Size(110 * Global.tCoefficient, 54 * Global.tCoefficient);
                this.mpbFindAdd.Size = new System.Drawing.Size(110 * Global.tCoefficient, 54 * Global.tCoefficient);
                this.mpbCancel.Size = new System.Drawing.Size(110 * Global.tCoefficient, 54 * Global.tCoefficient);
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
                if (this.mpbAdd.Enabled)
                    btnAdd();
            }
            if (e.KeyValue == HotKey.PriceChecker_FindAdd)
            {
                btnFindAdd();
            }
            if (e.KeyValue == HotKey.PriceChecker_Cancel)
            {
                if (this.mpbCancel.Enabled)
                    btnCancel();
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel();
        }
                

        // Функції
        private void btnExit()
        {
            this.Close();
        }
        private void btnAbout()
        {
            try
            {
                frmAbout formInfo = new frmAbout();
                formInfo.Show();
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }
        }

        void showProgres(int parPercent)
        {
           // this.mainPanel.Visible = false;
            this.progressBar.Value = parPercent;
        }

        private void btnSync()
        {
            if (clsDialogBox.ConfirmationBoxShow("Почати синхронізацію?") == DialogResult.Yes)
            {
                this.mainPanel.Visible = false;
                this.mainPanel.Enabled = false;
                this.progressBar.Enabled = true;
                this.progressBar.Visible = true;
                this.SyncCapt.Enabled = true;
                this.SyncCapt.Visible = true;
                this.Refresh();

                Status st = Global.cData.Sync(TypeSynchronization.Price, showProgres);
                //if (st.status == EStatus.Ok)

                if (clsDialogBox.InformationBoxShow(st.StrStatus) == DialogResult.OK)
                {
                    this.mainPanel.Visible = true;
                    this.mainPanel.Enabled = true;
                    this.progressBar.Enabled = false;
                    this.progressBar.Visible = false;
                    this.SyncCapt.Enabled = false;
                    this.SyncCapt.Visible = false;
                    this.Refresh();
                }
            }

            else
            {
                clsDialogBox.InformationBoxShow("Синхронізація відмінена!");
            }
        }
       

        private void btnAdd()
        {
            if (st.status == EStatus.FoundByBarCode)
               Global.cData.SavePCh(Global.cBL.CurbcID, Global.cBL.CurBarCode, "2");
            else if (st.status == EStatus.NoFoundByBarCode || st.status == EStatus.NoFoundByCodeWares)
                Global.cData.SavePCh(Global.cBL.CurbcID, Global.cBL.CurBarCode, "1");
            else if (st.status == EStatus.FoundByCodeWares || st.status == EStatus.NoFoundRows)//
                Global.cData.SavePCh(this.mplArticle.Text, string.Empty, "1");

            this.mplInfo.Text = "Збережено!";
            this.mpbAdd.Enabled = false;

        }
        private void btnFindAdd()
        {
            Global.cTerminal.StopScan();
            string varCodeWares = null;

            if (!mptbArticle.Enabled)
            {
                this.mptbArticle.Enabled = true;
                this.mptbArticle.Visible = true;
                this.mptbArticle.Focus();
                this.mpbAdd.Enabled = false;
                dr = null;
                fillDataForm();
                this.mplInfo.Text = string.Empty;
                this.mpbFindAdd.Text = "Знайти " + HotKey.strPriceChecker_FindAdd;
                this.mpbCancel.Enabled = true;
                this.mpbCancel.Visible = true;
            }
            else
            {
                st = Global.cBL.SerchCodeGoodsPriceCheck(mptbArticle.Text, out dr);

                if (st.status == EStatus.NoCorectCodeWares)
                {
                    this.mplInfo.ForeColor = System.Drawing.Color.DarkBlue;
                    this.mplInfo.Text = "Не коректний код товару";
                    dr = null;
                    this.mptbArticle.Focus();
                }
                else
                {
                    if (st.status == EStatus.NoFoundRows)
                    {
                        this.mplInfo.Text = "По коду товар не знайдено";
                        varCodeWares = this.mptbArticle.Text;
                        dr = null;
                    }
                    else if (st.status == EStatus.FoundByCodeWares)
                    {
                        this.mplInfo.Text = "По коду знайдено!";
                    }

                    this.mplInfo.ForeColor = System.Drawing.Color.DarkBlue;
                    this.mptbArticle.Text = string.Empty;
                    this.mptbArticle.Enabled = false;
                    this.mptbArticle.Visible = false;
                    this.mpbCancel.Enabled = false;
                    this.mpbCancel.Visible = false;
                    this.mpbAdd.Enabled = true;
                    this.mpbFindAdd.Text = "Пошук " + HotKey.strPriceChecker_FindAdd;

                    Global.cTerminal.StartScan(this.scanBarcode);
                }
            }

            fillDataForm();
            if (varCodeWares != null)
                this.mplArticle.Text = varCodeWares.TrimStart('0');
              
        }
        private void btnCancel()
        {
            dr = null;
            fillDataForm();
            this.mptbArticle.Text = string.Empty;
            this.mplInfo.Text = string.Empty;
            this.mptbArticle.Visible = false;
            this.mptbArticle.Enabled = false;
            this.mpbCancel.Visible = false;
            this.mpbCancel.Enabled = false;
            try
            {
                Global.cTerminal.StartScan(this.scanBarcode);
            }
            catch
            {
            }
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