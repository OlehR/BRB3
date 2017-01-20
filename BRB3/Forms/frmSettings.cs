﻿using System;
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
            //this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();

            //this.miExit.Text += " " + HotKey.Settings_Exit;
            

            if (Global.eTypeTerminal ==TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            
        }

        #region Кнопки/функції ---------------------

        private void Settings_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == HotKey.Settings_Exit)
            //{
            //    btnExit();
            //}
            
        }

        // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //btnSave();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //btnCancel();
        }
        

        // Функції
        private void btnExit()
        {
            this.Close();
        }
        

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}