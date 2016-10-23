using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SimpleBankATM.Data;
using SimpleBankATM.Data.Infrastructure;
using SimpleBankATM.Data.Repositories;

namespace SimpleBankATM.Console.Configuration
{

    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //DataContext
            builder.RegisterType<DataContext>().As<IDataContext>().InstancePerLifetimeScope();


            //Applicaion 
            builder.RegisterType<Application>().As<IApplication>();

            //Services



            //Repositories
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<AuthRepository>().As<IAuthRepository>();




            base.Load(builder);
        }
    }
}
