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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();

            this.miExit.Text += " " + HotKey.strSearch_Exit;

            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;
        }

        private void DocSearch_Load(object sender, EventArgs e)
        {
            string [] inventory = Global.ShopInventory.Split('-');
            if (inventory.Length == 2)
            {
                this.tctbTMInvDoc.Text = inventory[0];
                this.tctbTMInvTM.Text = inventory[1];
            }
            this.tclDeviceName.Text = " " + Global.eTypeTerminal.ToString();
            this.tclSerial.Text = " " + PocketID.GetDeviceID();
            this.tclTM.Text  = " " + Global.ShopName;
            this.tclFile.Text = " " + Global.RemouteFile;
            this.tclDownload.Text = " " + Global.Directory;
            this.tcdbBase.Text = Global.dbPathBRB;
            this.tcdbSync.Text = Global.ServiceUrl;
        }

        #region Кнопки/функції ---------------------

        private void DocSerch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.Search_Exit)
            {
                btnExit();
            }

        }

        // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }


        // Функції
        private void btnExit()
        {
            this.Close();
        }

        #endregion

   
    }
}