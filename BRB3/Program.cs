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
          
            Global.Init(DefineTerminal.getOEMName());
            //Application.Run(new BRB.Forms.frmWaresScan());
            //SingleInstanceApplication.Run(new Forms.frmDocGrid(TypeDoc.SupplyLogistic));
            //SingleInstanceApplication.Run(new Forms.frmWaresGrid(TypeDoc.SupplyLogistic, 3699652));
            SingleInstanceApplication.Run(new Forms.frmMain());
            //SingleInstanceApplication.Run(new Forms.frmDocSearch());
            //SingleInstanceApplication.Run(new Forms.frmAdvSettingsDoc());
        }
    }
}