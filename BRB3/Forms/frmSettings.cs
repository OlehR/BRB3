using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;

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

        private void Settings_Load(object sender, EventArgs e)
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

        private void Settings_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.Search_Exit)
            {
                btnExit();
            }

        }
            
        private void btnCleanDB_Click(object sender, EventArgs e)
        {
         
            if (clsDialogBox.ConfirmationBoxShow("Очистити Базу даних? Всі дані будуть знищені!!! Ви впевнені?") == DialogResult.Yes)
            
            {
                this.tcdbBottonCleanDB.Enabled = false;
                this.tcdbProgressBar.Visible = true;
                this.tcdbProgressBar.Enabled = true;


                Status st = Global.cData.CreadeDB(showProgres);

                if (st.status == EStatus.DbCleaned)
                {
                    clsDialogBox.InformationBoxShow(st.StrStatus);

                    this.tcdbBottonCleanDB.Enabled = true;
                    this.tcdbProgressBar.Visible = false;
                    this.tcdbProgressBar.Enabled = false;
                }
                else
                {
                    clsDialogBox.ErrorBoxShow(st.StrStatus);

                    this.tcdbBottonCleanDB.Enabled = true;
                    this.tcdbProgressBar.Visible = false;
                    this.tcdbProgressBar.Enabled = false;
                }
            }
            else 

            {
                clsDialogBox.InformationBoxShow("Очистка бази відмінена.");
            }
        }

        // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }


        // Функції
        void showProgres(int parPercent)
        {
            this.tcdbProgressBar.Value = parPercent;
        }

        private void btnExit()
        {
            this.Close();
        }

        #endregion

   
    }
}