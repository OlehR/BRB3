using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Resco.Controls;

namespace BRB.Forms
{
    public partial class frmDocGrid : Form
    {
        public frmDocGrid(TypeDoc parTypeDoc)
        {
            DataTable dt = Global.cBL.LoadDocs(parTypeDoc);

            InitializeComponent();
            InitializeComponentManual();
        }

        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();
        }
    }
}