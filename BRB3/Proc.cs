using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;
using ErikEJ.SqlCe;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Text;
using System.Collections;

public class MSCeSQL
{
    /// <summary>
    /// Код Помилки при роботі з MSSQL
    /// </summary>
    public int varCodeLastErrror;
    /// <summary>
    /// Текст Помилки при роботі з MSSQL
    /// </summary>
    public string varStrLstErrror;
    SqlCeConnection varSqlConnect;
    
    SqlCeCommand varCommand;
    SqlCeTransaction varTransaction;
    private List<SqlCeParameter> varListSqlParameter = new List<SqlCeParameter>();


    public MSCeSQL(string parConnectionString)
    {
        varSqlConnect = new SqlCeConnection(parConnectionString);
        varSqlConnect.Open(); //
    }
    
    public void Close()
    {
        varSqlConnect.Close();
    }

    /// <summary>
    /// Створює новий список параметрів і добавляє перший набір
    /// </summary>
    /// <param name="paramretrName">Назва параметра</param>
    /// <param name="value">значення параметра</param>
    public void AddWithValueF(string paramretrName, object value)
    {
        ClearParam();
        AddWithValue(paramretrName, value);
    }
    /// <summary>
    /// Очищає параметри
    /// </summary>
    public void ClearParam()
    {
        varListSqlParameter.Clear();        
    }


    /// <summary>
    /// Добавляє параметр в набір
    /// </summary>
    /// <param name="paramretrName">Назва параметра</param>
    /// <param name="value">значення параметра</param>

    public void AddWithValue(string paramretrName, object value)
    {
        SqlCeParameter varP = new SqlCeParameter(paramretrName, value);
        varListSqlParameter.Add(varP);
    }
    /// <summary>
    /// Провіряє чи в DataTable є хоба б один рядок
    /// </summary>
    /// <param name="parData">DataTable для провірки</param>
    /// <returns>true/false</returns>
    public bool IsData(DataTable parData)
    {
        return parData != null && parData.Rows.Count > 0 && parData.Rows[0] != null;
    }
    
    /// <summary>
    /// Запуск запита, який не вертає результат(UPDATE,INSERT)
    /// </summary>
    /// <param name="parSQL">Рядок з запитом</param>
    /// <returns>Кількість змінених рядків</returns>
    public int ExecuteNonQuery(string parSQL)
    {
        int varRez = 0;
        varCodeLastErrror = 0;
        varStrLstErrror = "";
        try
        {
            using (varTransaction = varSqlConnect.BeginTransaction())
            {
                using (varCommand = new SqlCeCommand(parSQL, varSqlConnect, varTransaction))
                {
                    foreach (SqlCeParameter par in varListSqlParameter)
                        varCommand.Parameters.Add(par);

                    varRez = varCommand.ExecuteNonQuery();
                    varTransaction.Commit();
                    return varRez;
                }
            }
        }
        catch (Exception e)
        {
            varCodeLastErrror = 1;
            varStrLstErrror = e.Message;
        }
        return varRez;

    }
    /// <summary>
    /// Запуск запита Select
    /// </summary>
    /// <param name="parSQL">>Рядок з запитом</param>
    /// <returns>Повертає DataTable з результатом</returns>
    public DataTable ExecuteQuery(string parSQL)
    {
        DataTable vaT = new DataTable();
        varCodeLastErrror = 0;
        varStrLstErrror = "";
        try
        {
            using (SqlCeCommand varCommand = new SqlCeCommand(parSQL, varSqlConnect))
            {
                foreach (SqlCeParameter par in varListSqlParameter)
                    varCommand.Parameters.Add(par);
                using (SqlCeDataAdapter da = new SqlCeDataAdapter(varCommand))
                { da.Fill(vaT); }
            }
        }
        catch (Exception e)
        {
            varCodeLastErrror = 1;
            varStrLstErrror = e.Message;
        }

        return vaT;
    }



    public object ExecuteScalar(string parSQL)
    {
        object vaT = null;
        varCodeLastErrror = 0;
        varStrLstErrror = "";
        try
        {
            using (SqlCeCommand varCommand = new SqlCeCommand(parSQL, varSqlConnect))
            {
                foreach (SqlCeParameter par in varListSqlParameter)
                    varCommand.Parameters.Add(par);
                using (SqlCeDataAdapter da = new SqlCeDataAdapter(varCommand))
                {
                    vaT = varCommand.ExecuteScalar();
                }
            }
        }
        catch (Exception e)
        {
            varCodeLastErrror = 1;
            varStrLstErrror = e.Message;
        }

        return vaT;
    }
    public string BulkInsert(DataTable x, string local_table)
    {
        SqlCeBulkCopyOptions options = new SqlCeBulkCopyOptions();
        options = options |= SqlCeBulkCopyOptions.KeepNulls;
        using (SqlCeBulkCopy bc = new SqlCeBulkCopy(varSqlConnect, options))
        {
            bc.DestinationTableName = local_table;
            try
            {
                //conn.Open();
                bc.WriteToServer(x);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                return ex.ToString() + local_table;
                //clsException.EnableException(ex);
            }
            finally
            {
                //conn.Close();
            }
            return null;
        }
    }

}

static class SingleInstanceApplication
{
    [DllImport("coredll.dll", SetLastError = true)]
    public static extern IntPtr CreateMutex(IntPtr Attr, bool Own, string Name);

    [DllImport("coredll.dll", SetLastError = true)]
    public static extern bool ReleaseMutex(IntPtr hMutex);

    const long ERROR_ALREADY_EXISTS = 183;

    public static void Run(Form frm)
    {
        string name = Assembly.GetExecutingAssembly().GetName().Name;
        IntPtr mutexHandle = CreateMutex(IntPtr.Zero, true, name);
        long error = Marshal.GetLastWin32Error();

        if (error != ERROR_ALREADY_EXISTS)
            Application.Run(frm);
        else
            /// Тимчасово
            cDialogBox.ErrorBoxShow( "Запуск другої копії програми заборонено!");

        ReleaseMutex(mutexHandle);
    }
}

public sealed class ConfigFile
	{
    // -----------------------------------------------------------------------------
    // ------------клас для зчитування і запису config файла програми---------------
    // -----------------------------------------------------------------------------
    
		#region LoadFile Section -------------------------------------------------------

		private string configFileName = null;
		private XmlDocument xmlDoc = new XmlDocument();

        public ConfigFile(string parConfigFileName)
        {
            if(string.IsNullOrEmpty(parConfigFileName))
               parConfigFileName = System.IO.Path.GetDirectoryName(
			        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ) +
			        System.IO.Path.DirectorySeparatorChar + 
			        System.IO.Path.GetFileNameWithoutExtension(
			        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ) + ".config";

            this.configFileName = parConfigFileName;
            // Проверим, есть ли такой файл - если нет, создадим
            if (!File.Exists(configFileName))
            {
                string strFile = @"<configuration>
									<appSettings>
										<add key=""DbPathBRB"" value=""\Program Files\BRB\Database\BRB.sdf"" />
                                        <add key=""DbPwl"" value="""" />
                                        <add key=""ServiceUrl"" value=""http://10.10.4.215/BRB_Sync/BRB_Sync.asmx"" />
                                        <add key=""ServiceTimeOut"" value=""100000"" />
                                        <add key=""ShopName"" value=""6399"" />
                                        <add key=""ShopInventory"" value=""6399"" />
                                        <add key=""SettingsPwl"" value=""5744"" />
                                        <add key=""RemouteFile"" value=""BRB.exe"" />
                                        <add key=""Directory"" value=""\Download\"" />                                        
									</appSettings>
								</configuration>";

                StreamWriter sw = null;
                try
                {
                    sw = File.CreateText(configFileName);
                    sw.Write(strFile);
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }

            this.xmlDoc.Load(this.configFileName);

        }
		/*public ConfigFile()
		{			      
		  

          this.ConfigFile(null);
		  
		}*/

	    #endregion ---------------------------------------------------------------------

		#region Config Section ---------------------------------------------------------

		public void AddConfigSection(string sectionName, string handlerClass)
		{
			XmlNode rootNode = this.xmlDoc.GetElementsByTagName("configuration").Item(0);
			
			// Create the configSections node if it doesn't exist as config sections need an entry in this node.
			XmlNode node = this.xmlDoc.DocumentElement["configSections"];
			
			if (node == null)
			{
				node = this.xmlDoc.CreateElement("configSections");
				if (rootNode.ChildNodes.Count > 0)
				{
					XmlNode firstChild = rootNode.FirstChild;
					rootNode.InsertBefore(node, firstChild);
				}
				else
				{
					rootNode.AppendChild(node);
				}
			}

			// Add the section into the configSections node
			XmlNode subNode = this.xmlDoc.CreateElement("section");
			subNode.Attributes.Append(this.xmlDoc.CreateAttribute("name")).Value = sectionName;
			subNode.Attributes.Append(this.xmlDoc.CreateAttribute("type")).Value = handlerClass;
			node.AppendChild(subNode);

			// Now create the actual section if it's not there.
			node = this.xmlDoc.DocumentElement[sectionName];
			if (node == null)
			{
				node = this.xmlDoc.CreateElement(sectionName);
				rootNode.AppendChild(node);
			}

			// Save the config file.
			this.xmlDoc.Save(this.configFileName);
		}
		
    // Check whether a configuration section exists
		private bool ConfigSectionExists(string sectionName)
		{
			return (this.xmlDoc.DocumentElement[sectionName] != null);
		}
	
    // Set an attribute in the configuration file
		public void SetConfigAttribute(string sectionName, string attributeName, string attributeValue, bool createIfNotExist)
		{
			// Get the section node
			XmlNode sectionNode = this.xmlDoc.DocumentElement[sectionName];
			
			XmlAttribute attr = sectionNode.Attributes[attributeName];

			if (attr == null)
			{
				if (!createIfNotExist)
				{
					// Leave it.
					return;
				}
				else
				{
					// Create the attribute.
					attr = this.xmlDoc.CreateAttribute(attributeName);
					sectionNode.Attributes.Append(attr);
				}
			}
			// Now set its value
			attr.Value = attributeValue;

			// Save the config file.
			this.xmlDoc.Save(this.configFileName);
		}

		public string GetConfigAttribute(string sectionName, string attributeName, bool createIfNotFound)
		{
			XmlNode sectionNode = this.xmlDoc.DocumentElement[sectionName];
			XmlAttribute attr = sectionNode.Attributes[attributeName];

			if (attr == null)
			{
				if (createIfNotFound)
				{
					attr = this.xmlDoc.CreateAttribute(attributeName);
					sectionNode.Attributes.Append(attr);
					this.xmlDoc.Save(this.configFileName);
				}
			}

			return (attr == null) ? "" : attr.Value;
		}

		#endregion // ------------------------------------------------------------------

		#region appSetting Section -----------------------------------------------------

		// Create an application setting
		public void CreateAppSetting(string settingName, string settingValue)
		{
			// Get the setting node, creating if it doesn't exist.
			XmlNode settingNode = GetAppSettingNode(settingName, true);

			// Set its value.
			settingNode.Attributes["value"].Value = settingValue;

			// Save changes
			this.xmlDoc.Save(this.configFileName);
		}

		// Add an application setting, and its value (if provided)
		// Returns created node.
		private  XmlNode AddAppSetting(string settingName, string settingValue)
		{
			// Get the appSettings node
			XmlNode appSettingsNode = this.xmlDoc.DocumentElement["appSettings"];

			// Create the key attribute
			XmlAttribute keyAttr = this.xmlDoc.CreateAttribute("key");
			keyAttr.Value = settingName;

			// Set is value
			XmlAttribute valueAttr = this.xmlDoc.CreateAttribute("value");
            valueAttr.Value = (settingValue == null) ? "" : settingValue;

			// Create the node for the setting
			XmlNode childNode = this.xmlDoc.CreateElement("add");
			childNode.Attributes.Append(keyAttr);
			childNode.Attributes.Append(valueAttr);
			
			// Add this to the appSettings node
			appSettingsNode.AppendChild(childNode);

			// Return the child.
			return childNode;
		}
	
    	public void SetAppSetting(string settingName, string settingValue, bool createIfNotExist)
		{
			// Get the section node
			//XmlNode sectionNode = this.xmlDoc.DocumentElement["appSettings"];

			XmlNode node = GetAppSettingNode(settingName, createIfNotExist);

			if (node != null)
			{
				node.Attributes["value"].Value = settingValue;
				this.xmlDoc.Save(this.configFileName);
			}
		}
		
        // Returns the node in the appSettings part with the given name.
		// Optional extra to create the node if it is not found.
		private XmlNode GetAppSettingNode(string settingName, bool createIfNotFound)
		{
			// Get the appSettings node
			XmlNode appSettingsNode = this.xmlDoc.DocumentElement["appSettings"];
			XmlNode foundNode = null;

			// Find node corresponding to the setting name
			foreach (XmlNode childNode in appSettingsNode.ChildNodes)
			{
				if (childNode.Attributes["key"].Value == settingName)
				{
					foundNode = childNode;
					break;
				}
			}

			// Did we find it?
			if (foundNode == null)
			{
				// Nope.
				if (createIfNotFound)
				{
					foundNode = AddAppSetting(settingName, null);
				}
			}

			return foundNode;
		}
      		
        // Returns an appSettings value, given its key
		public string  GetAppSetting(string settingName)
		{			
            XmlNode appSettingNode = GetAppSettingNode(settingName, false);

			return (appSettingNode == null) ? null : appSettingNode.Attributes["value"].Value;
		}

        // видаляє ноду з config файла
        public void RemoveAppSetting(string settingName)
        {
            XmlNode appSettingsNode = this.xmlDoc.DocumentElement["appSettings"];
            XmlNode foundNode = null;

            foreach (XmlNode childNode in appSettingsNode.ChildNodes)
            {
                if (childNode.Attributes["key"].Value == settingName)
                {
                    foundNode = childNode;
                    break;
                }
            }

            if (foundNode != null)
            {
                appSettingsNode.RemoveChild(foundNode);
                this.xmlDoc.Save(this.configFileName);
            }
        }

		#endregion ---------------------------------------------------------------------

    // -----------------------------------------------------------------------------
	}

public class FileVersionInfo
{
    #region Variables

    private string m_sFileName;
    private byte[] m_bytVersionInfo;

    #endregion

    #region Constants

    private const int GMEM_FIXED = 0x0000;
    private const int LMEM_ZEROINIT = 0x0040;
    private const int LPTR = (GMEM_FIXED | LMEM_ZEROINIT);

    #endregion

    #region Constructors

    ///

    /// Constructor.
    ///

    /// File name and path.
    private FileVersionInfo(string sFileName)
    {
        if (File.Exists(sFileName))
        {
            int iHandle = 0;
            int iLength = 0;
            int iFixedLength = 0;
            IntPtr ipFixedBuffer = IntPtr.Zero;
            m_bytVersionInfo = null;

            // Get the file information.
            m_sFileName = Path.GetFileName(sFileName);
            iLength = GetFileVersionInfoSize(sFileName, ref iHandle);

            if (iLength > 0)
            {
                // Allocate memory.
                IntPtr ipBuffer = AllocHGlobal(iLength);

                // Get the version information.
                if (GetFileVersionInfo(sFileName, iHandle, iLength, ipBuffer))
                {
                    // Get language independant version info.
                    if (VerQueryValue(ipBuffer, "\\", ref ipFixedBuffer, ref iFixedLength))
                    {
                        // Copy information to array.
                        m_bytVersionInfo = new byte[iFixedLength];
                        Marshal.Copy(ipFixedBuffer, m_bytVersionInfo, 0, iFixedLength);
                    }
                }
                // Free memory.
                FreeHGlobal(ipBuffer);
            }
        }
        else
        {
            m_bytVersionInfo = new byte[200];
        }
    }

    #endregion

    #region Properties

    ///
    /// Get the file build part.
    ///

    public int FileBuildPart
    {
        get
        {
            return Convert.ToInt32(BitConverter.ToInt16(m_bytVersionInfo, 14));
        }
    }

    ///
    /// Get the file major part.
    ///

    public int FileMajorPart
    {
        get
        {
            return Convert.ToInt32(BitConverter.ToInt16(m_bytVersionInfo, 10));
        }
    }

    ///
    /// Get the file minor part.
    ///

    public int FileMinorPart
    {
        get
        {
            return Convert.ToInt32(BitConverter.ToInt16(m_bytVersionInfo, 8));
        }
    }

    ///
    /// Get the name of the file.
    ///

    public string FileName
    {
        get
        {
            return m_sFileName;
        }
    }

    ///
    /// Get the file private part.
    ///

    public int FilePrivatePart
    {
        get
        {
            return Convert.ToInt32(BitConverter.ToInt16(m_bytVersionInfo, 12));
        }
    }

    ///
    /// Get the product build part.
    ///

    public int ProductBuildPart
    {
        get
        {
            return Convert.ToInt32(BitConverter.ToInt16(m_bytVersionInfo, 22));
        }
    }

    ///
    /// Get the product major part.
    ///

    public int ProductMajorPart
    {
        get
        {
            return Convert.ToInt32(BitConverter.ToInt16(m_bytVersionInfo, 18));
        }
    }

    ///
    /// Get the product minor part.
    ///

    public int ProductMinorPart
    {
        get
        {
            return Convert.ToInt32(BitConverter.ToInt16(m_bytVersionInfo, 16));
        }
    }

    ///
    /// Get the product private part.
    ///

    public int ProductPrivatePart
    {
        get
        {
            return Convert.ToInt32(BitConverter.ToInt16(m_bytVersionInfo, 20));
        }
    }

    #endregion

    #region Functions

    ///
    /// Allocate unmanged memory.
    ///

    /// Length to allocate.
    /// IntPtr object.
    private static IntPtr AllocHGlobal(int iLength)
    {
        return LocalAlloc(LPTR, (uint)iLength);
    }

    ///
    /// Free allocated memory.
    ///

    /// IntPtr object to free.
    private static void FreeHGlobal(IntPtr hGlobal)
    {
        LocalFree(hGlobal);
    }

    ///
    /// Get the file version information.
    ///

    /// File name and path.
    /// FileVersionInfo object.
    public static FileVersionInfo GetVersionInfo(string sFileName)
    {
        return new FileVersionInfo(sFileName);
    }

    ///
    /// Get the file version.
    ///
    public string ProductVersion
    {
        get
        {
            return ProductMajorPart + "." + ProductMinorPart + "." + ProductBuildPart + "." + ProductPrivatePart;
        }
    }

    #endregion

    #region Win32API

    [DllImport("coredll", EntryPoint = "GetFileVersionInfo", SetLastError = true)]
    private static extern bool GetFileVersionInfo(
    string filename,
    int handle,
    int len,
    IntPtr buffer);

    [DllImport("coredll", EntryPoint = "GetFileVersionInfoSize", SetLastError = true)]
    private static extern int GetFileVersionInfoSize(
    string filename,
    ref int handle);

    [DllImport("coredll.dll", EntryPoint = "LocalAlloc", SetLastError = true)]
    private static extern IntPtr LocalAlloc(
    uint uFlags,
    uint Bytes);

    [DllImport("coredll.dll", EntryPoint = "LocalFree", SetLastError = true)]
    private static extern IntPtr LocalFree(
    IntPtr hMem);

    [DllImport("coredll", EntryPoint = "VerQueryValue", SetLastError = true)]
    private static extern bool VerQueryValue(
    IntPtr buffer,
    string subblock,
    ref IntPtr blockbuffer,
    ref int len);

    #endregion
}

class cDialogBox
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





namespace Platform
{
    internal partial class PInvoke
    {
        #region Invoke  and Enums
        /// <summary>
        /// to find whether you are running on a Smartphone or a Pocket PC
        /// </summary>
        /// <param name="uiAction"></param>
        /// <param name="uiParam"></param>
        /// <param name="pvParam"></param>
        /// <param name="fWinIni"></param>
        /// <returns></returns>
        [DllImport("Coredll.dll", EntryPoint = "SystemParametersInfoW", CharSet = CharSet.Unicode)]
        static extern int SystemParametersInfo4Strings(uint uiAction, uint uiParam, StringBuilder pvParam, uint fWinIni);


        public enum SystemParametersInfoActions : uint
        {
            SPI_GETPLATFORMTYPE = 257, // this is used elsewhere for Smartphone/PocketPC detection

        }
        #endregion

        /// <summary>
        /// Get Platform Type: Pocket Pc or Windows CE
        /// </summary>
        /// <returns></returns>
        public static string GetPlatformType()
        {
            StringBuilder platformType = new StringBuilder(50);
            if (SystemParametersInfo4Strings((uint)SystemParametersInfoActions.SPI_GETPLATFORMTYPE,
                (uint)platformType.Capacity, platformType, 0) == 0)
                throw new Exception("Error getting platform type.");
            return platformType.ToString();
        }
    }

    /// <summary>
    /// Platform Detections methods
    /// </summary>
    internal partial class PlatformDetection
    {
        public static bool IsSmartphone()
        {
            return PInvoke.GetPlatformType() == "SmartPhone";
        }
        public static bool IsPocketPC()
        {
            return PInvoke.GetPlatformType() == "PocketPC";
        }
    }


}



public class ReadINI2
{

    private Hashtable keyPairs = new Hashtable();
    private String iniFilePath;

    private struct SectionPair
    {
        public String Section;
        public String Key;
    }

    /// <summary>
    /// Opens the INI file at the given path and enumerates the values in the IniParser.
    /// </summary>
    /// <param name="iniPath">Full path to INI file.</param>
    public ReadINI2(String iniPath)
    {
        TextReader iniFile = null;
        String strLine = null;
        String currentRoot = null;
        String[] keyPair = null;

        iniFilePath = iniPath;

        if (File.Exists(iniPath))
        {
            try
            {
                iniFile = new StreamReader(iniPath);

                strLine = iniFile.ReadLine();

                while (strLine != null)
                {
                    strLine = strLine.Trim().ToUpper();

                    if (strLine != "")
                    {
                        if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                        {
                            currentRoot = strLine.Substring(1, strLine.Length - 2);
                        }
                        else
                        {
                            keyPair = strLine.Split(new char[] { '=' });

                            SectionPair sectionPair;
                            String value = null;

                            if (currentRoot == null)
                                currentRoot = "ROOT";

                            sectionPair.Section = currentRoot;
                            sectionPair.Key = keyPair[0].Trim();

                            if (keyPair.Length > 1)
                                value = keyPair[1].Trim();

                            keyPairs.Add(sectionPair, value);
                        }
                    }

                    strLine = iniFile.ReadLine();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (iniFile != null)
                    iniFile.Close();
            }
        }
        else
            throw new FileNotFoundException("Unable to locate " + iniPath);

    }

    /// <summary>
    /// Returns the value for the given section, key pair.
    /// </summary>
    /// <param name="sectionName">Section name.</param>
    /// <param name="settingName">Key name.</param>
    public String GetSetting(String sectionName, String settingName)
    {
        /*        	if (settingName==null || sectionName ==null)
                        return null;*/
        SectionPair sectionPair;
        sectionPair.Section = sectionName.ToUpper().Trim();
        sectionPair.Key = settingName.ToUpper().Trim();

        return (String)keyPairs[sectionPair];

    }

    /// <summary>
    /// Enumerates all lines for given section.
    /// </summary>
    /// <param name="sectionName">Section to enum.</param>
    public String[] EnumSection(String sectionName)
    {
        ArrayList tmpArray = new ArrayList();

        foreach (SectionPair pair in keyPairs.Keys)
        {
            if (pair.Section == sectionName.ToUpper())
                tmpArray.Add(pair.Key);
        }

        return (String[])tmpArray.ToArray(typeof(String));
    }

    /// <summary>
    /// Adds or replaces a setting to the table to be saved.
    /// </summary>
    /// <param name="sectionName">Section to add under.</param>
    /// <param name="settingName">Key name to add.</param>
    /// <param name="settingValue">Value of key.</param>
    public void AddSetting(String sectionName, String settingName, String settingValue)
    {
        SectionPair sectionPair;
        sectionPair.Section = sectionName.ToUpper();
        sectionPair.Key = settingName.ToUpper();

        if (keyPairs.ContainsKey(sectionPair))
            keyPairs.Remove(sectionPair);

        keyPairs.Add(sectionPair, settingValue);
    }

    /// <summary>
    /// Adds or replaces a setting to the table to be saved with a null value.
    /// </summary>
    /// <param name="sectionName">Section to add under.</param>
    /// <param name="settingName">Key name to add.</param>
    public void AddSetting(String sectionName, String settingName)
    {
        AddSetting(sectionName, settingName, null);
    }

    /// <summary>
    /// Remove a setting.
    /// </summary>
    /// <param name="sectionName">Section to add under.</param>
    /// <param name="settingName">Key name to add.</param>
    public void DeleteSetting(String sectionName, String settingName)
    {
        SectionPair sectionPair;
        sectionPair.Section = sectionName.ToUpper();
        sectionPair.Key = settingName.ToUpper();

        if (keyPairs.ContainsKey(sectionPair))
            keyPairs.Remove(sectionPair);
    }

    /// <summary>
    /// Save settings to new file.
    /// </summary>
    /// <param name="newFilePath">New file path.</param>
    public void SaveSettings(String newFilePath)
    {
        ArrayList sections = new ArrayList();
        String tmpValue = "";
        String strToSave = "";

        foreach (SectionPair sectionPair in keyPairs.Keys)
        {
            if (!sections.Contains(sectionPair.Section))
                sections.Add(sectionPair.Section);
        }

        foreach (String section in sections)
        {
            strToSave += ("[" + section + "]\r\n");

            foreach (SectionPair sectionPair in keyPairs.Keys)
            {
                if (sectionPair.Section == section)
                {
                    tmpValue = (String)keyPairs[sectionPair];

                    if (tmpValue != null)
                        tmpValue = "=" + tmpValue;

                    strToSave += (sectionPair.Key + tmpValue + "\r\n");
                }
            }

            strToSave += "\r\n";
        }

        try
        {
            TextWriter tw = new StreamWriter(newFilePath);
            tw.Write(strToSave);
            tw.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Save settings back to ini file.
    /// </summary>
    public void SaveSettings()
    {
        SaveSettings(iniFilePath);
    }

    public String GetCountValue(String sectionName)
    {
        int i = 0;
        string s = String.Empty;
        foreach (DictionaryEntry de in keyPairs)
        {
            i++;
            if (i == 1)
            {
                s = "Key = " + de.Key + ", Value = " + de.Value;
            }
        }
        return s;
    }
}