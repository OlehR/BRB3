using System;
//using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
//using BRB.Run;

namespace BRB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
           // var f = new BRB.Form1();
            Global.Init(DefineTerminal.getOEMName());
            Application.Run(new BRB.Forms.frmMain());
            //SingleInstanceApplication.Run(new Forms.frmMain());
        }
    }
}