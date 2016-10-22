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

        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(236, (1 + Global.hToolbarTerminal));
            this.Text = "BRB++ " + Global.eTypeTerminal.ToString();
            //this.mplBorderDown.Location = new System.Drawing.Point(1, (263 - Global.hToolbarTerminal));
            //this.mplBorderLeft.Size = new System.Drawing.Size(1, (231 - Global.hToolbarTerminal));
            //this.mplBorderRight.Size = new System.Drawing.Size(1, (231 - Global.hToolbarTerminal));
                                    
        }
    }
}