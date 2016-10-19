using System;

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
            this.labelDown.Size = new System.Drawing.Size(236, (2 + Global.hToolbarTerminal));
            this.Text = "BRB++ " + Global.eTypeTerminal.ToString();

        }
    }
}