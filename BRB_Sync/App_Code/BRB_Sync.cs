using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.IO;
using System.Diagnostics;
using System.Reflection;

[WebService(Namespace = "http://pakko.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class BRB_Sync : System.Web.Services.WebService
{
	// --------------------------------------------------------------------------------------


    public BRB_Sync() 
	{
    }

	[WebMethod(Description = "Вказує розробника і версію сервісу")]
	public string GetServiceVersion()
	{
		return " Pakko Holding, 2017, BRB(C) Версія:  3.0 " ;        
	}

    [WebMethod(Description = "Вказує версію файла на сервері")]
    public string GetFileVersion()
    {
        string file = "BRB.exe";
        string ss = string.Empty;
        ss = GetFileVersionNew(file);
        return ss;
    }

    [WebMethod(Description = "Вказує версію файла на сервері по назві файла")]
    public string GetFileVersionNew(string file)
    {
        string ss = string.Empty;
        string folder = System.Configuration.ConfigurationManager.AppSettings["FolderForFile"];
        if (folder == string.Empty)
            folder = @"C:";
        string sFilePath = folder + "\\" + file;
        try
        {
            ss = Assembly.LoadFile(sFilePath).GetName().Version.ToString();
        }
        catch (Exception ex)
        {
            ss = file + "-" +/*ex.ToString() + */ sFilePath;
        }
        return ss;
    }

    [WebMethod(Description = "Загружає файл на термінал")]
    public byte[] GetFile(string file)
    {
        string folder = System.Configuration.ConfigurationManager.AppSettings["FolderForFile"];
        if (folder == string.Empty)
            folder = @"C:";
        string sFilePath = folder + "\\" + file;

        FileStream stream = new FileStream(sFilePath, FileMode.Open, FileAccess.Read);
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, (int)stream.Length);
        stream.Close();

        return buffer;
    }    

	[WebMethod(Description = "Провірка з'єднання з БД")]
	public string TestConnectionToDbServer()
	{
		string returnValue = string.Empty;
		string providerName = string.Empty;
		string connectionString = string.Empty;
		
		// Вибираем настройки з config-файла
		providerName = System.Configuration.ConfigurationManager.AppSettings["ProviderName"];
		connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        if (providerName == "ORACLE")
		{
			OracleConnection conn = new OracleConnection(connectionString);
			try
			{
				conn.Open();
				returnValue = "З'єднання з БД Oracle успішно встановлено";
			}
			finally
			{
				conn.Close();
			}
		}

		return returnValue;
	}

    [WebMethod(Description = "Загружає ціни на термінал")]
    public DataSet LoadCheckPrices(DataSet dsTerm, string pocketName, string shopName)
    {
        DataTable dtTerm = dsTerm.Tables["dtCheckPrices"];

        DataTable dtServer;
        DataTable dtSettings;

        // Таблица, вычитанная с сервера
        dtServer = new DataTable("CheckPrices");

        dtServer.Columns.Add("cpID", typeof(string));
        dtServer.Columns.Add("cpGoodsName", typeof(string));
        dtServer.Columns.Add("cpGoodsArticle", typeof(string));
        dtServer.Columns.Add("cpBarcode", typeof(string));
        dtServer.Columns.Add("cpPrice1", typeof(decimal));
        dtServer.Columns.Add("cpPrice2", typeof(decimal));
        dtServer.Columns.Add("Action", typeof(int));

        dtServer.PrimaryKey = new DataColumn[] { dtServer.Columns["cpID"] };

        // Таблиця параметрів
        dtSettings = new DataTable("Settings");

        dtSettings.Columns.Add("pocket_id", typeof(string));
        dtSettings.Columns.Add("code_shop", typeof(string));

        //dtSettings.PrimaryKey = new DataColumn[] { dtSettings.Columns["pocked_id"]};

        // --------------------------------------------------------------------------------------------------

        // Вычитаем настройки из config
        string providerName = System.Configuration.ConfigurationManager.AppSettings["ProviderName"];
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        string folder = System.Configuration.ConfigurationManager.AppSettings["PathToLogFolder"];

        // соберем имя файла
        string strMessage = "";

        string sMonth = DateTime.Now.Date.Month.ToString();
        if (sMonth.Length == 1) sMonth = "0" + sMonth;

        string sDay = DateTime.Now.Date.Day.ToString();
        if (sDay.Length == 1) sDay = "0" + sDay;

        string sHour = DateTime.Now.Hour.ToString();
        if (sHour.Length == 1) sHour = "0" + sHour;

        string sMinute = DateTime.Now.Minute.ToString();
        if (sMinute.Length == 1) sMinute = "0" + sMinute;

        string sSecond = DateTime.Now.Second.ToString();
        if (sSecond.Length == 1) sSecond = "0" + sSecond;

        string sFilePath = DateTime.Today.Date.Year.ToString() + sMonth + sDay + "-" +
        sHour + "" + sMinute + "" + sSecond + ".txt";

        // Добавим доп. инфу
        strMessage = "Дата: " + DateTime.Now.ToString() + "\n";

        if (folder == string.Empty)
            folder = @"C:";

        sFilePath = folder + "\\" + sFilePath;

        // Вычитаем сюда всю таблицу с сервера --------------------------------------------------------------

        if (providerName == "MSSQL")
        {
        }

        else if (providerName == "ORACLE")
        {
            // Если сервер - ORACLE
            OracleConnection conn = new OracleConnection(connectionString);
            string sqlPriceCheck = @"select    to_char(tt.code_wares) || '-' ||
                                               to_char(nvl(bcau.bar_code,
                                                           row_number()
                                                           over(partition by w.code_wares order by w.code_wares))) cpID,
                                               substr(w.name_wares, 1, 100) cpGoodsName,
                                               to_char(w.code_wares) cpGoodsArticle,
                                               bcau.bar_code cpBarcode,
                                               nvl(round(tt.price_promotion* (1 + w.vat / 100) * au.coefficient,2),nvl(round(pd.price_dealer * (1 + w.vat / 100) * au.coefficient, 2),
                                                   0)) cpPrice1,
                                               nvl(round(tt.price_promotion* (1 + w.vat / 100) * au.coefficient,2),nvl(round(pdo.price_dealer * (1 + w.vat / 100) * au.coefficient, 2),
                                                   0)) cpPrice2,    
                                               tt.code_shop
                                          from spr.wares w, spr.addition_unit au
                                          left join spr.bar_code_additional_unit bcau
                                            on au.code_wares = bcau.code_wares
                                           and au.code_unit = bcau.code_unit,
                                         (select code_shop, code_wares, code_dealer, code_subgroup, c.pricesupplier.GetPricePromotionSale(code_shop, code_wares) price_promotion
                                                  from (select la.code_shop,
                                                               la.code_wares,
                                                               ss.code_dealer,
                                                               ss.code_subgroup
                                                          from c.list_assortment la,
                                                               c.data_name       dn,
                                                               spr.subgroup_shop ss
                                                         where ss.code_shop = la.code_shop
                                                           and la.quantity_min >= 0
                                                           and la.code_shop = dn.n01
                                                           and dn.code_data = to_number(:pocket_id)
                                                           and dn.data_level = 502
                                                        union all
                                                        select ss.code_shop,
                                                               ww.code_wares,
                                                               ss.code_dealer,
                                                               ss.code_subgroup
                                                          from mz.wares_warehouse ww,
                                                               spr.subgroup_shop  ss,
                                                               c.data_name        dn
                                                         where dn.code_data = to_number(:pocket_id)
                                                           and dn.data_level = 502
                                                           and ww.code_shop = dn.n01
                                                           and ss.code_shop = ww.code_shop
                                                           and ww.code_subgroup = 2
                                                           and ww.code_subgroup = ss.code_subgroup)
                                                 group by code_shop, code_wares, code_dealer, code_subgroup) tt
                                          left join spr.price_dealer pd
                                            on (tt.code_dealer = pd.code_dealer and
                                               tt.code_subgroup = pd.code_subgroup and
                                               tt.code_wares = pd.code_wares)
                                          left join spr.price_dealer pdo
                                            on (spr.pack_opts.opts_get_vchar_value(111000126, tt.code_shop) =
                                               pdo.code_dealer and tt.code_subgroup = pdo.code_subgroup and
                                               tt.code_wares = pdo.code_wares)
                                         where w.code_wares = tt.code_wares
                                           and au.code_wares = decode(w.code_wares_relative,
                                                                      Null,
                                                                      w.code_wares,
                                                                      w.code_wares_relative)
                                           and (au.default_unit = 'Y' or au.sign_activity = 'Y')
                                           and (pd.PRICE_DEALER > 0 or pdo.price_dealer > 0)";
            OracleDataAdapter PriceCheck = new OracleDataAdapter(sqlPriceCheck, conn);
            PriceCheck.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocketName;

            string sqlSettings = @"select listagg(t.code_shop, ',') within group(order by t.code_shop) code_shop,
                                           sysdate time_sync
                                      from (select ml.link_to code_shop
                                              from c.data_name dn
                                              left join c.multi_link ml
                                                on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                             where dn.code_data = to_number(:pocket_id)
                                               and dn.data_level = 502
                                            union all
                                            select dn.n01 code_shop
                                              from c.data_name dn
                                             where dn.code_data = to_number(:pocket_id)
                                               and dn.data_level = 502) t";
            OracleDataAdapter Settings = new OracleDataAdapter(sqlSettings, conn);
            Settings.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocketName;
            try
            {
                conn.Open();
                PriceCheck.Fill(dtServer);
                Settings.Fill(dtSettings);
            }
            catch (System.Exception ex)
            {
                // Запишем в текстовый лог - не смогли установить соединение
                File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);
            }
            finally
            {
                conn.Close();
            }
        }

        DataSet dsReturn = new DataSet("dsCheckPrices");
        dsReturn.Tables.Add(dtServer);
        dsReturn.Tables.Add(dtSettings);
        return dsReturn;
    }

    [WebMethod(Description = "Вигружає на сервер результат сканування цінників")]
    public DataSet UpLoadPriceLogs(DataSet dsTerm, string pocketName, string shopName)
    {
        DataSet dsReturn = new DataSet("dsReturn");
        DataTable dtReturn;
        DataTable dtSettings;

        // Таблиця, яка вказує на шапки не вставлених в ORACLE документів
        dtReturn = new DataTable("dtReturn");
        dtReturn.Columns.Add("clID", typeof(string));
        dtReturn.Columns.Add("clGoodsArticle", typeof(string));
        dtReturn.PrimaryKey = new DataColumn[] { dtReturn.Columns["clID"] };

        dsReturn.Tables.Add(dtReturn);

        dtSettings = new DataTable("dtSettings");
        dtSettings.Columns.Add("code_shop", typeof(int));
        dsReturn.Tables.Add(dtSettings);

        int Shop = 0;

        // --------------------------------------------------------------------------------------------------

        // Вычитаем настройки из config
        string providerName = System.Configuration.ConfigurationManager.AppSettings["ProviderName"];
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        string folder = System.Configuration.ConfigurationManager.AppSettings["PathToLogFolder"];

        // соберем имя файла
        string strMessage = "";

        string sMonth = DateTime.Now.Date.Month.ToString();
        if (sMonth.Length == 1) sMonth = "0" + sMonth;

        string sDay = DateTime.Now.Date.Day.ToString();
        if (sDay.Length == 1) sDay = "0" + sDay;

        string sHour = DateTime.Now.Hour.ToString();
        if (sHour.Length == 1) sHour = "0" + sHour;

        string sMinute = DateTime.Now.Minute.ToString();
        if (sMinute.Length == 1) sMinute = "0" + sMinute;

        string sSecond = DateTime.Now.Second.ToString();
        if (sSecond.Length == 1) sSecond = "0" + sSecond;

        string sFilePath = DateTime.Today.Date.Year.ToString() + sMonth + sDay + "-" +
        sHour + "" + sMinute + "" + sSecond + ".txt";

        // Добавимо дод. инфу
        strMessage = "Дата: " + DateTime.Now.ToString() + "\n";

        if (folder == string.Empty)
            folder = @"C:";

        sFilePath = folder + "\\" + sFilePath;

        // --------------------------------------------------------------------------------------------------

        if (providerName == "ORACLE")
        {
            // Якщо сервер - ORACLE
            OracleConnection conn = new OracleConnection(connectionString);
            OracleCommand cmdHead = new OracleCommand(@"insert into c.price_check
                                                          (id_input_session, code_wares, barcode, status, serial_tzd, code_shop)
                                                        values
                                                          (:id_input_session,
                                                           :code_wares,
                                                           :barcode,
                                                           :status,
                                                           :serial_tzd,
                                                           :code_shop)", conn);
            cmdHead.Parameters.Add("id_input_session", OracleType.Number);
            cmdHead.Parameters.Add("code_wares", OracleType.Number);
            cmdHead.Parameters.Add("barcode", OracleType.NVarChar);
            cmdHead.Parameters.Add("status", OracleType.Number);
            cmdHead.Parameters.Add("serial_tzd", OracleType.NVarChar);
            cmdHead.Parameters.Add("code_shop", OracleType.Number);

            OracleDataAdapter cmdShop = new OracleDataAdapter(@"select dn.n01 code_shop
                                                                  from c.data_name dn
                                                                 where dn.data_level = 502
                                                                   and dn.code_data = to_number(:pocketName)
                                                                   and rownum = 1", conn);
            cmdShop.SelectCommand.Parameters.Add("pocketName", OracleType.NVarChar).Value = pocketName;

            OracleTransaction tran = null;
            try
            {
                conn.Open();

                cmdShop.Fill(dsReturn.Tables["dtSettings"]);

                if (dsReturn.Tables["dtSettings"].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsReturn.Tables["dtSettings"].Rows)
                    {
                        Shop = Convert.ToInt32(dr["code_shop"]);
                    }
                }

                // Проаналізуємо всі строки і вставимо результат сканування
                foreach (DataRow drHead in dsTerm.Tables["dtCheckLogs"].Rows)
                {
                    try
                    {
                        tran = conn.BeginTransaction();

                        // Збережемо строку сканування
                        cmdHead.Transaction = tran;
                        cmdHead.Parameters["id_input_session"].Value = Convert.ToInt32(drHead["clID"]);
                        try
                        {
                            cmdHead.Parameters["code_wares"].Value = Convert.ToInt32(drHead["clGoodsArticle"]);
                        }
                        catch
                        {
                            cmdHead.Parameters["code_wares"].Value = DBNull.Value;
                        }
                        cmdHead.Parameters["barcode"].Value = drHead["clBarcode"];
                        cmdHead.Parameters["status"].Value = Convert.ToInt32(drHead["clStatus"]);
                        cmdHead.Parameters["serial_tzd"].Value = pocketName;
                        cmdHead.Parameters["code_shop"].Value = Shop;

                        cmdHead.ExecuteNonQuery();

                        // Закомітимо
                        tran.Commit();
                    }
                    catch (System.Exception ex)
                    {
                        File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);
                        if (tran != null)
                            tran.Rollback();

                        // вернемо строку, яка не вставилась
                        DataRow row = dsReturn.Tables["dtReturn"].NewRow();
                        row["clID"] = drHead["clID"];
                        row["clGoodsArticle"] = drHead["clGoodsArticle"];
                        dsReturn.Tables["dtReturn"].Rows.Add(row);
                    }
                }
            }
            catch (System.Exception ex)
            {
                // Запишемо в текстовий лог - не змогли встановити з'єднання
                File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);

                // Повернемо все назад - нічого не записалось
                foreach (DataRow drHead in dsTerm.Tables["dtHead"].Rows)
                {
                    DataRow row = dsReturn.Tables["dtReturn"].NewRow();
                    row["clID"] = drHead["clID"];
                    row["clGoodsArticle"] = drHead["clGoodsArticle"];
                    dsReturn.Tables["dtReturn"].Rows.Add(row);
                }
            }
            finally
            {
                conn.Close();
            }
        }

        return dsReturn;
    }

    [WebMethod(Description = "Загружає документи на термінал")]
    public DataSet LoadDocs(DataSet dsTerm, string pocket_id, string shopName, int w, int a, int u, DateTime date, string number_doc)
    {
        DataSet dsReturn = new DataSet("dsInvoice");
        DataTable dtDocs;
        DataTable dtDocsWares;
        DataTable dtWares;
        DataTable dtAdditionUnit;
        DataTable dtUnitDimension;
        DataTable dtSettings;
        DataTable dtDelDocs;
        string Shop=shopName;
        int s=0;

        // Таблиця ЗНП
        dtDocs = new DataTable("dtDocs");

        dtDocs.Columns.Add("number_doc", typeof(int));
        dtDocs.Columns.Add("type_doc", typeof(int));
        dtDocs.Columns.Add("date_doc", typeof(DateTime));
        dtDocs.Columns.Add("name_supplier", typeof(string));
        dtDocs.Columns.Add("okpo_supplier", typeof(long));
        dtDocs.Columns.Add("code_shop", typeof(int));
        dtDocs.Columns.Add("flag_sum_qty_doc", typeof(int));
        dtDocs.Columns.Add("sum_with_vat", typeof(decimal));
        dtDocs.Columns.Add("sum_without_vat", typeof(decimal));
        dtDocs.Columns.Add("input_code", typeof(int));
        
        dtDocs.PrimaryKey = new DataColumn[] { dtDocs.Columns["number_doc"] };

        dsReturn.Tables.Add(dtDocs);

        // таблиця товарів ЗНП
        dtDocsWares = new DataTable("dtDocsWares");

        dtDocsWares.Columns.Add("number_doc", typeof(int));
        dtDocsWares.Columns.Add("code_wares", typeof(int));
        dtDocsWares.Columns.Add("code_unit", typeof(int));
        dtDocsWares.Columns.Add("price_temp", typeof(decimal));
        dtDocsWares.Columns.Add("quantity_temp", typeof(decimal));

        dsReturn.Tables.Add(dtDocsWares);

        dtWares = new DataTable("dtWares");

        dtWares.Columns.Add("code_wares", typeof(int));
        dtWares.Columns.Add("name_wares", typeof(string));
        dtWares.Columns.Add("vat", typeof(int));
        dtWares.Columns.Add("term", typeof(int));

        dtWares.PrimaryKey = new DataColumn[] { dtWares.Columns["code_wares"] };
        
        dsReturn.Tables.Add(dtWares);

        dtAdditionUnit = new DataTable("dtAdditionUnit");

        dtAdditionUnit.Columns.Add("code_wares", typeof(int));
        dtAdditionUnit.Columns.Add("code_unit", typeof(int));
        dtAdditionUnit.Columns.Add("coefficient", typeof(int));
        dtAdditionUnit.Columns.Add("bar_code", typeof(string));
        dtAdditionUnit.Columns.Add("default_unit", typeof(string));

        dsReturn.Tables.Add(dtAdditionUnit);

        dtUnitDimension = new DataTable("dtUnitDimension");

        dtUnitDimension.Columns.Add("code_unit", typeof(int));
        dtUnitDimension.Columns.Add("abr_unit", typeof(string));
        dtUnitDimension.Columns.Add("div", typeof(int));

        dsReturn.Tables.Add(dtUnitDimension);

        dtSettings = new DataTable("dtSettings");

        dtSettings.Columns.Add("code_shop", typeof(string));
        dtSettings.Columns.Add("time_sync", typeof(DateTime));

        dsReturn.Tables.Add(dtSettings);

        dtDelDocs = new DataTable("dtDelDocs");

        dtDelDocs.Columns.Add("number_doc", typeof(int));

        dsReturn.Tables.Add(dtDelDocs);

      
        // --------------------------------------------------------------------------------------------------

        // Вычитаем настройки из config
        string providerName = System.Configuration.ConfigurationManager.AppSettings["ProviderName"];
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        string folder = System.Configuration.ConfigurationManager.AppSettings["PathToLogFolder"];

        TimeSpan cTSpan = DateTime.Now.Date.Subtract(date.Date);
        string p = cTSpan.Days.ToString();
        
        int dd = Convert.ToInt32(p);
        

        // соберем имя файла
        string strMessage = "";

        string sMonth = DateTime.Now.Date.Month.ToString();
        if (sMonth.Length == 1) sMonth = "0" + sMonth;

        string sDay = DateTime.Now.Date.Day.ToString();
        if (sDay.Length == 1) sDay = "0" + sDay;

        string sHour = DateTime.Now.Hour.ToString();
        if (sHour.Length == 1) sHour = "0" + sHour;

        string sMinute = DateTime.Now.Minute.ToString();
        if (sMinute.Length == 1) sMinute = "0" + sMinute;

        string sSecond = DateTime.Now.Second.ToString();
        if (sSecond.Length == 1) sSecond = "0" + sSecond;

        string sFilePath = DateTime.Today.Date.Year.ToString() + sMonth + sDay + "-" +
        sHour + "" + sMinute + "" + sSecond + ".txt";

        // Добавим доп. инфу
        strMessage = "Дата: " + DateTime.Now.ToString() + "\n";

        if (folder == string.Empty)
            folder = @"C:";

        sFilePath = folder + "\\" + sFilePath;

        // Вычитаем сюда всю таблицу с сервера --------------------------------------------------------------

        if (providerName == "ORACLE")
        {
            // сервер - ORACLE
            
            OracleConnection conn = new OracleConnection(connectionString);
            string sqlDocs = @"select  number_doc,
                                       type_doc,
                                       date_doc,
                                       name_supplier,
                                       okpo_supplier,
                                       code_shop,
                                       flag_sum_qty_doc,
                                       input_code,
                                       sum_with_vat,
                                       sum_without_vat
                                  from (select os.number_order_supply number_doc,
                                               1 type_doc,
                                               trunc(os.date_warehouse, 'J') date_doc,
                                               f.name name_supplier,
                                               f.code_zip okpo_supplier,
                                               os.code_shop code_shop,
                                               0 flag_sum_qty_doc,
                                               nvl(ddn.n18, 0) input_code,
                                               round(sum(wos.confirm_price * wos.confirm_quantity), 2) +
                                               os.nds sum_with_vat,
                                               round(sum(wos.confirm_price * wos.confirm_quantity), 2) sum_without_vat
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.wares_ord_supply wos, spr.firms f, mz.order_supply os
                                        left join c.docs d
                                          on (d.id_doc = 18 and d.code_doc = os.code_order_supply)
                                        left join c.data_name ddn
                                          on (ddn.data_level = 4101 and ddn.code_data = d.n01)
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = os.code_shop or ml.link_to = os.code_shop)
                                           and os.date_warehouse >= trunc(sysdate, 'J')
                                           and os.date_warehouse < trunc(sysdate, 'J') + 1
                                           and trim(os.state_order) in ('2', '4', '7')
                                           and os.code_company_supply not in (3758034, 3793508)
                                           and os.code_company_supply = f.code_firm
                                           and not (f.code_zip = 34928470)
                                           and os.code_order_supply = wos.code_order_supply
                                           and nvl(os.code_warehouse,0) = (case
                                                 when (dn.n02 is not null and os.code_warehouse is not null) then
                                                  dn.n02
                                                 else
                                                  nvl(os.code_warehouse,0)
                                               end)
                                           and exists
                                         (select 1
                                                  from mz.wares_ord_supply wos
                                                 where wos.code_order_supply = os.code_order_supply
                                                   and wos.begin_quantity > 0)
                                              and not exists
                                              (select 1
                                                       from c.tzd_docs td
                                                      where td.number_doc = os.number_order_supply
                                                       and  td.type_doc = 1)
                                           and not (:number_doc || ',' like
                                                '%' || os.number_order_supply || ',%')
                                         group by os.number_order_supply,
                                                  trunc(os.date_warehouse, 'J'),
                                                  f.name,
                                                  f.code_zip,
                                                  os.code_shop,
                                                  os.nds,
                                                  nvl(ddn.n18, 0)
                                        union all
                                        select ci.number_cinv number_doc,
                                               2 type_doc,
                                               to_date(ci.date_cinv, 'dd.mm.yyyy') date_doc,
                                               f.name name_supplier,
                                               f.code_zip okpo_supplier,
                                               ci.code_shop code_shop,
                                               1 flag_sum_qty_doc,
                                               1 input_code,
                                               0 sum_with_vat,
                                               0 sum_without_vat
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.cinv_inventories ci, spr.firms f
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = ci.code_shop or ml.link_to = ci.code_shop)
                                           and ci.date_cinv >= trunc(sysdate, 'J')
                                           and ci.date_cinv < trunc(sysdate, 'J') + 1
                                           and trim(ci.state_cinv) = 'S1'
                                           and ci.code_subgroup = 2
                                           and ci.code_firm = f.code_firm
                                           and ci.wares_list is null
                                        and not exists
                                        (select 1
                                                 from mz.cinv_calculation cc
                                                where cc.code_cinv = ci.code_cinv)
                                          and exists
                                        (select 1
                                                 from mz.cinv_total_warehouse_state ctws
                                                where ctws.code_cinv = ci.code_cinv)
                                          and not exists
                                        (select 1
                                                 from c.tzd_docs td
                                                where td.number_doc = ci.number_cinv
                                                and   td.type_doc = 2)
                                          and not (:number_doc || ',' like
                                               '%' || ci.number_cinv || ',%')
                                        union all
                                        select ci.number_cinv number_doc,
                                               2 type_doc,
                                               to_date(ci.date_cinv, 'dd.mm.yyyy') date_doc,
                                               f.name name_supplier,
                                               f.code_zip okpo_supplier,
                                               ci.code_shop code_shop,
                                               1 flag_sum_qty_doc,
                                               1 input_code,
                                               0 sum_with_vat,
                                               0 sum_without_vat
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.cinv_inventories ci, spr.firms f
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = ci.code_shop or ml.link_to = ci.code_shop)
                                           and ci.date_cinv >= trunc(sysdate, 'J')
                                           and ci.date_cinv < trunc(sysdate, 'J') + 1
                                           and trim(ci.state_cinv) = 'S1'
                                           and ci.code_subgroup = 2
                                           and ci.code_firm = f.code_firm
                                           and ci.wares_list is not null
                                           and not exists (select 1
                                                  from mz.cinv_calculation cc
                                                 where cc.code_cinv = ci.code_cinv)    
                                           and not exists
                                         (select 1
                                                  from c.tzd_docs td
                                                 where td.number_doc = ci.number_cinv
                                                   and td.type_doc = 2)
                                           and not (:number_doc || ',' like '%' || ci.number_cinv || ',%')
                                        union all
                                        select woi.number_write_off_invoice number_doc,
                                               3 type_doc,
                                               case
                                                 when woi.date_from_warehouse < trunc(sysdate, 'J')-2
                                                   then trunc(sysdate, 'J') 
                                                   else woi.date_from_warehouse
                                               end  date_doc,
                                               'РЦ ПАККО Холдинг' name_supplier,
                                               '34928470' okpo_supplier,
                                               woi.code_shop_addressee code_shop,
                                               1 flag_sum_qty_doc,
                                               1 input_code,
                                               spr.out_writeoff.GetSumWriteOffInvoiceWithVAT(woi.code_write_off_invoice) sum_with_vat,
                                               spr.out_writeoff.GetSumWriteOffInvoice(woi.code_write_off_invoice) sum_without_vat
                                          from mz.write_off_invoice woi, c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where woi.date_from_warehouse >= trunc(sysdate, 'J') - DECODE(woi.code_shop_addressee, 7721, 15, 5)
                                           and (woi.code_shop = 3179)
                                           and (woi.code_shop_addressee = dn.n01 or
                                               woi.code_shop_addressee = ml.link_to)
                                           and dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and not exists
                                         (select 1
                                                  from mz.invoice_from_transfer ift, mz.invoice i
                                                 where ift.code_transfer = woi.code_write_off_invoice
                                                   and ift.code_invoice = i.code_invoice
                                                   and i.state_invoice <> 'F')
                                           and not exists
                                         (select 1
                                                  from c.tzd_docs td
                                                 where td.number_doc = woi.number_write_off_invoice
                                                  and  td.type_doc = 3)
                                           and not (:number_doc || ',' like
                                                '%' || woi.number_write_off_invoice || ',%')
                                         group by woi.number_write_off_invoice,
                                                  woi.date_from_warehouse,
                                                  woi.code_shop_addressee,
                                                  woi.code_write_off_invoice,
                                                  woi.code_write_off_invoice
                                        union all
                                        select i.number_invoice number_doc,
                                               3 type_doc,
                                               case when trunc(i.date_invoice, 'J')< trunc(sysdate, 'J')-2
                                                    then trunc(sysdate, 'J') 
                                               else trunc(i.date_invoice, 'J') 
                                               end date_doc,
                                               'РЦ ПАККО Холдинг' name_supplier,
                                               f.code_zip okpo_supplier,
                                               i.code_shop code_shop,
                                               1 flag_sum_qty_doc,
                                               1 input_code,
                                               round(sum(wi.price_by_invoice * wi.quantity_by_invoice), 2) +
                                               i.nds_tax_invoice sum_with_vat,
                                               round(sum(wi.price_by_invoice * wi.quantity_by_invoice), 2) sum_without_vat
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.wares_invoice wi, spr.firms f, mz.invoice i
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = i.code_shop or ml.link_to = i.code_shop)
                                           and i.date_invoice >= trunc(sysdate, 'J') - 2
                                           and i.date_invoice < trunc(sysdate, 'J') + 1
                                           and trim(i.state_invoice) in ('C','F')
                                           and i.code_firm_source = f.code_firm
                                           and i.code_firm_source in (3758034)
                                           and c.proc.GetCodeFirmFromShop(i.code_shop) <> 3758034
                                           and i.code_invoice = wi.code_invoice
                                           and exists (select 1
                                                  from mz.wares_invoice wii
                                                 where wii.code_invoice = i.code_invoice
                                                   and wii.quantity_by_invoice > 0)
                                           and not exists
                                         (select 1
                                                  from c.tzd_docs td
                                                 where td.number_doc = i.number_invoice
                                                  and  td.type_doc = 3)
                                           and not (:number_doc || ',' like '%' || i.number_invoice || ',%')
                                         group by i.number_invoice,
                                                  trunc(i.date_invoice, 'J'),
                                                  f.code_zip,
                                                  i.code_shop,
                                                  i.nds_tax_invoice
                                        union all        
                                        select woi.number_write_off_invoice number_doc,
                                               4 type_doc,
                                               trunc(woi.date_write_off_invoice, 'J') date_doc,
                                               'ТзОВ ПАККО Холдинг_' name_supplier,
                                               '34928470' okpo_supplier,
                                               woi.code_shop code_shop,
                                               0 flag_sum_qty_doc,
                                               1 input_code,
                                               0 sum_with_vat,
                                               0 sum_without_vat
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.write_off_invoice woi, c.docs_wares dw
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = woi.code_shop or ml.link_to = woi.code_shop)
                                           and woi.date_write_off_invoice >= trunc(sysdate, 'J')
                                           and woi.date_write_off_invoice < trunc(sysdate, 'J') + 1
                                           and woi.code_pattern IN (44)
                                           and trim(woi.state_write_off_invoice) = 'C'
                                           and woi.code_write_off_invoice = dw.code_doc
                                           and dw.id_doc = 4
                                           and not exists (select 1
                                                  from mz.wares_write_off_invoice wwoi
                                                 where wwoi.code_write_off_invoice =
                                                       woi.code_write_off_invoice)
                                           and not exists
                                                 (select 1
                                                  from c.tzd_docs td
                                                 where td.number_doc = woi.number_write_off_invoice
                                                   and td.type_doc = 4)
                                           and not (:number_doc || ',' like
                                                '%' || woi.number_write_off_invoice || ',%')
                                         group by woi.number_write_off_invoice,
                                                  woi.date_write_off_invoice,
                                                  woi.code_shop
                                        union all
                                        select woi.number_write_off_invoice number_doc,
                                               5 type_doc,
                                               trunc(woi.date_write_off_invoice, 'J') date_doc,
                                               'ТзОВ ПАККО Холдинг_' name_supplier,
                                               '34928470' okpo_supplier,
                                               woi.code_shop code_shop,
                                               0 flag_sum_qty_doc,
                                               1 input_code,
                                               0 sum_with_vat,
                                               0 sum_without_vat
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.write_off_invoice woi, c.docs_wares dw
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = woi.code_shop or ml.link_to = woi.code_shop)
                                           and woi.date_write_off_invoice >= trunc(sysdate, 'J')
                                           and woi.date_write_off_invoice < trunc(sysdate, 'J') + 1
                                           and woi.code_pattern IN (42)
                                           and trim(woi.state_write_off_invoice) = 'C'
                                           and woi.code_write_off_invoice = dw.code_doc
                                           and dw.id_doc = 4
                                           and not exists (select 1
                                                  from mz.wares_write_off_invoice wwoi
                                                 where wwoi.code_write_off_invoice =
                                                       woi.code_write_off_invoice)
                                           and not exists
                                         (select 1
                                                  from c.tzd_docs td
                                                 where td.number_doc = woi.number_write_off_invoice
                                                   and td.type_doc = 5)
                                           and not (:number_doc || ',' like
                                                '%' || woi.number_write_off_invoice || ',%')
                                         group by woi.number_write_off_invoice,
                                                  woi.date_write_off_invoice,
                                                  woi.code_shop
                                        union all
                                        select iri.number_in_return_invoice number_doc,
                                               6 type_doc,
                                               trunc(iri.date_in_return_invoice, 'J') date_doc,
                                               'пп-'||f.name name_supplier,
                                               f.code_zip okpo_supplier,
                                               iri.code_shop code_shop,
                                               0 flag_sum_qty_doc,
                                               1 input_code,
                                               0 sum_with_vat,
                                               0 sum_without_vat
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.in_return_invoice iri, c.docs_wares dw, mz.firms f
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = iri.code_shop or ml.link_to = iri.code_shop)
                                           and iri.date_in_return_invoice >= trunc(sysdate, 'J')
                                           and iri.date_in_return_invoice < trunc(sysdate, 'J') + 1
                                           and iri.code_pattern IN (16000)
                                           and trim(iri.state_in_return_invoice) = 'C'
                                           and iri.code_firm = f.code_firm
                                           and iri.code_in_return_invoice = dw.code_doc
                                           and dw.id_doc = 3
                                           and exists (select 1
                                                  from mz.wares_in_return_invoice wiri
                                                 where wiri.code_in_return_invoice =
                                                       iri.code_in_return_invoice)
                                           and not exists
                                         (select 1
                                                  from c.tzd_docs td
                                                 where td.number_doc = iri.number_in_return_invoice
                                                 and   td.type_doc = 6)
                                           and not (:number_doc || ',' like
                                                '%' || iri.number_in_return_invoice || ',%')                                          
                                         group by iri.number_in_return_invoice,
                                                  iri.date_in_return_invoice,
                                                  iri.code_shop,
                                                  f.name,
                                                  f.code_zip                                     
                                        ) tt
                                 group by number_doc,
                                          type_doc,
                                          date_doc,
                                          name_supplier,
                                          okpo_supplier,
                                          code_shop,
                                          flag_sum_qty_doc,
                                          input_code,
                                          sum_with_vat,
                                          sum_without_vat";            
            OracleDataAdapter docs = new OracleDataAdapter(sqlDocs, conn);
            docs.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocket_id;
            docs.SelectCommand.Parameters.Add("number_doc", OracleType.NVarChar).Value = number_doc;

            string sqlDocsWares = @"WITH Shops AS
                                     (select dn.n01 as Code_Shop, n02
                                        from c.data_name dn
                                       where dn.data_level = 502
                                         and dn.code_data = to_number(:pocket_id)
                                      union
                                      select ml.link_to as Code_Shop, null
                                        from c.multi_link ml
                                       where ml.level_link = 502
                                         and ml.link_from = to_number(:pocket_id))

                                    SELECT number_doc, code_wares, code_unit, price_temp, quantity_temp
                                      FROM (select os.number_order_supply number_doc,
                                                   wos.code_order_wares code_wares,
                                                   wos.code_dimension code_unit,
                                                   round(wos.invoice_price, 4) price_temp,
                                                   wos.invoice_quantity quantity_temp
                                              from Shops sh
                                              join mz.order_supply os
                                                on (sh.Code_Shop = os.code_shop)
                                              join mz.wares_ord_supply wos
                                                on (os.code_order_supply = wos.code_order_supply)
                                              join spr.firms f
                                                on (os.code_company_supply = f.code_firm)
                                             where os.date_warehouse >= trunc(sysdate, 'J')
                                               and os.date_warehouse < trunc(sysdate, 'J') + 1
                                               and trim(os.state_order) in ('2', '4', '7')
                                               and os.code_company_supply not in (3758034, 3793508)
                                               and wos.invoice_quantity > 0
                                               and not (f.code_zip = 34928470)
                                               and nvl(os.code_warehouse, 0) = (case
                                                     when (sh.n02 is not null and os.code_warehouse is not null) then
                                                      sh.n02
                                                     else
                                                      nvl(os.code_warehouse, 0)
                                                   end)
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = os.number_order_supply
                                                       and td.type_doc = 1)
                                               and not (:number_doc || ',' like
                                                    '%' || os.number_order_supply || ',%')
                                            union all
                                            select i.number_invoice number_doc,
                                                   wi.code_wares code_wares,
                                                   wi.code_unit_by_invoice code_unit,
                                                   round(wi.price_by_invoice, 4) price_temp,
                                                   wi.quantity_by_invoice quantity_temp
                                              from Shops Sh
                                              join mz.invoice i
                                                on (sh.code_shop = i.code_shop)
                                              join mz.wares_invoice wi
                                                on (i.code_invoice = wi.code_invoice)
                                             where i.date_invoice >= trunc(sysdate, 'J') - 2
                                               and i.date_invoice < trunc(sysdate, 'J') + 1
                                               and i.state_invoice in ('C', 'F')
                                               and i.code_firm_source in (3758034)
                                               and i.code_firm_destination <> 3758034
                                               and wi.quantity_by_invoice > 0
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = i.number_invoice
                                                       and td.type_doc = 3)
                                               and not (:number_doc || ',' like '%' || i.number_invoice || ',%')
                                            union all
                                            select ci.number_cinv number_doc,
                                                   ctws.code_wares code_wares,
                                                   mz.GetCodeUnitDefault(ctws.code_wares) code_unit,
                                                   0 price_temp,
                                                   case
                                                     when ctws.total_free_in_basis > 0 then
                                                      99999999.000
                                                     else
                                                      88888888.000
                                                   end quantity_temp
                                              from Shops Sh
                                              join mz.cinv_inventories ci
                                                on (sh.code_shop = ci.code_shop)
                                              join mz.cinv_total_warehouse_state ctws
                                                on (ci.code_cinv = ctws.code_cinv)
                                             where ci.date_cinv >= trunc(sysdate, 'J')
                                               and ci.date_cinv < trunc(sysdate, 'J') + 1
                                               and ci.state_cinv = 'S1'
                                               and ci.code_subgroup = 2
                                               and ci.wares_list is null
                                               and not exists (select 1
                                                      from mz.cinv_calculation cc
                                                     where cc.code_cinv = ci.code_cinv)
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = ci.number_cinv
                                                       and td.type_doc = 2)
                                               and not (:number_doc || ',' like '%' || ci.number_cinv || ',%')
                                            union all
                                            select distinct ci.number_cinv number_doc,
                                                            w.code_wares code_wares,
                                                            mz.GetCodeUnitDefault(w.code_wares) code_unit,
                                                            0 price_temp,
                                                            88888888.000 quantity_temp
                                              from Shops sh
                                              join mz.cinv_inventories ci
                                                on (ci.code_shop = sh.code_shop)
                                              join mz.cinv_wares_groups cwg
                                                on (ci.code_cinv = cwg.code_cinv)
                                              join spr.wds_shopwares_warehouse wsw
                                                on (wsw.code_warehouse = ci.code_warehouse)
                                              join spr.wares w
                                                on (wsw.code_wares = w.code_wares)
                                             where ci.date_cinv >= trunc(sysdate, 'J')
                                               and ci.date_cinv < trunc(sysdate, 'J') + 1
                                               and ci.state_cinv = 'S1'
                                               and ci.code_subgroup = 2
                                               and ci.wares_list is null
                                               and wsw.min_rest_basis >= 0
                                               and c.proc.GroupInCapitalGroup(w.code_group, cwg.code_group_wares) = 1
                                               and not exists (select 1
                                                      from mz.cinv_calculation cc
                                                     where cc.code_cinv = ci.code_cinv)
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = ci.number_cinv
                                                       and td.type_doc = 2)
                                               and not (:number_doc || ',' like '%' || ci.number_cinv || ',%')
                                               and not exists
                                             (select *
                                                      from mz.cinv_total_warehouse_state ctws
                                                     where ctws.code_cinv = ci.code_cinv
                                                       and ctws.code_wares = w.code_wares)
                                            union all
                                            select ci.number_cinv,
                                                   w.code_wares,
                                                   mz.GetCodeUnitDefault(w.code_wares) code_unit,
                                                   0 price_temp,
                                                   case
                                                     when (select count(*)
                                                             from mz.cinv_total_warehouse_state ctws
                                                            where ctws.code_wares = w.code_wares
                                                              and ctws.code_cinv = ci.code_cinv) > 0 then
                                                      99999999.000
                                                     else
                                                      88888888.000
                                                   end quantity_temp
                                              from mz.cinv_inventories ci,
                                                   table(SPR.SYS_AUXILIARY_LIB.GetTblInteger(to_char(wares_list))) t,
                                                   Shops sh,
                                                   spr.wares w
                                             WHERE ci.date_cinv >= TRUNC(SYSDATE, 'J')
                                               AND ci.date_cinv < TRUNC(SYSDATE, 'J') + 1
                                               AND ci.state_cinv = 'S1'
                                               AND ci.code_subgroup = 2
                                               AND ci.wares_list IS NOT NULL
                                               AND sh.code_shop = ci.code_shop
                                               and not exists (select 1
                                                      from mz.cinv_calculation cc
                                                     where cc.code_cinv = ci.code_cinv)
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = ci.number_cinv
                                                       and td.type_doc = 2)
                                               and not (:number_doc || ',' like '%' || ci.number_cinv || ',%')
                                               and t.column_value = w.code_wares
                                            union all
                                            select woi.number_write_off_invoice number_doc,
                                                   wwoi.code_wares code_wares,
                                                   wwoi.code_unit code_unit,
                                                   round(sum(wwoi.price * wwoi.quantity) / sum(wwoi.quantity), 4) price_temp,
                                                   sum(wwoi.quantity) quantity_temp
                                              from Shops sh
                                              join mz.write_off_invoice woi
                                                on (Sh.code_shop = woi.code_shop_addressee)
                                              join mz.wares_write_off_invoice wwoi
                                                on (woi.code_write_off_invoice = wwoi.code_write_off_invoice)
                                             where (woi.code_shop = 3179)
                                               and woi.date_from_warehouse >= trunc(sysdate, 'J') - DECODE(woi.code_shop_addressee, 7721, 15, 5)
                                               and not exists
                                             (select 1
                                                      from mz.invoice_from_transfer ift, mz.invoice i
                                                     where ift.code_transfer = woi.code_write_off_invoice
                                                       and ift.code_invoice = i.code_invoice
                                                       and i.state_invoice <> 'F')
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = woi.number_write_off_invoice
                                                       and td.type_doc = 3)
                                               and not (:number_doc || ',' like
                                                    '%' || woi.number_write_off_invoice || ',%')
                                             group by woi.number_write_off_invoice,
                                                      wwoi.code_wares,
                                                      wwoi.code_unit
                                            union all
                                            select woi.number_write_off_invoice number_doc,
                                                   dw.code_wares                code_wares,
                                                   dw.n02                       code_unit,
                                                   0                            price_temp,
                                                   dw.n01                       quantity_temp
                                              from shops sh
                                              join mz.write_off_invoice woi
                                                on (woi.code_shop = sh.code_shop)
                                              join c.docs_wares dw
                                                on (woi.code_write_off_invoice = dw.code_doc and dw.id_doc = 4)
                                             where woi.date_write_off_invoice >= trunc(sysdate, 'J')
                                               and woi.date_write_off_invoice < trunc(sysdate, 'J') + 1
                                               and woi.code_pattern IN (44)
                                               and woi.state_write_off_invoice = 'C'
                                               and not exists (select 1
                                                      from mz.wares_write_off_invoice wwoi
                                                     where wwoi.code_write_off_invoice =
                                                           woi.code_write_off_invoice)
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = woi.number_write_off_invoice
                                                       and td.type_doc = 4)
                                               and not (:number_doc || ',' like
                                                    '%' || woi.number_write_off_invoice || ',%')
                                             group by woi.number_write_off_invoice,
                                                      dw.code_wares,
                                                      dw.n02,
                                                      dw.n01
                                            union all
                                            select woi.number_write_off_invoice number_doc,
                                                   dw.code_wares                code_wares,
                                                   dw.n02                       code_unit,
                                                   0                            price_temp,
                                                   dw.n01                       quantity_temp
                                              from shops sh
                                              join mz.write_off_invoice woi
                                                on (woi.code_shop = sh.code_shop)
                                              join c.docs_wares dw
                                                on (woi.code_write_off_invoice = dw.code_doc and dw.id_doc = 4)
                                             where woi.date_write_off_invoice >= trunc(sysdate, 'J')
                                               and woi.date_write_off_invoice < trunc(sysdate, 'J') + 1
                                               and woi.code_pattern IN (42)
                                               and woi.state_write_off_invoice = 'C'
                                               and not exists (select 1
                                                      from mz.wares_write_off_invoice wwoi
                                                     where wwoi.code_write_off_invoice =
                                                           woi.code_write_off_invoice)
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = woi.number_write_off_invoice
                                                       and td.type_doc = 5)
                                               and not (:number_doc || ',' like
                                                    '%' || woi.number_write_off_invoice || ',%')
                                             group by woi.number_write_off_invoice,
                                                      dw.code_wares,
                                                      dw.n02,
                                                      dw.n01
                                            union all
                                            select iri.number_in_return_invoice number_doc,
                                                   dw.code_wares                code_wares,
                                                   dw.n02                       code_unit,
                                                   0                            price_temp,
                                                   dw.n01                       quantity_temp
                                              from shops sh
                                              join mz.in_return_invoice iri
                                                on (iri.code_shop = sh.code_shop)
                                              join c.docs_wares dw
                                                on (iri.code_in_return_invoice = dw.code_doc and dw.id_doc = 3)
                                             where iri.date_in_return_invoice >= trunc(sysdate, 'J')
                                               and iri.date_in_return_invoice < trunc(sysdate, 'J') + 1
                                               and iri.code_pattern IN (16000)
                                               and trim(iri.state_in_return_invoice) = 'C'
                                               and exists (select 1
                                                      from mz.wares_in_return_invoice wiri
                                                     where wiri.code_in_return_invoice =
                                                           iri.code_in_return_invoice)
                                               and not exists
                                             (select 1
                                                      from c.tzd_docs td
                                                     where td.number_doc = iri.number_in_return_invoice
                                                       and td.type_doc = 6)
                                               and not (:number_doc || ',' like
                                                    '%' || iri.number_in_return_invoice || ',%')
                                             group by iri.number_in_return_invoice,
                                                      dw.code_wares,
                                                      dw.n02,
                                                      dw.n01)
                                     GROUP BY number_doc, code_wares, code_unit, price_temp, quantity_temp";
            OracleDataAdapter docswares = new OracleDataAdapter(sqlDocsWares, conn);
            docswares.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocket_id;
            docswares.SelectCommand.Parameters.Add("number_doc", OracleType.NVarChar).Value = number_doc;

            string sqlWares = @"select w.code_wares,
                                       substr(w.name_wares, 1, 100) name_wares,
                                       w.vat,
                                       w.keeping_time term
                                  from spr.wares w,
                                       (select la.code_wares
                                          from c.list_assortment la, c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where c.proc.ToNumber(la.quantity_min) >= 0
                                           and (la.code_shop = dn.n01 or la.code_shop = ml.link_to)
                                           and dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                        union all
                                        select ww.code_wares
                                          from mz.wares_warehouse ww, c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (ww.code_shop = dn.n01 or ww.code_shop = ml.link_to)
                                           and ww.code_subgroup = 2
                                        union all
                                        select wos.code_order_wares
                                          from mz.order_supply os, mz.wares_ord_supply wos, c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (os.code_shop = dn.n01 or os.code_shop = ml.link_to)
                                           and os.date_warehouse >= trunc(sysdate, 'J') - 4
                                           and os.date_warehouse < trunc(sysdate, 'J') + 1
                                           and trim(os.state_order) in ('2', '4', '7')
                                           and os.code_company_supply not in (3758034, 3793508)
                                           and os.code_order_supply = wos.code_order_supply
                                        union all
                                        select ctws.code_wares code_wares
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.cinv_total_warehouse_state ctws, mz.cinv_inventories ci
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = ci.code_shop or ml.link_to = ci.code_shop)
                                           and ci.date_cinv >= trunc(sysdate, 'J') - 1
                                           and ci.date_cinv < trunc(sysdate, 'J') + 1
                                           and ci.code_subgroup = 2
                                           and ci.code_cinv = ctws.code_cinv
                                        union all
                                        select w.code_wares
                                          from mz.cinv_inventories ci,
                                               table(SPR.SYS_AUXILIARY_LIB.GetTblInteger(to_char(wares_list))) t,
                                               (SELECT dn.n01 AS Code_Shop, n02
                                                  FROM c.data_name dn
                                                 WHERE dn.data_level = 502
                                                   AND dn.code_data = TO_NUMBER(:pocket_id)
                                                UNION
                                                SELECT ml.link_to AS Code_Shop, NULL
                                                  FROM c.multi_link ml
                                                 WHERE ml.level_link = 502
                                                   AND ml.link_from = TO_NUMBER(:pocket_id)) sh,
                                               spr.wares w
                                         WHERE ci.date_cinv >= TRUNC(SYSDATE, 'J') - 1
                                           AND ci.date_cinv < TRUNC(SYSDATE, 'J') + 1
                                           AND ci.state_cinv = 'S1'
                                           AND ci.code_subgroup = 2
                                           AND ci.wares_list IS NOT NULL
                                           AND sh.code_shop = ci.code_shop
                                           and t.column_value = w.code_wares
                                        union all
                                        select wwoi.code_wares
                                          from mz.write_off_invoice       woi,
                                               mz.wares_write_off_invoice wwoi,
                                               c.data_name                dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where (woi.date_from_warehouse >= sysdate - 5 or
                                               woi.date_write_off_invoice >= sysdate - 5)
                                           and woi.code_shop = 3179
                                           and dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (woi.code_shop_addressee = dn.n01 or
                                               woi.code_shop_addressee = ml.link_to)
                                           and woi.code_write_off_invoice = wwoi.code_write_off_invoice
                                        union all
                                        select wo.code_wares
                                          from mz.order_client oc, mz.wares_order wo
                                         where oc.code_pattern = 19582
                                           and oc.date_order >= sysdate - 5
                                           and oc.code_order = wo.code_order
                                        union all
                                        select wiri.code_wares
                                          from mz.in_return_invoice       iri,
                                               mz.wares_in_return_invoice wiri,
                                               c.data_name                dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where iri.date_in_return_invoice >= sysdate - 5
                                           and dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (iri.code_shop = dn.n01 or iri.code_shop = ml.link_to)
                                           and iri.code_in_return_invoice = wiri.code_in_return_invoice) t
                                 where w.code_wares = t.code_wares
                                 group by w.code_wares, w.name_wares, w.vat, w.keeping_time";
            OracleDataAdapter wares = new OracleDataAdapter(sqlWares, conn);
            wares.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocket_id;

            string sqlAdditionUnit = @"select  w.code_wares code_wares,
                                               au.code_unit code_unit,
                                               to_number(au.coefficient) coefficient,
                                               case
                                                 when au.code_unit = 7 then
                                                  (select max(bcauu.bar_code)
                                                     from spr.bar_code_additional_unit bcauu
                                                    where bcauu.code_wares = w.code_wares
                                                      and bcauu.code_unit = 5
                                                      and substr(bcauu.bar_code,1,2)=25)
                                                 else
                                                  bcau.bar_code
                                               end bar_code,
                                               case
                                                 when au.default_unit = 'Y' then
                                                  case
                                                    when bcau.is_main_bar_code = 1 then
                                                     'Y'
                                                    when bcau.is_main_bar_code = 0 and
                                                         (select count(*)
                                                            from spr.bar_code_additional_unit bcauu
                                                           where bcauu.code_wares = w.code_wares
                                                             and bcauu.code_unit = au.code_unit) <= 1 then
                                                     'Y'
                                                    when bcau.is_main_bar_code = 0 then
                                                     'N'
                                                    when bcau.is_main_bar_code is null then
                                                     au.default_unit
                                                  end
                                                 else
                                                  au.default_unit
                                               end default_unit
                                          from spr.addition_unit au
                                          left join spr.bar_code_additional_unit bcau
                                            on au.code_wares = bcau.code_wares
                                           and au.code_unit = bcau.code_unit, spr.wares w,
                                         (select la.code_wares
                                          from c.list_assortment la, c.data_name dn 
                                          left join c.multi_link ml on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where c.proc.ToNumber(la.quantity_min) >= 0
                                           and (la.code_shop = dn.n01 or la.code_shop = ml.link_to)
                                           and dn.code_data = to_number(:pocket_id)  
                                           and dn.data_level = 502      
                                        union all        
                                        select ww.code_wares
                                          from mz.wares_warehouse ww,  c.data_name dn 
                                          left join c.multi_link ml on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where dn.code_data = to_number(:pocket_id)  
                                           and dn.data_level = 502 
                                           and (ww.code_shop = dn.n01 or ww.code_shop = ml.link_to)
                                           and ww.code_subgroup = 2      
                                        union all        
                                        select wos.code_order_wares
                                          from mz.order_supply os, mz.wares_ord_supply wos, c.data_name dn 
                                          left join c.multi_link ml on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where dn.code_data = to_number(:pocket_id)  
                                           and dn.data_level = 502 
                                           and (os.code_shop = dn.n01 or os.code_shop = ml.link_to)
                                           and os.date_warehouse >= trunc(sysdate, 'J') - 4
                                           and os.date_warehouse < trunc(sysdate, 'J') + 1
                                           and trim(os.state_order) in ('2', '4', '7')
                                           and os.code_company_supply not in (3758034, 3793508)
                                           and os.code_order_supply = wos.code_order_supply    
                                        union all        
                                        select  ctws.code_wares code_wares
                                          from c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data),
                                         mz.cinv_total_warehouse_state ctws, mz.cinv_inventories ci
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = ci.code_shop or ml.link_to = ci.code_shop)
                                           and ci.date_cinv >= trunc(sysdate, 'J') - 1
                                           and ci.date_cinv < trunc(sysdate, 'J') + 1
                                           and ci.code_subgroup = 2
                                           and ci.code_cinv = ctws.code_cinv
                                        union all
                                        select w.code_wares
                                          from mz.cinv_inventories ci,
                                               table(SPR.SYS_AUXILIARY_LIB.GetTblInteger(to_char(wares_list))) t,
                                               (SELECT dn.n01 AS Code_Shop, n02
                                                  FROM c.data_name dn
                                                 WHERE dn.data_level = 502
                                                   AND dn.code_data = TO_NUMBER(:pocket_id)
                                                UNION
                                                SELECT ml.link_to AS Code_Shop, NULL
                                                  FROM c.multi_link ml
                                                 WHERE ml.level_link = 502
                                                   AND ml.link_from = TO_NUMBER(:pocket_id)) sh,
                                               spr.wares w
                                         WHERE ci.date_cinv >= TRUNC(SYSDATE, 'J') - 1
                                           AND ci.date_cinv < TRUNC(SYSDATE, 'J') + 1
                                           AND ci.state_cinv = 'S1'
                                           AND ci.code_subgroup = 2
                                           AND ci.wares_list IS NOT NULL
                                           AND sh.code_shop = ci.code_shop
                                           and t.column_value = w.code_wares    
                                        union all        
                                        select wwoi.code_wares
                                          from mz.write_off_invoice       woi,
                                               mz.wares_write_off_invoice wwoi,
                                               c.data_name                dn 
                                               left join c.multi_link ml on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where (woi.date_from_warehouse >= sysdate - 5 or woi.date_write_off_invoice >= sysdate-5)
                                           and woi.code_shop = 3179
                                           and dn.code_data = to_number(:pocket_id)  
                                           and dn.data_level = 502 
                                           and (woi.code_shop_addressee = dn.n01 or woi.code_shop_addressee = ml.link_to)
                                           and woi.code_write_off_invoice = wwoi.code_write_off_invoice                                           
                                        union all  
                                        select wo.code_wares
                                          from mz.order_client oc, 
                                               mz.wares_order wo
                                         where oc.code_pattern = 19582
                                           and oc.date_order >= sysdate - 5
                                           and oc.code_order = wo.code_order
                                        union all  
                                        select wiri.code_wares
                                          from mz.in_return_invoice       iri,
                                               mz.wares_in_return_invoice wiri,
                                               c.data_name                dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where iri.date_in_return_invoice >= sysdate - 5
                                           and dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (iri.code_shop = dn.n01 or iri.code_shop = ml.link_to)
                                           and iri.code_in_return_invoice = wiri.code_in_return_invoice) t
                                         where w.code_wares = t.code_wares
                                           and au.code_wares = decode(w.code_wares_relative,
                                                                      Null,
                                                                      w.code_wares,
                                                                      w.code_wares_relative)
                                           and (au.default_unit = 'Y' or au.sign_activity = 'Y')
                                         group by w.code_wares,
                                                  au.code_unit,
                                                  au.coefficient,
                                                  bcau.bar_code,
                                                  au.default_unit,
                                                  bcau.is_main_bar_code";
            OracleDataAdapter AdditionUnit = new OracleDataAdapter(sqlAdditionUnit, conn);
            AdditionUnit.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocket_id;

            string sqlUnitDimension = @"select code_unit, 
                                               trim(abr_unit) abr_unit,
                                               decode(sign_divisional, 'Y', 1, 'N', 0) div 
                                       from    spr.unit_dimension";
            OracleDataAdapter UnitDimension = new OracleDataAdapter(sqlUnitDimension, conn);

            string sqlSettings = @"select listagg(t.code_shop, ',') within group(order by t.code_shop) code_shop,
                                           sysdate time_sync
                                      from (select ml.link_to code_shop
                                              from c.data_name dn
                                              left join c.multi_link ml
                                                on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                             where dn.code_data = to_number(:pocket_id)
                                               and dn.data_level = 502
                                            union all
                                            select dn.n01 code_shop
                                              from c.data_name dn
                                             where dn.code_data = to_number(:pocket_id)
                                               and dn.data_level = 502) t";
            OracleDataAdapter Settings = new OracleDataAdapter(sqlSettings, conn);
            Settings.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocket_id;

            string sqlDelDocs = @"select number_doc
                                  from (select os.number_order_supply number_doc
                                          from mz.order_supply os, c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = os.code_shop or ml.link_to = os.code_shop)
                                           and os.date_warehouse >= trunc(sysdate, 'J') - 4
                                           and os.date_warehouse < trunc(sysdate, 'J') + 1
                                           and not (trim(os.state_order) in ('2', '4', '7'))
                                           and (:number_doc || ',' like
                                               '%' || os.number_order_supply || ',%')
                                        union all
                                        select woi.number_write_off_invoice number_doc
                                          from mz.write_off_invoice woi, c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where woi.date_from_warehouse >= sysdate - 5
                                           and woi.code_shop = 3179
                                           and dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (woi.code_shop_addressee = dn.n01 or
                                               woi.code_shop_addressee = ml.link_to)
                                           and exists
                                         (select 1
                                                  from mz.invoice_from_transfer ift, mz.invoice i
                                                 where ift.code_transfer = woi.code_write_off_invoice
                                                   and ift.code_invoice = i.code_invoice
                                                   and i.state_invoice <> 'F')
                                           and (:number_doc || ',' like
                                               '%' || woi.number_write_off_invoice || ',%')
                                        union all
                                        select i.number_invoice number_doc
                                          from mz.invoice i, c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where i.date_invoice >= sysdate - 5
                                           and dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = i.code_shop or ml.link_to = i.code_shop)
                                           and i.state_invoice not in ('C', 'F')
                                           and (:number_doc || ',' like '%' || i.number_invoice || ',%')
                                        union all
                                        select ci.number_cinv number_doc
                                          from mz.cinv_inventories ci, c.data_name dn
                                          left join c.multi_link ml
                                            on (ml.level_link = 502 and ml.link_from = dn.code_data)
                                         where dn.code_data = to_number(:pocket_id)
                                           and dn.data_level = 502
                                           and (dn.n01 = ci.code_shop or ml.link_to = ci.code_shop)
                                           and not (ci.state_cinv = 'S1')
                                           and ci.date_cinv>trunc(sysdate)-5
                                           and (:number_doc || ',' like '%' || ci.number_cinv || ',%')
                                        union all
                                        select td.number_doc number_doc
                                          from c.tzd_docs td
                                         where (:number_doc || ',' like '%' || td.number_doc || ',%')
                                           and td.date_doc > trunc(sysdate) - 7) t
                                 group by t.number_doc";
            OracleDataAdapter DelDocs = new OracleDataAdapter(sqlDelDocs, conn);
            DelDocs.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocket_id;
            DelDocs.SelectCommand.Parameters.Add("number_doc", OracleType.NVarChar).Value = number_doc;

            try
            {
                conn.Open();
                docs.Fill(dsReturn.Tables["dtDocs"]);
                docswares.Fill(dsReturn.Tables["dtDocsWares"]);
                DelDocs.Fill(dsReturn.Tables["dtDelDocs"]);

                Settings.Fill(dsReturn.Tables["dtSettings"]);

                if (dsReturn.Tables["dtSettings"].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsReturn.Tables["dtSettings"].Rows)
                    {
                       Shop = dr["code_shop"].ToString();
                    }
                }
                if (shopName !=  Shop)
                {
                    s = 1;
                }
                
                if (dd > 0 || w==0||s==1)
                {
                    wares.Fill(dsReturn.Tables["dtWares"]);
                }
                if (dd > 0 || a == 0||s==1)
                {
                    AdditionUnit.Fill(dsReturn.Tables["dtAdditionUnit"]);
                }
                if (dd > 0 || u == 0||s==1)
                {
                    UnitDimension.Fill(dsReturn.Tables["dtUnitDimension"]);
                }
                int d = dsReturn.Tables["dtDocs"].Rows.Count;
                int dw = dsReturn.Tables["dtDocsWares"].Rows.Count;
                int del = dsReturn.Tables["dtDelDocs"].Rows.Count;
                int ww = dsReturn.Tables["dtWares"].Rows.Count;
                int aa = dsReturn.Tables["dtAdditionUnit"].Rows.Count;
                int uu = dsReturn.Tables["dtUnitDimension"].Rows.Count;

                //File.WriteAllText(sFilePath, strMessage + "  " + pocket_id + ",Doc=" + d + ",DocsWares="+dw+",DelDocs="+del+",Wares="+ww+",AdditionUnit="+aa+",UnitDimension="+uu, System.Text.Encoding.Default);
            }
            catch (System.Exception ex)
            {
                // Запишем в текстовый лог - не смогли установить соединение
                File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);
            }
            finally
            {
                conn.Close();
            }
        }

        // --------------------------------------------------------------------------------------------------

        return dsReturn;
    }

    [WebMethod(Description = "Вигружає на сервер документи, оброблені клієнтом (передається версія)")]
    public DataSet UpLoadDocsNew(DataSet dsTerm, string version)
    {
        DataSet dsReturn = new DataSet("dsReturn");
        DataTable dtReturnHead;

        // Таблица, возвращающая шапки не вставившихся документов
        dtReturnHead = new DataTable("dtReturnHead");
        dtReturnHead.Columns.Add("number_doc", typeof(int));
        dtReturnHead.PrimaryKey = new DataColumn[] { dtReturnHead.Columns["number_doc"] };

        // Добавим ее в DataSet
        dsReturn.Tables.Add(dtReturnHead);

        // --------------------------------------------------------------------------------------------------

        // Вычитаем настройки из config
        string providerName = System.Configuration.ConfigurationManager.AppSettings["ProviderName"];
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        string folder = System.Configuration.ConfigurationManager.AppSettings["PathToLogFolder"];

        // соберем имя файла
        string strMessage = "";

        string sMonth = DateTime.Now.Date.Month.ToString();
        if (sMonth.Length == 1) sMonth = "0" + sMonth;

        string sDay = DateTime.Now.Date.Day.ToString();
        if (sDay.Length == 1) sDay = "0" + sDay;

        string sHour = DateTime.Now.Hour.ToString();
        if (sHour.Length == 1) sHour = "0" + sHour;

        string sMinute = DateTime.Now.Minute.ToString();
        if (sMinute.Length == 1) sMinute = "0" + sMinute;

        string sSecond = DateTime.Now.Second.ToString();
        if (sSecond.Length == 1) sSecond = "0" + sSecond;

        string sFilePath = DateTime.Today.Date.Year.ToString() + sMonth + sDay + "-" +
        sHour + "" + sMinute + "" + sSecond + ".txt";

        // Добавим доп. инфу
        strMessage = "Дата: " + DateTime.Now.ToString() + "\n";

        if (folder == string.Empty)
            folder = @"C:";

        sFilePath = folder + "\\" + sFilePath;

        // --------------------------------------------------------------------------------------------------

        if (providerName == "MSSQL")
        {
            // Если сервер - MSSQL
        }
        else if (providerName == "ORACLE")
        {
            // Если сервер - ORACLE
            OracleConnection conn = new OracleConnection(connectionString);
            OracleCommand cmdHead = new OracleCommand(@"insert into c.tzd_docs(number_doc,
                                                                                type_doc, 
                                                                                date_doc, 
                                                                                serial_tzd, 
                                                                                name_supplier, 
                                                                                code_shop,
                                                                                status, 
                                                                                sum_with_vat, 
                                                                                sum_without_vat,
                                                                                flag_price_with_vat,
                                                                                number_out_invoice,
                                                                                date_out_invoice,
                                                                                number_tax_invoice,
                                                                                date_tax_invoice,
                                                                                flag_sum_qty_doc,
                                                                                date_change,
                                                                                input_code,
                                                                                flag_change_doc_sup,
                                                                                okpo_supplier,
                                                                                flag_insert_weigth_from_barcod,
                                                                                version)
                                                       values    ( :number_doc,
                                                                   :type_doc, 
                                                                   :date_doc, 
                                                                   :serial_tzd, 
                                                                   :name_supplier, 
                                                                   :code_shop,
                                                                   1,
                                                                   :sum_with_vat, 
                                                                   :sum_without_vat,
                                                                   :flag_price_with_vat,
                                                                   :number_out_invoice,
                                                                   :date_out_invoice,
                                                                   :number_tax_invoice,
                                                                   :date_tax_invoice,
                                                                   :flag_sum_qty_doc,
                                                                   :change_date,
                                                                   :input_code,
                                                                   :flag_change_doc_sup,
                                                                   :okpo_supplier,
                                                                   :flag_insert_weigth_from_barcod,
                                                                   :version)", conn);
            cmdHead.Parameters.Add("number_doc", OracleType.Number);
            cmdHead.Parameters.Add("type_doc", OracleType.Number);
            cmdHead.Parameters.Add("date_doc", OracleType.DateTime);
            cmdHead.Parameters.Add("serial_tzd", OracleType.NVarChar);
            cmdHead.Parameters.Add("name_supplier", OracleType.NVarChar);
            cmdHead.Parameters.Add("code_shop", OracleType.Number);
            cmdHead.Parameters.Add("sum_with_vat", OracleType.Number);
            cmdHead.Parameters.Add("sum_without_vat", OracleType.Number);
            cmdHead.Parameters.Add("flag_price_with_vat", OracleType.Number);
            cmdHead.Parameters.Add("number_out_invoice", OracleType.NVarChar);
            cmdHead.Parameters.Add("date_out_invoice", OracleType.DateTime);
            cmdHead.Parameters.Add("number_tax_invoice", OracleType.NVarChar);
            cmdHead.Parameters.Add("date_tax_invoice", OracleType.DateTime);
            cmdHead.Parameters.Add("flag_sum_qty_doc", OracleType.Number);
            cmdHead.Parameters.Add("change_date", OracleType.DateTime);
            cmdHead.Parameters.Add("input_code", OracleType.Number);
            cmdHead.Parameters.Add("flag_change_doc_sup", OracleType.Number);
            cmdHead.Parameters.Add("okpo_supplier", OracleType.Number);
            cmdHead.Parameters.Add("flag_insert_weigth_from_barcod", OracleType.Number);
            cmdHead.Parameters.Add("version", OracleType.NVarChar);

            OracleCommand cmdRows = new OracleCommand(@"insert into c.tzd_docs_wares(number_doc, 
                                                                                     code_wares, 
                                                                                     code_unit, 
                                                                                     price, 
                                                                                     price_temp, 
                                                                                     quantity, 
                                                                                     quantity_temp, 
                                                                                     num_pop, 
                                                                                     date_change,
                                                                                     type_doc)
                                                                             values (:number_doc, 
                                                                                     :code_wares, 
                                                                                     :code_unit, 
                                                                                     :price, 
                                                                                     :price_temp, 
                                                                                     :quantity, 
                                                                                     :quantity_temp, 
                                                                                     :num_pop, 
                                                                                     :change_date,
                                                                                     :type_doc)", conn);
            cmdRows.Parameters.Add("number_doc", OracleType.Number);
            cmdRows.Parameters.Add("code_wares", OracleType.Number);
            cmdRows.Parameters.Add("code_unit", OracleType.Number);
            cmdRows.Parameters.Add("price", OracleType.Number);
            cmdRows.Parameters.Add("price_temp", OracleType.Number);
            cmdRows.Parameters.Add("quantity", OracleType.Number);
            cmdRows.Parameters.Add("quantity_temp", OracleType.Number);
            cmdRows.Parameters.Add("num_pop", OracleType.Number);
            cmdRows.Parameters.Add("change_date", OracleType.DateTime);
            cmdRows.Parameters.Add("type_doc", OracleType.Number);
            
            OracleTransaction tran = null;
            try
            {
                conn.Open();

                // Пробежимся по всем полученным с клиента шапкам
                foreach (DataRow drHead in dsTerm.Tables["dtDocs"].Rows)
                {
                    // Теперь выберем все строки данного документа
                    DataRow[] drRows = dsTerm.Tables["dtDocsWares"].Select("number_doc = " + Convert.ToInt32(drHead["number_doc"]));

                    if (drRows.Length > 0)
                    {
                        try
                        {
                            tran = conn.BeginTransaction();

                            // Сохраним строки документа
                            cmdRows.Transaction = tran;

                            foreach (DataRow drRow in drRows)
                            {
                                cmdRows.Parameters["number_doc"].Value = drRow["number_doc"];
                                cmdRows.Parameters["code_wares"].Value = drRow["code_wares"];
                                cmdRows.Parameters["code_unit"].Value = drRow["code_unit"];
                                cmdRows.Parameters["price"].Value = drRow["price"];
                                cmdRows.Parameters["price_temp"].Value = drRow["price_temp"];
                                cmdRows.Parameters["quantity"].Value = drRow["quantity"];
                                cmdRows.Parameters["quantity_temp"].Value = drRow["quantity_temp"];
                                cmdRows.Parameters["num_pop"].Value = drRow["num_pop"];
                                cmdRows.Parameters["change_date"].Value = drRow["change_date"];
                                cmdRows.Parameters["type_doc"].Value = drHead["type_doc"];
                                cmdRows.ExecuteNonQuery();
                            }

                            // Сохраним шапку документа
                            cmdHead.Transaction = tran;

                            cmdHead.Parameters["number_doc"].Value = drHead["number_doc"];
                            cmdHead.Parameters["type_doc"].Value = drHead["type_doc"];
                            cmdHead.Parameters["date_doc"].Value = drHead["date_doc"];
                            cmdHead.Parameters["serial_tzd"].Value = drHead["serial_tzd"];
                            cmdHead.Parameters["name_supplier"].Value = drHead["name_supplier"];
                            cmdHead.Parameters["code_shop"].Value = drHead["code_shop"];
                            cmdHead.Parameters["sum_with_vat"].Value = drHead["sum_with_vat"];
                            cmdHead.Parameters["sum_without_vat"].Value = drHead["sum_without_vat"];
                            cmdHead.Parameters["flag_price_with_vat"].Value = drHead["flag_price_with_vat"];
                            cmdHead.Parameters["number_out_invoice"].Value = drHead["number_out_invoice"];
                            cmdHead.Parameters["date_out_invoice"].Value = drHead["date_out_invoice"];
                            cmdHead.Parameters["number_tax_invoice"].Value = drHead["number_tax_invoice"];
                            cmdHead.Parameters["date_tax_invoice"].Value = drHead["date_tax_invoice"];
                            cmdHead.Parameters["flag_sum_qty_doc"].Value = drHead["flag_sum_qty_doc"];
                            cmdHead.Parameters["change_date"].Value = drHead["change_date"];
                            cmdHead.Parameters["input_code"].Value = drHead["input_code"];
                            cmdHead.Parameters["flag_change_doc_sup"].Value = drHead["flag_change_doc_sup"];
                            cmdHead.Parameters["okpo_supplier"].Value = drHead["okpo_supplier"];
                            cmdHead.Parameters["flag_insert_weigth_from_barcod"].Value = drHead["flag_insert_weigth_from_barcod"];
                            cmdHead.Parameters["version"].Value = version;

                            cmdHead.ExecuteNonQuery();

                            // Закоммитем
                            tran.Commit();
                        }
                        catch (System.Exception ex)
                        {
                            if (tran != null)
                                tran.Rollback();
                            File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);

                            // вернем код документа не сохранившегося
                            DataRow row = dsReturn.Tables["dtReturnHead"].NewRow();
                            row["number_doc"] = drHead["number_doc"];
                            dsReturn.Tables["dtReturnHead"].Rows.Add(row);

                        }
                    }
                    else
                    {
                        // Запишем в лог - нет строк в документе
                        DataRow row = dsReturn.Tables["dtReturnHead"].NewRow();
                        row["number_doc"] = drHead["number_doc"];
                        dsReturn.Tables["dtReturnHead"].Rows.Add(row);
                    }
                }
            }
            catch (System.Exception ex)
            {
                // Запишем в текстовый лог - не смогли установить соединение
                File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);

                // Вернем все назад - ничего не записалось
                foreach (DataRow drHead in dsTerm.Tables["dtHead"].Rows)
                {
                    DataRow row = dsReturn.Tables["dtReturnHead"].NewRow();
                    row["number_doc"] = drHead["number_doc"];
                    dsReturn.Tables["dtReturnHead"].Rows.Add(row);
                }
            }
            finally
            {
                conn.Close();
            }
        }

        return dsReturn;
    }

    [WebMethod(Description = "Вигружає на сервер документи, оброблені клієнтом")]
    public DataSet UpLoadDocs(DataSet dsTerm)
    {
        DataSet dsReturn;
        string version = "1.0.0.6";
        dsReturn = UpLoadDocsNew(dsTerm, version);
        return dsReturn;    
    }

    [WebMethod(Description = "Загружає ревізії на термінал")]
    public DataSet LoadInventory(string pocket_id, string shopName, string number_doc)
    {
        DataSet dsReturn = new DataSet("dsInventory");
        DataTable dtDocs;
        DataTable dtWares;
        DataTable dtAdditionUnit;
        DataTable dtUnitDimension;
        DataTable dtSettings;
        DataTable dtDelDocs;
        string Shop = shopName;
        
        // Таблиця ЗНП
        dtDocs = new DataTable("dtDocs");

        dtDocs.Columns.Add("number_doc", typeof(int));
        dtDocs.Columns.Add("type_doc", typeof(int));
        dtDocs.Columns.Add("date_doc", typeof(DateTime));
        dtDocs.Columns.Add("name_supplier", typeof(string));
        dtDocs.Columns.Add("okpo_supplier", typeof(long));
        dtDocs.Columns.Add("code_shop", typeof(int));
        dtDocs.Columns.Add("flag_sum_qty_doc", typeof(int));
        dtDocs.Columns.Add("sum_with_vat", typeof(decimal));
        dtDocs.Columns.Add("sum_without_vat", typeof(decimal));

        dtDocs.PrimaryKey = new DataColumn[] { dtDocs.Columns["number_doc"] };

        dsReturn.Tables.Add(dtDocs);

        
        dtWares = new DataTable("dtWares");

        dtWares.Columns.Add("code_wares", typeof(int));
        dtWares.Columns.Add("name_wares", typeof(string));
        dtWares.Columns.Add("vat", typeof(int));

        dtWares.PrimaryKey = new DataColumn[] { dtWares.Columns["code_wares"] };

        dsReturn.Tables.Add(dtWares);

        dtAdditionUnit = new DataTable("dtAdditionUnit");

        dtAdditionUnit.Columns.Add("code_wares", typeof(int));
        dtAdditionUnit.Columns.Add("code_unit", typeof(int));
        dtAdditionUnit.Columns.Add("coefficient", typeof(int));
        dtAdditionUnit.Columns.Add("bar_code", typeof(string));
        dtAdditionUnit.Columns.Add("default_unit", typeof(string));

        dsReturn.Tables.Add(dtAdditionUnit);

        dtUnitDimension = new DataTable("dtUnitDimension");

        dtUnitDimension.Columns.Add("code_unit", typeof(int));
        dtUnitDimension.Columns.Add("abr_unit", typeof(string));
        dtUnitDimension.Columns.Add("div", typeof(int));

        dsReturn.Tables.Add(dtUnitDimension);

        dtSettings = new DataTable("dtSettings");

        dtSettings.Columns.Add("time_sync", typeof(DateTime));

        dsReturn.Tables.Add(dtSettings);

        dtDelDocs = new DataTable("dtDelDocs");

        dtDelDocs.Columns.Add("number_doc", typeof(int));

        dsReturn.Tables.Add(dtDelDocs);


        // --------------------------------------------------------------------------------------------------

        // Вычитаем настройки из config
        string providerName = System.Configuration.ConfigurationManager.AppSettings["ProviderName"];
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        string folder = System.Configuration.ConfigurationManager.AppSettings["PathToLogFolder"];

        //TimeSpan cTSpan = DateTime.Now.Date.Subtract(date.Date);
        //string p = cTSpan.Days.ToString();

        //int dd = Convert.ToInt32(p);


        // соберем имя файла
        string strMessage = "";

        string sMonth = DateTime.Now.Date.Month.ToString();
        if (sMonth.Length == 1) sMonth = "0" + sMonth;

        string sDay = DateTime.Now.Date.Day.ToString();
        if (sDay.Length == 1) sDay = "0" + sDay;

        string sHour = DateTime.Now.Hour.ToString();
        if (sHour.Length == 1) sHour = "0" + sHour;

        string sMinute = DateTime.Now.Minute.ToString();
        if (sMinute.Length == 1) sMinute = "0" + sMinute;

        string sSecond = DateTime.Now.Second.ToString();
        if (sSecond.Length == 1) sSecond = "0" + sSecond;

        string sFilePath = DateTime.Today.Date.Year.ToString() + sMonth + sDay + "-" +
        sHour + "" + sMinute + "" + sSecond + ".txt";

        // Добавим доп. инфу
        strMessage = "Дата: " + DateTime.Now.ToString() + "\n";

        if (folder == string.Empty)
            folder = @"C:";

        sFilePath = folder + "\\" + sFilePath;

        // Вычитаем сюда всю таблицу с сервера --------------------------------------------------------------


        if (providerName == "ORACLE")
        {
            // сервер - ORACLE

            OracleConnection conn = new OracleConnection(connectionString);
            string sqlDocs = @"select distinct il.code_list number_doc,
                                       9            type_doc,
                                       to_date(inv.date_start_inv, 'dd.mm.yyyy') date_doc,
                                       'Всі товари'                              name_supplier,
                                       '34928470'                                okpo_supplier,
                                       inv.code_shop                             code_shop,
                                       1                                         flag_sum_qty_doc,
                                       0                                         sum_with_vat,
                                       0                                         sum_without_vat
                                from   mz.inventories inv,
                                       mz.inv_lists   il,
                                       mz.inv_books   ib       
                                where  ib.date_change >= sysdate-5
                                and    inv.code_inv = ib.code_inv
                                and    ib.code_book = il.code_book
                                and    inv.code_shop = to_number(substr(:shopName,4))
                                and    ib.name_book = 'ТЗД №'||substr(:shopName,1,2)
                                and    not exists (select 1 
                                                   from   MZ.INV_WARES_A iwa 
                                                   where  iwa.code_list = il.code_list)
                                and    not (:number_doc || ',' like '%' || il.code_list || ',%')
                                and    not exists 
                                            (select 1
                                             from c.tzd_docs td
                                             where td.number_doc = il.code_list
                                             and   td.type_doc = 9)";
            OracleDataAdapter docs = new OracleDataAdapter(sqlDocs, conn);
            docs.SelectCommand.Parameters.Add("shopName", OracleType.NVarChar).Value = shopName;
            docs.SelectCommand.Parameters.Add("number_doc", OracleType.NVarChar).Value = number_doc;

            string sqlWares = @"select code_wares, substr(name_wares, 1, 100) name_wares, vat
                                  from (select code_wares, name_wares, vat, sum(t)
                                          from (select w.code_wares, w.name_wares, w.vat, 1 t
                                                  from spr.wares w, c.list_assortment la
                                                 where w.code_wares = la.code_wares
                                                   and la.quantity_min >= 0
                                                   and la.code_shop = to_number(substr(:shopName,4))
                                                union all
                                                select  /*+ index (ww I7_WARES_WAREHOUSE)*/
                                                       w.code_wares, w.name_wares, w.vat, 1 t
                                                  from spr.wares w, mz.wares_warehouse ww
                                                 where w.code_wares = ww.code_wares
                                                   and ww.code_shop = to_number(substr(:shopName,4))
                                                   and ww.code_subgroup = 2)
                                         group by code_wares, name_wares, vat)";
            OracleDataAdapter wares = new OracleDataAdapter(sqlWares, conn);
            wares.SelectCommand.Parameters.Add("shopName", OracleType.NVarChar).Value = shopName;

            string sqlAdditionUnit = @"select  w.code_wares code_wares,
                                               au.code_unit code_unit,
                                               to_number(au.coefficient) coefficient,
                                               bcau.bar_code bar_code,
                                               case
                                                 when au.default_unit = 'Y' then
                                                  case
                                                    when bcau.is_main_bar_code = 1 then
                                                     'Y'
                                                    when bcau.is_main_bar_code = 0 and (count(bcau.code_wares) over (partition by bcau.code_wares, bcau.code_unit)) = 1 then
                                                     'Y'
                                                    when bcau.is_main_bar_code = 0 then
                                                     'N'
                                                    when bcau.is_main_bar_code is null then
                                                     au.default_unit
                                                  end
                                                 else
                                                  au.default_unit
                                               end default_unit
                                          from (select code_wares
                                                  from (select w.code_wares
                                                          from spr.wares w, c.list_assortment la
                                                         where w.code_wares = la.code_wares
                                                           and la.quantity_min >= 0
                                                           and la.code_shop = to_number(substr(:shopName, 4))
                                                        union all
                                                        select /*+ index (ww I7_WARES_WAREHOUSE)*/
                                                         w.code_wares
                                                          from spr.wares w, mz.wares_warehouse ww
                                                         where w.code_wares = ww.code_wares
                                                           and ww.code_shop = to_number(substr(:shopName, 4))
                                                           and ww.code_subgroup = 2)
                                                 group by code_wares) tt,
                                               spr.addition_unit au
                                          left join spr.bar_code_additional_unit bcau
                                            on au.code_wares = bcau.code_wares
                                           and au.code_unit = bcau.code_unit, spr.wares w
                                         where tt.code_wares = w.code_wares
                                           and au.code_wares = decode(w.code_wares_relative,
                                                                      Null,
                                                                      w.code_wares,
                                                                      w.code_wares_relative)
                                           and (au.default_unit = 'Y' or au.sign_activity = 'Y')
                                         group by w.code_wares,
                                                  au.code_unit,
                                                  au.coefficient,
                                                  bcau.bar_code,
                                                  au.default_unit,
                                                  bcau.is_main_bar_code,
                                                  bcau.code_wares,
                                                  bcau.code_unit";
            OracleDataAdapter AdditionUnit = new OracleDataAdapter(sqlAdditionUnit, conn);
            AdditionUnit.SelectCommand.Parameters.Add("shopName", OracleType.NVarChar).Value = shopName;

            string sqlUnitDimension = @"select code_unit, 
                                               trim(abr_unit) abr_unit,
                                               decode(sign_divisional, 'Y', 1, 'N', 0) div 
                                       from    spr.unit_dimension";
            OracleDataAdapter UnitDimension = new OracleDataAdapter(sqlUnitDimension, conn);

            string sqlSettings = @"select sysdate time_sync from  dual";
            OracleDataAdapter Settings = new OracleDataAdapter(sqlSettings, conn);
            

            string sqlDelDocs = @"select  il.code_list number_doc
                                    from   mz.inventories inv,
                                           mz.inv_lists   il,
                                           mz.inv_books   ib       
                                    where  ib.date_change >= sysdate-5
                                    and    inv.code_inv = ib.code_inv
                                    and    ib.code_book = il.code_book
                                    and    inv.code_shop = to_number(substr(:shopName,4))
                                    and    ib.name_book = 'ТЗД №'||substr(:shopName,1,2)
                                    and    exists (select 1 
                                                       from   MZ.INV_WARES_A iwa 
                                                       where  iwa.code_list = il.code_list)
                                    and    (:number_doc || ',' like '%' || il.code_list || ',%')
                                    union all
                                    (SELECT to_number(regexp_substr(str, '[^,]+', 1, level))  number_doc
                                      FROM (SELECT :number_doc str FROM dual) t
                                      CONNECT BY instr(str, ',', 1, level - 1) > 0
                                     minus 
                                     select il.code_list
                                     from    mz.inv_lists il
                                     where   (:number_doc || ',' like '%' || il.code_list || ',%'))";
            OracleDataAdapter DelDocs = new OracleDataAdapter(sqlDelDocs, conn);
            DelDocs.SelectCommand.Parameters.Add("shopName", OracleType.NVarChar).Value = shopName;
            DelDocs.SelectCommand.Parameters.Add("number_doc", OracleType.NVarChar).Value = number_doc;

            try
            {
                conn.Open();
                docs.Fill(dsReturn.Tables["dtDocs"]);
                Settings.Fill(dsReturn.Tables["dtSettings"]);
                DelDocs.Fill(dsReturn.Tables["dtDelDocs"]);
                if (dsReturn.Tables["dtDocs"].Rows.Count > 0)
                {
                    wares.Fill(dsReturn.Tables["dtWares"]);
                    AdditionUnit.Fill(dsReturn.Tables["dtAdditionUnit"]);
                    UnitDimension.Fill(dsReturn.Tables["dtUnitDimension"]);
                }
            }
            catch (System.Exception ex)
            {
                File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);
            }
            finally
            {
                conn.Close();
            }
        }

        // --------------------------------------------------------------------------------------------------

        return dsReturn;
    }

    [WebMethod(Description = "Загружає ревізії ОС на термінал")]
    public DataSet LoadInventoryOS(DataSet dsTerm, string pocketName)
    {
        DataTable dtRevisionOS = dsTerm.Tables["dsInventoryOS"];

        // Таблиця OS
        dtRevisionOS = new DataTable("dsInventoryOS");

        dtRevisionOS.Columns.Add("revID", typeof(int));
        dtRevisionOS.Columns.Add("revCode", typeof(string));
        dtRevisionOS.Columns.Add("revDate", typeof(DateTime));
        dtRevisionOS.Columns.Add("osName", typeof(string));
        dtRevisionOS.Columns.Add("osBarcode", typeof(string));
        dtRevisionOS.Columns.Add("osCode", typeof(string));
        dtRevisionOS.Columns.Add("osPrice", typeof(decimal));
        dtRevisionOS.Columns.Add("osState", typeof(int));

        dtRevisionOS.PrimaryKey = new DataColumn[] { dtRevisionOS.Columns["revID"] };

        // --------------------------------------------------------------------------------------------------

        // Вычитаем настройки из config
        string providerName = System.Configuration.ConfigurationManager.AppSettings["ProviderName"];
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        string folder = System.Configuration.ConfigurationManager.AppSettings["PathToLogFolder"];

        //TimeSpan cTSpan = DateTime.Now.Date.Subtract(date.Date);
        //string p = cTSpan.Days.ToString();

        //int dd = Convert.ToInt32(p);


        // соберем имя файла
        string strMessage = "";

        string sMonth = DateTime.Now.Date.Month.ToString();
        if (sMonth.Length == 1) sMonth = "0" + sMonth;

        string sDay = DateTime.Now.Date.Day.ToString();
        if (sDay.Length == 1) sDay = "0" + sDay;

        string sHour = DateTime.Now.Hour.ToString();
        if (sHour.Length == 1) sHour = "0" + sHour;

        string sMinute = DateTime.Now.Minute.ToString();
        if (sMinute.Length == 1) sMinute = "0" + sMinute;

        string sSecond = DateTime.Now.Second.ToString();
        if (sSecond.Length == 1) sSecond = "0" + sSecond;

        string sFilePath = DateTime.Today.Date.Year.ToString() + sMonth + sDay + "-" +
        sHour + "" + sMinute + "" + sSecond + ".txt";

        // Добавим доп. инфу
        strMessage = "Дата: " + DateTime.Now.ToString() + "\n";

        if (folder == string.Empty)
            folder = @"C:";

        sFilePath = folder + "\\" + sFilePath;

        // Вычитаем сюда всю таблицу с сервера --------------------------------------------------------------

        if (providerName == "MSSQL")
        {
        }

        else if (providerName == "ORACLE")
        {
            // Если сервер - ORACLE
            OracleConnection conn = new OracleConnection(connectionString);
            string sqlInventoryOS = @"select row_number() over(partition by ios.revCode order by ios.osCode) revID,
                                               ios.revCode,
                                               ios.revDate,
                                               ios.osBarcode,
                                               ios.osName,
                                               0 osState,
                                               ios.osPrice,
                                               ios.osCode,
                                               ios.numberTZD
                                          from c.v_inventory_os ios
                                         WHERE ios.numberTZD = :pocket_id";
            OracleDataAdapter InventoryOS = new OracleDataAdapter(sqlInventoryOS, conn);
            InventoryOS.SelectCommand.Parameters.Add("pocket_id", OracleType.NVarChar).Value = pocketName;

            try
            {
                conn.Open();
                InventoryOS.Fill(dtRevisionOS);
            }
            catch (System.Exception ex)
            {
                // Запишем в текстовый лог - не смогли установить соединение
                File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);
            }
            finally
            {
                conn.Close();
            }
        }

        // --------------------------------------------------------------------------------------------------
        DataSet dsReturn = new DataSet("dsInventoryOS");
        dsReturn.Tables.Add(dtRevisionOS);
        return dsReturn;
    }
    
    [WebMethod(Description = "Вигружає на сервер результат сканування ОС")]
    public DataSet UpLoadInventoryOS(DataSet dsTerm, string pocketName, string shopName)
    {
        DataSet dsReturn = new DataSet("dsReturn");
        DataTable dtReturn;

        // Таблиця, яка вказує на шапки не вставлених в ORACLE документів
        dtReturn = new DataTable("dtReturn");
        dtReturn.Columns.Add("revID", typeof(string));
        dtReturn.Columns.Add("revCode", typeof(string));
        dtReturn.Columns.Add("revDate", typeof(DateTime));
        dtReturn.PrimaryKey = new DataColumn[] { dtReturn.Columns["revID"] };

        dsReturn.Tables.Add(dtReturn);

        // --------------------------------------------------------------------------------------------------

        // Вычитаем настройки из config
        string providerName = System.Configuration.ConfigurationManager.AppSettings["ProviderName"];
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        string folder = System.Configuration.ConfigurationManager.AppSettings["PathToLogFolder"];

        // соберем имя файла
        string strMessage = "";

        string sMonth = DateTime.Now.Date.Month.ToString();
        if (sMonth.Length == 1) sMonth = "0" + sMonth;

        string sDay = DateTime.Now.Date.Day.ToString();
        if (sDay.Length == 1) sDay = "0" + sDay;

        string sHour = DateTime.Now.Hour.ToString();
        if (sHour.Length == 1) sHour = "0" + sHour;

        string sMinute = DateTime.Now.Minute.ToString();
        if (sMinute.Length == 1) sMinute = "0" + sMinute;

        string sSecond = DateTime.Now.Second.ToString();
        if (sSecond.Length == 1) sSecond = "0" + sSecond;

        string sFilePath = DateTime.Today.Date.Year.ToString() + sMonth + sDay + "-" +
        sHour + "" + sMinute + "" + sSecond + ".txt";

        // Добавимо дод. инфу
        strMessage = "Дата: " + DateTime.Now.ToString() + "\n";

        if (folder == string.Empty)
            folder = @"C:";

        sFilePath = folder + "\\" + sFilePath;

        // --------------------------------------------------------------------------------------------------

        if (providerName == "ORACLE")
        {
            // Якщо сервер - ORACLE
            OracleConnection conn = new OracleConnection(connectionString);
            OracleCommand cmdHead = new OracleCommand(@"insert into c.inventory_os
                                                          (id_input_session, code_revision, date_revision, barcode, status, serial_tzd)
                                                        values
                                                          (:id_input_session,
                                                           :code_revision,
                                                           :date_revision,
                                                           :barcode,
                                                           :status,
                                                           :serial_tzd)", conn);
            cmdHead.Parameters.Add("id_input_session", OracleType.Number);
            cmdHead.Parameters.Add("code_revision", OracleType.NVarChar);
            cmdHead.Parameters.Add("date_revision", OracleType.DateTime);
            cmdHead.Parameters.Add("barcode", OracleType.NVarChar);
            cmdHead.Parameters.Add("status", OracleType.Number);
            cmdHead.Parameters.Add("serial_tzd", OracleType.NVarChar);

            OracleTransaction tran = null;
            try
            {
                conn.Open();

                // Проаналізуємо всі строки і вставимо результат сканування
                foreach (DataRow drHead in dsTerm.Tables["dtRevisionOSLogs"].Rows)
                {
                    try
                    {
                        tran = conn.BeginTransaction();

                        // Збережемо строку сканування
                        cmdHead.Transaction = tran;
                        cmdHead.Parameters["id_input_session"].Value = Convert.ToInt32(drHead["revID"]);
                        try
                        {
                            cmdHead.Parameters["code_revision"].Value = Convert.ToString(drHead["revCode"]);
                        }
                        catch
                        {
                            cmdHead.Parameters["code_revision"].Value = DBNull.Value;
                        }
                        try
                        {
                            cmdHead.Parameters["date_revision"].Value = Convert.ToDateTime(drHead["revDate"]);
                        }
                        catch
                        {
                            cmdHead.Parameters["date_revision"].Value = DBNull.Value;
                        }
                        cmdHead.Parameters["barcode"].Value = drHead["osBarcode"];
                        cmdHead.Parameters["status"].Value = Convert.ToInt32(drHead["osStatus"]);
                        cmdHead.Parameters["serial_tzd"].Value = pocketName;

                        cmdHead.ExecuteNonQuery();

                        // Закомітимо
                        tran.Commit();
                    }
                    catch (System.Exception ex)
                    {
                        File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);
                        if (tran != null)
                            tran.Rollback();

                        // вернемо строку, яка не вставилась
                        DataRow row = dsReturn.Tables["dtReturn"].NewRow();
                        row["revID"] = drHead["revID"];
                        row["revCode"] = drHead["revCode"];
                        row["revDate"] = drHead["revDate"];
                        dsReturn.Tables["dtReturn"].Rows.Add(row);
                    }
                }
            }
            catch (System.Exception ex)
            {
                // Запишемо в текстовий лог - не змогли встановити з'єднання
                File.WriteAllText(sFilePath, strMessage + "  " + ex.ToString(), System.Text.Encoding.Default);

                // Повернемо все назад - нічого не записалось
                foreach (DataRow drHead in dsTerm.Tables["dtHead"].Rows)
                {
                    DataRow row = dsReturn.Tables["dtReturn"].NewRow();
                    row["revID"] = drHead["revID"];
                    row["revCode"] = drHead["revCode"];
                    row["revDate"] = drHead["revDate"];
                    dsReturn.Tables["dtReturn"].Rows.Add(row);
                }
            }
            finally
            {
                conn.Close();
            }
        }

        return dsReturn;
    }

    // --------------------------------------------------------------------------------------
}
