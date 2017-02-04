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
            //this.labelDown.Size = new System.Drawing.Size(236 * Global.tCoefficient, (1 + Global.hToolbarTerminal) * Global.tCoefficient);
            this.Text = "BRB3 " + Global.eTypeTerminal.ToString();

            this.miExit.Text += " " + HotKey.strSearch_Exit;
            

            if (Global.eTypeTerminal == TypeTerminal.BitatekIT8000)
                this.WindowState = FormWindowState.Maximized;
        }

        private void DocSearch_Load(object sender, EventArgs e)
        {
            

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


        protected override void OnPaint(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            System.Windows.Forms.Label labelDraw = null;
            labelDraw = mplBarCodeCapt;
            e.Graphics.DrawLine(blackPen, labelDraw.Location.X - 1, labelDraw.Location.Y - 1, labelDraw.Location.X + labelDraw.Size.Width, labelDraw.Location.Y - 1); // верхняя
            e.Graphics.DrawLine(blackPen, labelDraw.Location.X - 1, labelDraw.Location.Y - 1, labelDraw.Location.X - 1, labelDraw.Location.Y + labelDraw.Size.Height); // левая
            e.Graphics.DrawLine(blackPen, labelDraw.Location.X + labelDraw.Size.Width, labelDraw.Location.Y - 1, labelDraw.Location.X + labelDraw.Size.Width, labelDraw.Location.Y + labelDraw.Size.Height); // правая
            e.Graphics.DrawLine(blackPen, labelDraw.Location.X - 1, labelDraw.Location.Y + labelDraw.Size.Height, labelDraw.Location.X + labelDraw.Size.Width, labelDraw.Location.Y + labelDraw.Size.Height); // нижняя

            e.Graphics.DrawLine(blackPen, 5, 20, 100, 20);
        }
        
        #endregion
    }
}