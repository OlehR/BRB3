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
    public partial class frmAdvSettingsDoc : Form
    {
        public frmAdvSettingsDoc()
        {
            InitializeComponent();
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            //this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();

            this.miExit.Text += " " + HotKey.strAdvSettingsDoc_Exit;
            this.mpbExit.Text += " " + HotKey.strAdvSettingsDoc_Exit;
            this.mpbSave.Text += " " + HotKey.strAdvSettingsDoc_Save;


            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;

            if (Global.eTypeTerminal == TypeTerminal.MotorolaMC75Ax)
            {
                this.mpbSave.Size = new System.Drawing.Size(138 * Global.tCoefficient, 50 * Global.tCoefficient);
                this.mpbExit.Size = new System.Drawing.Size(85 * Global.tCoefficient, 50 * Global.tCoefficient);
            }
        }

        private void AdvSettingsDoc_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;

        }

        #region Кнопки/функції ---------------------

        private void AdvSettingsDoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == HotKey.AdvSettingsDoc_Exit)
            {
                btnExit();
            }
            else if (e.KeyValue == HotKey.AdvSettingsDoc_Save)
            {
                btnSave();
            }

        }

        // Клік по пункту меню
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave();
        }
       

        // Функції
        private void btnExit()
        {
            this.Close();
        }
        private void btnSave()
        {
            clsDialogBox.InformationBoxShow("Save");
        }


        #endregion

       
    }
}