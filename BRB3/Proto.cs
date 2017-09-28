using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BRB
{
    public static class Proto
    {
        public static string DeleteZeroEnds(string s)
        {
            while (s.Contains(".") && (s.EndsWith("0") || s.EndsWith(".")))
            {
                s = s.Remove(s.Length - 1, 1);
            }

            if (String.IsNullOrEmpty(s)) s = "0";

            return s;
        }

        public static System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." };

        public static decimal ToDecimal(string parS)
        {
            try
            {
                return Convert.ToDecimal(parS.Replace(",", "."), nfi);
            }
            catch //(Exception ex)
            { }
            return decimal.Zero;
        }
        
        public static string ToDateStr (string s)
         {
            s = s.Replace('.', '/');
             return s;
         }
        public static bool IsData(System.Data.DataTable parData)
        {
            return parData != null && parData.Rows.Count > 0 && parData.Rows[0] != null;
        }
    }
}
