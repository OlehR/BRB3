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
    public partial class frmWaresGrid : Form
    {
        DataTable dt;

        public frmWaresGrid(TypeDoc parTypeDoc, int panNumberDoc)
        {
            dt = Global.cBL.LoadWaresDocs(parTypeDoc, panNumberDoc);
            InitializeComponent();
            InitializeComponentManual();
            this.Text = panNumberDoc.ToString();
        }

        public void InitializeComponentManual()
        {
            this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();
        }
    }
}