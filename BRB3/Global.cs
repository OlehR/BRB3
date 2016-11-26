using System;
using System.Runtime.InteropServices;
using System.Data;
namespace BRB
{
    public enum TypeTerminal
    {
     NoDetect=0,
     BitatekIT8000=1,
     MotorolaMC75Ax=2
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

        static public Data cData;
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

        public static void InitKeyMap(TypeTerminal parType)
        {
            varIniKeyMap = new ReadINI2(Global.varPathIni + @"Key.map");
            HotKey.Init( parType);
            
        }

    }

    /// <summary>
    /// Клас для роботою з гарячими клавішами 
    /// </summary>
    public class HotKey
    {
        static int MainIncome = 0;
        static int MainOutcome = 0;
        
        public static void Init( TypeTerminal parType)
        {
            string varNameSection = parType.ToString();
            MainIncome = Global.BildKeyCode(varNameSection, "MainIncome");
            MainOutcome = Global.BildKeyCode(varNameSection, "MainOutcome");
       
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
}