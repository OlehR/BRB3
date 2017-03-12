////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using BRB;
////namespace Test
////{
////    class Program
////    {
////        static void Main(string[] args)
////        {
////            Global.dbPathBRB = @"D:\WORK\CS4\BRB3\BRB3\Database\BRB.sdf";//@"c:" + Global.dbPathBRB;
////              Global.Init(TypeTerminal.MotorolaMC75Ax);
////              Global.DeviceID = "123454321";
////              Global.cData.SyncPr();
////              return;
/////*              var bl = Global.cBL;
////              var Docs = bl.LoadDocs( TypeDoc.SupplyLogistic);
////              var DocsWares = bl.LoadWaresDocs(TypeDoc.SupplyLogistic, 3702947);
////              var res = bl.FindGoodCode(163142);
////              var res2 = bl.SaveGoods("163142", "10", "9.88");
////               res = bl.FindGoodCode(163146);
////              res2 = bl.SaveGoods("163146", "10", "20.00");
////              bl.saveAdvSetDoc("1234321", "03.03.2016", 1, 1, 1,1);
////             // bl.SaveDocEx(12, DateTime.Now, 0, 0, 0);
////              //bl.SetStatusDoc(11,);

////              //BL.SaveGoods(0, 2, 99.99m);
////              //var rw = BL.FindGoodBarCode("2816314200191"); */
////        }
        
////    }
////}

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
            Global.DeviceID = "6922660";
            Global.dbPathBRB = @"D:\WORK\CS4\BRB3\BRB3\Database\BRB.sdf";//@"c:" + Global.dbPathBRB;
            Global.varConfigFile= @"D:\WORK\CS4\BRB3\BRB3\BRB3.config";
            Global.Init(TypeTerminal.MotorolaMC75Ax);
            //webService.Url = Global.ServiceUrl; //@wsUrl;
            //Global.ServiceUrl = "http://localhost:20416/BRB3_Sync/BRB3_Sync.asmx"; //TMP LocalHost

            Global.cData.Sync(TypeSynchronization.Price,null);
            return;
        }
    }
}