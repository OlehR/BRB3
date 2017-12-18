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
        public delegate void CallProgressBar(int parPercent);

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
                                     COALESCE(flag_sum_qty_doc, 0) as flag_sum_qty_doc,
                                     COALESCE(input_code, 0) as input_code,
                                     COALESCE(flag_change_doc_sup, 0) as flag_change_doc_sup,
                                     COALESCE(flag_insert_weigth_from_barcode, 0) as flag_insert_weigth_from_barcode
                              FROM  DOCS AS d LEFT OUTER JOIN
                                     DOCS_WARES AS dw ON d.number_doc = dw.number_doc LEFT OUTER JOIN
                                      WARES AS w ON dw.code_wares=w.code_wares
                              WHERE type_doc {0} 
GROUP BY d.number_doc, d.type_doc, d.name_supplier, d.date_doc, d.flag_price_with_vat, d.sum_without_vat, d.sum_with_vat, d.status, d.okpo_supplier,  
                         d.number_out_invoice, d.date_out_invoice, d.flag_sum_qty_doc, input_code, flag_change_doc_sup, flag_insert_weigth_from_barcode";
        ////type_doc in (1, 3, 4, 5, 6, 7, 8)
        //TMP Є трохи магії з комплектацією Інший запит() треба буде розібратись
        private string varSQLDocsWares = @"SELECT dw.number_doc, 
                                           dw.code_wares, 
                                           dw.code_unit, 
                                           CASE
                                              WHEN d .flag_price_with_vat = 1 THEN dw.price * (1 + w.vat/100) 
                                              ELSE dw.price 
                                           END AS price,
                                           CASE
                                              WHEN d .flag_price_with_vat = 1 THEN round(dw.price_temp * (1 + w.vat/100) ,2)
                                              ELSE round(dw.price_temp, 2)
                                           END AS price_temp,  
                                           dw.quantity, 
                                           dw.quantity_temp, 
                                           dw.num_pop, 
                                           dw.change_date, 
                                           w.name_wares,
                                           au.coefficient,
                                           ud.abr_unit,
                                           COALESCE (ud.div, 0) AS div,
                                           w.vat,
                                           w.term,
                                           au.bar_code,
                                           d.type_doc,
                                           1.0 as coef_bar_code,
                                           '' as abr_unit_bar_code
                                 FROM      DOCS AS d INNER JOIN
                                           DOCS_WARES AS dw ON d.number_doc = dw.number_doc INNER JOIN
                                           WARES AS w ON dw.code_wares = w.code_wares INNER JOIN
                                           ADDITION_UNIT AS au ON dw.code_wares = au.code_wares AND dw.code_unit = au.code_unit AND au.default_unit = 'Y' INNER JOIN
                                           UNIT_DIMENSION AS ud ON dw.code_unit = ud.code_unit 
                                 WHERE     dw.number_doc = @parNumberDoc
                                 order by num_pop, name_wares";

        private string varSQLTimeSync = @"SELECT COALESCE(max(TimeSync), CONVERT(DATETIME, '01.01.2000', 000)),  FROM SETTINGS"; 
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

        private string varSQLSetStatusDoc = @"update docs set status = @parStatus where number_doc = @parNumberDoc";


        private string varSQLGetTypeDoc = @"select COALESCE(type_doc, 1) from Docs where number_doc = @parNumberDoc";

        private string varSQLGetDifferenceDoc = @"SELECT  COALESCE (COUNT(code_wares), 0)  FROM DOCS_WARES WHERE (quantity <> quantity_temp OR  quantity IS NULL) AND number_doc = @parNumberDoc";

        private string varSQLGetNumberOutInvoice = @"select COALESCE (number_out_invoice, '') from Docs where number_doc = @parNumberDoc";

        private string varSQLGetDateOutInvoice = @"select COALESCE (LEN(date_out_invoice), 0) from Docs where number_doc = @parNumberDoc";

        private string varSQLGetWaresOrder = @"SELECT   COALESCE (MAX(num_pop), 0)+1 as  num_pop  FROM     docs_wares   WHERE    number_doc  = @parNumberDoc";

        private string varSQLSaveDocWares = @"update docs_wares
						   set    quantity = @parQty,
						          price = @parPrice,
						          num_pop = @parNumPop,
                                  change_date = @parChangeDate 
						   where  code_wares = @parCodeWares
                           and    number_doc = @parNumberDoc";

        private string varSQLSaveDocEx = @"update docs
						   set    number_out_invoice =@parNumberOutInvoice,
                                  date_out_invoice = @parDateOutInvoice,
                                  flag_price_with_vat = @parFlagPriceWithVat,
                                  flag_change_doc_sup = @parFlagChangeDocSup,
                                  flag_sum_qty_doc = @parFlagSumQtyDoc,
                                  flag_insert_weigth_from_barcode=@parFlagInsertWeigthFromBarcode
                            where  number_doc = @parNumberDoc";

        private string varSQLFindCodeWaresFromBarCode = @"SELECT        au.code_wares, au.code_unit,au.coefficient, ud.abr_unit
                FROM   ADDITION_UNIT AS au INNER JOIN
                   UNIT_DIMENSION AS ud ON au.code_unit = ud.code_unit
                WHERE        (au.bar_code = @parBarCode)";
        //tree
        /*        private string varSQLFindBarCode(bool parIsComplect,bool parIsBarCode)
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
                                              w.term,
                                              d.type_doc
                                      FROM    DOCS_WARES AS dw 
                                      INNER JOIN WARES AS w ON dw.code_wares = w.code_wares 
                                      INNER JOIN ADDITION_UNIT AS au ON dw.code_unit = au.code_unit AND dw.code_wares = au.code_wares 
                                      INNER JOIN ADDITION_UNIT AS aus ON dw.code_wares = aus.code_wares 
                                      INNER JOIN DOCS AS d ON dw.number_doc = d.number_doc 
        " +
                                        (parIsComplect ? @"INNER JOIN DOCS AS dd ON d.okpo_supplier = dd.okpo_supplier AND d.type_doc = dd.type_doc AND d.date_doc = dd.date_doc AND d.code_shop = dd.code_shop " : "") +
                                        @"
                                       WHERE   (dw.number_doc = @parNumberDoc) AND 
        " +
         (parIsBarCode?@"                (aus.bar_code = @parBarCode)": @"(dw.code_wares = @parCodeWares)")+
        @"                              ORDER BY dw.quantity";
                }*/
        #endregion
        private string varError = null;
        private DataTable tDocs;
        private DataTable tDocsWares;
        private MSCeSQL SQL = null;
        //private bool UseCash = false;
        public Data() { }
        public Data(MSCeSQL parSQL) { Init(parSQL); }

        public void Close()
        {
            SQL.Close();
        }
        public void Init(MSCeSQL parSQL)
        {
            SQL = parSQL;
        }

        public DataTable FillDocs(TypeDoc parTypeDoc)
        {
            string varSQL = string.Format(varSQLDocs,
                (parTypeDoc == TypeDoc.Supply || parTypeDoc == TypeDoc.SupplyLogistic ? " in (1,3,4,5,6,7) " : string.Concat(" = ", (int)parTypeDoc)));
            //SQL.AddWithValueF("@parTypeDoc", parTypeDoc);
            SQL.ClearParam();
            tDocs = SQL.ExecuteQuery(varSQL);
            return tDocs;
        }

        public DataTable FillDocsWares(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            tDocsWares = SQL.ExecuteQuery(varSQLDocsWares);
            return tDocsWares;
        }
        public DateTime GetDateSync()
        {
            SQL.ClearParam(); //AddWithValueF("@parNumberDoc", parNumberDoc);
            return Convert.ToDateTime(SQL.ExecuteScalar(varSQLTimeSync)); // TMP !!!!!

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

        public Status SetStatusDoc(int parNumberDoc, TypeStatusDoc parStatus)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            SQL.AddWithValue("@parStatus", parStatus);
            SQL.ExecuteNonQuery(varSQLSetStatusDoc);
            return new Status();
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
            return (o == null ? 1 : Convert.ToInt32(o));
        }
        public DataRow GetCodeWaresFromBarCode(string parBarCode)
        {
            SQL.AddWithValueF("@parBarCode", parBarCode);
            DataTable dt = SQL.ExecuteQuery(varSQLFindCodeWaresFromBarCode);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }
        /*
                /// <summary>
                /// Шукає товар по штрихкоду MetGetScanGoods
                /// </summary>
                /// <param name="parBarCode"></param>
                /// <returns>DataTable З знайденими товарами</returns>
                public DataTable FindGoodBarCode(int parNumberDoc, string parBarCode, bool parIsComplect)
                {
                    SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
                    SQL.AddWithValue("@parBarCode", parBarCode);
                    string varSQL = varSQLFindBarCode(parIsComplect, true);
                    DataTable dt = SQL.ExecuteQuery(varSQL);
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
                */
        public void SaveDocWares(int parNumberDoc, int parCodeWares, int parNupPop, decimal parQty, decimal @parPrice)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            SQL.AddWithValue("@parCodeWares", parCodeWares);
            SQL.AddWithValue("@parNumPop", parNupPop);
            SQL.AddWithValue("@parQty", parQty);
            SQL.AddWithValue("@parPrice", parPrice);
            SQL.AddWithValue("@parChangeDate", DateTime.Now);
            SQL.ExecuteNonQuery(varSQLSaveDocWares);
        }

        public void SaveDocEx(int parNumberDoc, int parNumberOutInvoice, DateTime parDateOutInvoice, int parFlagPriceWithVat, int parFlagChangeDocSup, int parFlagSumQtyDoc, int parFlagInsertWeigthFromBarcode)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            SQL.AddWithValue("@parNumberOutInvoice", parNumberOutInvoice);
            SQL.AddWithValue("@parDateOutInvoice", parDateOutInvoice);
            SQL.AddWithValue("@parFlagPriceWithVat", parFlagPriceWithVat);
            SQL.AddWithValue("@parFlagChangeDocSup", parFlagChangeDocSup);
            SQL.AddWithValue("@parFlagSumQtyDoc", parFlagSumQtyDoc);
            SQL.AddWithValue("@parFlagInsertWeigthFromBarcode", parFlagInsertWeigthFromBarcode);

            SQL.ExecuteNonQuery(varSQLSaveDocEx);
        }

        /// <summary>
        /// Зберігає інформацію про ціну(Прайсчекер)
        /// </summary>
        /// <param name="parCodeWares"></param>
        /// <param name="parBarCode"></param>
        /// <param name="parStatus"></param>
        /// <returns></returns>
        public Status SavePCh(string parCodeWares, string parBarCode, string parStatus)
        {
            try
            {
                SQL.ClearParam();
                var o = SQL.ExecuteScalar(@"SELECT count(clID)+1 from CheckLogs");
                int clID = 1;
                if (o != null && o != DBNull.Value)
                    clID = Convert.ToInt32(o);

                string sqlStr = @"insert into CheckLogs(clID, clGoodsArticle, clBarcode, clStatus) values(@clID, @clGoodsArticle, @clBarcode, @clStatus)";
                SQL.AddWithValueF("@clID", clID);
                SQL.AddWithValue("@clGoodsArticle", parCodeWares);
                SQL.AddWithValue("@clBarcode", parBarCode);
                SQL.AddWithValue("@clStatus", parStatus);
                SQL.ExecuteNonQuery(sqlStr);
                return new Status();
            }
            catch (Exception ex)
            {
                return new Status(EStatus.DBError, ex.Message);
            }
        }

        public DataTable FindPCh(string parStrFind, int TypeFind)
        {
            string sqlFindPCh = "select cpID, cpGoodsName, cpGoodsArticle, cpBarcode, cpPrice1, cpPrice2 from CheckPrices where " +
                (TypeFind == 0 ? "cpGoodsArticle" : "cpBarcode") + "=@parStrFind";
            SQL.AddWithValueF("@parStrFind", parStrFind);
            return SQL.ExecuteQuery(sqlFindPCh);

        }

        /// <summary>
        /// Синхронізація з сервером.
        /// </summary>
        public Status Sync(TypeSynchronization parTSync, CallProgressBar parCallProgressBar)
        {
            try
            {
                if (parCallProgressBar != null)
                    parCallProgressBar(0);
                int start_web = Environment.TickCount;
                string varLocalVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                // Заповнюємо в DataSet документи, які відмічені для відправки на сервер
                DataSet dsInvoice = new DataSet("dsInvoice");
                DataTable dtDocs;
                DataTable dtDocsWares;
                DataTable dtDocsIn;
                DataTable dtWares;

                //налаштування для WEB-сервісу 
                BRB.WebReference.BRB_Sync webService = new BRB.WebReference.BRB_Sync();
                webService.Url = Global.ServiceUrl;  //@"http://localhost:20416/BRB3_Sync/BRB3_Sync.asmx";// Global.ServiceUrl; //@wsUrl;
                webService.Timeout = Global.ServiceTimeOut;


                #region Завантаження  даних на сервер
                string varWrongUpLoadDocs = string.Empty, sqlStr;

                if (parTSync == TypeSynchronization.Price)
                {
                    DataSet dsCheckLogs = new DataSet("dsCheckLogs");
                    sqlStr = @"select clID, clGoodsArticle, clBarcode, clStatus   from CheckLogs";
                    var dt = SQL.ExecuteQuery(sqlStr);
                    dt.TableName = "dtCheckLogs";
                    dsCheckLogs.Tables.Add(dt);

                    if (Proto.IsData(dt))
                    {
                        if (parCallProgressBar != null)
                            parCallProgressBar(15);
                        DataSet ds = webService.UpLoadPriceLogs(dsCheckLogs, Global.DeviceID, Global.ShopName);
                        if(parCallProgressBar!=null)
                            parCallProgressBar(35);
                        foreach (DataRow dr in ds.Tables["dtReturn"].Rows)
                        {
                            //sum++;
                            //errText = (string.IsNullOrEmpty(errText) ? "" : errText + ",") + dr["clGoodsArticle"].ToString();
                            varWrongUpLoadDocs = (string.IsNullOrEmpty(varWrongUpLoadDocs) ? "" : varWrongUpLoadDocs + ",") + "'" + dr["clID"].ToString() + "'";
                        }
                    }
                    // Видаляємо всі документи крім тих що не синхронізувались
                    sqlStr = @"delete from CheckLogs where clID not in (" + varWrongUpLoadDocs + ") ";
                    SQL.ExecuteNonQuery(sqlStr);
                    if (parCallProgressBar != null)
                        parCallProgressBar(50);
                  
                }
                else
                {
                    sqlStr = @"SELECT number_doc, type_doc, date_doc,@parSerialTZD as serial_tzd, name_supplier, code_shop, sum_with_vat, sum_without_vat, flag_price_with_vat, number_out_invoice, 
                         date_out_invoice, number_tax_invoice, date_tax_invoice, flag_sum_qty_doc, change_date, input_code, flag_change_doc_sup, okpo_supplier, 
                         flag_insert_weigth_from_barcode AS flag_insert_weigth_from_barcod
                            FROM DOCS  WHERE  (status = 1) AND EXISTS  (SELECT 1 AS Expr1 FROM DOCS_WARES  WHERE (number_doc = DOCS.number_doc))";

                    //SQL.ClearParam();
                    SQL.AddWithValueF("@parSerialTZD", Global.DeviceID);
                    dtDocs = SQL.ExecuteQuery(sqlStr);
                    dtDocs.TableName = "dtDocs";
                    dsInvoice.Tables.Add(dtDocs);

                    sqlStr = @"SELECT   DW.number_doc, DW.code_wares, DW.code_unit, DW.price,  DW.price_temp, 
                                        DW.quantity,  DW.quantity_temp,  DW.num_pop, DW.change_date
                               FROM     DOCS_WARES AS DW 
                                INNER JOIN DOCS AS D ON DW.number_doc = D.number_doc
                               WHERE    (D.status = 1)";
                    SQL.ClearParam();
                    dtDocsWares = SQL.ExecuteQuery(sqlStr);
                    dtDocsWares.TableName = "dtDocsWares";
                    dsInvoice.Tables.Add(dtDocsWares);


                    // Вигружаємо дані на сервер,якщо є що
                
                     if (dtDocs.Rows.Count > 0)
                    {
                        try
                        {
                            if (parCallProgressBar != null)
                                parCallProgressBar(10);
                            var ds = webService.UpLoadDocsNew(dsInvoice, varLocalVersion);
                            if (parCallProgressBar != null)
                                parCallProgressBar(15);
                            foreach (DataRow dr in ds.Tables["dtReturnHead"].Rows)
                            {  //Формуємо список успішно вигружених документів.
                                varWrongUpLoadDocs += (varWrongUpLoadDocs == "" ? "" : ",") + dr["number_doc"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            return new Status(EStatus.Error, ex.Message);
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
                    if (parCallProgressBar != null)
                        parCallProgressBar(25);

                }
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
                string varNumberDoc = String.Empty;
                foreach (DataRow r in dtDocsIn.Rows)
                    varNumberDoc += (varNumberDoc == String.Empty ? "" : ",") + r[0];

                if (varNumberDoc == string.Empty)
                    varNumberDoc = "0";

                DataSet temp = null, dsAnswer = null;

                int w = 0, a = 0, u = 0;
                //Якщо синхронізація відбувалась не сьогодня то повне оновлення.
                if (Global.TimeSync.Date != DateTime.Now.Date)
                    w = a = u = 1;

                try
                {
                    if (parCallProgressBar != null)
                        parCallProgressBar(65);
                    switch (parTSync)
                    {
                        case TypeSynchronization.Document:
                            dsAnswer = webService.LoadDocs(temp, Global.DeviceID, Global.ShopName, w, a, u, Global.TimeSync.Date, varNumberDoc);
                            // Зберігаємо отримані довідники  в базі

                            break;
                        case TypeSynchronization.Inventories:
                            dsAnswer = webService.LoadInventory ( Global.DeviceID, Global.ShopName, varNumberDoc);
                            break;
                        case TypeSynchronization.Price:
                            //Удалим все цены на товары!!! 08.04.2011
                            sqlStr = @"delete from CheckPrices";
                            SQL.ExecuteNonQuery(sqlStr);

                            // Загрузим новые документы -------------------------------------------
                            DataSet dsCheckPrices = new DataSet("dsCheckPrices");
                            sqlStr = @"select cpID  from CheckPrices ";
                            var dt = SQL.ExecuteQuery(sqlStr);
                            dt.TableName = "dtCheckPrices";
                            dsCheckPrices.Tables.Add(dt);
                            dsAnswer = webService.LoadCheckPrices(dsCheckPrices, Global.DeviceID, Global.ShopName);
                            if (dsAnswer != null && Proto.IsData(dsAnswer.Tables["CheckPrices"]))
                                SQL.BulkInsert(dsAnswer.Tables["CheckPrices"], "CheckPrices");
                            break;
                    }
                    if (parCallProgressBar != null)
                        parCallProgressBar(75);

                    if (SQL.IsData(dsAnswer.Tables["dtDocs"]))
                        SQL.BulkInsert(dsAnswer.Tables["dtDocs"], "Docs");

                    if (SQL.IsData(dsAnswer.Tables["dtDocsWares"]))
                        SQL.BulkInsert(dsAnswer.Tables["dtDocsWares"], "Docs_Wares");


                    if (SQL.IsData(dsAnswer.Tables["dtWares"]))
                    {
                        SQL.ExecuteNonQuery(@"DELETE FROM wares");
                        SQL.BulkInsert(dsAnswer.Tables["dtWares"], "Wares");
                    }

                    if (SQL.IsData(dsAnswer.Tables["dtUnitDimension"]))
                    {
                        SQL.ExecuteNonQuery(@"DELETE FROM addition_unit");
                        SQL.BulkInsert(dsAnswer.Tables["dtAdditionUnit"], "Addition_Unit");
                    }

                    if (SQL.IsData(dsAnswer.Tables["dtAdditionUnit"]))
                    {
                        SQL.ExecuteNonQuery(@"DELETE FROM unit_dimension");
                        SQL.BulkInsert(dsAnswer.Tables["dtUnitDimension"], "Unit_Dimension");
                    }

                    if (SQL.IsData(dsAnswer.Tables["dtSettings"]))
                    {
                        DataRow dr = dsAnswer.Tables["dtSettings"].Rows[0];
                        Global.TimeSync = Convert.ToDateTime(dr["time_sync"]);

                        if (dr["code_shop"].ToString() != Global.ShopName)
                        {
                            try
                            {
                                Global.ShopName = dr["code_shop"].ToString();
                                ConfigFile cFile = new ConfigFile(Global.varConfigFile);
                                cFile.SetAppSetting("ShopName", Global.ShopName, true);

                            }
                            catch (System.Exception)
                            {
                                varError = "Оновлення конфіг файла невдале!!";
                            }

                        }

                        SQL.AddWithValueF("@timesync", Global.TimeSync);
                        SQL.ExecuteNonQuery(@"update Settings set  TimeSync = @timesync");
                    }
                    if (parCallProgressBar != null)
                        parCallProgressBar(85);

                    
                    if (SQL.IsData(dsAnswer.Tables["dtDelDocs"]))
                      foreach (DataRow drHead in dsAnswer.Tables["dtDelDocs"].Rows)
                            {
                                try
                                {
                                    SQL.AddWithValueF("@number_doc", Convert.ToInt32(drHead["number_doc"]));
                                    SQL.ExecuteNonQuery(@"delete from docs_wares where number_doc in (@number_doc)");
                                    SQL.ExecuteNonQuery(@"delete from docs where  number_doc in (@number_doc)");
                                }
                                catch { }
                            }
                    
                    if (parCallProgressBar != null)
                        parCallProgressBar(90);


                }
                catch (Exception Ex)
                {
                    return new Status(EStatus.Error, "Звязок відсутній! Провірте підключення ТЗД!!!" + Ex.Message);
                }
                #endregion

                string Directory = Global.Directory;
                string file = Global.RemouteFile;

                DownLoadFile(@"\Program Files\Update_brb", "Update_brb.exe", webService, null);
                if (DownLoadFile(Global.Directory, Global.RemouteFile, webService, varLocalVersion))
                    try
                    {
                        Process.Start(@"\Program Files\Update_brb\Update_brb.exe", null);
                    }
                    catch
                    { }

                int end_web = Environment.TickCount;
                int result_web = (end_web - start_web) / 1000;

                if (varWrongUpLoadDocs == String.Empty)
                    varError = "Синхронізація завершена! Час синхронізації:" + result_web.ToString() + " сек.";
                else
                    varError = "Завершено з помилками! Документи №" + varWrongUpLoadDocs + " не загрузились на сервер! Час синхронізації:" + result_web.ToString();

                if (parCallProgressBar != null)
                    parCallProgressBar(100);
            }
            catch
            { }
            return new Status(EStatus.Ok, varError);
        }
/*

        public Status SyncPr()
        {
            // Синхронизация           
            //доработка
            int start_web, end_web, result_web, start_base, end_base, result_base, start_proc, end_proc, result_proc;
            int sum = 0;
            try
            {

                string errText = string.Empty;
                string errDocs = "'-0'";
                //int i=0;

                start_proc = Environment.TickCount;

                //налаштування для WEB-сервісу
                var webService = new BRB.WebReference.BRB_Sync();
                webService.Url = Global.ServiceUrl; //@wsUrl;
                webService.Timeout = Global.ServiceTimeOut;


                // Вычитаем готовые к отправке
                DataSet dsCheckLogs = new DataSet("dsCheckLogs");
                string sqlStr = @"select clID, clGoodsArticle, clBarcode, clStatus   from CheckLogs";
                var dt = SQL.ExecuteQuery(sqlStr);
                dt.TableName = "dtCheckLogs";
                dsCheckLogs.Tables.Add(dt);

                if (Proto.IsData(dt))
                {

                    DataSet ds = webService.UpLoadPriceLogs(dsCheckLogs, Global.DeviceID, Global.ShopName);
                    foreach (DataRow dr in ds.Tables["dtReturn"].Rows)
                    {
                        sum++;
                        errText = (string.IsNullOrEmpty(errText) ? "" : errText + ",") + dr["clGoodsArticle"].ToString();
                        errDocs = (string.IsNullOrEmpty(errDocs) ? "" : errText + ",") + "'" + dr["clID"].ToString() + "'";
                    }
                }


                // Удалим все локальные загруженные документы
                sqlStr = @"delete from CheckLogs where clID not in (" + errDocs + ") ";
                SQL.ExecuteNonQuery(sqlStr);

                //Удалим все цены на товары!!! 08.04.2011
                sqlStr = @"delete from CheckPrices";
                SQL.ExecuteNonQuery(sqlStr);

                // Загрузим новые документы -------------------------------------------
                DataSet dsCheckPrices = new DataSet("dsCheckPrices");
                sqlStr = @"select cpID  from CheckPrices ";
                dt = SQL.ExecuteQuery(sqlStr);
                dt.TableName = "dtCheckPrices";
                dsCheckLogs.Tables.Add(dt);

                start_web = Environment.TickCount;

                DataSet ds1 = webService.LoadCheckPrices(dsCheckPrices, Global.DeviceID, Global.ShopName);

                end_web = Environment.TickCount;
                result_web = (end_web - start_web) / 1000;


                start_base = Environment.TickCount;
                if (ds1 != null && Proto.IsData(ds1.Tables["CheckPrices"]))
                    SQL.BulkInsert(ds1.Tables["CheckPrices"], "CheckPrices");

                end_base = Environment.TickCount;
                result_base = (end_base - start_base) / 1000;

                end_proc = Environment.TickCount;
                result_proc = (end_proc - start_proc) / 1000;

                // Вычитаем 
                if (errText == "")
                    varError = "Синхронізація завершена успішно!";
                else
                    varError = "Завершено з помилками! Не загрузилось " + sum + " товарів";

            }
            catch (Exception)
            {
                varError = "Звязок відсутній! Провірте підключення ТЗД!!!";
            }
            return new Status(EStatus.Ok, varError);

        }
*/
        /// <summary>
        /// Оновлюємо файл з сервера. 
        /// </summary>
        /// <param name="parDir"></param>
        /// <param name="parFile"></param>
        /// <param name="parWebService"></param>
        /// <param name="parVersion">null Якщо треба визначити версію</param>
        /// <returns>Якщо файл оновлено true</returns>
        bool DownLoadFile(string parDir, string parFile, BRB.WebReference.BRB_Sync parWebService, string parVersion)
        {
            string varSourceFile = System.IO.Path.Combine(parDir, parFile);
            if (parVersion == null)
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
            if (varVersionServer != string.Empty && varVersionServer != parVersion)
            {

                using (FileStream stream2 = new FileStream(varSourceFile, FileMode.Create))
                {
                    try
                    {
                        byte[] buffer = parWebService.GetFile(parFile);
                        stream2.Write(buffer, 0, buffer.Length);
                        return true;
                    }
                    catch { }
                }
            }

            return false;
        }

        #region База Даних

        private string dbCreateTableAU = @"CREATE TABLE [ADDITION_UNIT]
                                        (
                                           [code_wares] INT NOT NULL,
                                           [code_unit] INT NOT NULL,
                                           [coefficient] INT NOT NULL,
                                           [bar_code] NVARCHAR(15),
                                           [default_unit] NVARCHAR(2)
                                        )";

        private string dbCreateTableCL = @"CREATE TABLE [CheckLogs]
                                    (
                                       [clID] NVARCHAR(50) NOT NULL,
                                       [clGoodsArticle] NVARCHAR(50),
                                       [clBarcode] NVARCHAR(50),
                                       [clStatus] NVARCHAR(100)
                                    )";

        private string dbCreateTableCP = @"CREATE TABLE [CheckPrices]
                                        (
                                           [cpID] NVARCHAR(50) NOT NULL,
                                           [cpGoodsName] NVARCHAR(100),
                                           [cpGoodsArticle] NVARCHAR(50),
                                           [cpBarcode] NVARCHAR(50),
                                           [cpPrice1] DECIMAL(18,4),
                                           [cpPrice2] DECIMAL(18,4)
                                        )";

        private string dbCreateTableDocs = @"CREATE TABLE [DOCS]
                                            (
                                               [number_doc] INT NOT NULL,
                                               [type_doc] INT,
                                               [date_doc] DATETIME,
                                               [serial_tzd] NVARCHAR(20),
                                               [name_supplier] NVARCHAR(500),
                                               [code_shop] INT,
                                               [status] INT DEFAULT 0,
                                               [sum_with_vat] DECIMAL(18,4) DEFAULT 0,
                                               [sum_without_vat] DECIMAL(18,4) DEFAULT 0,
                                               [flag_price_with_vat] INT DEFAULT 0,
                                               [number_out_invoice] NVARCHAR(20),
                                               [date_out_invoice] DATETIME,
                                               [number_tax_invoice] NVARCHAR(20),
                                               [date_tax_invoice] DATETIME,
                                               [flag_sum_qty_doc] INT DEFAULT 0,
                                               [change_date] DATETIME,
                                               [input_code] INT DEFAULT 1,
                                               [flag_change_doc_sup] INT DEFAULT 0,
                                               [okpo_supplier] BIGINT,
                                               [flag_insert_weigth_from_barcode] INT DEFAULT 0
                                            )";

        private string dbCreateTableDW = @"CREATE TABLE [DOCS_WARES]
                                        (
                                           [number_doc] INT NOT NULL,
                                           [code_wares] INT NOT NULL,
                                           [code_unit] INT NOT NULL,
                                           [price] DECIMAL(18,8),
                                           [price_temp] DECIMAL(18,8),
                                           [quantity] DECIMAL(18,3),
                                           [quantity_temp] DECIMAL(18,3),
                                           [num_pop] INT,
                                           [change_date] DATETIME
                                        )";

        private string dbCreateTableR = @"CREATE TABLE [RevisionOS]
                                        (
                                           [revID] INT NOT NULL IDENTITY (1,1),
                                           [revCode] NVARCHAR(20) NOT NULL,
                                           [revDate] DATETIME NOT NULL,
                                           [osBarcode] NVARCHAR(20) NOT NULL,
                                           [osName] NVARCHAR(100),
                                           [osState] INT NOT NULL DEFAULT 0,
                                           [osPrice] REAL,
                                           [osCode] NVARCHAR(10)
                                        )";

        private string dbCreateTableRL = @"CREATE TABLE [RevisionOSLogs]
                                        (
                                           [revID] INT NOT NULL,
                                           [revCode] NVARCHAR(20) NOT NULL,
                                           [revDate] DATETIME NOT NULL,
                                           [osBarcode] NVARCHAR(13) NOT NULL,
                                           [osStatus] INT NOT NULL
                                        )";

        private string dbCreateTableSet = @"CREATE TABLE [SETTINGS]
                                        (
                                            [TimeSync] DATETIME,
                                            [TimeSyncInvent] DATETIME
                                         )";

        private string dbCreateTableUD = @"CREATE TABLE [UNIT_DIMENSION]
                                        (
                                           [code_unit] INT NOT NULL,
                                           [abr_unit] NVARCHAR(10),
                                           [div] INT DEFAULT 0
                                        )";

        private string dbCreateTableWares = @"CREATE TABLE [WARES]
                                            (
                                               [code_wares] INT NOT NULL,
                                               [name_wares] NVARCHAR(100) NOT NULL,
                                               [vat] DECIMAL(10,0) NOT NULL DEFAULT 20,
                                               [term] DECIMAL(18,0)
                                            )";

        private string dbCreateAlterTable1 = @"ALTER TABLE [CheckLogs] ADD CONSTRAINT [PK_CheckLogs] PRIMARY KEY ([clID])";
        private string dbCreateAlterTable2 = @"ALTER TABLE [CheckPrices] ADD CONSTRAINT [PK_CheckPrices] PRIMARY KEY ([cpID])";
        private string dbCreateAlterTable3 = @"ALTER TABLE [DOCS] ADD CONSTRAINT [PK_DOCS] PRIMARY KEY ([number_doc])";
        private string dbCreateAlterTable4 = @"ALTER TABLE [RevisionOS] ADD CONSTRAINT [PK_RevisionOS] PRIMARY KEY ([revID])";
        private string dbCreateAlterTable5 = @"ALTER TABLE [RevisionOSLogs] ADD CONSTRAINT [PK_RevisionOSLogs] PRIMARY KEY ([revID])";
        private string dbCreateAlterTable6 = @"ALTER TABLE [WARES] ADD CONSTRAINT [PK__WARES__0000000000000036] PRIMARY KEY ([code_wares])";

        private string dbCreateIndex01 = @"CREATE INDEX [ad_u_ind] ON [ADDITION_UNIT] ([bar_code] ASC)";
        private string dbCreateIndex02 = @"CREATE INDEX [id_code_wares] ON [ADDITION_UNIT] ([code_wares] ASC, [code_unit] ASC)";
        private string dbCreateIndex03 = @"CREATE UNIQUE INDEX [UQ__CheckLogs__0000000000000207] ON [CheckLogs] ([clID] ASC)";
        private string dbCreateIndex04 = @"CREATE INDEX [Bar_code_ind] ON [CheckPrices] ([cpBarcode] ASC)";
        private string dbCreateIndex05 = @"CREATE UNIQUE INDEX [UQ__CheckPrices__00000000000001F5] ON [CheckPrices] ([cpID] ASC)";
        private string dbCreateIndex06 = @"CREATE UNIQUE INDEX [UQ__DOCS__0000000000000073] ON [DOCS] ([number_doc] ASC)";
        private string dbCreateIndex07 = @"CREATE INDEX [id_code_wares] ON [DOCS_WARES] ([code_wares] ASC)";

        private string dbCreateIndex08 = @"CREATE INDEX [id_number_doc] ON [DOCS_WARES] ([number_doc] ASC)";
        private string dbCreateIndex09 = @"CREATE INDEX [osBarcode_ind] ON [RevisionOS] ([osBarcode] ASC)";
        private string dbCreateIndex10 = @"CREATE UNIQUE INDEX [UQ__RevisionOS__0000000000000266] ON [RevisionOS] ([revID] ASC)";
        private string dbCreateIndex11 = @"CREATE UNIQUE INDEX [UQ__RevisionOSLogs__000000000000027D] ON [RevisionOSLogs] ([revID] ASC)";
        private string dbCreateIndex12 = @"CREATE UNIQUE INDEX [UQ__UNIT_DIMENSION__0000000000000031] ON [UNIT_DIMENSION] ([code_unit] ASC)";
        private string dbCreateIndex13 = @"CREATE UNIQUE INDEX [UQ__WARES__000000000000000B] ON [WARES] ([code_wares] ASC)";



        #endregion

        public Status CreadeDB(CallProgressBar parCallProgressBar)
        {
            if (parCallProgressBar != null)
                parCallProgressBar(0);

            Global.cData.Close();

            string pathDbBack = Global.dbPathBRB + ".bak";
            int lcid = 1033;
            string connStr = string.Format("DataSource=\"{0}\"; LCID='{1}'; Password='{2}'", Global.dbPathBRB, lcid, Global.DbPwl);

            try
            {
                if (File.Exists(pathDbBack))
                    File.Delete(pathDbBack);

                if (File.Exists(Global.dbPathBRB))
                    File.Move(Global.dbPathBRB, pathDbBack);

                if (parCallProgressBar != null)
                    parCallProgressBar(10);

                SqlCeEngine engine = new SqlCeEngine(connStr);
                engine.CreateDatabase();
                engine.Dispose();

                if (parCallProgressBar != null)
                    parCallProgressBar(20);

                try
                {
                    Global.cData.Init(new MSCeSQL(Global.SqlCeConectionBRB));
                    SQL.ClearParam();

                    SQL.ExecuteNonQuery(dbCreateTableAU);
                    SQL.ExecuteNonQuery(dbCreateTableCL);
                    SQL.ExecuteNonQuery(dbCreateTableCP);
                    SQL.ExecuteNonQuery(dbCreateTableDocs);
                    SQL.ExecuteNonQuery(dbCreateTableDW);

                    if (parCallProgressBar != null)
                        parCallProgressBar(40);

                    SQL.ExecuteNonQuery(dbCreateTableR);
                    SQL.ExecuteNonQuery(dbCreateTableRL);
                    SQL.ExecuteNonQuery(dbCreateTableSet);
                    SQL.ExecuteNonQuery(dbCreateTableUD);
                    SQL.ExecuteNonQuery(dbCreateTableWares);

                    if (parCallProgressBar != null)
                        parCallProgressBar(70);

                    SQL.ExecuteNonQuery(dbCreateAlterTable1);
                    SQL.ExecuteNonQuery(dbCreateAlterTable2);
                    SQL.ExecuteNonQuery(dbCreateAlterTable3);
                    SQL.ExecuteNonQuery(dbCreateAlterTable4);
                    SQL.ExecuteNonQuery(dbCreateAlterTable5);
                    SQL.ExecuteNonQuery(dbCreateAlterTable6);

                    if (parCallProgressBar != null)
                        parCallProgressBar(80);

                    SQL.ExecuteNonQuery(dbCreateIndex01);
                    SQL.ExecuteNonQuery(dbCreateIndex02);
                    SQL.ExecuteNonQuery(dbCreateIndex03);
                    SQL.ExecuteNonQuery(dbCreateIndex04);
                    SQL.ExecuteNonQuery(dbCreateIndex05);
                    SQL.ExecuteNonQuery(dbCreateIndex06);
                    SQL.ExecuteNonQuery(dbCreateIndex07);

                    if (parCallProgressBar != null)
                        parCallProgressBar(90);

                    SQL.ExecuteNonQuery(dbCreateIndex08);
                    SQL.ExecuteNonQuery(dbCreateIndex09);
                    SQL.ExecuteNonQuery(dbCreateIndex10);
                    SQL.ExecuteNonQuery(dbCreateIndex11);
                    SQL.ExecuteNonQuery(dbCreateIndex12);
                    SQL.ExecuteNonQuery(dbCreateIndex13);
                 
                    if (parCallProgressBar != null)
                        parCallProgressBar(100);

                }
                catch (Exception e)
                {
                    return new Status(EStatus.DbStructCreatedError, e.ToString());
                }
                finally
                {
                    //Global.cData.Close(); //TMP
                }

            }
            catch (Exception e)
            {
                return new Status(EStatus.DbCreatedError, e.ToString());
            }
            
            return new Status(EStatus.DbCleaned);
        }
    }
    
}