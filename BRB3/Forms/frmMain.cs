using System;

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
            
            this.Text = "BRB++ " + Global.eTypeTerminal.ToString();
            this.labelDown.Size = new System.Drawing.Size(236, (1 + Global.hToolbarTerminal));
            
            if (listView.Items.Count > 0)
            {
                listView.Items[0].Focused = true;
                listView.Items[0].Selected = true;
            }    
        }

        private void listView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.Main_Invoice)
            {
                btnInvoice();
            }
        }

        private void listView_ItemActivate(object sender, EventArgs e)
        {
            switch (listView.Items.IndexOf(listView.FocusedItem))
            {
                case 0:
                    btnInvoice();
                    break;
            }
        }

        private void btnInvoice()
        {
            try
            {
                frmDocGrid formDocGrid = new frmDocGrid(TypeDoc.Invoice);
                formDocGrid.Show();
            }
            catch (Exception ex)
            {
               // ViSoft.Common.clsException.EnableException(ex);
            }
            finally
            {
               // this.Text = ViSoft.Common.clsCommon.PropProgramCaption;
            }
        }
    }
}