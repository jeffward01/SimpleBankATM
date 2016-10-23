using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SimpleBankATM.Console.Logging
{
   public static class BankLogManager 

    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public static void LogErrors(Exception ex)
        {
            Logger.Debug(ex.Message);
            Logger.Debug(ex.StackTrace);
            Logger.Debug(ex.InnerException);
        }
    }
}
