using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BRB
{
    /// <summary>
    /// Клас бізнес логіки
    /// Проміжний між інтерфейсами (формами ) і Data
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
            Global.cData.FindGoodBarCode(parBarCode);
            return null;
        }
    }
}
