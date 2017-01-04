using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BRB
{
    /// <summary>
    /// Клас бізнес логіки
    /// Проміжний між інтерфейсами (формами ) і Data можливо варто зробити static
    /// </summary>
    public class BL
    {
        public BL(Data parData)
        {
            cData = parData;        
        }

        static private TypeDoc CurTypeDoc;
        static private int CurNumDoc;
        static private int CurCodeWares;
        static private DataTable dtDocs;
        static private DataTable dtWaresDoc;
        static private DataRow CurDoc;
        static private DataRow CurWaresDoc;
        static public Data cData;

        public static DataTable LoadDocs(TypeDoc parTypeDoc)
        {
            CurTypeDoc = parTypeDoc;
            return dtDocs=cData.FillDocs(parTypeDoc);        
        }

        public static DataTable LoadWaresDocs(TypeDoc parTypeDoc, int parNumberDoc)
        {
            //CurNumDoc = parNumberDoc;
            SetCurDoc(parNumberDoc);
            return dtWaresDoc=cData.FillDocsWares(parNumberDoc);        
        }

        /// <summary>
        /// Зберігаємо текучу шапку документа
        /// </summary>
        /// <param name="parCurDoc"></param>
        public static bool SetCurDoc(int  parCurNumberDoc)
        {
            if (dtDocs != null)
            {
                CurNumDoc = parCurNumberDoc;
                CurDoc = dtDocs.Select(string.Format("number_doc={0}", parCurNumberDoc)).First();
                return (CurDoc != null && CurDoc.ItemArray.Count()>0 );
            }
            else
                return false;
        }
/*
        /// <summary>
        /// Зберігаємо текучу шапку документа
        /// </summary>
        /// <param name="parCurDoc"></param>
        public static void SetCurDoc(DataRow parCurDoc)
        {
            CurDoc = parCurDoc;
            CurNumDoc = Convert.ToInt32(parCurDoc["number_doc"]);
        }*/
        /// <summary>
        /// Чи можна редагувати товар напряму з гріда
        /// </summary>
        /// <param name="parCodeWares"></param>
        public static bool IsEditWaresManual(int parCodeWares)
        {
            SetCurWaresDoc(parCodeWares);
            return IsEditWaresManual();
        }
        
        /// <summary>
        /// Чи можна редагувати товар напряму з гріда
        /// </summary>
        /// <param name="parCodeWares"></param>
        public static bool IsEditWaresManual()
        {            
            if (Convert.ToInt32(CurWaresDoc["div"]) == 0 && Convert.ToInt32(CurDoc["input_code"]) == 0)
                return false;
            return true;
        }

        /// <summary>
        /// Чи дозволена дробна кількість товару.
        /// </summary>
        /// <returns></returns>
        public static bool IsFractional()
        {
            return Convert.ToInt32(CurWaresDoc["div"]) == 1; 
        }
        /*/// <summary>
        /// Зберігаємо текучий рядок документа
        /// </summary>
        /// <param name="parCurDoc"></param>
        public static void SetCurWaresDoc(DataRow parCurWaresDoc)
        {
            CurWaresDoc = parCurWaresDoc;
        }
        */
                /// <summary>
        /// Зберігаємо текучий рядок документа
        /// </summary>
        /// <param name="parCurDoc"></param>
        public static bool SetCurWaresDoc(int parCurCodeWares)
        {
            if (dtWaresDoc != null)
            {
                CurCodeWares = parCurCodeWares;
                CurWaresDoc = dtWaresDoc.Select(string.Format("code_wares={0}", parCurCodeWares)).First();
                return (CurWaresDoc != null && CurWaresDoc.ItemArray.Count() > 0);
            }
            return false;
        }

        
        /// <summary>
        /// Шукає товар по штрихкоду
        /// </summary>
        /// <param name="parBarCode"></param>
        /// <returns></returns>
        public static DataRow FindGoodBarCode(string parBarCode)
        {
            try
            {
                var dt = cData.FindGoodBarCode(CurNumDoc, parBarCode, false);
                if (dt != null && dt.Rows.Count > 0)
                {
                    SetCurWaresDoc(Convert.ToInt32(dt.Rows[0]["code_wares"]));
                    return dt.Rows[0];
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        

        /// <summary>
        /// Вертає текучий товар
        /// </summary>
        /// <param name="parBarCode"></param>
        /// <returns></returns>
        public static DataRow FindGoodCode()
        {
            if (dtWaresDoc != null)
                return dtWaresDoc.Select(string.Format("code_wares={0}", CurCodeWares)).First();
            return null;
        }

        /// <summary>
        /// Встановлює текучий товар і вертає по ньому інфу.
        /// </summary>
        /// <param name="parBarCode"></param>
        /// <returns></returns>
        public static DataRow FindGoodCode(int parCodeWares)
        {
           SetCurWaresDoc(parCodeWares);
           return FindGoodCode(); 
        }

        /// <summary>
        /// Якщо треба сумувати кількості в документі - MetGetSumQtyZNP
        /// </summary>
        /// <returns></returns>

        public static bool IsSumQty()
        {
            return (Convert.ToInt32( CurDoc["flag_sum_qty_doc"]) != 0);
        }
        /// <summary>
        /// MetSaveRowGoods
        /// </summary>
        /// <param name="code_wares"></param>
        /// <param name="pnrQty"></param>
        /// <param name="pnrPrice"></param>
        /// <param name="pnrNumPop"></param>
        /// <param name="number_doc"></param>
        /// <param name="pPacQty"></param>
        /// <param name="coefficient"></param>
        /// <param name="conn"></param>
        public static Status SaveGoods(int parNumPop, decimal parQty, decimal parPrice)//, decimal pPacQty, decimal coefficient)
        {
            Status res = new Status();
            try
            {
                // Проверим номер по порядку
                if (parNumPop == 0)
                    parNumPop = cData.GetWaresOrder(CurNumDoc);

                if (parPrice != 0)
                {
                   int flag = Convert.ToInt32( CurDoc["flag_price_with_vat"]);
                   int vat = Convert.ToInt32( CurWaresDoc["vat"]);
                   if (flag == 1 && vat!=0 )
                     parPrice = decimal.Round(parPrice / (1 + vat / 100), 4);                     
                }
              cData.SaveDocWares(CurNumDoc, CurCodeWares, parNumPop, parQty, parPrice);
              CurWaresDoc["num_pop"] = parNumPop;
              CurWaresDoc["parQty"] = parQty;
              CurWaresDoc["price"] = parPrice;
            }
            catch (System.Exception Ex)
            {                
                res.status=EStatus.Error;
                res.message = "Помилка оновлення ціни, кількості і  т.д.! "+ Ex.Message;
            }
            
            return res;
        }



        public static Status SetStatusDoc( int parStatus)
        {
         Status res = new Status();

          try
            {
                cData.SetStatusDoc(CurNumDoc,parStatus);
            }
            catch (System.Exception Ex)
            {                
                res.status=EStatus.Error;
                res.message = "Помилка зміни статуса "+ Ex.Message;
            }
            return res;

        }
    }
}
