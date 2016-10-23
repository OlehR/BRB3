using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BRB.Forms
{
    public partial class frmWaresScan : Form
    {
        public frmWaresScan()
        {
            InitializeComponent();
            InitializeComponentManual();
        }
        /// <summary>
        /// Enablin Full Screen on Load Form Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWaresScan_Load(object sender, EventArgs e)
        {
            FullScreen.StartFullScreen(this);
        }

        /// <summary>
        /// Disabling FullScreen on Closing Main Form of Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWaresScan_Closing(object sender, CancelEventArgs e)
        {
            FullScreen.StopFullScreen(this);
        }
        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(100, (1 + Global.hToolbarTerminal));
            this.Text = "BRB++ " + Global.eTypeTerminal.ToString();
            //this.mplBorderDown.Location = new System.Drawing.Point(1, (263 - Global.hToolbarTerminal));
            //this.mplBorderLeft.Size = new System.Drawing.Size(1, (231 - Global.hToolbarTerminal));
            //this.mplBorderRight.Size = new System.Drawing.Size(1, (231 - Global.hToolbarTerminal));
            
                                    
        }

        
    }
}