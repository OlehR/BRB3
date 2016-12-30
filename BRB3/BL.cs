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
        static private int CurNumDoc;
        static private DataRow CurDoc;
        static private DataRow CurWaresDoc;
        static public Data cData;

        public DataTable LoadDocs(TypeDoc parTypeDoc)
        {
            return cData.FillDocs(parTypeDoc);        
        }

        public DataTable LoadWaresDocs(TypeDoc parTypeDoc, int parNumberDoc)
        {
            return cData.FillDocsWares(parNumberDoc);        
        }
        

        /// <summary>
        /// Зберігаємо текучу шапку документа
        /// </summary>
        /// <param name="parCurDoc"></param>
        public static void SetCurDoc(DataRow parCurDoc)
        {
            CurDoc = parCurDoc;
            CurNumDoc = Convert.ToInt32(parCurDoc["number_doc"]);
        }

        /// <summary>
        /// Зберігаємо текучий рядок документа
        /// </summary>
        /// <param name="parCurDoc"></param>
        public void SetCurWaresDoc(DataRow parCurWaresDoc)
        {
            CurWaresDoc = parCurWaresDoc;
        }

        /// <summary>
        /// Шукає товар по штрихкоду
        /// </summary>
        /// <param name="parBarCode"></param>
        /// <returns></returns>
        public DataTable FindGoodBarCode(string parBarCode)
        {
            try
            {
                return cData.FindGoodBarCode(CurNumDoc, parBarCode, false);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Якщо треба сумувати кількості в документі - MetGetSumQtyZNP
        /// </summary>
        /// <returns></returns>

        public bool IsSumQty()
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
        public Status SaveGoods(  int parCodeWares,int parNumPop, decimal parQty, decimal parPrice,  decimal pPacQty, decimal coefficient)
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
              cData.SaveDocWares(CurNumDoc, parCodeWares, parNumPop, parQty, parPrice);

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
