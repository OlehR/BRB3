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
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();

            this.miExit.Text += " " + HotKey.strSearch_Exit;

            this.mplDeviceName.Text = Global.eTypeTerminal.ToString() + " ";
            this.mplDeviceID.Text = " " + PocketID.GetDeviceID();
            
            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;
        }

        private void DocSearch_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
           
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