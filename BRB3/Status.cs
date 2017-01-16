using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BRB
{
    public enum EStatus
        {
            Ok = 0,
            NoWares,
            NoCorectQuantity,
            NoQuantity,
            QuantityTooMuch,
            QuantityCanNotBeFractional,
            NoCorectPrice,
            NoPrice,
            PriceTooLong,
            
            NoInputWares,
            NoDocSupply,
            NoDateDocSupply,

            UserCodeNotFound,
            UserNotFound,

            DBError,
            BadLoginPassword,

            NoDataFound,
            NoGoodData,
            ErrorSerializer,
            DontGetKey,
            HttpPOSTError,
            Error
        }

    public class Status
        {
            public Status()
            {
                status = EStatus.Ok;
                message=null;
            }
            public Status(EStatus parStatus)
            {
                status = parStatus;
                message = null;
            }

            public Status(EStatus parStatus  ,string parMessage)
            { 
                status = parStatus;
                message = parMessage;
            }
            public EStatus status { get; set; }
            public string message { get; set; }
           // public string strStatus { get { return StrStatus.strStatus(status); } }
/*
            public string LocalizationMessage { get {return "У вас сталась помилка"; } }
            public string GetLocalizationMessage(EStatus parStatus,string parLang)
            {
                string varMessage=null;


                return varMessage;
            }
        */
        public string StrStatus
            { 
                get 
                {
                    string res = string.Empty;
                    switch (status)
                    {
                        case EStatus.NoWares:
                            res = "Вкажіть товар!";
                            break;

                        case EStatus.NoCorectQuantity:
                            res = "Внесіть правильну кіл-ть товару!";
                            break;
                        case EStatus.NoQuantity:
                            res = "Внесіть кіл-ть товару!";
                            break;
                        
                        case EStatus.QuantityTooMuch:
                            res = "Кіл-ть товару > ніж в ЗНП!";
                            break;
                        case EStatus.QuantityCanNotBeFractional:
                            res = "Кількість даного товару не може бути дробною!";
                            break;
                        case EStatus.NoCorectPrice:
                            res = "Внесіть правильну ціну товару!";
                            break;
                        case EStatus.NoPrice:
                            res = "Внесіть ціну товару!";
                            break;
                        case EStatus.PriceTooLong:
                            res = "Кількість символів повинна бути менше 15";
                            break;
                        case EStatus.NoInputWares:
                            res = "По даному документу товар не приймався!";
                            break;
                        case EStatus.NoDocSupply:
                            res = "Введіть номер розхідної від постачальника!";
                            break;
                        case EStatus.NoDateDocSupply:
                            res = "Введіть дату розхідної від постачальника!";
                            break;

                       default:
                            res = status.ToString();
                            break;
                    }


                    return res; 
                
                } 
            
            }

    
        }

      
   /*

        public static class StrStatus
        {
            public static string strStatus(EStatus parEStatus)
            {
                string res=Ok;
                switch(parEStatus)
                {
                    case EStatus.Ok:
                        res=Ok;
                        break;
                    case EStatus.DBError:
                        res=DBError;
                        break;
                    default:
                        res=Error;
                        break;
                }

                return res;
            }

            static string  Ok { get { return "ok"; } }
            static string  Success { get { return "success"; } }
            static string Error { get { return "error"; } }
            
            static string CodeNotFound { get { return "code-not-found"; } }
            static string UserNotFound { get { return "user-not-found"; } }

            static string DBError { get { return "DBError"; } }
            
        }
  */  
}
