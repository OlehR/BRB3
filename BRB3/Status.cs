using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BRB
{
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
            public string strStatus { get { return StrStatus.strStatus(status); } }

            public string LocalizationMessage { get {return "У вас сталась помилка"; } }
            public string GetLocalizationMessage(EStatus parStatus,string parLang)
            {
                string varMessage=null;
/*                if(parLang==null)
                    parLang=globalLogic.system.Localization.Lang;
                
                */

                return varMessage;
            }

            

        }

        public enum EStatus
        {
            Ok = 0,
            Success = 1,

            BadOrderStatus, //
            BadSecretCode,
            BadSecretCodeTooLate,
            BadSecretCodeAlreadyUse,

            UserCodeNotFound,
            CodeNotFound,
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
            static string BadSecretCode { get { return "BadSecretCode"; } }
            static string BadSecretCodeTooLate { get { return "too-late"; } }
            static string BadSecretCodeAlreadyUse { get { return "already-use"; } }
            static string UserCodeNotFound { get { return "user-code-not-found"; } }
            static string CodeNotFound { get { return "code-not-found"; } }
            static string UserNotFound { get { return "user-not-found"; } }

            static string DBError { get { return "DBError"; } }
            static string BadOrderStatus { get { return "BadOrderStatus"; } }
        }
}
