using System;
using System.Data;
using System.Reflection;
//using System.Linq;
using System.Data.SqlServerCe;
using System.IO;
using System.Diagnostics;
namespace BRB
{

    public class Data
    {
        #region Запити
        private string varSQLDocs = @"SELECT  d.number_doc,
                                      d.type_doc, 
                                      d.name_supplier, 
                                      d.date_doc,
                                      CASE
                                           WHEN d.flag_price_with_vat = 1 then d.sum_with_vat
                                           WHEN d.flag_price_with_vat = 0 then d.sum_without_vat
                                           else 0 
                                      END AS SummaZak, 
                                      d.status,
                                      d.okpo_supplier,
                                      d.flag_price_with_vat,
                                      CASE 
                                           WHEN d.status = 0 THEN '-' 
                                           WHEN d.status = 1 THEN '+' 
                                      ELSE '' END AS StatusName, 
                                     COUNT(dw.number_doc) AS SumWaresZam,
                                     COALESCE (MAX(dw.num_pop), 0) AS SumWaresInv,
                                     CASE 
                                        WHEN d .flag_price_with_vat = 0 THEN COALESCE (SUM(dw.price * dw.quantity), 0) 
                                        ELSE COALESCE (SUM(dw.price * dw.quantity*(1+w.vat/100)), 0) END AS SummaPrih,
                                     number_out_invoice,
                                     date_out_invoice,
                                     COALESCE(flag_sum_qty_doc, 0) as flag_sum_qty_doc
                              FROM  DOCS AS d LEFT OUTER JOIN
                                     DOCS_WARES AS dw ON d.number_doc = dw.number_doc LEFT OUTER JOIN
                                      WARES AS w ON dw.code_wares=w.code_wares
                              WHERE type_doc=@parTypeDoc 
GROUP BY d.number_doc, d.type_doc, d.name_supplier, d.date_doc, d.flag_price_with_vat, d.sum_without_vat, d.sum_with_vat, d.status, d.okpo_supplier,  
                         d.number_out_invoice, d.date_out_invoice, d.flag_sum_qty_doc";
        ////type_doc in (1, 3, 4, 5, 6, 7, 8)
        //TMP Є трохи магії з комплектацією Інший запит() треба буде розібратись
        private string varSQLDocsWares = @"SELECT DISTINCT dw.number_doc, 
                                           dw.code_wares, 
                                           dw.code_unit, 
                                           CASE
                                              WHEN d .flag_price_with_vat = 1 THEN dw.price * (1 + w.vat/100) 
                                              ELSE dw.price 
                                           END AS price,
                                           CASE
                                              WHEN d .flag_price_with_vat = 1 THEN dw.price_temp * (1 + w.vat/100) 
                                              ELSE dw.price_temp 
                                           END AS price_temp, 
                                           dw.quantity, 
                                           dw.quantity_temp, 
                                           dw.num_pop, 
                                           dw.change_date, 
                                           w.name_wares,
                                           au.coefficient,
                                           ud.abr_unit
                                 FROM      DOCS AS d INNER JOIN
                                           DOCS_WARES AS dw ON d.number_doc = dw.number_doc INNER JOIN
                                           WARES AS w ON dw.code_wares = w.code_wares INNER JOIN
                                           ADDITION_UNIT AS au ON dw.code_wares = au.code_wares AND dw.code_unit = au.code_unit INNER JOIN
                                           UNIT_DIMENSION AS ud ON dw.code_unit = ud.code_unit 
                                 WHERE     dw.number_doc = @parNumberDoc";

        private string varSQLTimeSync = @"SELECT MAX(TimeSync) FROM SETTINGS";
        private string varSQLSumDocs = @"SELECT CASE WHEN d .flag_price_with_vat = 0 THEN d .sum_without_vat WHEN d .flag_price_with_vat = 1 THEN d .sum_with_vat ELSE 0 END AS SummaZak FROM DOCS AS d WHERE (d.number_doc = @parNumberDoc)";
        private string varSQLSumDocsWares = @"SELECT  CASE 
                                        WHEN d .flag_price_with_vat = 0 THEN COALESCE (SUM(price * quantity), 0) 
                                        ELSE COALESCE (SUM(price * quantity*(1+w.vat/100)), 0)
                                        END AS SummaPrih
                              FROM    DOCS_WARES AS dw INNER JOIN
                                      DOCS AS d ON dw.number_doc = d.number_doc INNER JOIN
                                      WARES AS w on dw.code_wares = w.code_wares
                              WHERE   (d.number_doc = @parNumberDoc)
                              GROUP BY d.flag_price_with_vat";

        private string varSQLSumDocsWaresInv = @"SELECT COALESCE (MAX(dw.num_pop), 0) AS SumWaresInv FROM docs_wares AS dw where dw.number_doc = @parNumberDoc";

        private string varSQLSetStatusDoc = @"update docs set status = @parStatus where number_doc = @parNumberDo";


        private string varSQLGetTypeDoc = @"select COALESCE(type_doc, 1) from Docs where number_doc = @parNumberDoc";

        private string varSQLGetDifferenceDoc = @"SELECT  COALESCE (COUNT(code_wares), 0)  FROM DOCS_WARES WHERE (quantity <> quantity_temp OR  quantity IS NULL) AND number_doc = @parNumberDoc";

        private string varSQLGetNumberOutInvoice = @"select COALESCE (number_out_invoice, '') from Docs where number_doc = @parNumberDoc";

        private string varSQLGetDateOutInvoice = @"select COALESCE (LEN(date_out_invoice), 0) from Docs where number_doc = @parNumberDoc";

        private string varSQLGetWaresOrder  = @"SELECT   COALESCE (MAX(num_pop), 0)+1 as  num_pop  FROM     docs_wares   WHERE    number_doc  = @number_doc";

        private string varSQLSaveDocWares = @"update docs_wares
						   set    quantity = @parQty,
						          price = @parPrice,
						          num_pop = @parNumPop,
                                  change_date = @parChangeDate 
						   where  code_wares = @parCodeWares
                           and    number_doc = @parNumberDoc";
  
        private string varSQLFindBarCode(bool parIsComplect,bool parIsBarCode)
        {
            return
                @"SELECT  dw.code_wares, 
                                      dw.number_doc, 
                                      dw.quantity,
                                      case  
                                         WHEN d .flag_price_with_vat = 1 THEN dw.price * (1 + w.vat/100) 
                                         ELSE dw.price 
                                      END AS price, 
                                      w.name_wares, 
                                      dw.num_pop, 
                                      dw.quantity_temp, 
                                      CASE 
                                          WHEN d .flag_price_with_vat = 1 THEN dw.price_temp * (1 + w.vat/100) 
                                          ELSE dw.price_temp 
                                      END AS price_temp, 
                                      au.bar_code, 
                                      au.coefficient, 
                                      au.code_unit, 
                                      aus.code_unit as code_unit_scan,
                                      w.term
                              FROM    DOCS_WARES AS dw 
                              INNER JOIN WARES AS w ON dw.code_wares = w.code_wares 
                              INNER JOIN ADDITION_UNIT AS au ON dw.code_unit = au.code_unit AND dw.code_wares = au.code_wares 
                              INNER JOIN ADDITION_UNIT AS aus ON dw.code_wares = aus.code_wares 
                              INNER JOIN DOCS AS d ON dw.number_doc = d.number_doc 
" +
                                (parIsComplect ? @"INNER JOIN DOCS AS dd ON d.okpo_supplier = dd.okpo_supplier AND d.type_doc = dd.type_doc AND d.date_doc = dd.date_doc AND d.code_shop = dd.code_shop " : "") +
                                @"
                               WHERE   (dw.number_doc = @number_doc) AND 
"+
 (parIsBarCode?@"                (aus.bar_code = @bar_code)": @"(dw.code_wares = @code_wares)")+
@"                              ORDER BY dw.quantity";
        }
        #endregion
        private string varError=null;
        private DataTable tDocs;
        private DataTable tDocsWares;
        private MSCeSQL SQL = null;
        private bool UseCash = false;
        public Data() { }
        public Data(MSCeSQL parSQL) { Init(parSQL); }

        public void Init(MSCeSQL parSQL)
        {
            SQL = parSQL;
        }

        public DataTable FillDocs(TypeDoc parTypeDoc)
        {
            SQL.AddWithValueF("@parTypeDoc", parTypeDoc);
            tDocs = SQL.ExecuteQuery(varSQLDocs);
            return tDocs;
        }

        public DataTable FillDocsWares(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            tDocsWares = SQL.ExecuteQuery(varSQLDocsWares);
            return tDocsWares;
        }
        public DateTime GetDateSync(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToDateTime(SQL.ExecuteScalar(varSQLTimeSync));
        }
        //Old GetSummaZak
        public decimal GetSumDocs(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToDecimal(SQL.ExecuteScalar(varSQLSumDocs));
        }
        //Old GetSummaPrih
        public decimal GetSumDocsWares(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToDecimal(SQL.ExecuteScalar(varSQLSumDocsWares));
        }
        public decimal GetSumWaresInv(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToDecimal(SQL.ExecuteScalar(varSQLSumDocsWaresInv));
        }

        public void SetStatusDoc(int parNumberDoc, int parStatus)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            SQL.AddWithValue("@parStatus", parStatus);
            SQL.ExecuteNonQuery(varSQLSetStatusDoc);
        }

        public int GetTypeDoc(int parNumberDoc)
        {//TMP Треба тобисати через Link p tDocs
            /* if(tDocs!=null)
             {

             }
             */
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToInt32(SQL.ExecuteScalar(varSQLGetTypeDoc));
        }


        public int GetDifferenceDoc(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToInt32(SQL.ExecuteScalar(varSQLGetDifferenceDoc));
        }


        public string GetNumberOutInvoice(int parNumberDoc)
        {
            //TMP Треба Добисати через Link p tDocs
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToString(SQL.ExecuteScalar(varSQLGetNumberOutInvoice));
        }

        public DateTime GetDateOutInvoice(int parNumberDoc)
        {
            //TMP Треба Добисати через Link p tDocs
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToDateTime(SQL.ExecuteScalar(varSQLGetDateOutInvoice));
        }

        
        public int GetWaresOrder(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            object o = SQL.ExecuteScalar(varSQLGetWaresOrder);
            return (o == null?1:Convert.ToInt32(o));
        }


        /// <summary>
        /// Шукає товар по штрихкоду MetGetScanGoods
        /// </summary>
        /// <param name="parBarCode"></param>
        /// <returns>DataTable З знайденими товарами</returns>
        public DataTable FindGoodBarCode(int parNumberDoc, string parBarCode, bool parIsComplect)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            SQL.AddWithValue("@parBarCode", parBarCode);
            DataTable dt = SQL.ExecuteQuery(varSQLFindBarCode(parIsComplect,true));
            return dt;
        }

        /// <summary>
        /// Шукає товар по коду MetGetScanVesGoods
        /// </summary>
        /// <param name="parBarCode"></param>
        /// <returns>DataTable З знайденими товарами</returns>
        public DataTable FindGoodCodeWares(int parNumberDoc, string parCodeWares, bool parIsComplect)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            SQL.AddWithValue("@parCodeWares", parCodeWares);
            DataTable dt = SQL.ExecuteQuery(varSQLFindBarCode(parIsComplect,false));
            return dt;
        }

        public void SaveDocWares(int parNumberDoc, int parCodeWares,int parNupPop ,decimal parQty, decimal @parPrice)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            SQL.AddWithValue("@parCodeWares", parCodeWares);
            SQL.AddWithValue("@parNupPop", parNupPop);
            SQL.AddWithValue("@parQty", parQty);
            SQL.AddWithValue("@parPrice", parPrice);
            SQL.AddWithValue("@parChangeDate", DateTime.Now);
            SQL.ExecuteNonQuery(varSQLSaveDocWares);
        }

                
        /// <summary>
        /// Синхронізація з сервером.
        /// </summary>
        public void Sync()
        {
            
            try
            {
                int start_web = Environment.TickCount;
                string varLocalVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                // Заповнюємо в DataSet документи, які відмічені для відправки на сервер
                DataSet dsInvoice = new DataSet("dsInvoice");
                DataTable dtDocs;
                DataTable dtDocsWares;
                DataTable dtDocsIn;                
                DataTable dtWares;


                #region Завантаження  даних на сервер
                SQL.ClearParam();
                //налаштування для WEB-сервісу
                BRB.WebReference.BRB_Sync webService = new BRB.WebReference.BRB_Sync();
                webService.Url = Global.ServiceUrl; //@wsUrl;
                webService.Timeout = Global.ServiceTimeOut;

                string sqlStr = @"SELECT number_doc, type_doc, date_doc, serial_tzd, name_supplier, code_shop, sum_with_vat, sum_without_vat, flag_price_with_vat, number_out_invoice, 
                         date_out_invoice, number_tax_invoice, date_tax_invoice, flag_sum_qty_doc, change_date, input_code, flag_change_doc_sup, okpo_supplier, 
                         flag_insert_weigth_from_barcode AS flag_insert_weigth_from_barcod
                            FROM DOCS  WHERE  (status = 1) AND EXISTS  (SELECT 1 AS Expr1 FROM DOCS_WARES  WHERE (number_doc = DOCS.number_doc))";
                dtDocs=SQL.ExecuteQuery(sqlStr);
                dsInvoice.Tables.Add(dtDocs);
                
                sqlStr = @"SELECT   DW.number_doc, DW.code_wares, DW.code_unit, DW.price,  DW.price_temp, 
                                        DW.quantity,  DW.quantity_temp,  DW.num_pop, DW.change_date
                               FROM     DOCS_WARES AS DW 
                                INNER JOIN DOCS AS D ON DW.number_doc = D.number_doc
                               WHERE    (D.status = 1)";
                dtDocsWares = SQL.ExecuteQuery(sqlStr);
                dsInvoice.Tables.Add(dtDocsWares);
                
                // Вигружаємо дані на сервер,якщо є що
                string varWrongUpLoadDocs = string.Empty;
                if (dtDocs.Rows.Count > 0)
                {
                    DataSet ds = webService.UpLoadDocsNew(dsInvoice, varLocalVersion);
                    foreach (DataRow dr in ds.Tables["dtReturnHead"].Rows)
                    {  //Формуємо список успішно вигружених документів.
                        varWrongUpLoadDocs += (varWrongUpLoadDocs == "" ? "" : ",") + dr["number_doc"].ToString();
                    }
                }
                //Видаляємо завантажені документи з бази
                if (varWrongUpLoadDocs != string.Empty)
                {
                    sqlStr = @"delete from docs_wares where number_doc in 
					( select number_doc from docs where status = 1 and number_doc not in (" + varWrongUpLoadDocs + "))";
                    SQL.ExecuteNonQuery(sqlStr);
                    sqlStr = @"delete from docs where  status = 1 and number_doc not in (" + varWrongUpLoadDocs + ")";
                    SQL.ExecuteNonQuery(sqlStr);
                }
              
                //Видаляємо старі дані + де відсутня шапка або товари
                SQL.AddWithValueF("@Date_doc", DateTime.Now.Date.AddDays(-2));
                sqlStr = @"delete from docs_wares where number_doc in 
					( SELECT number_doc
                      FROM   DOCS
                      WHERE (date_doc < @Date_doc) AND (status = 0) AND (type_doc <> 2) OR
                            (date_doc - 1 < @Date_doc) AND (status = 0) AND (type_doc = 2) 
                     union 
                     SELECT DISTINCT dw.number_doc
                               FROM   DOCS_WARES AS dw LEFT OUTER JOIN
                                      DOCS AS d ON dw.number_doc = d.number_doc
                               WHERE  (d.number_doc IS NULL)
                     )";
                 SQL.ExecuteNonQuery(sqlStr);


                 sqlStr = @"delete from   docs where number_doc in 
                    ( SELECT number_doc
                      FROM   DOCS
                      WHERE (date_doc < @Date_doc) AND (status = 0) AND (type_doc <> 2) OR
                            (date_doc - 1 < @Date_doc) AND (status = 0) AND (type_doc = 2) 
                     union 
                         SELECT DISTINCT d.number_doc
                               FROM   DOCS AS d LEFT OUTER JOIN
                                      DOCS_WARES AS dw ON dw.number_doc = d.number_doc
                               WHERE  (dw.number_doc IS NULL)
                               AND    (d.type_doc <> 9)";
                SQL.ExecuteNonQuery(sqlStr);
                #endregion

                #region Завантаження даних з сервера
                //TMP ніде не використовується!!! вираховуємо товари, які є в документах, але відсутні в довідниках !!!Покіщо ніде не використовується
                sqlStr = @"SELECT  DISTINCT dw.code_wares
                                FROM   DOCS_WARES AS dw LEFT OUTER JOIN
                                        WARES AS w ON w.code_wares = dw.code_wares
                                WHERE  (w.code_wares IS NULL)";
               
                SQL.ClearParam();
                dtWares = SQL.ExecuteQuery(sqlStr);

                sqlStr = @"select number_doc from Docs";
                dtDocsIn = SQL.ExecuteQuery(sqlStr);
                string varNumberDoc=String.Empty;
                foreach (DataRow r in dtDocsIn.Rows)
                    varNumberDoc += (varNumberDoc == String.Empty ? "" : ",") + r[0];

                if (varNumberDoc == string.Empty)
                    varNumberDoc = "0";

                DataSet temp = null, dsInvoiceTemplate = null;
               
                DateTime t = Convert.ToDateTime(Global.TimeSync).Date;
                
                int w = 0, a = 0, u = 0;


              
                try
                {
                    dsInvoiceTemplate = webService.LoadDocs(temp, Global.DeviceID, Global.ShopName, w, a, u, t, varNumberDoc);
                

                // Зберігаємо отримані довідники  в базі
                SQL.BulkInsert(dsInvoiceTemplate.Tables["dtDocs"], "Docs");
                SQL.BulkInsert(dsInvoiceTemplate.Tables["dtDocsWares"], "Docs_Wares");
                if(SQL.IsData(dsInvoiceTemplate.Tables["dtWares"]))
                 {
                    SQL.ExecuteNonQuery(@"DELETE FROM wares");
                    SQL.BulkInsert(dsInvoiceTemplate.Tables["dtWares"], "Wares");
                  }

                 if(SQL.IsData(dsInvoiceTemplate.Tables["dtUnitDimension"]))
                 {
                    SQL.ExecuteNonQuery(@"DELETE FROM addition_unit");
                    SQL.BulkInsert(dsInvoiceTemplate.Tables["dtAdditionUnit"], "Addition_Unit");
                 }

                if(SQL.IsData(dsInvoiceTemplate.Tables["dtAdditionUnit"]))
                 {
                    SQL.ExecuteNonQuery(@"DELETE FROM unit_dimension");
                     SQL.BulkInsert(dsInvoiceTemplate.Tables["dtUnitDimension"], "Unit_Dimension");
                 }  
                
               

                    if (SQL.IsData( dsInvoiceTemplate.Tables["dtSettings"]))
                    {
                        DataRow dr =dsInvoiceTemplate.Tables["dtSettings"].Rows[0];
                        Global.TimeSync = Convert.ToDateTime( dr["time_sync"]);
                        
                        if(dr["code_shop"].ToString()!=Global.ShopName)
                        {
                            try
                            {
                              
                                    Global.ShopName = dr["code_shop"].ToString();
                                    ConfigFile cFile = new ConfigFile();
                                    cFile.SetAppSetting("ShopName", Global.ShopName, true);
                               
                            }
                            catch (System.Exception)
                            {
                                
                                varError= "Оновлення конфіг файла невдале!!";
                            }
                            

                        }
                           
                        SQL.AddWithValueF("@timesync",Global.TimeSync);
                        SQL.ExecuteNonQuery( @"update Settings set  TimeSync = @timesync"); 
                          
                       
                    }

                    if (dsInvoiceTemplate.Tables["dtDelDocs"].Rows.Count > 0)
                    {
                        if(SQL.IsData(dsInvoiceTemplate.Tables["dtDelDocs"]))
                         foreach (DataRow drHead in dsInvoiceTemplate.Tables["dtDelDocs"].Rows)
                            {
                                try
                                {
                                  SQL.AddWithValueF("@number_doc",Convert.ToInt32(drHead["number_doc"]));
                                  SQL.ExecuteNonQuery(@"delete from docs_wares where number_doc in (@number_doc)");
                                  SQL.ExecuteNonQuery(@"delete from docs where  number_doc in (@number_doc)");
                                }
                                catch{}
                            }
                        }

                    
                }
                catch(Exception Ex)
                {
                    varError="Звязок відсутній! Провірте підключення ТЗД!!!";
                    return;
                }
                #endregion


                string Directory = Global.Directory;
                string file = Global.RemouteFile;

                DownLoadFile(@"\Program Files\Update_brb", "Update_brb.exe", webService, null);
                if(DownLoadFile(Global.Directory, Global.RemouteFile, webService, varLocalVersion))
                    try
                    {
                        Process.Start("\\Program Files\\Update_brb\\Update_brb.exe", null);
                    }
                    catch
                    { }
                
                
                int end_web = Environment.TickCount;
                int result_web = (end_web - start_web) / 1000;
               
                
                if (varWrongUpLoadDocs == String.Empty)
                    varError = "Синхронізація завершена! Час синхронізації:" + result_web.ToString() + " сек.";
                else
                    varError = "Завершено з помилками! Документи №" + varWrongUpLoadDocs + " не загрузились на сервер! Час синхронізації:" + result_web.ToString();

            }
            catch
            { }
        }
        
        /// <summary>
        /// Оновлюємо файл з сервера. 
        /// </summary>
        /// <param name="parDir"></param>
        /// <param name="parFile"></param>
        /// <param name="parWebService"></param>
        /// <param name="parVersion">null Якщо треба визначити версію</param>
        /// <returns>Якщо файл оновлено true</returns>
        bool DownLoadFile(string parDir,string parFile,BRB.WebReference.BRB_Sync parWebService,string parVersion)
        {
            string varSourceFile = System.IO.Path.Combine(parDir, parFile);
            if(parVersion==null)
                try
                {
                    FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(varSourceFile);
                    
                        parVersion = fileInfo.ProductVersion;
                    
                }
                catch
                {
                    parVersion = "-1";
                }
            string varVersionServer = parWebService.GetFileVersionNew(parFile);
                if (varVersionServer != string.Empty && varVersionServer!=parVersion)
                    {

                        using (FileStream stream2 = new FileStream(varSourceFile, FileMode.Create))
                        {
                            try
                            {
                                byte[] buffer = parWebService.GetFile(parFile);
                                stream2.Write(buffer, 0, buffer.Length);
                                return true;
                            }
                            catch  { }
                        }                            
                     }

                return false;
        }
    }
}