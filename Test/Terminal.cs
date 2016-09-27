using System;
//using System.Linq;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;
//using Microsoft.WindowsCE.Forms;

//using Symbol.Barcode2;
//using BCD.net;


/// <summary>
/// Віртуальний Універсальний клас для роботи з терміналами 
/// </summary>
    public class Terminal
    {
        public delegate void CallDelegate(string parBarcode);
        protected CallDelegate varCallBackBarcode; // это тот самый член-делегат :))

        public bool StartScan(CallDelegate parCallBackBarcode)
        {
            if (parCallBackBarcode == null )
                return false;

            varCallBackBarcode = parCallBackBarcode;
            return init();
        }
        public virtual bool init()
        {
            return false;
        }

        public bool StopScan()
        {
            varCallBackBarcode = null;
            close();
            return true;
        }

        public virtual void close()
        {
            //return false;
        }
    }

/// <summary>
/// MotorolaMC75Ax
/// </summary>
    class TerminalMotorola : Terminal 
    {
        

    }
/// <summary>
    /// Bitatek IT8000
/// </summary>
    class TerminalBitatek : Terminal  
    {
        

    }

 
