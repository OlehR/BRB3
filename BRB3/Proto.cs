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
            while (s.EndsWith("0"))
            {
                s = s.Remove(s.Length - 1, 1);
            }
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
            return 0;
        }
        
        public static string ToDateStr (string s)
         {
            s = s.Replace('.', '/');
             return s;
         }
    }
}
