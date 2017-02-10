using System;
using System.Runtime.InteropServices;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
using System.ComponentModel;
using System.Text;

namespace BRB
{
    public enum TypeTerminal
    {
     NoDetect=0,
     BitatekIT8000=1,
     MotorolaMC75Ax=2,
     PitechLPT80 = 3
    }
    /// <summary>
    /// Тип документа:1-ЗНП,2-Міні-ревізія,3-Пер.Логістик,4-Перед.334,5-Списання,6-Поверн.Постач,7-Перед.забір.лист,9-Ревізія
    /// </summary>
    public enum TypeDoc
    {
        /// <summary>
        /// ЗНП
        /// </summary>
        Supply = 1,
        /// <summary>
        /// 2-Міні-ревізія
        /// </summary>
        MiniInventories = 2,
        /// <summary>
        /// 3-Пер.Логістик
        /// </summary>
        SupplyLogistic = 3,
        /// <summary>
        /// 4-Перед.334
        /// </summary>
        WriteOffInvoice334 = 4,
        /// <summary>
        /// 5-Списання
        /// </summary>
        WriteOffInvoice = 5,
        /// <summary>
        /// 6-Поверн.Постач
        /// </summary>
        InReturnInvoice = 6,
        /// <summary>
        /// 7-Перед.забір.лист
        /// </summary>
        WriteOffInvoiceProd = 7,
        /// <summary>
        /// 9-Ревізія
        /// </summary>
        Inventories = 9

        
  
      }

    public enum TypeStatusDoc
    {
        NoMark = 0,
        Mark = 1
    }
    
    static class Global
    {
        static public string varPathIni = @"\Program Files\brb3\";//\Program Files\brb3\
        /// <summary>
        /// Початок штрихкоду вагового товару
        /// </summary>
        static public string WeightBarCodeBegin="25";
        /// <summary>
        /// Кількість символів для коду товару в ваговому штрихкоді  InGoodsWidth=6
        /// </summary>
        static public int WeightBarCodeWares=6;
       
        /// <summary>
        /// Кількість символів для кількості товару в ваговому штрихкоді
        /// </summary>
        static public int WeightBarQtyChar=4;


        static public int PChBarCodeBegin = 29;
        static public int PChPrice2Pos = 14;


        /// <summary>
        /// Відхилення в % в кількості для вагового товару
        /// </summary>
        static public int WeightQtyPersent = 20;
        /// <summary>
        /// Чи обов'язково заповнювати інформацію по постачальнику номер дату)
        /// </summary>
        static public bool isControlDocSup = true;
        /// <summary>
        /// Чи можна вводити кількість більшу чим ЗНП.
        /// </summary>
        static public bool isQtyBiggerZNP = false;
        static public Data cData;
        static public BRB.BL cBL;
        static public Terminal cTerminal;
        static public TypeTerminal eTypeTerminal;
        static public int hToolbarTerminal = 0;
        static public int icoSize = 32;
        static public int tCoefficient = 1;
        //static public Single mainFont = 10F;
        public static string DeviceID=string.Empty;
        static public string dbPathBRB = @"\Program Files\BRB3\Database\BRB.sdf";
        static public string DbPwl = "";
        static public string SqlCeConectionBRB
         { get { return "Data Source = " + dbPathBRB + ";Password=" + DbPwl + ";"; }}
        static public string ServiceUrl = @"http://10.10.4.215/BRB_Sync/BRB_Sync.asmx";//@"http://vm/VsSyncMobile/VsSyncMobile.asmx";
     static public int ServiceTimeOut = 100000 ;   
    static public string ShopName ="6399";
    static public string SettingsPwl ="5744";
    static public DateTime TimeSync;
    static public string RemouteFile="BRB.exe";
    static public string Directory=@"\Download\";
        
    static public  ReadINI2 varIniKeyMap;

    static public void Init(TypeTerminal parTypeTerminal)
        {
            cData = new Data(new MSCeSQL(SqlCeConectionBRB));
            cBL = new BL(cData);
            eTypeTerminal = parTypeTerminal;
            InitKeyMap(eTypeTerminal);
            
            switch(parTypeTerminal)
            {
                case TypeTerminal.BitatekIT8000:
                    hToolbarTerminal = 25;
                    icoSize = 32;
                    tCoefficient = 1;
                    cTerminal = new TerminalBitatek();
                    break;

                case TypeTerminal.MotorolaMC75Ax:
                    hToolbarTerminal = 0;
                    icoSize = 64;
                    tCoefficient = 2;
                    cTerminal = new TerminalMotorola();
                    break;

                case TypeTerminal.PitechLPT80:
                    hToolbarTerminal = 0;
                    icoSize = 64;
                    tCoefficient = 1;
                    //TMP
                    //cTerminal = new TerminalPitech();
                    break;

            }
                
        }

    public static int BildKeyCode(string parSection, string parKeyName)
        {
            int varKeyCode = 0;
            string varStrKey = varIniKeyMap.GetSetting(parSection, parKeyName);
            if (varStrKey != null)
            {
                
                string[] varStrKeys = varStrKey.Split(new char[] { '+' });
                for (int i = 0; i < varStrKeys.Length; i++)
                    varKeyCode += Convert.ToInt32(varIniKeyMap.GetSetting("KeyCode", varStrKeys[i].Trim()));
            }
            return varKeyCode;
        }

    public static string BildStrKeyCode(string parSection, string parKeyName)
    {
        //int varKeyCode = 0;
        string varStrKey = varIniKeyMap.GetSetting(parSection, parKeyName);

        if (varStrKey != null)
        {
            return "[" + varStrKey.Trim() + "]";
        }
        else return "";
    }
        public static void InitKeyMap(TypeTerminal parType)
        {
            if (System.IO.File.Exists(Global.varPathIni + @"Key.map"))
            {
                varIniKeyMap = new ReadINI2(Global.varPathIni + @"Key.map");
                HotKey.Init(parType);
            }
            
        }

    }

    /// <summary>
    /// Клас для роботою з гарячими клавішами 
    /// </summary>
    public class HotKey
    {   
        public static int Up = 0;
        public static string strUP;
        public static int Down = 0;
        public static string strDown;
        public static int Enter = 0;
        public static string strEnter;
        public static int Main_Invoice = 0;
        public static string strMain_Invoice;
        public static int Main_MAudit = 0;
        public static string strMain_MAudit;
        public static int Main_PriceChecker = 0;
        public static string strMain_PriceChecker;
        public static int Main_Audit = 0;
        public static string strMain_Audit;
        public static int Main_Components = 0;
        public static string strMain_Components;
        public static int Main_Settings = 0;
        public static string strMain_Settings;

        public static int DocGrid_Exit = 0;
        public static string strDocGrid_Exit;
        public static int DocGrid_Wares = 0;
        public static string strDocGrid_Wares;
        public static int DocGrid_MarkDoc = 0;
        public static string strDocGrid_MarkDoc;
        public static int DocGrid_Filter = 0;
        public static string strDocGrid_Filter;
        public static int DocGrid_WaresScan = 0;
        public static string strDocGrid_WaresScan;
        public static int DocGrid_ExtraProperties = 0;
        public static string strDocGrid_ExtraProperties;
        public static int DocGrid_GroupingDoc = 0;
        public static string strDocGrid_GroupingDoc;
        public static int DocGrid_Sync = 0;
        public static string strDocGrid_Sync;
        public static int DocGrid_Settings = 0;
        public static string strDocGrid_Settings;

        public static int WaresGrid_Exit = 0;
        public static string strWaresGrid_Exit;
        public static int WaresGrid_Edit = 0;
        public static string strWaresGrid_Edit;
        public static int WaresGrid_Scan = 0;
        public static string strWaresGrid_Scan;
        public static int WaresGrid_Filter = 0;
        public static string strWaresGrid_Filter;

        public static int WaresScan_Add = 0;
        public static string strWaresScan_Add;
        public static int WaresScan_Cancel = 0;
        public static string strWaresScan_Cancel;
        public static int WaresScan_Exit = 0;
        public static string strWaresScan_Exit;

        public static int Search_Exit = 0;
        public static string strSearch_Exit;
        public static int Search_Select = 0;
        public static string strSearch_Select;
        public static int Search_Cancel = 0;
        public static string strSearch_Cancel;
        public static int Search_CancelFilter = 0;
        public static string strSearch_CancelFilter;

        public static int AdvSettingsDoc_Save = 0;
        public static string strAdvSettingsDoc_Save;
        public static int AdvSettingsDoc_Exit = 0;
        public static string strAdvSettingsDoc_Exit;

        public static int PriceChecker_Exit = 0;
        public static string strPriceChecker_Exit;
        public static int PriceChecker_About = 0;
        public static string strPriceChecker_About;
        public static int PriceChecker_Add = 0;
        public static string strPriceChecker_Add;
        public static int PriceChecker_FindAdd = 0;
        public static string strPriceChecker_FindAdd;
        public static int PriceChecker_Settings = 0;
        public static string strPriceChecker_Settings;
        public static int PriceChecker_Sync = 0;
        public static string strPriceChecker_Sync;
        public static int PriceChecker_Cancel = 0;
        public static string strPriceChecker_Cancel;
        
        
        public static void Init( TypeTerminal parType)
        {
            string varNameSection = parType.ToString();
            
            Up = Global.BildKeyCode(varNameSection, "Up");
            strUP = Global.BildStrKeyCode(varNameSection, "Up");
            Down = Global.BildKeyCode(varNameSection, "Down");
            strDown = Global.BildStrKeyCode(varNameSection, "Down");
            Enter = Global.BildKeyCode(varNameSection, "Enter");
            strEnter = Global.BildStrKeyCode(varNameSection, "Enter");
            Main_Invoice = Global.BildKeyCode(varNameSection, "Main_Invoice");
            strMain_Invoice = Global.BildStrKeyCode(varNameSection, "Main_Invoice");
            Main_MAudit = Global.BildKeyCode(varNameSection, "Main_MAudit");
            strMain_MAudit = Global.BildStrKeyCode(varNameSection, "Main_MAudit");
            Main_PriceChecker = Global.BildKeyCode(varNameSection, "Main_PriceChecker");
            strMain_PriceChecker = Global.BildStrKeyCode(varNameSection, "Main_PriceChecker");
            Main_Audit = Global.BildKeyCode(varNameSection, "Main_Audit");
            strMain_Audit = Global.BildStrKeyCode(varNameSection, "Main_Audit");
            Main_Components = Global.BildKeyCode(varNameSection, "Main_Components");
            strMain_Components = Global.BildStrKeyCode(varNameSection, "Main_Components");
            Main_Settings = Global.BildKeyCode(varNameSection, "Main_Settings");
            strMain_Settings = Global.BildStrKeyCode(varNameSection, "Main_Settings");
            Main_Settings = Global.BildKeyCode(varNameSection, "Main_Settings");
            strMain_Settings = Global.BildStrKeyCode(varNameSection, "Main_Settings");

            DocGrid_Exit = Global.BildKeyCode(varNameSection, "DocGrid_Exit");
            strDocGrid_Exit = Global.BildStrKeyCode(varNameSection, "DocGrid_Exit");
            DocGrid_Wares = Global.BildKeyCode(varNameSection, "DocGrid_Wares");
            strDocGrid_Wares = Global.BildStrKeyCode(varNameSection, "DocGrid_Wares");
            DocGrid_MarkDoc = Global.BildKeyCode(varNameSection, "DocGrid_MarkDoc");
            strDocGrid_MarkDoc = Global.BildStrKeyCode(varNameSection, "DocGrid_MarkDoc");
            DocGrid_Filter = Global.BildKeyCode(varNameSection, "DocGrid_Filter");
            strDocGrid_Filter = Global.BildStrKeyCode(varNameSection, "DocGrid_Filter");
            DocGrid_WaresScan = Global.BildKeyCode(varNameSection, "DocGrid_WaresScan");
            strDocGrid_WaresScan = Global.BildStrKeyCode(varNameSection, "DocGrid_WaresScan");
            DocGrid_ExtraProperties = Global.BildKeyCode(varNameSection, "DocGrid_ExtraProperties");
            strDocGrid_ExtraProperties = Global.BildStrKeyCode(varNameSection, "DocGrid_ExtraProperties");
            DocGrid_GroupingDoc = Global.BildKeyCode(varNameSection, "DocGrid_GroupingDoc");
            strDocGrid_GroupingDoc = Global.BildStrKeyCode(varNameSection, "DocGrid_GroupingDoc");
            DocGrid_Sync = Global.BildKeyCode(varNameSection, "DocGrid_Sync");
            strDocGrid_Sync = Global.BildStrKeyCode(varNameSection, "DocGrid_Sync");
            DocGrid_Settings = Global.BildKeyCode(varNameSection, "DocGrid_Settings");
            strDocGrid_Settings = Global.BildStrKeyCode(varNameSection, "DocGrid_Settings");

            WaresGrid_Exit = Global.BildKeyCode(varNameSection, "WaresGrid_Exit");
            strWaresGrid_Exit = Global.BildStrKeyCode(varNameSection, "WaresGrid_Exit");
            WaresGrid_Edit = Global.BildKeyCode(varNameSection, "WaresGrid_Edit");
            strWaresGrid_Edit = Global.BildStrKeyCode(varNameSection, "WaresGrid_Edit");
            WaresGrid_Scan = Global.BildKeyCode(varNameSection, "WaresGrid_Scan");
            strWaresGrid_Scan = Global.BildStrKeyCode(varNameSection, "WaresGrid_Scan");
            WaresGrid_Filter = Global.BildKeyCode(varNameSection, "WaresGrid_Filter");
            strWaresGrid_Filter = Global.BildStrKeyCode(varNameSection, "WaresGrid_Filter");

            WaresScan_Add = Global.BildKeyCode(varNameSection, "WaresScan_Add");
            strWaresScan_Add = Global.BildStrKeyCode(varNameSection, "WaresScan_Add");
            WaresScan_Cancel = Global.BildKeyCode(varNameSection, "WaresScan_Cancel");
            strWaresScan_Cancel = Global.BildStrKeyCode(varNameSection, "WaresScan_Cancel");
            WaresScan_Exit = Global.BildKeyCode(varNameSection, "WaresScan_Exit");
            strWaresScan_Exit = Global.BildStrKeyCode(varNameSection, "WaresScan_Exit");

            Search_Exit = Global.BildKeyCode(varNameSection, "Search_Exit");
            strSearch_Exit = Global.BildStrKeyCode(varNameSection, "Search_Exit");
            Search_Select = Global.BildKeyCode(varNameSection, "Search_Select");
            strSearch_Select = Global.BildStrKeyCode(varNameSection, "Search_Select");
            Search_Cancel = Global.BildKeyCode(varNameSection, "Search_Cancel");
            strSearch_Cancel = Global.BildStrKeyCode(varNameSection, "Search_Cancel");
            Search_CancelFilter = Global.BildKeyCode(varNameSection, "Search_CancelFilter");
            strSearch_CancelFilter = Global.BildStrKeyCode(varNameSection, "Search_CancelFilter");

            AdvSettingsDoc_Save = Global.BildKeyCode(varNameSection, "AdvSettingsDoc_Save");
            strAdvSettingsDoc_Save = Global.BildStrKeyCode(varNameSection, "AdvSettingsDoc_Save");
            AdvSettingsDoc_Exit = Global.BildKeyCode(varNameSection, "AdvSettingsDoc_Exit");
            strAdvSettingsDoc_Exit = Global.BildStrKeyCode(varNameSection, "AdvSettingsDoc_Exit");

            PriceChecker_Exit = Global.BildKeyCode(varNameSection, "PriceChecker_Exit");
            strPriceChecker_Exit = Global.BildStrKeyCode(varNameSection, "PriceChecker_Exit");
            PriceChecker_About = Global.BildKeyCode(varNameSection, "PriceChecker_About");
            strPriceChecker_About = Global.BildStrKeyCode(varNameSection, "PriceChecker_About");
            PriceChecker_Add = Global.BildKeyCode(varNameSection, "PriceChecker_Add");
            strPriceChecker_Add = Global.BildStrKeyCode(varNameSection, "PriceChecker_Add");
            PriceChecker_FindAdd = Global.BildKeyCode(varNameSection, "PriceChecker_FindAdd");
            strPriceChecker_FindAdd = Global.BildStrKeyCode(varNameSection, "PriceChecker_FindAdd");
            PriceChecker_Settings = Global.BildKeyCode(varNameSection, "PriceChecker_Settings");
            strPriceChecker_Settings = Global.BildStrKeyCode(varNameSection, "PriceChecker_Settings");
            PriceChecker_Sync = Global.BildKeyCode(varNameSection, "PriceChecker_Sync");
            strPriceChecker_Sync = Global.BildStrKeyCode(varNameSection, "PriceChecker_Sync");
            PriceChecker_Cancel = Global.BildKeyCode(varNameSection, "PriceChecker_Cancel");
            strPriceChecker_Cancel = Global.BildStrKeyCode(varNameSection, "PriceChecker_Cancel");
        }
    
    }
/*
    /// <summary>
    /// Глобальний клас з списком гарячих клавіш
    ///Tmp Необхідно буде доробити десерелізацію xml/json
    /// </summary>
    static class HotKey
    {
        static int MainIncome = 0;
        static int MainOutcome = 0;

        public static void Init(TypeTerminal parTypeTerminal)
        {
            switch (parTypeTerminal)
            {
                case TypeTerminal.BitatekIT8000:
                    //Ініціалізуємо гарячі клавіші
                    MainIncome = 0;
                    MainOutcome = 0;
                    break;

                case TypeTerminal.MotorolaMC75Ax:
                    MainIncome = 0;
                    MainOutcome = 0;
                    break;

            }
        }
    }
*/
    static class DefineTerminal
    {
        private const string MotorolaMC75A0 = "MOTOROLA MC75A";
        private const string BitatekIT8000 = "Intel MainstoneIII";
        private const string PitechLPT80 = "Freescale i.MX25 3DS";

        private const int SPI_GETOEMINFO = 258;
        private const int MAX_OEM_NAME_LENGTH = 128;
        private const int WCHAR_SIZE = 2;

        public static TypeTerminal getOEMName()
        {
            int numOfBytes = MAX_OEM_NAME_LENGTH * WCHAR_SIZE;

            char[] OEMNameChArr = new char[MAX_OEM_NAME_LENGTH];
            string OEMName = new string(OEMNameChArr);

            int status = SystemParametersInfo(SPI_GETOEMINFO, numOfBytes, OEMName, 0);

            if (System.Convert.ToBoolean(status)) // If the call has succeeded, return OEM Name. 
            {
                if (string.Compare(OEMName, MotorolaMC75A0) == 0)
                {
                    return TypeTerminal.MotorolaMC75Ax;
                }
                else if (string.Compare(OEMName, BitatekIT8000) == 0)
                {
                    return TypeTerminal.BitatekIT8000;
                }
                if (string.Compare(OEMName, PitechLPT80) == 0)
                {
                    return TypeTerminal.PitechLPT80;
                }
                else
                {
                    return TypeTerminal.NoDetect;
                }

            }
            else // If failed, return an empty.
            {
                return TypeTerminal.NoDetect;
            }

        }

        [DllImport("coreDLL.dll")]
        public static extern int SystemParametersInfo(int uiAction, int uiParam, string pBuf, int fWinIni);
    }

    class clsDialogBox
    {
        protected internal static DialogResult ErrorBoxShow(string message)
        {
            string text = message;
            string captionText = "Помилка!";

            return MessageBox.Show(text, captionText, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        protected internal static DialogResult InformationBoxShow(string message)
        {
            string text = message;
            string captionText = "Інформація!";

            return MessageBox.Show(text, captionText, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        protected internal static DialogResult ConfirmationBoxShow(string message)
        {
            string text = message;
            string captionText = "Увага!";

            return MessageBox.Show(text, captionText, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
    }

    //Повідомлення
    class clsException
    {
        protected internal static void EnableException(System.Exception ex)
        {
            string errorMessages = string.Empty;

            if (ex is SqlCeException) // ошибка SQL 
            {
                SqlCeException errSql = ex as SqlCeException;

                /*				if (errSql.Errors[0].Number == 17)
                                    errorMessages = "Нет соединения!";
                                else if (errSql.Errors[0].Number == 18456)
                                    errorMessages = "Ошибка аутентификации!";				
                                errorMessages += "\n";
                 * */
                for (int i = 0; i < errSql.Errors.Count; i++)
                {
                    errorMessages +=
                        ":" + errSql.Errors[i].Message;
                }
                errorMessages += "Ошибка SQL!";
            }
            else if (ex is IOException)
            {
                IOException errIO = ex as IOException;

                errorMessages += errIO.Message;
            }
            else
            {
                errorMessages += ex.Message;
            }

            clsDialogBox.ErrorBoxShow(errorMessages);
        }
    }

    public class PocketID
    {

        private static Int32 METHOD_BUFFERED = 0;
        private static Int32 FILE_ANY_ACCESS = 0;
        private static Int32 FILE_DEVICE_HAL = 0x00000101;

        private const Int32 ERROR_NOT_SUPPORTED = 0x32;
        private const Int32 ERROR_INSUFFICIENT_BUFFER = 0x7A;

        private static Int32 IOCTL_HAL_GET_DEVICEID =
            ((FILE_DEVICE_HAL) << 16) | ((FILE_ANY_ACCESS) << 14)
            | ((21) << 2) | (METHOD_BUFFERED);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool KernelIoControl(Int32 dwIoControlCode,
            IntPtr lpInBuf, Int32 nInBufSize, byte[] lpOutBuf,
            Int32 nOutBufSize, ref Int32 lpBytesReturned);

        public static string GetDeviceID()
        {
            // Initialize the output buffer to the size of a 
            // Win32 DEVICE_ID structure.
            byte[] outbuff = new byte[20];
            Int32 dwOutBytes;
            bool done = false;

            Int32 nBuffSize = outbuff.Length;

            // Set DEVICEID.dwSize to size of buffer.  Some platforms look at
            // this field rather than the nOutBufSize param of KernelIoControl
            // when determining if the buffer is large enough.
            BitConverter.GetBytes(nBuffSize).CopyTo(outbuff, 0);
            dwOutBytes = 0;

            // Loop until the device ID is retrieved or an error occurs.
            while (!done)
            {
                if (KernelIoControl(IOCTL_HAL_GET_DEVICEID, IntPtr.Zero,
                    0, outbuff, nBuffSize, ref dwOutBytes))
                {
                    done = true;
                }
                else
                {
                    int error = Marshal.GetLastWin32Error();
                    switch (error)
                    {
                        case ERROR_NOT_SUPPORTED:
                            throw new NotSupportedException(
                                "IOCTL_HAL_GET_DEVICEID is not supported on this device",
                                new Win32Exception(error));

                        case ERROR_INSUFFICIENT_BUFFER:

                            // The buffer is not big enough for the data.  The
                            // required size is in the first 4 bytes of the output
                            // buffer (DEVICE_ID.dwSize).
                            nBuffSize = BitConverter.ToInt32(outbuff, 0);
                            outbuff = new byte[nBuffSize];

                            // Set DEVICEID.dwSize to size of buffer.  Some
                            // platforms look at this field rather than the
                            // nOutBufSize param of KernelIoControl when
                            // determining if the buffer is large enough.
                            BitConverter.GetBytes(nBuffSize).CopyTo(outbuff, 0);
                            break;

                        default:
                            throw new Win32Exception(error, "Unexpected error");
                    }
                }
            }

            // Copy the elements of the DEVICE_ID structure.
            Int32 dwPresetIDOffset = BitConverter.ToInt32(outbuff, 0x4);
            Int32 dwPresetIDSize = BitConverter.ToInt32(outbuff, 0x8);
            Int32 dwPlatformIDOffset = BitConverter.ToInt32(outbuff, 0xc);
            Int32 dwPlatformIDSize = BitConverter.ToInt32(outbuff, 0x10);
            StringBuilder sb = new StringBuilder();

            for (int i = dwPlatformIDOffset;
                i < dwPlatformIDOffset + dwPlatformIDSize; i++)
            {
                sb.Append(String.Format("{0:X2}", outbuff[i]));
            }
            string id = sb.ToString();
            string cod = "";

            for (int i = 1; i < id.Length - 1; i = i + 2)
            {
                //cod = cod + id[i];
                if (id[i] >= '0' && id[i] <= '9') { cod = cod + id[i]; }
                else { cod = cod + (int)id[i]; }
            }
            return cod;
        }
    }

}