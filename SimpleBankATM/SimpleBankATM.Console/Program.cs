using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankATM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Global Exception Handler
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(e.ExceptionObject.ToString());
            System.Console.WriteLine("Press Enter to continue");
            System.Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
