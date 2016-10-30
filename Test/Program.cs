using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BRB;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Global.dbPathBRB = @"c:\" + Global.dbPathBRB;
              Global.Init(TypeTerminal.MotorolaMC75Ax);
              Global.DeviceID = "123454321";
              Global.cData.Sync();
        }
        
    }
}
