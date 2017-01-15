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
    }
}
