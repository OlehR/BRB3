﻿using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BRB.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            InitializeComponentManual();
        }
         
        public void InitializeComponentManual()
        {

            res = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.imageList.ImageSize = new System.Drawing.Size(Global.icoSize, Global.icoSize);
            this.imageList.Images.Clear();
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_00_" + Global.icoSize.ToString())));
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_01_" + Global.icoSize.ToString())));
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_02_" + Global.icoSize.ToString())));
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_03_" + Global.icoSize.ToString())));
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_04_" + Global.icoSize.ToString())));
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_05_" + Global.icoSize.ToString())));
            this.imageList.Images.Add((System.Drawing.Icon)(res.GetObject("Ico_06_" + Global.icoSize.ToString())));

            this.Text = Global.curVersionBRB + " Головне меню"; //+ Global.eTypeTerminal.ToString();
            //this.labelDown.Size = new System.Drawing.Size(236, (1 + Global.hToolbarTerminal));

            this.lviInvoice.Text = HotKey.strMain_Invoice + " " + lviInvoice.Text;
            this.lviMAudit.Text = HotKey.strMain_MAudit + " " + lviMAudit.Text;
            this.lviPriceChecker.Text = HotKey.strMain_PriceChecker + " " + lviPriceChecker.Text;
            this.lviAudit.Text = HotKey.strMain_Audit + " " + lviAudit.Text;
            this.lviComponents.Text = HotKey.strMain_Components + " " + lviComponents.Text;
            this.lviSettings.Text = HotKey.strMain_Settings + " " + lviSettings.Text;

            this.miInvoice.Text += " " + HotKey.strMain_Invoice;
            this.miMAudit.Text += " " + HotKey.strMain_MAudit;
            this.miPriceChecker.Text += " " + HotKey.strMain_PriceChecker;
            this.miAudit.Text += " " + HotKey.strMain_Audit;
            this.miComponents.Text += " " + HotKey.strMain_Components;
            this.miSettings.Text += " " + HotKey.strMain_Settings;
            
            if (listView.Items.Count > 0)
            {
                listView.Items[0].Focused = true;
                listView.Items[0].Selected = true;
            }
        }

        #region Кнопки/функції ---------------------
        
        //По гарячих кнопках
        private void listView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.Main_Invoice)
            {
                btnNewDocGrid(TypeDoc.SupplyLogistic);
            }
            else if (e.KeyValue == HotKey.Main_MAudit)
            {
                btnNewDocGrid(TypeDoc.MiniInventories); //Міні ревізія
            }
            else if (e.KeyValue == HotKey.Main_PriceChecker)
            {
                btnNewPriceChecker();
            }
            else if (e.KeyValue == HotKey.Main_Audit)
            {
                btnNewDocGrid(TypeDoc.Inventories);
            }

            else if (e.KeyValue == HotKey.Main_Settings)
            {
                btnSettings();
            }
        }
        // Клік по пункту листа
        private void listView_ItemActivate(object sender, EventArgs e)
        {
            switch (listView.Items.IndexOf(listView.FocusedItem))
            {
                case 0:
                    btnNewDocGrid(TypeDoc.SupplyLogistic);
                    break;
                case 1:
                    btnNewDocGrid(TypeDoc.MiniInventories); // Переписати на мініревізію
                    break;
                case 2:
                    btnNewPriceChecker();
                    break;
                case 3:
                    btnNewDocGrid(TypeDoc.Inventories);
                    break;
                case 4:
                    btnSettings();
                    break;
            }
        }
        
            // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            btnNewDocGrid(TypeDoc.SupplyLogistic);
        }
        private void btnMAudit_Click(object sender, EventArgs e)
        {
            btnNewDocGrid(TypeDoc.MiniInventories); //Міні ревізія
        }
        private void btnPriceChecker_Click(object sender, EventArgs e)
        {
            btnNewPriceChecker();
        }
        private void btnAudit_Click(object sender, EventArgs e)
        {
            btnNewDocGrid(TypeDoc.Inventories);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnSettings();
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            btnAbout();
        }


        // функції
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

        private void btnNewDocGrid(TypeDoc typeDoc)
        {
            try
            {
                frmDocGrid formDocGrid = new frmDocGrid(typeDoc);
                formDocGrid.Show();
            }
            catch (Exception ex)
            {
                string er = ex.Message;
               // ViSoft.Common.clsException.EnableException(ex);
            }
            finally
            {
               // this.Text = ViSoft.Common.clsCommon.PropProgramCaption;
            }
        }
        private void btnNewPriceChecker()
        {
            try
            {
                frmPriceChecker formPriceChecker = new frmPriceChecker();
                formPriceChecker.Show();
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }
        }
        private void btnSettings()
        {
            try
            {
                frmSettings formSettings = new frmSettings();
                formSettings.Show();
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }
        }
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

        #endregion // Кнопки/функції
    }
}