using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BRB;
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

        public TypeDoc CurTypeDoc;
        public int CurNumDoc;
        private int CurCodeWares;
        private DataTable dtDocs;
        private DataTable dtWaresDoc;
        public DataRow CurDoc;
        private DataRow CurWaresDoc;
        static public Data cData;
        public DataView dvFilterDoc;

        public  DataTable LoadDocs(TypeDoc parTypeDoc)
        {
            CurTypeDoc = parTypeDoc;
            return dtDocs=cData.FillDocs(parTypeDoc);        
        }

        public  DataTable LoadWaresDocs(TypeDoc parTypeDoc, int parNumberDoc)
        {
            //CurNumDoc = parNumberDoc;
            SetCurDoc(parNumberDoc);
            return dtWaresDoc=cData.FillDocsWares(parNumberDoc);        
        }

        /// <summary>
        /// Зберігаємо текучу шапку документа
        /// </summary>
        /// <param name="parCurDoc"></param>
        public  bool SetCurDoc(int  parCurNumberDoc)
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
        public  bool IsEditWaresManual(int parCodeWares)
        {
            SetCurWaresDoc(parCodeWares);
            return IsEditWaresManual();
        }
        
        /// <summary>
        /// Чи можна редагувати товар напряму з гріда
        /// </summary>
        /// <param name="parCodeWares"></param>
        public  bool IsEditWaresManual()
        {            
            if (Convert.ToInt32(CurWaresDoc["div"]) == 0 && Convert.ToInt32(CurDoc["input_code"]) == 0)
                return false;
            return true;
        }

        /// <summary>
        /// Чи дозволена дробна кількість товару.
        /// </summary>
        /// <returns></returns>
        public  bool IsFractional()
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
        public  bool SetCurWaresDoc(int parCurCodeWares)
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
        public  DataRow FindGoodBarCode(string parBarCode)
        {
            try
            {
                DataRow dr = cData.GetCodeWaresFromBarCode(parBarCode);
                if (dr != null)
                {
                    if (SetCurWaresDoc(Convert.ToInt32(dr["code_wares"])))
                    {
                        CurWaresDoc["coef_bar_code"] = Convert.ToInt32(dr["coefficient"]) / Convert.ToInt32(CurWaresDoc["coefficient"]);
                        CurWaresDoc["abr_unit_bar_code"] = dr["abr_unit"];
                        return CurWaresDoc;
                    }
                    return null;
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
        public  DataRow FindGoodCode()
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
        public  DataRow FindGoodCode(int parCodeWares)
        {
           SetCurWaresDoc(parCodeWares);
           return FindGoodCode(); 
        }

        /// <summary>
        /// Якщо треба сумувати кількості в документі - MetGetSumQtyZNP
        /// </summary>
        /// <returns></returns>

        public  bool IsSumQty()
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
        public  Status SaveGoods(int parNumPop, decimal parQty, decimal parPrice)//, decimal pPacQty, decimal coefficient)
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
              CurWaresDoc["quantity"] = parQty;
              CurWaresDoc["price"] = parPrice;
            }
            catch (System.Exception Ex)
            {
                string ss = Ex.ToString();
                res.status=EStatus.Error;
                res.message = "Помилка оновлення ціни, кількості і  т.д.! "+ Ex.Message;
            }
            
            return res;
        }

        public Status SaveDocEx( int parNumberOutInvoice, DateTime parDateOutInvoice, int parFlagPriceWithVat, int parFlagChangeDocSup, int parFlagSumQtyDoc)
        {
            CurDoc["number_out_invoice"]=parNumberOutInvoice;
            CurDoc["date_out_invoice"] = parDateOutInvoice;
            CurDoc["flag_price_with_vat"] = parFlagPriceWithVat ;
            CurDoc["flag_change_doc_sup"] = parFlagChangeDocSup;
            CurDoc["flag_sum_qty_doc"] = parFlagSumQtyDoc ;
            
            cData.SaveDocEx(CurNumDoc, parNumberOutInvoice, parDateOutInvoice, parFlagPriceWithVat, parFlagChangeDocSup, parFlagSumQtyDoc);
            return new Status();
        }

/*
        public Status SetStatusDoc(TypeStatusDoc parStatus)
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
*/
        public Status SaveGoods(string parArticle,string parQty,string parPrice)
        {
            int varArticle;
            decimal varQty;
            decimal varPrice;
            int num_pop;
            if (!String.IsNullOrEmpty(parArticle))
            {
                try
                {
                    varArticle = Convert.ToInt32(parArticle);
                }
                catch 
                {
                    return new Status(EStatus.NoWares);
                }
            }
            else
                return new Status(EStatus.NoWares);

            if (!String.IsNullOrEmpty(parQty))
            {
                try
                {
                    varQty = Convert.ToDecimal(parQty);
                }
                catch
                {
                    return new Status(EStatus.NoCorectQuantity);
                }
            }
            else
                return new Status(EStatus.NoQuantity);


            if (!String.IsNullOrEmpty(parPrice))
            {
                if (parPrice.Length > 14)
                {
                    return new Status(EStatus.PriceTooLong);
                }

                try
                {
                    varPrice = Convert.ToDecimal(parPrice);
                }
                catch
                {
                    return new Status(EStatus.NoCorectPrice);
                }
            }
            else
                return new Status(EStatus.NoPrice);

            
            //Провірка к-ті в ЗНП
            decimal OldQty;
            if (Convert.ToInt32(Global.cBL.CurDoc["flag_sum_qty_doc"]) == 0)
                OldQty = 0;
            else
                OldQty = decimal.Round(Proto.ToDecimal(CurWaresDoc["quantity"].ToString()), 3);
            decimal QtyTempl = decimal.Round(Proto.ToDecimal(CurWaresDoc["quantity_temp"].ToString()), 3);

            if (!Global.cBL.IsFractional() && !Global.isQtyBiggerZNP && (varQty + OldQty) > QtyTempl)//!Ваговий і !clsCommon.PropQtyBigZNP
                return new Status(EStatus.QuantityTooMuch);
            else if (Global.cBL.IsFractional() && !Global.isQtyBiggerZNP && ((varQty + OldQty) > (QtyTempl + QtyTempl * Global.WeightQtyPersent / 100)))
                return new Status(EStatus.QuantityTooMuch);

            //Провірка к-ть на дробність
            decimal QtyNew = decimal.Round((varQty + OldQty), 3);
            if (QtyNew != Decimal.Truncate(QtyNew) && !Global.cBL.IsFractional())
                return new Status(EStatus.QuantityCanNotBeFractional);

            //Провірим порядковий номер
            if ((CurWaresDoc != null) && CurWaresDoc["num_pop"] != DBNull.Value)
            {
                num_pop = Convert.ToInt32(CurWaresDoc["num_pop"]);
            }
            else num_pop = 0;
            //Зберігаємо в базу
            return SaveGoods(num_pop, QtyNew, varPrice);

        }


        public Status SetStatusDoc(TypeStatusDoc parNewStatuaDoc)
        {
            if (parNewStatuaDoc == TypeStatusDoc.Mark)
            {
                if (Convert.ToInt32(CurDoc["SumWaresInv"]) == 0)
                {
                    return new Status(EStatus.NoInputWares);
                }
                else if (Convert.ToInt32(Global.cBL.CurDoc["type_doc"]) == 1 && true) //clsCommon.PropControlDocSup
                {
                    if (CurDoc["number_out_invoice"].ToString().Length == 0)
                    {
                        return new Status(EStatus.NoDocSupply);
                    }
                    else if (Global.cBL.CurDoc["date_out_invoice"].ToString().Length == 0)
                    {
                        return new Status(EStatus.NoDateDocSupply);
                    }
                }
            }
            Status st = cData.SetStatusDoc(CurNumDoc, parNewStatuaDoc);
            if (st.status != EStatus.Ok)
                return st;
            CurDoc["status"] = Convert.ToInt32(parNewStatuaDoc);
            
 
            return new Status();
        
        }

        public Status filterDoc (string parNumberDoc, string parZKPO)
        {
            int varZKPO = 0;
            int varNumberDoc = 0;

            if (String.IsNullOrEmpty(parZKPO) && String.IsNullOrEmpty(parNumberDoc))
            {
                return new Status(EStatus.NoNumberDocOrZKPO);
            }

            else if (!String.IsNullOrEmpty(parZKPO))
            {
                try
                {
                    varZKPO = Convert.ToInt32(parZKPO);
                }
                catch
                {
                    return new Status(EStatus.NoCorectZKPO);
                }
            }
            else if (!String.IsNullOrEmpty(parNumberDoc))
            {
                try
                {
                    varNumberDoc = Convert.ToInt32(parNumberDoc);
                }
                catch
                {
                    return new Status(EStatus.NoCorectNumberDoc);
                }
            }

            if (varZKPO != 0)
            {
                dvFilterDoc = dtDocs.AsEnumerable().Where(x => (Convert.ToInt32(x["okpo_supplier"]) == varZKPO)).AsDataView();
            }
            else if (varNumberDoc != 0)
            {
                dvFilterDoc = dtDocs.AsEnumerable().Where(x => (Convert.ToInt32(x["number_doc"]) == varNumberDoc)).AsDataView();
            }

            if (dvFilterDoc.Count == 0)
                return new Status(EStatus.NoFoundRows);
         
            return new Status();
        }
    
    }
}
