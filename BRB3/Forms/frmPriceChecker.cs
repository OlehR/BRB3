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

        private void DocSearch_Load(object sender, EventArgs e)
        {
            

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
            this.Close();
        }
        private void btnSync()
        {
            this.Close();
        }
        private void btnAdd()
        {
            this.Close();
        }
        private void btnFindAdd()
        {
            this.Close();
        }
        private void btnSettings()
        {
            this.Close();
        }


        #endregion
    }
}