using System;
//using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsCE.Forms;

using Symbol.Barcode2;
using BCD.net;


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
        private Symbol.Barcode2.Design.Barcode2 barcodeMoto = new Symbol.Barcode2.Design.Barcode2();

        public override bool init()
        {
            try
            {
                this.barcodeMoto.Config.DecoderParameters.CODABAR = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.CODABARParams.ClsiEditing = false;
                this.barcodeMoto.Config.DecoderParameters.CODABARParams.NotisEditing = false;
                this.barcodeMoto.Config.DecoderParameters.CODABARParams.Redundancy = true;
                this.barcodeMoto.Config.DecoderParameters.CODE128 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.CODE128Params.EAN128 = true;
                this.barcodeMoto.Config.DecoderParameters.CODE128Params.ISBT128 = true;
                this.barcodeMoto.Config.DecoderParameters.CODE128Params.Other128 = true;
                this.barcodeMoto.Config.DecoderParameters.CODE128Params.Redundancy = false;
                this.barcodeMoto.Config.DecoderParameters.CODE39 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.CODE39Params.Code32Prefix = false;
                this.barcodeMoto.Config.DecoderParameters.CODE39Params.Concatenation = false;
                this.barcodeMoto.Config.DecoderParameters.CODE39Params.ConvertToCode32 = false;
                this.barcodeMoto.Config.DecoderParameters.CODE39Params.FullAscii = false;
                this.barcodeMoto.Config.DecoderParameters.CODE39Params.Redundancy = false;
                this.barcodeMoto.Config.DecoderParameters.CODE39Params.ReportCheckDigit = false;
                this.barcodeMoto.Config.DecoderParameters.CODE39Params.VerifyCheckDigit = false;
                this.barcodeMoto.Config.DecoderParameters.CODE93 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.CODE93Params.Redundancy = false;
                this.barcodeMoto.Config.DecoderParameters.D2OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.D2OF5Params.Redundancy = true;
                this.barcodeMoto.Config.DecoderParameters.EAN13 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.EAN8 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.EAN8Params.ConvertToEAN13 = false;
                this.barcodeMoto.Config.DecoderParameters.I2OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.I2OF5Params.ConvertToEAN13 = false;
                this.barcodeMoto.Config.DecoderParameters.I2OF5Params.Redundancy = true;
                this.barcodeMoto.Config.DecoderParameters.I2OF5Params.ReportCheckDigit = false;
                this.barcodeMoto.Config.DecoderParameters.I2OF5Params.VerifyCheckDigit = Symbol.Barcode2.Design.I2OF5.CheckDigitSchemes.Default;
                this.barcodeMoto.Config.DecoderParameters.KOREAN_3OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.KOREAN_3OF5Params.Redundancy = true;
                this.barcodeMoto.Config.DecoderParameters.MSI = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.MSIParams.CheckDigitCount = Symbol.Barcode2.Design.CheckDigitCounts.Default;
                this.barcodeMoto.Config.DecoderParameters.MSIParams.CheckDigitScheme = Symbol.Barcode2.Design.CheckDigitSchemes.Default;
                this.barcodeMoto.Config.DecoderParameters.MSIParams.Redundancy = true;
                this.barcodeMoto.Config.DecoderParameters.MSIParams.ReportCheckDigit = false;
                this.barcodeMoto.Config.DecoderParameters.UPCA = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.UPCAParams.Preamble = Symbol.Barcode2.Design.Preambles.Default;
                this.barcodeMoto.Config.DecoderParameters.UPCAParams.ReportCheckDigit = true;
                this.barcodeMoto.Config.DecoderParameters.UPCE0 = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.DecoderParameters.UPCE0Params.ConvertToUPCA = false;
                this.barcodeMoto.Config.DecoderParameters.UPCE0Params.Preamble = Symbol.Barcode2.Design.Preambles.Default;
                this.barcodeMoto.Config.DecoderParameters.UPCE0Params.ReportCheckDigit = false;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimDuration = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.BeamTimer = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.DPMMode = Symbol.Barcode2.Design.DPM_MODE.DPM_MODE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusMode = Symbol.Barcode2.Design.FOCUS_MODE.FOCUS_MODE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusPosition = Symbol.Barcode2.Design.FOCUS_POSITION.FOCUS_POSITION_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.IlluminationMode = Symbol.Barcode2.Design.ILLUMINATION_MODE.ILLUMINATION_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCaptureTimeout = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCompressionTimeout = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.Inverse1DMode = Symbol.Barcode2.Design.INVERSE1D_MODE.INVERSE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistMode = Symbol.Barcode2.Design.PICKLIST_MODE.PICKLIST_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PointerTimer = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PoorQuality1DMode = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedback = Symbol.Barcode2.Design.VIEWFINDER_FEEDBACK.VIEWFINDER_FEEDBACK_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedbackTime = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFMode = Symbol.Barcode2.Design.VIEWFINDER_MODE.VIEWFINDER_MODE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Bottom = 0;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Left = 0;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Right = 0;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Top = 0;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimDuration = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamTimer = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamWidth = Symbol.Barcode2.Design.BEAM_WIDTH.DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BidirRedundancy = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ControlScanLed = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.DBPMode = Symbol.Barcode2.Design.DBP_MODE.DBP_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.KlasseEinsEnable = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.PointerTimer = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterHeight = -1;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterMode = Symbol.Barcode2.Design.RASTER_MODE.RASTER_MODE_DEFAULT;
                this.barcodeMoto.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ScanLedLogicLevel = Symbol.Barcode2.Design.DisabledEnabled.Default;
                this.barcodeMoto.Config.ScanParameters.BeepFrequency = 2670;
                this.barcodeMoto.Config.ScanParameters.BeepTime = 700;
                this.barcodeMoto.Config.ScanParameters.CodeIdType = Symbol.Barcode2.Design.CodeIdTypes.Default;
                this.barcodeMoto.Config.ScanParameters.LedTime = 700;
                this.barcodeMoto.Config.ScanParameters.ScanType = Symbol.Barcode2.Design.SCANTYPES.Default;
                this.barcodeMoto.Config.ScanParameters.WaveFile = "";
                this.barcodeMoto.DeviceType = Symbol.Barcode2.DEVICETYPES.FIRSTAVAILABLE;
                this.barcodeMoto.EnableScanner = true;
                this.barcodeMoto.OnScan += new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler(this.barcodeMoto_OnScan);
                //this.barcodeMoto.OnStatus += new Symbol.Barcode2.Design.Barcode2.OnStatusEventHandler(this.barcodeMoto_OnStatus);
            }
            catch //(Exception ex)
            {
                return false;
            //clsDialogBox.InformationBoxShow("Помилка");
            }
            return true;
        }
        private void barcodeMoto_OnScan(ScanDataCollection scanDataCollection)
        {
            ScanData scanData = scanDataCollection.GetFirst;
            if (scanData.Result == Results.SUCCESS)
            {
                varCallBackBarcode(scanData.Text);

            }
        }
        public override void close()
        {
            barcodeMoto.EnableScanner = false;
        }

    }
/// <summary>
    /// Bitatek IT8000
/// </summary>
    class TerminalBitatek : Terminal  
    {
        MsgWindow MsgWin = new MsgWindow();
        public override bool init()
        {
            try
            {
                return MsgWin.InitCallBack(varCallBackBarcode); 
            }
            catch
            {
                return false;
            }
        }
        public override void close()
        {
            MsgWin.Close();
        }
    
    }

    public class MsgWindow : MessageWindow
    {
        public const int WM_APP = 0x8000;
        public const int WM_USER = 0x0400;      //20090601 sdk++
        public const int WM_COMMAND = 0x0111;   //20090601 sdk++

        const byte SCAN_MESSAGE = 0x1A;
        const byte SCAN_KEYDOWN = 0x1B;
        const byte SCAN_KEYUP = 0x1C;
        const byte SCAN_GOTBARCODE = 0x1D;
        const byte SCAN_ON = 0x00;
        const byte SCAN_OFF = 0x01;


        public BCD.net.CBScanner BScanner = new BCD.net.CBScanner();

        public MsgWindow()
        {
            BScanner.AppControlBarcode(SCAN_ON);
            BScanner.CheckAPPControlBarcodeNoUsed();
            BScanner.AppControlBarcode(SCAN_OFF);
        }
        
        IntPtr IDM_RESUME = new IntPtr(WM_USER + 110);   //20090601 sdk++
        IntPtr IDM_SUSPEND = new IntPtr(WM_USER + 111);  //20090601 sdk++

        //public delegate void CallDelegate(string parBarcode);
        protected Terminal.CallDelegate varCallBackBarcode; // это тот самый член-делегат :))
        public bool InitCallBack(Terminal.CallDelegate parCallBackBarcode)
        {
            if(true /*BScanner.CheckAPPControlBarcodeNoUsed()*/)
            {
                if (varCallBackBarcode == null)
                {
                   BScanner.AppControlBarcode(SCAN_ON);
                    this.BScanner.InitBarcode();
                    varCallBackBarcode = parCallBackBarcode;
                }
                return true;
            }
            /*else
             { 
                varCallBackBarcode = null;
                return false;
             }*/
        }


        // Override the default WndProc behavior to examine messages.
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_APP:
                    SendMSG((byte)msg.WParam);
                    break;
                case WM_COMMAND:
                    break;
            }
            // Call the base WndProc method
            // to process any messages not handled.
            base.WndProc(ref msg);
        }

        public void SendMSG(byte x)
        { if(varCallBackBarcode!=null)
            switch (x)
            {
                case SCAN_KEYDOWN:
                    this.BScanner.StartBarcodeScan();
                    break;

                case SCAN_KEYUP:
                    this.BScanner.StopBarcodeScan();
                    break;

                case SCAN_GOTBARCODE:

                    if (varCallBackBarcode != null)
                        varCallBackBarcode(this.BScanner.GetPrefix() + this.BScanner.GetBarcodeData() + this.BScanner.GetSuffix());

                    break;

            }
        }

        public void Close()
        {
            if (varCallBackBarcode != null)
            {
                this.BScanner.CloseBarcode();
                //this.BScanner.AppControlBarcode(SCAN_OFF);
                varCallBackBarcode = null;
            }
           // this.BScanner.AppControlBarcode(SCAN_ON);
            this.BScanner.AppControlBarcode(SCAN_OFF);

        }

    }

 
