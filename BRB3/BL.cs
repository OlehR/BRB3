﻿using System;
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
    class BL
    {
        /// <summary>
        /// Шукає товар по штрихкоду
        /// </summary>
        /// <param name="parBarCode"></param>
        /// <returns></returns>
        public DataTable FindGoodBarCode(string parBarCode)
        {
            try
            {
                return Global.cData.FindGoodBarCode(Global.CurNumDoc, parBarCode, false);
            }
            catch
            {
                return null;
            }
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
                    parNumPop = Global.cData.GetWaresOrder(Global.CurNumDoc);


                if (parPrice != 0)
                {
                    
                   int flag = Convert.ToInt32( Global.CurDoc["flag_price_with_vat"]);
                   int vat = Convert.ToInt32( Global.CurWaresDoc["vat"]);
                   if (flag == 1 && vat!=0 )
                     parPrice = decimal.Round(parPrice / (1 + vat / 100), 4); 
                    
                }
              Global.cData.SaveDocWares(Global.CurNumDoc, parCodeWares, parNumPop, parQty, parPrice);

            }
            catch (System.Exception Ex)
            {                
                res.status=EStatus.Error;
                res.message = "Помилка оновлення ціни, кількості і  т.д.! "+ Ex.Message;
            }
            
            return res;
        }


    }
}
