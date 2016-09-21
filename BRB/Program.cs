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

            //tmp Необхідно визначити тип термінала
            Global.Init(NameTerminal.getOEMName()); //(TypeTerminal.MotorolaMC75Ax);
            //Application.Run(new Form1());
            SingleInstanceApplication.Run(new Form1());
           
        }
    }
}