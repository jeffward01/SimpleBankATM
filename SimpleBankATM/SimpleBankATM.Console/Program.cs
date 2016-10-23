﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SimpleBankATM.Console.Configuration;
using SimpleBankATM.Console.Logging;

namespace SimpleBankATM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Global Exception Handler
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            BankLogManager.LogErrors((Exception)e.ExceptionObject);
            System.Console.WriteLine();
            System.Console.WriteLine(e.ExceptionObject.ToString());
            System.Console.WriteLine("Press Enter to continue");
            System.Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
