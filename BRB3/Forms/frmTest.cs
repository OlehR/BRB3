using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BRB.Forms
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            progressBar1.Value = 30;
           
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            System.Windows.Forms.Label labelDraw = null;
            labelDraw = mplBarCodeCapt;
            
            e.Graphics.DrawLine(blackPen, labelDraw.Location.X - 1, labelDraw.Location.Y - 1, labelDraw.Location.X + labelDraw.Size.Width, labelDraw.Location.Y - 1); // верхняя
            e.Graphics.DrawLine(blackPen, labelDraw.Location.X - 1, labelDraw.Location.Y - 1, labelDraw.Location.X - 1, labelDraw.Location.Y + labelDraw.Size.Height); // левая
            e.Graphics.DrawLine(blackPen, labelDraw.Location.X + labelDraw.Size.Width, labelDraw.Location.Y - 1, labelDraw.Location.X + labelDraw.Size.Width, labelDraw.Location.Y + labelDraw.Size.Height); // правая
            e.Graphics.DrawLine(blackPen, labelDraw.Location.X - 1, labelDraw.Location.Y + labelDraw.Size.Height, labelDraw.Location.X + labelDraw.Size.Width, labelDraw.Location.Y + labelDraw.Size.Height); // нижняя

            e.Graphics.DrawLine(blackPen, 5, 20, 200, 20);
        }

        private void frmTest_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}