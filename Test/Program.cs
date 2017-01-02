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
            Global.dbPathBRB = @"D:\WORK\CS4\BRB3\BRB3\Database\BRB.sdf";//@"c:" + Global.dbPathBRB;
              Global.Init(TypeTerminal.MotorolaMC75Ax);
              Global.DeviceID = "123454321";
              //Global.cData.Sync();

              var Docs = BL.LoadDocs( TypeDoc.Invoice);
              var DocsWares = BL.LoadWaresDocs(TypeDoc.Invoice,3702947);
              var res = BL.FindGoodCode(163142);
              var rw = BL.FindGoodBarCode("2816314200191"); 
        }
        
    }
}
