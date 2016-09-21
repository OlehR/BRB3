using System;
//using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BRB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

            this.textBox1.Text = NameTerminal.getOEMName().ToString();
            
            //Global.cTerminal.StartScan(null, null);
            //Global.cTerminal.StartScan(this.fig, this);
        }
        void fig(string a)
        {
          this.textBox1.Text = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.cTerminal.StartScan(this.fig);
            this.textBox1.Text = "Старт";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.cTerminal.StopScan();
            this.textBox1.Text = "Стоп";
        }


    }
}