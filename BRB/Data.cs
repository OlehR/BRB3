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
                                     date_out_invoice
                              FROM  DOCS AS d LEFT OUTER JOIN
                                     DOCS_WARES AS dw ON d.number_doc = dw.number_doc LEFT OUTER JOIN
                                      WARES AS w ON dw.code_wares=w.code_wares
                              WHERE type_doc in (1, 3, 4, 5, 6, 7, 8)
                              GROUP BY d.number_doc, d.type_doc, d.name_supplier, d.date_doc, d.flag_price_with_vat, d.sum_without_vat, d.sum_with_vat, d.status, d.okpo_supplier";
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


        #endregion
        private string varError=null;
        private DataTable tDocs;
        private DataTable tDocsWares;
        private MSCeSQL SQL = null;
        private bool UseCash = false;
        public void Init(MSCeSQL parSQL)
        {
            SQL = parSQL;
        }

        public void FillDocs()
        {
            tDocs = SQL.ExecuteQuery(varSQLDocs);
        }
        public void FillDocsWares()
        {
            tDocs = SQL.ExecuteQuery(varSQLDocsWares);
        }
        public void FillDocsWares(int parNumberDoc)
        {
            SQL.AddWithValueF("@parNumberDoc", parNumberDoc);
            tDocsWares = SQL.ExecuteQuery(varSQLDocs);
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
        /// <summary>
        /// Синхронізація
        /// </summary>
        private void btnSync()
        {
            
            try
            {
                int start_web = Environment.TickCount;
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                // Заповнюємо в DataSet документи, які відмічені для відправки на сервер
                DataSet dsInvoice = new DataSet("dsInvoice");
                DataTable dtDocs;
                DataTable dtDocsWares;
                DataTable dtDocsIn;
                DataTable dtDocsOnly;
                DataTable dtWares;
                #region Створення DataSet
                dtDocs = new DataTable("dtDocs");

                dtDocs.Columns.Add("number_doc", typeof(int));
                dtDocs.Columns.Add("type_doc", typeof(int));
                dtDocs.Columns.Add("date_doc", typeof(DateTime));
                dtDocs.Columns.Add("serial_tzd", typeof(string));
                dtDocs.Columns.Add("name_supplier", typeof(string));
                dtDocs.Columns.Add("code_shop", typeof(int));
                dtDocs.Columns.Add("sum_with_vat", typeof(decimal));
                dtDocs.Columns.Add("sum_without_vat", typeof(decimal));
                dtDocs.Columns.Add("flag_price_with_vat", typeof(int));
                dtDocs.Columns.Add("number_out_invoice", typeof(string));
                dtDocs.Columns.Add("date_out_invoice", typeof(DateTime));
                dtDocs.Columns.Add("number_tax_invoice", typeof(string));
                dtDocs.Columns.Add("date_tax_invoice", typeof(DateTime));
                dtDocs.Columns.Add("flag_sum_qty_doc", typeof(int));
                dtDocs.Columns.Add("change_date", typeof(DateTime));
                dtDocs.Columns.Add("input_code", typeof(int));
                dtDocs.Columns.Add("flag_change_doc_sup", typeof(int));
                dtDocs.Columns.Add("okpo_supplier", typeof(string));
                dtDocs.Columns.Add("flag_insert_weigth_from_barcod", typeof(int));

                dtDocs.PrimaryKey = new DataColumn[] { dtDocs.Columns["number_doc"] };

                dsInvoice.Tables.Add(dtDocs);

                dtDocsWares = new DataTable("dtDocsWares");

                dtDocsWares.Columns.Add("number_doc", typeof(int));
                dtDocsWares.Columns.Add("code_wares", typeof(int));
                dtDocsWares.Columns.Add("code_unit", typeof(int));
                dtDocsWares.Columns.Add("price", typeof(decimal));
                dtDocsWares.Columns.Add("price_temp", typeof(decimal));
                dtDocsWares.Columns.Add("quantity", typeof(decimal));
                dtDocsWares.Columns.Add("quantity_temp", typeof(decimal));
                dtDocsWares.Columns.Add("num_pop", typeof(int));
                dtDocsWares.Columns.Add("change_date", typeof(DateTime));

                dtDocsWares.PrimaryKey = new DataColumn[] { dtDocsWares.Columns["number_doc"], dtDocsWares.Columns["code_wares"] };

                dsInvoice.Tables.Add(dtDocsWares);

                dtDocsIn = new DataTable("dtDocsIn");
                dtDocsIn.Columns.Add("number_doc", typeof(int));
                dtDocsIn.PrimaryKey = new DataColumn[] { dtDocsIn.Columns["number_doc"] };

                dsInvoice.Tables.Add(dtDocsIn);

                dtDocsOnly = new DataTable("dtDocsOnly");
                dtDocsOnly.Columns.Add("number_doc", typeof(int));
                dtDocsOnly.PrimaryKey = new DataColumn[] { dtDocsOnly.Columns["number_doc"] };

                dsInvoice.Tables.Add(dtDocsOnly);

                dtWares = new DataTable("dtWares");
                dtWares.Columns.Add("code_wares", typeof(int));
                dtWares.PrimaryKey = new DataColumn[] { dtWares.Columns["code_wares"] };
                #endregion

                
                //налаштування для WEB-сервісу
                BRB.WebReference.BRB_Sync webService = new BRB.WebReference.BRB_Sync();

                webService.Url = Global.ServiceUrl; //@wsUrl;
                webService.Timeout = Global.ServiceTimeOut;

                SqlCeConnection conn = new SqlCeConnection(Global.SqlCeConectionBRB);
                ConfigFile cFile = null;

                string sqlStr = @"SELECT number_doc, type_doc, date_doc, serial_tzd, name_supplier, code_shop, sum_with_vat, sum_without_vat, flag_price_with_vat, number_out_invoice, 
                         date_out_invoice, number_tax_invoice, date_tax_invoice, flag_sum_qty_doc, change_date, input_code, flag_change_doc_sup, okpo_supplier, 
                         flag_insert_weigth_from_barcode AS flag_insert_weigth_from_barcod
                            FROM DOCS  WHERE  (status = 1) AND EXISTS  (SELECT 1 AS Expr1 FROM DOCS_WARES  WHERE (number_doc = DOCS.number_doc))";

                SqlCeDataAdapter daHead = new SqlCeDataAdapter(sqlStr, conn);

                sqlStr = @"SELECT   DW.number_doc, DW.code_wares, DW.code_unit, DW.price,  DW.price_temp, 
                                        DW.quantity,  DW.quantity_temp,  DW.num_pop, DW.change_date
                               FROM     DOCS_WARES AS DW 
                                INNER JOIN DOCS AS D ON DW.number_doc = D.number_doc
                               WHERE    (D.status = 1)";

                SqlCeDataAdapter daRows = new SqlCeDataAdapter(sqlStr, conn);

                sqlStr = @"SELECT DISTINCT dw.number_doc
                               FROM   DOCS_WARES AS dw LEFT OUTER JOIN
                                      DOCS AS d ON dw.number_doc = d.number_doc
                               WHERE  (d.number_doc IS NULL)";

                SqlCeDataAdapter daDel = new SqlCeDataAdapter(sqlStr, conn);

                sqlStr = @"SELECT DISTINCT d.number_doc
                               FROM   DOCS AS d LEFT OUTER JOIN
                                      DOCS_WARES AS dw ON dw.number_doc = d.number_doc
                               WHERE  (dw.number_doc IS NULL)
                               AND    (d.type_doc <> 9)";

                SqlCeDataAdapter daDelHead = new SqlCeDataAdapter(sqlStr, conn);

                try
                {
                    conn.Open();
                    daHead.Fill(dsInvoice.Tables["dtDocs"]);
                    daRows.Fill(dsInvoice.Tables["dtDocsWares"]);
                    daDel.Fill(dsInvoice.Tables["dtDocsIn"]);
                    daDelHead.Fill(dsInvoice.Tables["dtDocsOnly"]);
                }
                finally
                {
                    conn.Close();
                }

                string errDocs = string.Empty;

                if (dsInvoice.Tables["dtDocs"].Rows.Count > 0) 
                {
                    // Обратимся к сервису и скинем туда данные
                    DataSet ds = webService.UpLoadDocsNew(dsInvoice, version);
                    foreach (DataRow dr in ds.Tables["dtReturnHead"].Rows)
                    {
                        errDocs+= (errDocs==""? "":",")+dr["number_doc"].ToString();                        
                    }
                }

                if (errDocs == string.Empty)
                    errDocs = "0";

                string s = @"delete from docs_wares where number_doc in 
					( select number_doc from docs where status = 1 and number_doc not in (" + errDocs + "))";
                SqlCeCommand cmdDelDocWSt = new SqlCeCommand(s, conn);

                s = @"delete from docs where  status = 1 and number_doc not in (" + errDocs + ")";
                SqlCeCommand cmdDelDocSt = new SqlCeCommand(s, conn);

                DateTime dt = DateTime.Now.Date.AddDays(-2);

                s = @"delete from docs_wares where number_doc in 
					( SELECT number_doc
                      FROM   DOCS
                      WHERE (date_doc < @Date_doc) AND (status = 0) AND (type_doc <> 2) OR
                            (date_doc - 1 < @Date_doc) AND (status = 0) AND (type_doc = 2) )";
                SqlCeCommand cmdDelDocW = new SqlCeCommand(s, conn);
                cmdDelDocW.Parameters.Add("@Date_doc", SqlDbType.DateTime).Value = dt;

                s = @"delete 
                          from   docs 
                          where (date_doc < @Date_doc) AND (status = 0) AND (type_doc <> 2) OR
                                (date_doc - 1 < @Date_doc) AND (status = 0) AND (type_doc = 2)";
                SqlCeCommand cmdDelDoc = new SqlCeCommand(s, conn);
                cmdDelDoc.Parameters.Add("@Date_doc", SqlDbType.DateTime).Value = dt;

                // видаляємо товари документа, для яких шапка документа відсутня
                string number_doc_del = string.Empty;
                if (dsInvoice.Tables["dtDocsIn"].Rows.Count > 0)
                {
                    // Обратимся к сервису и скинем туда данные
                    foreach (DataRow dr in dsInvoice.Tables["dtDocsIn"].Rows)
                    {
                        if (number_doc_del == "")
                        {
                            number_doc_del = dr["number_doc"].ToString();
                        }
                        else
                        {
                            number_doc_del = number_doc_del + "," + dr["number_doc"].ToString();
                        }
                    }
                }
                if (number_doc_del == string.Empty)
                    number_doc_del = "0";
                s = @"DELETE 
                          FROM   DOCS_WARES
                          WHERE  (number_doc IN (" + number_doc_del + "))";
                SqlCeCommand cmdDelDocWar = new SqlCeCommand(s, conn);

                // видаляємо документи, для яких товари відсутні
                number_doc_del = string.Empty;
                if (dsInvoice.Tables["dtDocsOnly"].Rows.Count > 0)
                {
                    // Обратимся к сервису и скинем туда данные
                    foreach (DataRow dr in dsInvoice.Tables["dtDocsOnly"].Rows)
                    {
                        if (number_doc_del == "")
                        {
                            number_doc_del = dr["number_doc"].ToString();
                        }
                        else
                        {
                            number_doc_del = number_doc_del + "," + dr["number_doc"].ToString();
                        }
                    }
                }
                if (number_doc_del == string.Empty)
                    number_doc_del = "0";
                s = @"DELETE 
                          FROM   DOCS
                          WHERE  (number_doc IN (" + number_doc_del + "))";
                SqlCeCommand cmdDelDocOnly = new SqlCeCommand(s, conn);

                try
                {
                    conn.Open();
                    cmdDelDocWSt.ExecuteNonQuery();
                    cmdDelDocSt.ExecuteNonQuery();
                    cmdDelDocW.ExecuteNonQuery();
                    cmdDelDoc.ExecuteNonQuery();
                    cmdDelDocWar.ExecuteNonQuery();
                    cmdDelDocOnly.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }

                // вираховуємо товари, які є в документах, але відсутні в довідниках
                int refresh = 0;
                sqlStr = @"SELECT  DISTINCT dw.code_wares
                                FROM   DOCS_WARES AS dw LEFT OUTER JOIN
                                        WARES AS w ON w.code_wares = dw.code_wares
                                WHERE  (w.code_wares IS NULL)";

                SqlCeDataAdapter daWares = new SqlCeDataAdapter(sqlStr, conn);

                try
                {
                    conn.Open();
                    daWares.Fill(dtWares);
                }
                finally
                {
                    conn.Close();
                }

                if (dtWares.Rows.Count > 0)
                {
                    refresh = 1;
                }

                // записуємо в змінну перелік документів, які присутні на ТЗД
                string number_doc = string.Empty;
                sqlStr = @"select number_doc from Docs";

                SqlCeDataAdapter daDocsIn = new SqlCeDataAdapter(sqlStr, conn);
                dsInvoice.Tables["dtDocsIn"].Clear();

                try
                {
                    conn.Open();
                    daDocsIn.Fill(dsInvoice.Tables["dtDocsIn"]);
                }
                finally
                {
                    conn.Close();
                }


                if (dsInvoice.Tables["dtDocsIn"].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsInvoice.Tables["dtDocsIn"].Rows)
                    {
                        if (number_doc == "")
                        {
                            number_doc = dr["number_doc"].ToString();
                        }
                        else
                        {
                            number_doc = number_doc + "," + dr["number_doc"].ToString();
                        }
                    }
                }

                if (number_doc == string.Empty)
                    number_doc = "0";

                DataSet temp = null, dsInvoiceTemplate = null;
                string pocked_id = Global.DeviceID;
                DateTime t = Convert.ToDateTime(Global.TimeSync).Date;
                string shop = Global.ShopName;
                int w = 0, a = 0, u = 0;
                //tmp
                /*if (clsCommon.PropWares > 0)
                { w = 1; }
                if (clsCommon.PropAdditionUnit > 0)
                { a = 1; }
                if (clsCommon.PropUnitDimension > 0)
                { u = 1; }
                 */
                if (refresh == 1)
                {
                    w = 0;
                    a = 0;
                    u = 0;
                }

                try
                {
                    dsInvoiceTemplate = webService.LoadDocs(temp, pocked_id, shop, w, a, u, t, number_doc);
                }
                catch
                {
                    varError="Звязок відсутній! Провірте підключення ТЗД!!!";
                    return;
                }
                finally
                {
                }

                if (dsInvoiceTemplate != null)
                {
                    SqlCeCommand cmdHead = new SqlCeCommand(@"insert into Docs(number_doc, type_doc, date_doc, name_supplier, okpo_supplier, code_shop, flag_sum_qty_doc, serial_tzd, sum_with_vat, sum_without_vat, input_code) 
							values(@number_doc, @type_doc, @date_doc, @name_supplier, @okpo_supplier, @code_shop, @flag_sum_qty_doc, @serial_tzd, @sum_with_vat, @sum_without_vat, @input_code)", conn);

                    cmdHead.Parameters.Add("@number_doc", SqlDbType.Int);
                    cmdHead.Parameters.Add("@type_doc", SqlDbType.Int);
                    cmdHead.Parameters.Add("@date_doc", SqlDbType.DateTime);
                    cmdHead.Parameters.Add("@serial_tzd", SqlDbType.NVarChar);
                    cmdHead.Parameters.Add("@name_supplier", SqlDbType.NVarChar);
                    cmdHead.Parameters.Add("@okpo_supplier", SqlDbType.BigInt);
                    cmdHead.Parameters.Add("@code_shop", SqlDbType.Int);
                    cmdHead.Parameters.Add("@flag_sum_qty_doc", SqlDbType.Int);
                    cmdHead.Parameters.Add("@sum_with_vat", SqlDbType.Float);
                    cmdHead.Parameters.Add("@sum_without_vat", SqlDbType.Float);
                    cmdHead.Parameters.Add("@input_code", SqlDbType.Int);

                    object o = string.Empty;
                    try
                    {
                        // Пробежимся по всем полученным шапкам
                        SqlCeTransaction tran = null;
                        foreach (DataRow drHead in dsInvoiceTemplate.Tables["dtDocs"].Rows)
                        {
                            try
                            {

                                conn.Open();
                                tran = conn.BeginTransaction();

                                // Сохраним шапку документа
                                cmdHead.Transaction = tran;
                                cmdHead.Parameters["@number_doc"].Value = drHead["number_doc"];

                                if (drHead["type_doc"] != DBNull.Value)
                                    cmdHead.Parameters["@type_doc"].Value = drHead["type_doc"];
                                else
                                    cmdHead.Parameters["@type_doc"].Value = 1;

                                if (drHead["date_doc"] != DBNull.Value)
                                {
                                    cmdHead.Parameters["@date_doc"].Value = drHead["date_doc"];
                                }
                                else
                                    cmdHead.Parameters["@date_doc"].Value = DBNull.Value;

                                cmdHead.Parameters["@serial_tzd"].Value = Global.DeviceID;

                                if (drHead["name_supplier"] != DBNull.Value)
                                    cmdHead.Parameters["@name_supplier"].Value = drHead["name_supplier"];
                                else
                                    cmdHead.Parameters["@name_supplier"].Value = string.Empty;

                                if (drHead["okpo_supplier"] != DBNull.Value)
                                    cmdHead.Parameters["@okpo_supplier"].Value = drHead["okpo_supplier"];
                                else
                                    cmdHead.Parameters["@okpo_supplier"].Value = 0;

                                if (drHead["code_shop"] != DBNull.Value)
                                    cmdHead.Parameters["@code_shop"].Value = drHead["code_shop"];
                                else
                                    cmdHead.Parameters["@code_shop"].Value = 0;

                                if (drHead["flag_sum_qty_doc"] != DBNull.Value)
                                    cmdHead.Parameters["@flag_sum_qty_doc"].Value = drHead["flag_sum_qty_doc"];
                                else
                                    cmdHead.Parameters["@flag_sum_qty_doc"].Value = 0;

                                if (drHead["sum_with_vat"] != DBNull.Value)
                                    cmdHead.Parameters["@sum_with_vat"].Value = drHead["sum_with_vat"];
                                else
                                    cmdHead.Parameters["@sum_with_vat"].Value = 0;

                                if (drHead["sum_without_vat"] != DBNull.Value)
                                    cmdHead.Parameters["@sum_without_vat"].Value = drHead["sum_without_vat"];
                                else
                                    cmdHead.Parameters["@sum_without_vat"].Value = 0;

                                if (drHead["input_code"] != DBNull.Value)
                                    cmdHead.Parameters["@input_code"].Value = drHead["input_code"];
                                else
                                    cmdHead.Parameters["@input_code"].Value = 1;

                                cmdHead.ExecuteNonQuery();

                                // Закоммитем
                                tran.Commit();
                                conn.Close();

                            }
                            catch (System.Exception)
                            {
                                if (tran != null)
                                {
                                    tran.Rollback();
                                }
                               varError="Вставка невдала!";
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }

                    finally
                    {
                        //conn.Close();
                        //GC.Collect();
                    }

                    SQL.BulkInsert(dsInvoiceTemplate.Tables["dtDocsWares"], "Docs_Wares");

                    if (dsInvoiceTemplate.Tables["dtWares"].Rows.Count > 0)
                    {

                        string ss = @"DELETE FROM wares";
                        SqlCeCommand cmdDlWar = new SqlCeCommand(ss, conn);
                        SqlCeTransaction tran = null;
                        try
                        {
                            conn.Open();
                            tran = conn.BeginTransaction();
                            cmdDlWar.ExecuteNonQuery();
                            tran.Commit();
                        }
                        catch (System.Exception ex)
                        {
                            if (tran != null)
                            {
                                tran.Rollback();
                            }
                            varError= ex.ToString();
                        }
                        finally
                        {
                            conn.Close();
                        }
                        SQL.BulkInsert(dsInvoiceTemplate.Tables["dtWares"], "Wares");
                    }

                    if (dsInvoiceTemplate.Tables["dtAdditionUnit"].Rows.Count > 0)
                    {

                        string ss = @"DELETE FROM addition_unit";
                        SqlCeCommand cmdDlAd = new SqlCeCommand(ss, conn);
                        SqlCeTransaction tran = null;
                        try
                        {
                            conn.Open();
                            tran = conn.BeginTransaction();
                            cmdDlAd.ExecuteNonQuery();
                            tran.Commit();
                        }
                        catch (System.Exception ex)
                        {
                            if (tran != null)
                            {
                                tran.Rollback();
                            }
                            varError= ex.ToString();
                        }
                        finally
                        {
                            conn.Close();
                        }
                        SQL.BulkInsert(dsInvoiceTemplate.Tables["dtAdditionUnit"], "Addition_Unit");
                    }

                    if (dsInvoiceTemplate.Tables["dtUnitDimension"].Rows.Count > 0)
                    {
                        string ss = @"DELETE FROM unit_dimension";
                        SqlCeCommand cmdDlUd = new SqlCeCommand(ss, conn);
                        SqlCeTransaction tran = null;
                        try
                        {
                            conn.Open();
                            tran = conn.BeginTransaction();
                            cmdDlUd.ExecuteNonQuery();
                            tran.Commit();
                        }
                        catch (System.Exception ex)
                        {
                            if (tran != null)
                            {
                                tran.Rollback();
                            }
                             varError= ex.ToString();
                        }
                        finally
                        {
                            conn.Close();
                        }
                        SQL.BulkInsert(dsInvoiceTemplate.Tables["dtUnitDimension"], "Unit_Dimension");
                    }

                    if (dsInvoiceTemplate.Tables["dtSettings"].Rows.Count > 0)
                    {

                        foreach (DataRow dr in dsInvoiceTemplate.Tables["dtSettings"].Rows)
                        {
                            
                            Global.ShopName = dr["code_shop"].ToString();
                            Global.TimeSync = Convert.ToDateTime( dr["time_sync"]);

                            try
                            {
                                // Open the config file.
                                cFile = new ConfigFile();
                                cFile.SetAppSetting("ShopName", Global.ShopName, true);                                
                            }
                            catch (System.Exception)
                            {
                                
                                varError= "Оновлення конфіг файла невдале!!";
                            }
                            finally
                            {
                                cFile = null;
                            }

                            string ss = @"update Settings 
                                                set  TimeSync = @timesync";
                            DateTime dd = Convert.ToDateTime(dr["time_sync"]);
                            SqlCeCommand cmdUpdDate = new SqlCeCommand(ss, conn);
                            cmdUpdDate.Parameters.Add("@timesync", SqlDbType.DateTime).Value = dd;
                            SqlCeTransaction tran = null;
                            try
                            {
                                conn.Open();
                                tran = conn.BeginTransaction();
                                cmdUpdDate.ExecuteNonQuery();
                                tran.Commit();
                            }
                            catch (System.Exception ex)
                            {
                                if (tran != null)
                                {
                                    tran.Rollback();
                                }
                                varError=ex.ToString();
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }

                    if (dsInvoiceTemplate.Tables["dtDelDocs"].Rows.Count > 0)
                    {
                        string ss = @"delete from docs_wares where number_doc in (@number_doc)";
                        SqlCeCommand cmdDelDocWares = new SqlCeCommand(ss, conn);
                        cmdDelDocWares.Parameters.Add("@number_doc", SqlDbType.Int);

                        ss = @"delete from docs where  number_doc in (@number_doc)";
                        SqlCeCommand cmdDelDocs = new SqlCeCommand(ss, conn);
                        cmdDelDocs.Parameters.Add("@number_doc", SqlDbType.Int);

                        SqlCeTransaction tran = null;

                        try
                        {
                            foreach (DataRow drHead in dsInvoiceTemplate.Tables["dtDelDocs"].Rows)
                            {
                                try
                                {
                                    conn.Open();
                                    tran = conn.BeginTransaction();

                                    cmdDelDocWares.Transaction = tran;
                                    cmdDelDocWares.Parameters["@number_doc"].Value = drHead["number_doc"];
                                    cmdDelDocWares.ExecuteNonQuery();

                                    cmdDelDocs.Transaction = tran;
                                    cmdDelDocs.Parameters["@number_doc"].Value = drHead["number_doc"];
                                    cmdDelDocs.ExecuteNonQuery();

                                    tran.Commit();
                                    conn.Close();
                                }
                                catch (System.Exception ex)
                                {
                                    if (tran != null)
                                    {
                                        tran.Rollback();
                                    }
                                    varError=ex.ToString();
                                }

                                finally
                                {
                                    conn.Close();
                                }
                            }
                        }

                        finally
                        {

                        }
                    }
                }

                int docs = 0, docs_wares = 0, wares = 0, addition_unit = 0, unit_dimension = 0;
                SqlCeCommand cmd;

                //clsConfigFile cFile = null;
                try
                {
                    conn.Open();
                    object o;
                    cmd = new SqlCeCommand("select count(number_doc) from docs", conn);
                    o = cmd.ExecuteScalar();
                    if ((o != null) & (o != DBNull.Value))
                    {
                        docs = Convert.ToInt32(o);
                    }

                    cmd = new SqlCeCommand("select count(*) from docs_wares", conn);
                    o = cmd.ExecuteScalar();
                    if ((o != null) & (o != DBNull.Value))
                    {
                        docs_wares = Convert.ToInt32(o);
                    }

                    cmd = new SqlCeCommand("select count(*) from wares", conn);
                    o = cmd.ExecuteScalar();
                    if ((o != null) & (o != DBNull.Value))
                    {
                        wares = Convert.ToInt32(o);
                    }

                    cmd = new SqlCeCommand("select count(*) from addition_unit", conn);
                    o = cmd.ExecuteScalar();
                    if ((o != null) & (o != DBNull.Value))
                    {
                        addition_unit = Convert.ToInt32(o);
                    }

                    cmd = new SqlCeCommand("select count(*) from unit_dimension", conn);
                    o = cmd.ExecuteScalar();
                    if ((o != null) & (o != DBNull.Value))
                    {
                        unit_dimension = Convert.ToInt32(o);
                    }
                    //TMP
                    /*
                    cFile = new clsConfigFile();
                    clsCommon.PropDocs = docs;
                    clsCommon.PropDocsWares = docs_wares;
                    clsCommon.PropWares = wares;
                    clsCommon.PropAdditionUnit = addition_unit;
                    clsCommon.PropUnitDimension = unit_dimension;
                    cFile.SetAppSetting("Docs", docs.ToString(), true);
                    cFile.SetAppSetting("DocsWares", docs_wares.ToString(), true);
                    cFile.SetAppSetting("Wares", wares.ToString(), true);
                    cFile.SetAppSetting("AdditionUnit", addition_unit.ToString(), true);
                    cFile.SetAppSetting("UnitDimension", unit_dimension.ToString(), true);
                    */
                }
                catch (System.Exception ex)
                {
                    varError= ex.Message;
                }
                finally
                {
                    conn.Close();
                    cFile = null;
                }

                string Directory = Global.Directory;
                string file = Global.RemouteFile;
                int Update = 0;

                FileStream stream = new FileStream(Directory + file, FileMode.Create);
                try
                {
                    string ss = webService.GetFileVersionNew(file);
                    if (ss != string.Empty)
                    {
                        if (ss == version)
                            Update = 0;
                        else
                        {
                            byte[] buffer = webService.GetFile(file);
                            stream.Write(buffer, 0, buffer.Length);
                            Update = 1;
                        }
                    }
                }
                catch
                { }
                finally
                {
                    stream.Close();
                }

                // перевіряємо версію програми Update_brb.exe
                string file_version;
                file = "Update_brb.exe";
                Directory = @"\Program Files\Update_brb";
                string sourceFile = System.IO.Path.Combine(Directory, file);
                try
                {
                    FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(@"\Program Files\Update_brb\Update_brb.exe");
                    file_version = fileInfo.ProductVersion;
                }
                catch
                {
                    file_version = "-1";
                }

                if (file_version != "-1")
                {
                    string ss = webService.GetFileVersionNew(file);
                    if (ss != string.Empty)
                    {
                        if (ss != file_version)
                        {
                            FileStream stream2 = new FileStream(sourceFile, FileMode.Create);
                            try
                            {
                                byte[] buffer = webService.GetFile(file);
                                stream2.Write(buffer, 0, buffer.Length);
                            }
                            catch
                            { }
                            finally
                            {
                                stream2.Close();
                            }
                        }
                    }
                }

                //запускаємо оновлення продукта
                if (Update == 1)
                {
                    try
                    {
                        Process.Start("\\Program Files\\Update_brb\\Update_brb.exe", null);
                    }
                    catch
                    { }
                }

                
                int end_web = Environment.TickCount;
                int result_web = (end_web - start_web) / 1000;

                if (errDocs == "0")
                    varError = "Синхронізація завершена! Час синхронізації:" + result_web.ToString() + " сек.";
                else
                    varError = "Завершено з помилками! Документи №" + errDocs + " не загрузились на сервер! Час синхронізації:" + result_web.ToString();


            }
            catch
            { }
        }

    }
}