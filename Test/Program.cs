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

              var bl = Global.cBL;
              var Docs = bl.LoadDocs( TypeDoc.SupplyLogistic);
              var DocsWares = bl.LoadWaresDocs(TypeDoc.SupplyLogistic, 3702947);
              var res = bl.FindGoodCode(163142);
              var res2 = bl.SaveGoods("163142", "3", "9.88");

              bl.SaveDocEx(12, DateTime.Now, 0, 0, 0);
              //bl.SetStatusDoc(11,);

              //BL.SaveGoods(0, 2, 99.99m);
              //var rw = BL.FindGoodBarCode("2816314200191"); 
        }
        
    }
}
